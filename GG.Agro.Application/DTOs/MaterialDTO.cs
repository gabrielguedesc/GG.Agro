using System;
using System.Text.Json.Serialization;

namespace GG.Agro.Application.DTOs
{
    public class MaterialDTO
    {
        public Guid Id { get; set; }
        public Guid SociedadId { get; set; }
        public MaterialVariedadDTO MaterialVariedad { get; set; }

        [JsonIgnore]
        public Guid MaterialVariedadId { get; set; }
    }
}