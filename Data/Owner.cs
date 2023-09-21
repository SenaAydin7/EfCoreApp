using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string FullName{
            get 
            {
                return this.FirstName +" "+ this.LastName;
            }
        }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        public int? CarId { get; set; }
        public Cars Car { get; set; }=null!;

        public ICollection<Shops>Shops { get; set; } = new List<Shops>();
    }
}