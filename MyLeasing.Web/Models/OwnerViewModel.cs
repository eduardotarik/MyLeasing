using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Models
{
    public class OwnerViewModel
    {
        [Display(Name = "Document*")]
        public string Document { get; set; }

        [Display(Name = "First Name*")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name*")]
        public string LastName { get; set; }

        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }

        [Display(Name = "CellPhone")]
        public string CellPhone { get; set; }

        public string Address { get; set; }
    }
}
