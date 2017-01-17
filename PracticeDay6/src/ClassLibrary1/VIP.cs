using MicroOpdracht;
namespace MicroOpdracht
{
    public class VIP : Kaart
    {
        public decimal Korting { get; }
        public VIP(decimal saldo, decimal korting = 0) : base(saldo)
        {
            if(korting < 0)
            {
                throw new System.ArgumentOutOfRangeException();
            }
            Korting = korting;
        }       
    }
}