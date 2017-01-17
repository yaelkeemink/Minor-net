using Minor.Case1.FrontEnd.FrontEnd.Agents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.FrontEnd.FrontEnd.ViewModels
{
    public class InschrijvingenViewModel
    {
        public int InstantieId { get; set; }
        public IList<Inschrijving> Inschrijvingen { get; set; }
    }
}
