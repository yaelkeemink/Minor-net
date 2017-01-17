using System;

namespace EventEnMockOpdracht.Test
{
    internal class Mock
    {
        public int AantalKeerGeroepen { get; internal set; }
        public VerjaardEventArgs Arg { get; private set; }

        internal void VerjaardHandled(object sender, VerjaardEventArgs args)
        {
            AantalKeerGeroepen++;
            Arg = args;
        }
    }
}