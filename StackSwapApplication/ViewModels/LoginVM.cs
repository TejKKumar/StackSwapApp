using System.ComponentModel.DataAnnotations;

namespace StackSwapApplication.ViewModels
{
    public class LoginVM
    {
        [Required, MaxLength(256)]
        public string? Username { get; set; }

        [Required, DataType(DataType.Password), MaxLength(256)]
        public string? Password { get; set; }
    }
}
