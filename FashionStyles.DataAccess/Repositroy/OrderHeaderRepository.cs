using FashionStyles.DataAccess.Data;
using FashionStyles.DataAccess.Repositroy.IRepository;
using FashionStyles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionStyles.DataAccess.Repositroy
{
    public class OrderHeaderRepository : Repositroy<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;


        }

        public void Update(OrderHeader orderHeader)
        {
            var objFromDb = _db.OrderHeaders.FirstOrDefault(s => s.Id == orderHeader.Id);
            if(objFromDb !=null)
            {
                objFromDb.Name = orderHeader.Name;
              

            }    
        }
    }
}
