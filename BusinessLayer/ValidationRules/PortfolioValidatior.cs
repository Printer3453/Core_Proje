using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidatior: AbstractValidator<Portfolio>
    {
        public PortfolioValidatior()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje Adını Boş Geçemezsiniz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter girişi yapın");
            


            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Proje Görselini Boş Geçemezsiniz");
            RuleFor(x => x.ImageUrl).MaximumLength(250).WithMessage("Lütfen en fazla 250 karakter girişi yapın");

            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Proje Görselini Boş Geçemezsiniz");
            RuleFor(x => x.ImageUrl2).MaximumLength(250).WithMessage("Lütfen en fazla 250 karakter girişi yapın");
            
            RuleFor(x => x.ProjectUrl).NotEmpty().WithMessage("Proje Linkini Boş Geçemezsiniz");
            RuleFor(x => x.ProjectUrl).MaximumLength(250).WithMessage("Lütfen en fazla 250 karakter girişi yapın");



            RuleFor(x => x.Value).NotEmpty().WithMessage("Proje Değerini Boş Geçemezsiniz");
            RuleFor(x => x.Value).InclusiveBetween(0, 100).WithMessage("Lütfen 0 ile 100 arasında bir değer giriniz");

            RuleFor(x=> x.Price).NotEmpty().WithMessage("Proje Fiyatını Boş Geçemezsiniz");
            



        }
    }
}
