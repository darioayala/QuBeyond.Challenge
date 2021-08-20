using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuBeyond.Challenge.Business.Validators
{
    public class MatrixValidator: AbstractValidator<IEnumerable<string>>
    {
        public MatrixValidator()
        {
            RuleFor(p => p).NotEmpty().WithMessage("String cannot be empty");

            When(x => x != null, () =>
            {
                //var length = 
            });

        }
    }
}
