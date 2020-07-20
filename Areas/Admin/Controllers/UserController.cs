using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionStyles.DataAccess.Data;
using FashionStyles.DataAccess.Repositroy.IRepository;
using FashionStyles.Models;
using FashionStyles.Uitilty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FashionStyles.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class UserController : Controller
    {
        
      
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;

        public UserController(IUnitOfWork unitOfWork , ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;

        }
        public IActionResult Index()
        {
            
            return View();
        }

     


        [HttpGet]
        public IActionResult GetAll()
        {
            var userList = _unitOfWork.ApplicationUser.GetAll(includeProperties: "Company");
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            
            foreach(var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if(user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""

                };
                   
                }
           
            
            }

            
            

            return Json(new { data = userList });
        }


       [HttpPost]
       public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while locking/Unlocking" });

            }
            if (objFromDb.LockoutEnd!=null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is currently locked we will unlock them
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(3);

            }

            _db.SaveChanges();
            return Json(new { success = true, message = "Opertion Sucessful" });

           

        }


    }
}
