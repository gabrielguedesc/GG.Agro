using System;

namespace GG.Agro.Application.DTOs
{
    public enum ContratoTipoFluxoEnum
    {
        ContratoFisico,
        DocuSign
    }

    public class ContratoTipoFluxoDTO
    {
        public Guid Id { get; set; }
        public ContratoTipoFluxoEnum ContratoTipoFluxoEnum { get; set; }
        public string TipoFluxoDsc { get; set; }
    }
}