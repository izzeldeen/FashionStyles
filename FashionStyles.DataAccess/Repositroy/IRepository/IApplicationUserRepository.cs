using FashionStyles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionStyles.DataAccess.Repositroy.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        object Role { get; }
    }
}
