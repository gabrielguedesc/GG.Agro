using System;

namespace GG.Agro.Application.DTOs
{
    public class UsuarioDTO
    {
        public string UsrNombre { get; set; }
        public string UsrIdfiscal { get; set; }
        public string UsrEmail { get; set; }
        public Guid PerfilId { get; set; }
        public PerfilDTO Perfil { get; set; }
    }
}