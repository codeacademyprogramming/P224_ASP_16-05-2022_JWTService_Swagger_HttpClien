using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224FirstApi.DTOs.CategoryDtos
{
    public class CategoryPutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Kategoriya Validation
    /// </summary>
    public class CategoryPutDtoValidator : AbstractValidator<CategoryPutDto>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CategoryPutDtoValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage("Mecburidi");

            RuleFor(r => r.Name)
                .MaximumLength(100).WithMessage("maksimum 100 ola biler")
                .NotEmpty().WithMessage("Mecburidi");
        }
    }
}
