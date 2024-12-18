﻿using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("supplier")]
    public class ExportSupplierDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("parts-count")]
        public int Count { get; set; }
    }
}
