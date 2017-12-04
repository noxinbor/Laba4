using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Groups
    {
        public Groups()
        {
            Pupils = new HashSet<Pupils>();
        }

        public int GroupsId { get; set; }
        public string Name { get; set; }
        public int EducatorsId { get; set; }
        public int TypesOfGroupsId { get; set; }
        public int NumberOfChildren { get; set; }
        public DateTime YearOfCreation { get; set; }

        public Educators Educators { get; set; }
        public TypesOfGroups TypesOfGroups { get; set; }
        public ICollection<Pupils> Pupils { get; set; }
    }
}
