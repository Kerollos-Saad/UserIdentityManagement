using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UserIdentityManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(30)]
        public string? FirstName { get; set; }
        [MaxLength(30)]
        public string? LastName { get; set; }
        public byte[]? ProfilePic { get; set; }
    }
}
