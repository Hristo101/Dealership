using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Comments
{
    public class EditCommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Grade { get; set; }
    }
}
