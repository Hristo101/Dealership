using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Query
{
    public class QueryListViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Моля, въведете вашето съобщение.")]
        [StringLength(500, ErrorMessage = "Съобщението трябва да е между {2} и {1} символа.", MinimumLength = 10)]
        [Display(Name = "Вашето съобщение")]
        public string Message { get; set; }
        public bool IsAnswered { get; set; }
        public string AdminResponse { get; set; } = string.Empty;
        public int AnnouncementId { get; set; }
    }
}
