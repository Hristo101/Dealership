using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Comments
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Grade { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanDetails { get; set; }
    }
}
