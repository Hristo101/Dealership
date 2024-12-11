using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Comments
{
    public class EditCommentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Съдържанието на коментара е задължително.")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Коментарът трябва да е между 1 и 500 символа.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Оценката е задължителна.")]
        [Range(1, 5, ErrorMessage = "Оценката трябва да бъде между 1 и 5.")]
        public int Grade { get; set; }

        public bool IsInvalid => !string.IsNullOrEmpty(Content) && Content.Length < 1 || Grade < 1 || Grade > 5;
    }
}
