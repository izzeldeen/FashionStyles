﻿using FashionStyles.DataAccess.Data;
using FashionStyles.DataAccess.Repositroy.IRepository;
using FashionStyles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionStyles.DataAccess.Repositroy
{
    public class ProductRepository : Repositroy<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;


        }

        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(s => s.Id == product.Id);
            if (objFromDb != null)
            {
               
                if (product.ImageUrl !=null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }

                objFromDb.ISBN = product.ISBN;
                objFromDb.Price = product.Price;
                objFromDb.Price50 = product.Price50;
                objFromDb.ListPrice = product.ListPrice;
                objFromDb.Price100 = product.Price100;
                objFromDb.Title = product.Title;
                objFromDb.Description = product.Description;
                objFromDb.Brand = product.Brand;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.StoreId = product.StoreId;




            }
        }

    }
}
