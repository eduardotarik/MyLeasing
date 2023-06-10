using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entities
{
    public class Owner : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Display(Name = "Document*")]
        [MaxLength(6, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Document { get; set; }

        [Display(Name = "Owner Name")]
        public string OwnerName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50)]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50)]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }

        [MaxLength(9, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }

        [MaxLength(9, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "CellPhone")]
        public string CellPhone { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

    }
}
