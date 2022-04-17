namespace Warehouse.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(UserPasswordMaxLength)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage =
            "The new password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
