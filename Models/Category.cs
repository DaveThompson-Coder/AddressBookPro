using AddressBookPro.Models;
using System.ComponentModel.DataAnnotations;

namespace AddressBookPro.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string? AppUserId { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string? Name { get; set; }

        //Virtual properties tell application to create foreign keys
        //Foreign Key to AppUser Model, So AppUser replaces ASP.Identity as our Default Identity
        public virtual AppUser? AppUser { get; set; }
        //Foreign Key to Contact join Table
        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
    }
}
