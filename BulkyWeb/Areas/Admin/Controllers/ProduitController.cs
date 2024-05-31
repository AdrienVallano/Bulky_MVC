using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProduitController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProduitController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Produit> objProduitList = _unitOfWork.Produit.GetAll().ToList();
            
            return View(objProduitList);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.CategoryList = CategoryList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Produit obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DispalyOrder cannot exactly match the Name");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Produit.Add(obj);

                _unitOfWork.Save();
                TempData["success"] = "Produit créér avec succés";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Produit? produitFromDb = _unitOfWork.Produit.Get(u => u.Id == id);
            //Produit? ProduitFromDb2 = _db.Categories.FirstOrDefault(u=> u.Id==id);
            //Produit? ProduitFromDb3 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (produitFromDb == null)
            {
                return NotFound();
            }

            return View(produitFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Produit obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Produit.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Produit mise à jour";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Produit? produitFromDb = _unitOfWork.Produit.Get(u => u.Id == id);
            //Produit? ProduitFromDb2 = _db.Categories.FirstOrDefault(u=> u.Id==id);
            //Produit? ProduitFromDb3 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (produitFromDb == null)
            {
                return NotFound();
            }

            return View(produitFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Produit? obj = _unitOfWork.Produit.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Produit.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Produit supprimer";
            return RedirectToAction("Index");
        }
    }
}