using DuAnThucTap.Models;
using FluentValidation;

namespace DuAnThucTap.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerModel>
    {
        public CustomerValidator() { 
            RuleFor(x => x.Name_Customer).NotEmpty().WithMessage("Yeu cau ten ");
            RuleFor(x => x.Address_Customer).NotEmpty().WithMessage("Yeu cau nhap dia chi");
            RuleFor(x => x.Age_Customer).InclusiveBetween(0, 100).WithMessage("Tuoi nam trong khoang tu 0-100");
            RuleFor(x => x.Age_Customer).NotEmpty().WithMessage("Yeu cau nhap tuoi");
        }
    }
}
