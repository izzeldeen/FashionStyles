using FashionStyles.DataAccess.Data;
using FashionStyles.DataAccess.Repositroy.IRepository;
using FashionStyles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionStyles.DataAccess.Repositroy
{
    public class ShoppingCartRepository : Repositroy<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;


        }

        public void Update(ShoppingCart ShoppingCartRepository)
        {
            var objFromDb = _db.ShoppingCarts.FirstOrDefault(s => s.Id == ShoppingCartRepository.Id);
            if(objFromDb !=null)
            {
               
              

            }    
        }
    }
}
