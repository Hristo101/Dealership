using Dealership.Infrastructure.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Comments
{
    public class AddCommentViewModel
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "Съдържанието на коментара е задължително.")]
        [StringLength(DataConstant.Comment.ContentMaxLength, MinimumLength = DataConstant.Comment.ContentMinLength,
                    ErrorMessage = "Коментарът трябва да бъде между 1 и 500 символа.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Оценката е задължителна.")]
        [Range(DataConstant.Comment.GradeMinValue, DataConstant.Comment.GradeMaxValue,
               ErrorMessage = "Оценката трябва да бъде между 1 и 5.")]
        public int Grade { get; set; }

        [Required(ErrorMessage = "Потребителското име е задължително.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Потребителското име трябва да бъде между 2 и 50 символа.")]
        public string Username { get; set; }
    }
}
