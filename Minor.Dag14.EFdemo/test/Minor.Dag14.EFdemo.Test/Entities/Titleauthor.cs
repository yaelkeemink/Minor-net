﻿using System;
using System.Collections.Generic;

namespace Minor.Dag14.EFdemo.Test
{
    public partial class Titleauthor
    {
        public string AuId { get; set; }
        public string TitleId { get; set; }
        public byte? AuOrd { get; set; }
        public int? Royaltyper { get; set; }

        public virtual Authors Au { get; set; }
        public virtual Boek Title { get; set; }
    }
}
