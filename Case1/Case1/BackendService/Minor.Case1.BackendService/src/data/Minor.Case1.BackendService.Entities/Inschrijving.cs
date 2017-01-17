using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.BackendService.Entities
{
    public class Inschrijving
    {
        public int Id { get; set; }

        public int CursistId{ get; set; }

        public int CursusInstantieId { get; set; }

        public CursusInstantie Instantie { get; set; }

        public Cursist Cursist { get; set; }
    }
}
