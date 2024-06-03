using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProduitController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProduitController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Produit> objProduitList = _unitOfWork.Produit.GetAll(includeProperties: "Category").ToList();

            return View(objProduitList);
        }

        public IActionResult Upsert(int? id) //update & insert
        {
            ProduitVM produitVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Produit = new()
            };
            // Creation de l'article si le id est nulle ou si il n'existe pas
            if (id == null || id == 0)
            {
                return View(produitVM);
            }
            else
            // Mis à jour de l'article
            {
                produitVM.Produit = _unitOfWork.Produit.Get(u => u.Id == id);
                return View(produitVM);
            }
        }

        /// <summary>
        /// Creation d'un élément avec reaffichage de la vue en cas d'erreur si le modèle n'est pas valide.
        /// </summary>
        /// <param name="produitVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Upsert(ProduitVM produitVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                //Permet de d'acceder au dossier Root du serveur Web.
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    // Permet de renomer le fichier télécharger lors de l'import.
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    // Permet de cible le dossier Produit
                    string productPath = Path.Combine(wwwRootPath, @"images\produit");

                    //Verification de l'existence d'une imge
                    if (!string.IsNullOrEmpty(produitVM.Produit.ImageUrl))
                    {
                        //suppression de l'image existante.
                        var oldImagePath = Path.Combine(wwwRootPath, produitVM.Produit.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    //Permet de renommer l'image et de enregistrer
                    using (var filestream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    produitVM.Produit.ImageUrl = @"\images\produit\" + fileName;
                }
                if (produitVM.Produit.Id == 0)
                {
                    _unitOfWork.Produit.Add(produitVM.Produit);
                }
                else
                {
                    _unitOfWork.Produit.Update(produitVM.Produit);
                }
                //_unitOfWork.Produit.Update(produitVM.Produit);
                _unitOfWork.Save();

                TempData["success"] = "Produit mis à jour avec succés";
                return RedirectToAction("Index");
            }
            else
            {
                // Permet de mutualisé la vue de création et d'edition en allant chercher la fiche avec le bon ID.
                produitVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            };
            return View(produitVM);
        }
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Produit? produitFromDb = _unitOfWork.Produit.Get(u => u.Id == id);
        //    //Produit? ProduitFromDb2 = _db.Categories.FirstOrDefault(u=> u.Id==id);
        //    //Produit? ProduitFromDb3 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
        //    if (produitFromDb == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(produitFromDb);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int? id)
        //{
        //    Produit? obj = _unitOfWork.Produit.Get(u => u.Id == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Produit.Remove(obj);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Produit supprimer";
        //    return RedirectToAction("Index");
        //}
        #region DataTables Appel API
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Produit> objProduitList = _unitOfWork.Produit.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objProduitList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var objASupprimer = _unitOfWork.Produit.Get(u => u.Id == id);
            if (objASupprimer == null)
            {
                return Json(new { success = false, message = "Supperssion impossible." });
            }

            //var oldImagePath = 
            //    Path.Combine(_webHostEnvironment.WebRootPath, 
            //    objASupprimer.ImageUrl.TrimStart('\\'));

            //if (System.IO.File.Exists(oldImagePath))
            //{
            //    System.IO.File.Delete(oldImagePath);
            //}
            string productPath = @"images\products\product-" + id;
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }
            _unitOfWork.Produit.Remove(objASupprimer);
            _unitOfWork.Save();

            TempData["success"] = "Article supprimer";
            return Json(new { success = true, message = "Suppression ok." });
        }
        #endregion
    }
}