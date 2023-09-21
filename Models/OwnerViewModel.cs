using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Models
{
    public class OwnerViewModel
    {
        public int OwnerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        public int? CarId { get; set; }
    }
}