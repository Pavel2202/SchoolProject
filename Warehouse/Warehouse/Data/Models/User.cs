namespace Warehouse.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class User : IdentityUser
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public override string Id { get; set; }

        [Required]
        [MaxLength(UserNameMaxLength)]
        public override string UserName { get; set; }

        [Required]
        [MaxLength(UserPasswordMaxLength)]
        public string Password { get; set; }
    }
}
