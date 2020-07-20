﻿using FashionStyles.DataAccess.Data;
using FashionStyles.DataAccess.Repositroy.IRepository;
using FashionStyles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionStyles.DataAccess.Repositroy
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            Category = new CategoryRepository(_db);

            Store = new StoreRepository(_db);

            Product = new ProductRepository(_db);

            Company = new CompanyRepository(_db);

            ApplicationUser = new ApplicationUserRepository(_db);

            ShoppingCart = new ShoppingCartRepository(_db);

            OrderHeader = new OrderHeaderRepository(_db);

            OrderDetails = new OrderDetailsRepository(_db);

        }

       public  ICategoryRepository Category { get; private set; }

        public IStoreRepository Store { get; private set; }

        public IProductRepository Product { get; private set; }

        public ICompanyRepository Company { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IShoppingCartRepository ShoppingCart { get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }

        public IOrderDetailsRepository OrderDetails { get; private set; }

        public ISP_Call SP_Call { get; private set; }

        public object user => throw new NotImplementedException();

        public void Dispose()
        {
            _db.Dispose();

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
