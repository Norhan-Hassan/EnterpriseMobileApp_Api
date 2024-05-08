using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMobileApp_ASS1.Models
{
    public class Favourite_Store
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("store")]
        public int store_id { get; set; }
        public Store store { get; set; }
        [ForeignKey("student")]
        public int user_id { get; set; }
        public Student student { get; set; }
    }
}
