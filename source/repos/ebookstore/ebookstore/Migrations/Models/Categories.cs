using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.Models
{
    public class Categories
    {
           public Categories()
        {
            Books = new HashSet<Books>();
        }

        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Kjo fushe mund te permbaje vetem shkronja ose numra")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Vendosni emrin e kategorise")]
        [DisplayName("Emri i kategorise")]
        public string Name { get; set; }
        [DisplayName("Pershkrim")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Vendosni pershkrimin kategorise")]
        public string Description { get; set; }



        public virtual ICollection<Books> Books { get; set; }
    }
}
