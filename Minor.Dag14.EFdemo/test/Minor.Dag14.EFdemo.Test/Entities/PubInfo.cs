﻿using System;
using System.Collections.Generic;

namespace Minor.Dag14.EFdemo.Test
{
    public partial class PubInfo
    {
        public string PubId { get; set; }
        public byte[] Logo { get; set; }
        public string PrInfo { get; set; }

        public virtual Publishers Pub { get; set; }
    }
}
