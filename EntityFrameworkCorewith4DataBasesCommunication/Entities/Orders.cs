using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore_CodeFirst_4DataBasesCommunication.Entities
{
    public class Orders
    {
        [Key]
        public int orderid { get; set; }
        public string ordername { get; set; }
        public string orderlocation { get; set; }

    }
}
