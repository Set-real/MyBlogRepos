using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Models.Comments
{
    public class EditCommentReqest
    {
        public Guid Id { get; set; }
        public string NewContent { get; set; }
    }
}
