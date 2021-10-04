using System;
using System.Text.Json.Serialization;

namespace GG.Agro.Application.DTOs
{
    public class ContratoProductoDocGenerationDTO
    {
        public Guid? Id { get; set; }
        public decimal? CantidadVal { get; set; }
        public decimal? PrecioVal { get; set; }
        public Guid? UnidadMedidaId { get; set; }
        public Guid? EnvaseId { get; set; }
        public Guid? UnidadMedidaPrecioId { get; set; }
        public Guid? MaterialId { get; set; }

        [JsonIgnore]
        public MaterialDTO Material { get; set; }

        [JsonIgnore]
        public UnidadMedidaDTO UnidadMedida { get; set; }

        [JsonIgnore]
        public EnvaseDocGenerationDTO Envase { get; set; }

        [JsonIgnore]
        public UnidadMedidaPrecioDTO UnidadMedidaPrecio { get; set; }
    }
}