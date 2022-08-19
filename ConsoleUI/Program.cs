using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DTO: Data Transformation Object
            //IoC
            ProductTest();
            Console.WriteLine("\nCategories \n");
            CategoryTest();
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetAll();
            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            var result_2 = productManager.GetProductDetails();
            if (result_2.Success)
            {
                foreach (var product in result_2.Data)
                {
                    Console.WriteLine(product.ProductName + "  /  " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result_2.Message);
            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }
    }
}

