using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventEnMockOpdracht
{
    public delegate void VerjaardEventHandler(object sender, VerjaardEventArgs args); 
    public class VerjaardEventArgs
        : EventArgs
    {
        public int OudeLeeftijd { get; }
        public int NieuweLeeftijd { get; }
        public string Naam { get; }

        public VerjaardEventArgs(int oudeLeeftijd, int nieuweLeeftijd, string naam)
        {
            OudeLeeftijd = oudeLeeftijd;
            NieuweLeeftijd = nieuweLeeftijd;
            Naam = naam;
        }

    }
}
