using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Builder.Extensions;

namespace efcoreApp.Data
{
    public class ShopReg
    {
        [Key]
        public int ShopRegId { get; set; }   

        public int CarId { get; set; }
        public Cars Car{ get; set; } = null!;
        public int ShopId { get; set; }
        public Shops Shop { get; set; }= null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime RegDate { get; set; }
    }
}