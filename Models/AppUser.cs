using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AddressBookPro.Models
{
    //adding the AppUser Model allows us to add new properties & also use all properties from IndentityUser by inheritance 
    public class AppUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and a max {1} characters long.", MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and a max {1} characters long.", MinimumLength = 2)]
        public string? LastName { get; set; }

        [NotMapped]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }

        //allows a user to include its related contacts
        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();

        //allows a user to include its related categories
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();

    }
}
