using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventEnMockOpdracht
{
    public class Persoon
    {
        public VerjaardEventHandler LeeftijdVeranderd;
        public string Naam { get; set; }
        private int _leeftijd;
        public int Leeftijd
        {
            get { return _leeftijd; }
            set
            {
                OnVerjaar(new VerjaardEventArgs(Leeftijd, value, Naam));
                _leeftijd = value;
            }
        }

        public Persoon(string naam, int leeftijd)
        {
            Naam = naam;
            Leeftijd = leeftijd;
        }      
        public void Verjaar()
        {
            Leeftijd++;
        }

        protected virtual void OnVerjaar(VerjaardEventArgs args)
        {
            VerjaardEventHandler threadSafehandler = LeeftijdVeranderd;
            threadSafehandler?.Invoke(this, args);
        }
    }
}
