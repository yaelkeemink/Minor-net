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

    public partial class Cursist
    {
        /// <summary>
        /// Initializes a new instance of the Cursist class.
        /// </summary>
        public Cursist() { }

        /// <summary>
        /// Initializes a new instance of the Cursist class.
        /// </summary>
        public Cursist(int? id = default(int?), string voornaam = default(string), string achternaam = default(string))
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "voornaam")]
        public string Voornaam { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "achternaam")]
        public string Achternaam { get; set; }

    }
}