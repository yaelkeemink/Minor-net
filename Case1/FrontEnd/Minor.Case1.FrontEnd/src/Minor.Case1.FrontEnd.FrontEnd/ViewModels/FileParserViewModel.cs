using Minor.Case1.FrontEnd.FrontEnd.Agents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.FrontEnd.FrontEnd.ViewModels
{
    public class FileParserViewModel
    {
        public string ErrorMesage { get; set; }

        public List<CursusInstantie> Instanties { get; set; }
    }
}
