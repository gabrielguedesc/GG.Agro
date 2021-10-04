using System;

namespace GG.Agro.Application.DTOs
{
    public class ProveedorFertilizanteDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoSap { get; set; }
        public Guid? PaisId { get; set; }
    }
}