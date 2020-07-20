using FashionStyles.DataAccess.Data;
using FashionStyles.DataAccess.Repositroy.IRepository;
using FashionStyles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionStyles.DataAccess.Repositroy
{
    public class StoreRepository : Repositroy<Store>, IStoreRepository
    {
        private readonly ApplicationDbContext _db;

        public StoreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;


        }

        public void Update(Store store)
        {
            var objFromDb = _db.Stores.FirstOrDefault(s => s.Id == store.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = store.Name;


            }
        }

        
    }
}
