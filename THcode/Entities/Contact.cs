using System.ComponentModel.DataAnnotations;

namespace THcode.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Contact Name is required")]
        [StringLength(100, ErrorMessage = "Contact Name cannot exceed 100 characters")]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        [StringLength(20, ErrorMessage = "Contact Number cannot exceed 220 characters")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Contact Number must be a numeric value")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Group Name is required")]
        [StringLength(255, ErrorMessage = "Group Name cannot exceed 255 characters")]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [HireDateBeforeOrToday(ErrorMessage = "Hire Date must be before or equal to today.")]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
    }


    //Custom attibute:
    public class HireDateBeforeOrTodayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime hireDate = (DateTime)value;

            if (hireDate.Date > DateTime.Today)
            {
                return new ValidationResult("Hire Date must be before or equal to today.");
            }

            return ValidationResult.Success;
        }
    }
}
