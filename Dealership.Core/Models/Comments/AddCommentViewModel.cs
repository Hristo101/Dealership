using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Core.Models.Comments
{
    public class AddCommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Grade { get; set; }
        public string Username { get; set; }
    }

}
