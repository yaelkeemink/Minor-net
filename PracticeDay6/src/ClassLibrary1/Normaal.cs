namespace MicroOpdracht
{
    public class Normaal : Kaart
    {

        public Normaal(decimal saldo) : base(saldo)
        {
        }
            public override void Betaal(decimal bedrag)
        {
            if((Saldo - bedrag) < 0)
            {
                throw new System.ArgumentOutOfRangeException();
            }
            base.Betaal(bedrag);
        }
    

    }
}