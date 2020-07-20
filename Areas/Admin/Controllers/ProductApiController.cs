using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionStyles.DataAccess.Data;
using FashionStyles.Models;
using FashionStyles.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FashionStyles.DataAccess.Repositroy.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FashionStyles.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly ApplicationDbContext _unitOfWork;
  
        public ProductApiController(ApplicationDbContext unitOfWork , IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
  }

        



        [HttpGet]
        public IActionResult GetAll()
        {   
            var obj = _unitOfWork.Products.Include(i => i.Category).Include(i => i.Store).ToList();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value = _unitOfWork.Products.Include(x => x.Category).Include(x => x.Store).FirstOrDefault(i => i.Id == id);

            return Ok(value);

        }





    }
}
