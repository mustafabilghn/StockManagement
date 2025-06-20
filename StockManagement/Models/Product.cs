using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using StockManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Ürün adı boş geçilemez!")]
        public string Name { get; set; }

        [Display(Name = "Marka")]
        [Required(ErrorMessage = "Marka adı boş geçilemez!")]
        public string Brand { get; set; }

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori seçimi zorunludur!")]
        public int CategoryId { get; set; }

        [Display(Name = "Kategori")]
        [ValidateNever]
        public Category Category { get; set; }

        [Display(Name = "Fiyat")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalı!")]
        [Precision(18, 2)]
        [Required(ErrorMessage = "Lütfen bir fiyat giriniz.")]
        public decimal? Price { get; set; }

        [Display(Name = "Stok Adedi")]
        [Required(ErrorMessage = "Lütfen bir stok adedi giriniz.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok adedi negatif olamaz!")]
        public int? StockQuantity { get; set; }
    }
}

