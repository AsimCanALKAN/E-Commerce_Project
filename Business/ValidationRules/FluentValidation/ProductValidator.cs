using System;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();

            RuleFor(p=>p.ProductName).MinimumLength(2).WithMessage(Messages.ProductNameInvalid);

            RuleFor(p=>p.ProductName).Must(StartWithA).WithMessage(Messages.ProductStartsNameInvalid);

            RuleFor(p => p.UnitPrice).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0);

            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p=>p.CategoryId==2);

            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.CategoryId).NotEmpty();

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

