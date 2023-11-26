using System.ComponentModel.DataAnnotations;

namespace Chapter16._7
{
    public class UserBindingModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Your name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Your last name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
