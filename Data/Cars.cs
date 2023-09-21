using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Cars
    {
        [Key]
        public int CarId { get; set; }

        public string? CarName { get; set; }

        public string? CarModel { get; set; }

        public string FullName
        {
            get
            {
                return this.CarName+" "+this.CarModel;
            }
        }

        public string? CarPrice { get; set; }
        
        public string? CarImage { get; set; }

        public ICollection<ShopReg> ShopReg { get; set; } = new List<ShopReg>();
        public ICollection<Owner> Owners { get; set; } = new List<Owner>();
    }
}

