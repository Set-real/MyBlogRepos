using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Queries
{
    /// <summary>
    /// Класс для обновления тега
    /// </summary>
    public class UpdateTegQuery
    {
        public string NewTeg { get; }

        public UpdateTegQuery(string newTeg)
        {
            NewTeg = newTeg;
        }
    }
}
