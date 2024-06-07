using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class EntrepriseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntrepriseController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Entreprise> objEntrepriseList = _unitOfWork.Entreprise.GetAll().ToList();

            return View(objEntrepriseList);
        }

        public IActionResult Upsert(int? id) //update & insert
        {

            // Creation de l'article si le id est nulle ou si il n'existe pas
            if (id == null || id == 0)
            {
                return View(new Entreprise());
            }
            else
            // Mis à jour de l'article
            {

                Entreprise entrepriseObj = _unitOfWork.Entreprise.Get(u => u.Id == id);
                return View(entrepriseObj);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Entreprise EntrepriseObj)
        {
            if (ModelState.IsValid)
            {

                if (EntrepriseObj.Id == 0)
                {
                    _unitOfWork.Entreprise.Add(EntrepriseObj);
                    TempData["success"] = "Entreprise créée avec Succès";
                }
                else
                {
                    _unitOfWork.Entreprise.Update(EntrepriseObj);
                    TempData["success"] = "Entreprise mis à jour avec Succès";
                }

                _unitOfWork.Save();
                //TempData["success"] = "Entreprise mis à jour avec Succès";
                return RedirectToAction("Index");
            }
            else
            {

                return View(EntrepriseObj);
            }
        }

        #region DataTables Appel API
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Entreprise> objEntrepriseList = _unitOfWork.Entreprise.GetAll().ToList();
            return Json(new { data = objEntrepriseList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var objASupprimer = _unitOfWork.Entreprise.Get(u => u.Id == id);
            if (objASupprimer == null)
            {
                return Json(new { success = false, message = "Supperssion impossible." });
            }


            _unitOfWork.Entreprise.Remove(objASupprimer);
            _unitOfWork.Save();

            TempData["success"] = "Article supprimer";
            return Json(new { success = true, message = "Suppression ok." });
        }
        #endregion
    }
}