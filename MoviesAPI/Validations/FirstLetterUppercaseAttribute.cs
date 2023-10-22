using System;
using System.ComponentModel.DataAnnotations;
using MoviesAPI.Entities;

namespace MoviesAPI.Validations
{
	public class FirstLetterUppercaseAttribute : ValidationAttribute
	{
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var genre = (Genre)validationContext.ObjectInstance;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var firstLetter = value.ToString()[0].ToString();

            if (firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("First Letter should be uppercase");
            }

            return ValidationResult.Success;
        }
    }
}

