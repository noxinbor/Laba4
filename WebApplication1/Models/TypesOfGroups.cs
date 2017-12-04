using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class TypesOfGroups
    {
        public TypesOfGroups()
        {
            Groups = new HashSet<Groups>();
        }

        public int TypesOfGroupsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Groups> Groups { get; set; }
    }
}
