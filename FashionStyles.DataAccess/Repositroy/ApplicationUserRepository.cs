using FashionStyles.DataAccess.Data;
using FashionStyles.DataAccess.Repositroy.IRepository;
using FashionStyles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionStyles.DataAccess.Repositroy
{
    public class ApplicationUserRepository : Repositroy<ApplicationUser>,IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;


        }

        public object Role => throw new NotImplementedException();
    }
}
