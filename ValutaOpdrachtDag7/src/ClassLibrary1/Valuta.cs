using System;

namespace ClassLibrary1
{
    public struct Valuta
    {
        public Muntsoort Type { get; }
        public decimal Bedrag { get; }

        public Valuta(Muntsoort type, decimal startBedrag)
        {
            Type = type;
            Bedrag = startBedrag;
        }
        public Valuta(Muntsoort type) : this(type, 10M)
        {

        }

        public override string ToString()
        {
            switch (Type)
            {
                case Muntsoort.Dukaat:
                    return string.Format("{0}HD", Math.Round(Bedrag, 2));
                case Muntsoort.Euro:
                    return string.Format("{0}EUR", Math.Round(Bedrag, 2));
                case Muntsoort.Florijn:
                    return string.Format("{0}fl", Math.Round(Bedrag, 2));
                case Muntsoort.Gulden:
                    return string.Format("{0}fl", Math.Round(Bedrag, 2));
                default:
                    return "";
            }
        }

        private decimal ConvertToGulden()
        {
            switch (Type)
            {
                case Muntsoort.Dukaat:
                    return Bedrag * 5.1M;
                case Muntsoort.Euro:
                    return Bedrag * 2.20371M;
                case Muntsoort.Florijn:
                    return Bedrag * 1.00M;
                case Muntsoort.Gulden:
                    return Bedrag;
                default:
                    return Bedrag;
            }
        }

        public decimal ConvertTo(Muntsoort omrekenMuntsoort)
        {
            switch (omrekenMuntsoort)
            {
                case Muntsoort.Dukaat:
                    return Math.Round(ConvertToGulden() * 0.196078431372549M, 2);
                case Muntsoort.Euro:
                    return Math.Round(ConvertToGulden() * 0.45378M, 2);
                case Muntsoort.Florijn:
                    return Math.Round(ConvertToGulden() * 1.00M, 2);
                case Muntsoort.Gulden:
                    return Math.Round(ConvertToGulden(), 2);
                default:
                    return Bedrag;
            }
        }

        public static Valuta operator+(Valuta v1, Valuta v2)
        {            
            return new Valuta(v1.Type, v1.Bedrag + v2.ConvertTo(v1.Type));
        }
        public static Valuta operator *(Valuta v1, double multiplier)
        {
            return new Valuta(v1.Type, (decimal)multiplier * v1.Bedrag);
        }
        public static bool operator ==(Valuta v1, Valuta v2)
        {
            if (v1.Bedrag == v2.ConvertTo(v1.Type))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Valuta v1, Valuta v2)
        {
            if (v1.Bedrag == v2.ConvertTo(v1.Type))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode() ^ Bedrag.GetHashCode();
        }

        public static implicit operator Valuta (double x)
        {
            return new Valuta(Muntsoort.Euro, (decimal)x);
        }

        public static implicit operator double(Valuta x)
        {
            return (double)x.Bedrag;
        }

    }
}