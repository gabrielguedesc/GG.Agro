namespace GG.Agro.Application.DTOs
{
    public class ProveedoresMdDTO
    {
        public string NombrePoveedor { get; set; }
        public string CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Nfi1 { get; set; }
        public string ChaveBanco { get; set; }
        public string NombreBanco { get; set; }
        public string AgenciaBanco { get; set; }
        public string ContaBanco { get; set; }
        public string TitularBanco { get; set; }
        public string DireccionProveedor { get; set; }
        public PaisProvinciaDTO PaisProvincia { get; set; }
    }
}