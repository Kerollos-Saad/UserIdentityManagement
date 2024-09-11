using System.ComponentModel.DataAnnotations;

namespace UserIdentityManagement.ViewModels
{
    public class RoleFormViewModel
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
    }
}
