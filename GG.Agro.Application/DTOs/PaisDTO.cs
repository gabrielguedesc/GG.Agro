using System;
using System.Collections.Generic;

namespace GG.Agro.Application.DTOs
{
    public enum PaisEnum
    {
        Brasil,
        Argentina,
        Uruguai,
        Bolivia
    }

    public class PaisDTO
    {
        public Guid Id { get; set; }
        public string PaisIdIniciales { get; set; }
        public string PaisNombre { get; set; }
        public PaisEnum PaisEnum { get; set; }

        public IReadOnlyCollection<PaisResponsavelLegalDTO> PaisResponsavelLegal { get; set; }

        public PaisDTO()
        {
            PaisResponsavelLegal = new HashSet<PaisResponsavelLegalDTO>();
        }
    }
}