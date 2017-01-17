using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.BackendService.WebApi.Models
{
    public class DateModel
    {
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }

        public int Jaar { get; set; }

        public int Week{ get; set; }
    }
}
