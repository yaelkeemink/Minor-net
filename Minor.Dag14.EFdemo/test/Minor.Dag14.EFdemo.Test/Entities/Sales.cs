﻿using System;
using System.Collections.Generic;

namespace Minor.Dag14.EFdemo.Test
{
    public partial class Sales
    {
        public string StorId { get; set; }
        public string OrdNum { get; set; }
        public DateTime OrdDate { get; set; }
        public short Qty { get; set; }
        public string Payterms { get; set; }
        public string TitleId { get; set; }

        public virtual Stores Stor { get; set; }
        public virtual Boek Title { get; set; }
    }
}
