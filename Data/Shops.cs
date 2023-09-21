using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class Shops
    {
        [Key]
        public int ShopId { get; set; }

        public string? Title { get; set; } = null!;
        public int? OwnerId { get; set; }
        public Owner Owner { get; set; }=null!;

        public ICollection<ShopReg>ShopReg{ get; set; }=new List<ShopReg>();
    }
}