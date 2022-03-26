using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Hospital : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconURL { get; set; }
        public int Count { get; set; }
        public string Info { get; set; }
    }
}
