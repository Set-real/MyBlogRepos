using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Models.Comments
{
    public class GetCommentReqest
    {
        public int CommentAmount { get; set; }
        public CommentView[] CommentView { get; set; }
    }
    public class CommentView
    {
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
