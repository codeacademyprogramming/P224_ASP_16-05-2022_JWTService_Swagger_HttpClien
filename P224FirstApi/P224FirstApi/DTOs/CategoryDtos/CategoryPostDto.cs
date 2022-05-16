using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224FirstApi.DTOs.CategoryDtos
{
    /// <summary>
    /// Katero Yaranmasi Modeli
    /// </summary>
    public class CategoryPostDto
    {
        /// <summary>
        /// Kategoriyanin Adi
        /// </summary>
        public string Name { get; set; }
        public IFormFile[] Image { get; set; }
    }

    /// <summary>
    /// Kategoriya Validation
    /// </summary>
    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CategoryPostDtoValidator()
        {
            RuleFor(r => r.Name)
                .MaximumLength(100).WithMessage("maksimum 100 ola biler")
                .NotEmpty().WithMessage("Mecburidi");
        }
    }
}
