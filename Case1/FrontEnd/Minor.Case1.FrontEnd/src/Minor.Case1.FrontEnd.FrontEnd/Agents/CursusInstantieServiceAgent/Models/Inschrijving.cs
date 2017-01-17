// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Minor.Case1.FrontEnd.FrontEnd.Agents.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class Inschrijving
    {
        /// <summary>
        /// Initializes a new instance of the Inschrijving class.
        /// </summary>
        public Inschrijving() { }

        /// <summary>
        /// Initializes a new instance of the Inschrijving class.
        /// </summary>
        public Inschrijving(int? cursistId = default(int?), int? cursusInstantieId = default(int?), CursusInstantie instantie = default(CursusInstantie), Cursist cursist = default(Cursist))
        {
            CursistId = cursistId;
            CursusInstantieId = cursusInstantieId;
            Instantie = instantie;
            Cursist = cursist;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cursistId")]
        public int? CursistId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cursusInstantieId")]
        public int? CursusInstantieId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "instantie")]
        public CursusInstantie Instantie { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cursist")]
        public Cursist Cursist { get; set; }

    }
}
