using System;

namespace GG.Agro.Application.DTOs
{
    public class SociedadDTO
    {
        public Guid Id { get; set; }
        public string SociedadNombre { get; set; }
        public Guid PaisId { get; set; }
        public PaisDTO Pais { get; set; }
    }
}