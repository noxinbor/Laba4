using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Pupils
    {
        public int PupilsId { get; set; }
        public string Fio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string FioFather { get; set; }
        public string FioMather { get; set; }
        public int GroupsId { get; set; }
        public string Info { get; set; }
        public string AttendanceGroup { get; set; }

        public Groups Groups { get; set; }
    }
}
