using EventEnMockOpdracht;
namespace EventEnMockOpdracht
{
    public class Werknemer : Persoon
    {
        public decimal Salaris { get; set; }

        public Werknemer(string naam, int leeftijd, decimal salaris) : base(naam, leeftijd)
        {
            Salaris = salaris;
        }

        protected override void OnVerjaar(VerjaardEventArgs args)
        {
            decimal jaarVerschil = ((args.NieuweLeeftijd - args.OudeLeeftijd) / 100M + 1M) ;
            Salaris *= jaarVerschil;
            base.OnVerjaar(args);
        }
    }
}