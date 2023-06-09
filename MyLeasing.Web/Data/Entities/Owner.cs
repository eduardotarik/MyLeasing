using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Document field is required.")]
        [Display(Name = "Document*")]
        [MaxLength(6)]
        public string Document { get; set; }

        [Display(Name = "Owner Name")]
        public string OwnerName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = "The First Name field is required.")]
        [MaxLength(30)]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name field is required.")]
        [MaxLength(30)]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }

        [MaxLength(9)]
        [Display(Name = "Fixed Phone")]

        public string FixedPhone { get; set; }

        [MaxLength(9)]
        [Display(Name = "CellPhone")]
        public string CellPhone { get; set; }

        public string Address { get; set; }
    }
}
