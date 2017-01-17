using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Minor.Case1.BackendService.Entities
{
    public class Cursus
    {
        [Key]
        public string Code { get; set; }
        public string Titel { get; set; }

        public int Dagen { get; set; }
    }
}