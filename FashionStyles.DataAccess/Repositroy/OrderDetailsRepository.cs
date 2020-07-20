using FashionStyles.DataAccess.Data;
using FashionStyles.DataAccess.Repositroy.IRepository;
using FashionStyles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionStyles.DataAccess.Repositroy
{
    public class OrderDetailsRepository : Repositroy<OrderDetails>,IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailsRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;


        }

        public void Update(OrderDetails orderDetails)
        {
            var objFromDb = _db.OrderDetails.FirstOrDefault(s => s.Id == orderDetails.Id);
            if(objFromDb !=null)
            {
                
              

            }    
        }
    }
}
