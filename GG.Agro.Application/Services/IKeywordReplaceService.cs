using GG.Agro.Application.DTOs;

namespace GG.Agro.Application.Services
{
    public interface IKeywordReplaceService
    {
        string Replace(string file, ContractDTO contract);
    }
}
