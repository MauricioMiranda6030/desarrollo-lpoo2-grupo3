using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase
{
    class Evento
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int AthleteId { get; set; }
        public String State { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
    }

}
