using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ILogger _logger;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService, ILogger logger)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            _logger = logger;
        }

        [CacheAspect(duration:10)] //key, value
        public IDataResult<List<Product>> GetAll()
        {
            //Business Codes Write Here
            
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        [CacheAspect] //key, value
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect] //key, value
        [PerformanceAspect(5)]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        [CacheAspect] //key, value
        public IDataResult<List<Product>>  GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        [CacheAspect] //key, value
        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountCategoryAllowed(product.CategoryId),
                CheckIfProductNameExist(product.ProductName),
                CheckCategoryCount());

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);

            return new SuccessResult();
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            _productDal.Update(product);

            return new SuccessResult();
        }

        private IResult CheckIfProductCountCategoryAllowed(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count();
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountIsNotAllowed);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            return new SuccessResult();
        }

        private IResult CheckCategoryCount()
        {
            var result = _categoryService.GetAll();
            if(result.Data.Count >= 15)
            {
                return new ErrorResult(Messages.CategoryCountExcedeed);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}

