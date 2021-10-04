using System;

namespace GG.Agro.Application.DTOs
{
    public class PaisZonaDTO
    {
        public string ZonaNombre { get; set; }
        public Guid PaisId { get; set; }
        public PaisDTO Pais { get; set; }
    }
}