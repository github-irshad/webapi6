using System.ComponentModel.DataAnnotations;

namespace webapi6.Dtos{
    public record UpdateItem{
        [Required]
        public string Name{get;init;}
        [Required]
        [Range(1,1000)]
        public decimal Price{get;init;}
    }
}