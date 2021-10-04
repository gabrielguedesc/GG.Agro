using System;

namespace GG.Agro.Application.DTOs
{
    public class PaisProvinciaDTO
    {
        public string ProvinciaNombre { get; set; }
        public Guid PaisId { get; set; }
        public PaisDTO Pais { get; set; }
    }
}