using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Models.Tegs
{
    public class AddTegRequest
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}
