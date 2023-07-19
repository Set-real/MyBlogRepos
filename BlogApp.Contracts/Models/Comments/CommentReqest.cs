using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Models.Comments
{
    public class CommentReqest
    {
        public Guid Id { get; set; }
        public string CommentContext { get; set; }
    }
}
