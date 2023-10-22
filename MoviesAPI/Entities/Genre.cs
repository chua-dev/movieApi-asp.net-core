using System;
using System.ComponentModel.DataAnnotations;
using MoviesAPI.Validations;

namespace MoviesAPI.Entities
{
	public class Genre : IValidatableObject
	{
		public int Id { get; set; }

		// Attribute Validation
		[Required(ErrorMessage = "The field with name {0} is required")]
		[StringLength(10)]
		[FirstLetterUppercase]
		public string Name { get; set; }

		//[Range(18, 120)]
		//public int Age { get; set; }
		//[CreditCard]
		//public string CreditCard { get; set; }
		//[Url]
		//public string Url { get; set; }

		public Genre()
		{
		}

		// InModel Validation
		// Occur after the attribute validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name))
			{
				var firstLetter = Name[0].ToString();
				if (firstLetter != firstLetter.ToUpper())
				{
					yield return new ValidationResult("First letter should be uppercase", new string[] {nameof(Name)});
				}
			}
        }
    }
}

