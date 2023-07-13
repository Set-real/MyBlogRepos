using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Queries
{
    /// <summary>
    /// Класс для обновления комментариев
    /// </summary>
    public class UpdateCommentQuery
    {
        public string NewContent { get; } = string.Empty;
        public UpdateCommentQuery(string newContent) 
        {
            NewContent = newContent;
        }
    }
}
