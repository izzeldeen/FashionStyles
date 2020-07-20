//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace FashionStyles.Areas.Admin.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ValuesControllerApi : ControllerBase
//    {
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FashionStyles.Models;

using FashionStyles.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FashionStyles.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _unitOfWork;
        public ValuesController(ApplicationDbContext unitOfWork)
        {
            _unitOfWork = unitOfWork;



        }
        // GET api/values
        [HttpGet]
        public IActionResult GetValues()
        {
            var values = _unitOfWork.Categories.ToList();
           


            return Ok(values);

        }

        // GET api/values/
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value = _unitOfWork.Categories.FirstOrDefault(x => x.Id == id);

            return Ok(value);

        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _unitOfWork.Categories.Add(category);
            _unitOfWork.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

