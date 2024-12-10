using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Query
{
    public class QueryAnswerViewModel
    {
        [Required(ErrorMessage = "Моля, въведете вашето съобщение.")]
        [StringLength(500, ErrorMessage = "Отговорът трябва да е между {2} и {1} символа.", MinimumLength = 10)]
        [Display(Name = "Вашият отговор")]
        public string Answer {  get; set; }
        public int Id { get; set; }
    }
}
