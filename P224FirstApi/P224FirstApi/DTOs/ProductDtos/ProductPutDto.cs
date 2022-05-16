using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224FirstApi.DTOs.ProductDtos
{
    public class ProductPutDto
    {
        public int Id { get; set; }
        public string MehsulunAdi { get; set; }
        public double MehsulunQiymeti { get; set; }
        public double MehsulunEndirimQiymeti { get; set; }
    }

    public class ProductPutDtoValidator : AbstractValidator<ProductPutDto>
    {
        public ProductPutDtoValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty().WithMessage("Duzgun Daxil");

            RuleFor(r => r.MehsulunAdi)
                .MaximumLength(100).WithMessage("Maksimum 100 Simvol Ola Biler")
                .MinimumLength(10).WithMessage("Minimum 10 Simvol Olsun")
                .NotEmpty().WithMessage("Mejburidi Qaqa");

            RuleFor(r => r.MehsulunQiymeti)
                .NotEmpty().WithMessage("Mejburidi Qaqa")
                .GreaterThanOrEqualTo(1).WithMessage("1-den Boyuk Olmalidir");

            RuleFor(r => r.MehsulunEndirimQiymeti)
                .NotEmpty().WithMessage("Mejburidi Qaqa")
                .GreaterThanOrEqualTo(1).WithMessage("1-den Boyuk Olmalidir");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.MehsulunQiymeti <= x.MehsulunEndirimQiymeti)
                    context.AddFailure("Mehsulun Endirimli Qiymeti Mehsulun Qiymetinden Boyuk Ola Bilem");

                if (x.MehsulunAdi == "Code")
                    context.AddFailure(x.MehsulunAdi, "Mehsulun Adi Code Ola Bilme");
            });


        }
    }
}
