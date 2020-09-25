using ebookstore.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.ViewModels
{
    public class SearchBooksViewModel
    {
        [Required]
        [DisplayName("Search")]
        public string search { get; set; }

        //public IEnumerable<string> SearchListExamples { get; set; }

        public IEnumerable<Books> BookList { get; set; }

    }
}
