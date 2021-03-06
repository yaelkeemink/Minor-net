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

    public partial class Cursus
    {
        /// <summary>
        /// Initializes a new instance of the Cursus class.
        /// </summary>
        public Cursus() { }

        /// <summary>
        /// Initializes a new instance of the Cursus class.
        /// </summary>
        public Cursus(string code = default(string), string titel = default(string), int? dagen = default(int?))
        {
            Code = code;
            Titel = titel;
            Dagen = dagen;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "titel")]
        public string Titel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dagen")]
        public int? Dagen { get; set; }

    }
}
