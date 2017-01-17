using System;

namespace MicroOpdracht
{
    public abstract class Kaart
    {
        public decimal Saldo { get; private set; }
        public Kaart()
        {
        }

        public Kaart(decimal saldo)
        {
            Saldo = saldo;
        }

        public virtual void Betaal(decimal bedrag)
        {
            Saldo -= bedrag;
        }
    }   
}