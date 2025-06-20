using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı boş geçilemez!")]
        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
