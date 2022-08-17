using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //Global Variables
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product { CategoryId=1, ProductId=1, ProductName="iPhone 13 Pro", UnitPrice=1500, UnitsInStock=5 },
                new Product { CategoryId=2, ProductId=2, ProductName="Macbook Pro", UnitPrice=2000, UnitsInStock=5 },
                new Product { CategoryId=3, ProductId=3, ProductName="iPad Pro", UnitPrice=1750, UnitsInStock=5 },
            };
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

