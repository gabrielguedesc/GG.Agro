using System;

namespace GG.Agro.Application.DTOs
{
    public class ContratoModeloDocGenerationDTO
    {
        public Guid ContratoTipoId { get; set; }
        public Guid SociedadId { get; set; }
        public Guid CosechaId { get; set; }
        public byte[] DocumentoCargado { get; set; }
        public MonedaDTO Moneda { get; set; }
        public ProductoDocGenerationDTO Producto { get; set; }
    }
}