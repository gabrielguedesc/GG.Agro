using System;

namespace GG.Agro.Application.DTOs
{
    public enum MonedaEnum
    {
        Dolares,
        PesosUruguaios,
        PesosArgentinos,
        Reais,
        PesosBolivianos
    }

    public class MonedaDTO
    {
        public Guid Id { get; set; }
        public string MonedaNombre { get; set; }
        public string MonedaSimbolo { get; set; }
        public MonedaEnum MonedaEnum { get; set; }
    }
}