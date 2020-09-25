using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        //   public string SearchText { get; set; }
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Kjo fushe mund te permbaje vetem shkronja ose numra")]
        [DataType(DataType.Text)]
        [DisplayName("Zgjidhni titullin  librit")]
        [Required(ErrorMessage = "Ju lutem vendosni titullin ")]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Kjo fushe mund te permbaje vetem shkronja ose numra")]
        [DataType(DataType.Text)]
        [DisplayName("Zgjidhni Autorin  librit")]
        [Required(ErrorMessage = "Ju lutem vendosni autorin ")]
        
        public string Author { get; set; }
        [DisplayName("Cmimi")]
        [Required(ErrorMessage = "Ju lutem vendosni cmimin")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]


        public decimal Price { get; set; }

        [StringLength(255, MinimumLength = 2)]
        [DisplayName("Pershkrim")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Ju lutem jepni nje pershkrim")]
        public string Description { get; set; }
        [NotMapped] //Nuk ruhet si fushe ne databaze
        [DisplayName("Ngarkoni nje imazh")]
        [Required(ErrorMessage = "Ju lutem ngarkoni imazhin")]
        public IFormFile Image { get; set; }

        public string image { get; set; }

      //  public string[] images = new  string[3];  

        //     [DisplayName("Ngarkoni nje imazh")]
        //      public IFormFile ImageFile { get; set; }

        
        [Required(ErrorMessage = "Ju lutem  vendosni kategorine e librit")]
        [DisplayName("Kategoria")]
        public int CategoriesId { get; set; }
   public virtual Categories Category { get; set; }

    }
}
