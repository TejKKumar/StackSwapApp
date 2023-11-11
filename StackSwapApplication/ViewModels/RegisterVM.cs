using System.ComponentModel.DataAnnotations;

namespace StackSwapApplication.ViewModels
{
    public class RegisterVM
    {

        [Required, DataType(DataType.EmailAddress), MaxLength(256)]
        public string? Email { get; set; }

        [Required, MaxLength(256)]
        public string? Name { get; set; }

        [Required, MaxLength(256)]
        public string? Username { get; set; }

        [Required, DataType(DataType.Password), MaxLength(256)]
        public string? Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

    }
}
