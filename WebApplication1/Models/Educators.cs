using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Educators
    {
        public Educators()
        {
            Groups = new HashSet<Groups>();
        }

        public int EducatorsId { get; set; }
        public string Fio { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public int Experience { get; set; }
        public string Awards { get; set; }

        public ICollection<Groups> Groups { get; set; }
    }
}
