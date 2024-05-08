using System.ComponentModel.DataAnnotations;

namespace EnterpriseMobileApp_ASS1.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string StoreName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

    }
}
