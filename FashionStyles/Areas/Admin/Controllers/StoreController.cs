using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionStyles.DataAccess.Repositroy.IRepository;
using FashionStyles.Models;
using FashionStyles.Uitilty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FashionStyles.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class StoreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StoreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Store store = new Store();
            if (id == null)
            {
                // this is for create 
                return View(store);
            }

            //this is for edit
            store = _unitOfWork.Store.Get(id.GetValueOrDefault());

            if (store == null) { return NotFound(); }
            return View(store);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Store store)
        {
            if (ModelState.IsValid)
            {
                if (store.Id == 0)
                {
                    _unitOfWork.Store.Add(store);


                }
                else
                {
                    _unitOfWork.Store.Update(store);

                }

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(store);

        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var allobj = _unitOfWork.Store.GetAll();

            return Json(new { data = allobj });
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Store.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting " });
            }

            _unitOfWork.Store.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

    }
}
