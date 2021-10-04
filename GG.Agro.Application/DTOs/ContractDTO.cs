using System;
using System.Collections.Generic;

namespace GG.Agro.Application.DTOs
{
    public enum PrimaTipo : byte
    {
        Absolute = 0,
        Percentage = 1
    }

    public class ContractDTO
    {
        public Guid? Id { get; set; }
        public Guid ContratoModeloId { get; set; }
        public Guid? PaisProvinciaId { get; set; }
        public Guid? PaisZonaId { get; set; }
        public Guid ProveedorId { get; set; }
        public Guid? TarifaFleteId { get; set; }
        public Guid? DestinoFinalId { get; set; }
        public Guid ContratoDepositoFornecedorFertilizanteId { get; set; }
        public Guid SociedadId { get; set; }
        public Guid? VariedadId { get; set; }
        public Guid TipoFluxoId { get; set; }
        public Guid? ProductoId { get; set; }
        public Guid? ComercialAgroId { get; set; }


        public string Name { get; set; }

        public ContratoTipoFluxoDTO TipoFluxo { get; set; }
        public ContratoModeloDocGenerationDTO ContratoModelo { get; set; }
        public SociedadDTO Sociedad { get; set; }
        public decimal SuperficieHaVal { get; set; }
        public decimal RendimientoKgHaVal { get; set; }
        public decimal VolumenTonVal { get; set; }
        public decimal? PrimaVal { get; set; }
        public PrimaTipo? PrimaTipo { get; set; }
        public string PrimaValStr { get; set; }
        public decimal? PrecioSementeVal { get; set; }
        public DateTime? FechaInc { get; set; }
        public string ContratoDepositoLocalidad { get; set; }
        public decimal? PrecioVal { get; set; }
        public decimal TotalContrato { get; set; }
        public ProveedoresMdDTO Proveedor { get; set; }
        public ContratoTarifaFleteDTO TarifaFlete { get; set; }
        public PlantaDTO DestinoFinal { get; set; }
        public PaisZonaDTO PaisZona { get; set; }
        public PaisProvinciaDTO PaisProvincia { get; set; }
        public ProveedorFertilizanteDTO ContratoDepositoFornecedorFertilizante { get; set; }
        public VariedadDTO Variedad { get; set; }
        public ICollection<ContratoProductoDocGenerationDTO> ContratoProductos { get; set; }
        public ContratoAcreditacionRlDocGenerationDTO LegalRepresentative1 { get; set; }
        public ContratoAcreditacionRlDocGenerationDTO LegalRepresentative2 { get; set; }
        public ContratoAcreditacionRlTestigoDocGenerationDTO Witness1 { get; set; }
        public ContratoAcreditacionRlTestigoDocGenerationDTO Witness2 { get; set; }
        public UsuarioDTO AmbevLegalRepresentative1 { get; set; }
        public UsuarioDTO AmbevLegalRepresentative2 { get; set; }
        public UsuarioDTO AmbevWitness { get; set; }
    }
}
