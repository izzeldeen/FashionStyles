using FashionStyles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionStyles.DataAccess.Repositroy.IRepository
{
    public interface IOrderDetailsRepository : IRepository<OrderDetails>
    {
        void Update(OrderDetails orderDetails);


    }
}
