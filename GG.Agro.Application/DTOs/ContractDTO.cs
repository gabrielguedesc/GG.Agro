using System;

namespace GG.Agro.Application.DTOs
{
    public class ContractDTO
    {
        public string Name { get; set; }

        public decimal SuperficieHaVal { get; set; }
        public decimal RendimientoKgHaVal { get; set; }
        public decimal VolumenTonVal { get; set; }
        public decimal? PrimaVal { get; set; }
        public decimal? PrecioSementeVal { get; set; }
        public DateTime? FechaInc { get; set; }
        public string ContratoDepositoLocalidad { get; set; }
        public decimal? PrecioVal { get; set; }
        public decimal TotalContrato { get; set; }
    }
}
