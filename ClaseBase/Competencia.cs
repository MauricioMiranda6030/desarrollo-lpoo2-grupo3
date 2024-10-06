using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    class Competencia
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public String State { get; set; }
        public String Organizer { get; set; }
        public String Location { get; set; }
        public String Sponsors { get; set; }
        public int CategoryId { get; set; }
        public int DiciplineId { get; set; }

        public Competencia() { }
    }
}
