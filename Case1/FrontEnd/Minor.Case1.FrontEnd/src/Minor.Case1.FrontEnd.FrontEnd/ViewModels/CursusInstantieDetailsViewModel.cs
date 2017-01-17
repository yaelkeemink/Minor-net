using Minor.Case1.FrontEnd.FrontEnd.Agents.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.FrontEnd.FrontEnd.ViewModels
{
    public class CursusInstantieDetailsViewModel
    {
        public CursusInstantieDetailsViewModel(IEnumerable<CursusInstantie> instanties)
        {
            Instanties = new List<CursusInstantieModel>();

            foreach (var instantie in instanties)
            {
                Instanties.Add(new CursusInstantieModel()
                {
                    Cursus = instantie.Cursus,
                    CursusId = instantie.CursusId,
                    Id = instantie.Id,
                    StartDatum = instantie.StartDatum.ToString("dd/MM/yyyy"),
                });
            }
        }
        public class CursusInstantieModel
        {
            public int? Id { get; set; }

            public string CursusId { get; set; }

            public string StartDatum { get; set; }

            public Cursus Cursus { get; set; }
        }

        [Range(1, 53)]
        public int WeekNummer { get; set; }
        [Range(1900, 3000)]
        public int? Jaar { get; set; }
        public List<CursusInstantieModel> Instanties { get; set; }

    }
}
