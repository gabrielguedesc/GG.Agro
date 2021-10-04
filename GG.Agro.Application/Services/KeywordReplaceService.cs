using GG.Agro.Application.DTOs;
using Stubble.Core.Builders;
using Stubble.Core.Classes;
using System;
using System.Collections.Generic;

namespace GG.Agro.Application.Services
{
    public class KeywordReplaceService : IKeywordReplaceService
    {
        private Dictionary<string, Func<ContractDTO, string>> FunctionKeywords = 
            new Dictionary<string, Func<ContractDTO, string>>
        {
            { "AGENCIA", (c) => c.Proveedor.AgenciaBanco },
            { "AMBEV-CI-TESTEMUNHA-1", (c) => c.AmbevWitness.UsrIdfiscal },
            { "AMBEV-CI-TESTIGO-1", (c) => c.AmbevWitness.UsrIdfiscal },
            { "AMBEV-DNI-TESTIGO-1", (c) => c.AmbevWitness.UsrIdfiscal },
            { "AMBEV-TESTEMUNHA-1", (c) => c.AmbevWitness.UsrNombre },
            { "AMBEV-TESTIGO-1", (c) => c.AmbevWitness.UsrNombre },
            { "BANCO", (c) => c.Proveedor.NombreBanco },
            { "CARGO-AMBEV-1", (c) => c.AmbevLegalRepresentative1.Perfil.PerfilDsc },
            { "CARGO-AMBEV-2", (c) => c.AmbevLegalRepresentative2.Perfil.PerfilDsc },
            { "CARGO-FORNECEDOR-1", (c) => c.LegalRepresentative1.ContratoAcreditacionRlCargo },
            { "CARGO-FORNECEDOR-2", (c) => c.LegalRepresentative2.ContratoAcreditacionRlCargo },
            { "CARGO-PROVEEDOR-1", (c) => c.LegalRepresentative1.ContratoAcreditacionRlCargo },
            { "CARGO-PROVEEDOR-2", (c) => c.LegalRepresentative2.ContratoAcreditacionRlCargo },
            { "CEP", (c) => c.Proveedor.CodigoPostal },
            { "CIDADE", (c) => c.Proveedor.Ciudad },
            { "CONTA-CORRENTE", (c) => c.Proveedor.ContaBanco },
            { "CONTRATO-DESTINOFINAL", (c) => c.DestinoFinal.PlantaNombre },
            { "CONTRATO-PRECIODIFERENCIAL", (c) => c.PrimaVal?.ToString() }, // Percentage
            { "CONTRATO-PRECIODIFERENCIALLETRAS", (c) => c.PrimaVal?.ToString() }, // NumbersToWords // Money
            { "CONTRATO-TONELADAS", (c) => c.VolumenTonVal.ToString() },
            { "CONTRATO-TONELADASLETRAS", (c) => c.VolumenTonVal.ToString() }, // NumberToWords
            { "CULTIVAR", (c) => c.Variedad.VariedadNombre },
            { "DIA", (c) => c.FechaInc?.ToString() }, // Format ("dd")
            { "FECHA", (c) => c.FechaInc?.ToString() }, // Format ("dd 'de' MMMM 'de' yyyy")
            { "FORNECEDOR-CI-TESTEMUNHA-1", (c) => c.Witness1.ContratoAcreditacionRlTestigoNombreId },
            { "FORNECEDOR-CI-TESTEMUNHA-2", (c) => c.Witness2.ContratoAcreditacionRlTestigoNombreId },
            { "FORNECEDOR-DOC", (c) => c.Proveedor.Nfi1 },
            { "FORNECEDOR-ENDEREÇO", (c) => c.Proveedor.DireccionProveedor },
            { "FORNECEDOR-NOME", (c) => c.Proveedor.NombrePoveedor },
            { "FORNECEDOR-REPRESENTANTE-1", (c) => c.LegalRepresentative1.ContratoAcreditacionRlNombre },
            { "FORNECEDOR-REPRESENTANTE-2", (c) => c.LegalRepresentative2.ContratoAcreditacionRlNombre },
            { "FORNECEDOR-REPRESENTANTE-CI-1", (c) => c.LegalRepresentative1.ContratoAcreditacionRlNombreId },
            { "FORNECEDOR-REPRESENTANTE-CI-2", (c) => c.LegalRepresentative2.ContratoAcreditacionRlNombreId },
            { "FORNECEDOR-TESTEMUNHA-1", (c) => c.Witness1.ContratoAcreditacionRlTestigoNombre },
            { "FORNECEDOR-TESTEMUNHA-2", (c) => c.Witness2.ContratoAcreditacionRlTestigoNombre },
            { "HECTAREAS", (c) => c.SuperficieHaVal.ToString() },
            { "HIBRIDO", (c) => c.Variedad.VariedadNombre },
            { "LOCALIDAD", (c) => c.ContratoDepositoLocalidad },
            { "MES", (c) => c.FechaInc?.ToString() }, // Format ("MMMM")
            { "PRECIO" , (c) => c.PrecioVal?.ToString() },
            { "PRECIO-SEMILLA", (c) => c.PrecioSementeVal?.ToString() },
            { "PREÇO-FIXO", (c) => c.PrecioVal?.ToString() },
            { "PROVEEDOR-CI-TESTIGO-1", (c) => c.Witness1.ContratoAcreditacionRlTestigoNombreId },
            { "PROVEEDOR-CI-TESTIGO-2", (c) => c.Witness2.ContratoAcreditacionRlTestigoNombreId },
            { "PROVEEDOR-DEPOSITO", (c) => c.Proveedor.DireccionProveedor },
            { "PROVEEDOR-DNI-TESTIGO-1", (c) => c.Witness1.ContratoAcreditacionRlTestigoNombreId },
            { "PROVEEDOR-DNI-TESTIGO-2", (c) => c.Witness2.ContratoAcreditacionRlTestigoNombreId },
            { "PROVEEDOR-DOC", (c) => c.Proveedor.Nfi1 },
            { "PROVEEDOR-DOMICILIO", (c) => c.Proveedor.DireccionProveedor },
            { "PROVEEDOR-FERTI", (c) => c.ContratoDepositoFornecedorFertilizante.Nombre },
            { "PROVEEDOR-NOMBRE", (c) => c.Proveedor.NombrePoveedor },
            { "PROVEEDOR-REPRESENTANTE-1", (c) => c.LegalRepresentative1.ContratoAcreditacionRlNombre },
            { "PROVEEDOR-REPRESENTANTE-2", (c) => c.LegalRepresentative2.ContratoAcreditacionRlNombre },
            { "PROVEEDOR-REPRESENTANTE-CI-1", (c) => c.LegalRepresentative1.ContratoAcreditacionRlNombreId },
            { "PROVEEDOR-REPRESENTANTE-CI-2", (c) => c.LegalRepresentative2.ContratoAcreditacionRlNombreId },
            { "PROVEEDOR-REPRESENTANTE-DNI-1", (c) => c.LegalRepresentative1.ContratoAcreditacionRlNombreId },
            { "PROVEEDOR-REPRESENTANTE-DNI-2", (c) => c.LegalRepresentative2.ContratoAcreditacionRlNombreId },
            { "PROVEEDOR-TESTIGO-1", (c) => c.Witness1.ContratoAcreditacionRlTestigoNombre },
            { "PROVEEDOR-TESTIGO-2", (c) => c.Witness2.ContratoAcreditacionRlTestigoNombre },
            { "PROVINCIA", (c) => c.PaisZona.ZonaNombre }, // ? No antigo essa tag está flagada para duas props
            { "REPRESENTANTE-AMBEV-1", (c) => c.AmbevLegalRepresentative1.UsrNombre },
            { "REPRESENTANTE-AMBEV-2", (c) => c.AmbevLegalRepresentative2.UsrNombre },
            { "REPRESENTANTE-CI-AMBEV-1", (c) => c.AmbevLegalRepresentative1.UsrIdfiscal },
            { "REPRESENTANTE-CI-AMBEV-2", (c) => c.AmbevLegalRepresentative2.UsrIdfiscal },
            { "REPRESENTANTE-DNI-AMBEV-1", (c) => c.AmbevLegalRepresentative1.UsrIdfiscal },
            { "REPRESENTANTE-DNI-AMBEV-2", (c) => c.AmbevLegalRepresentative2.UsrIdfiscal },
            { "RINDE", (c) => c.RendimientoKgHaVal.ToString() },
            { "SUMA-EN-LETRAS", (c) => c.TotalContrato.ToString() }, // NumberToWords
            { "SUMA-EN-NUMEROS", (c) => c.TotalContrato.ToString() },
            { "TABELA-PRODUTOS", (c) => c.Name }, // Precisar criar o método de mapear e preencher a tabela
            { "TARIFA-FLETE", (c) => c.TarifaFlete.ContratoTarifafleteVal.ToString() },
            { "UF", (c) => c.Proveedor.PaisProvincia.ProvinciaNombre },
        };

        public string Replace(string file, ContractDTO contract)
        {
            var keywords = new Dictionary<string, object>();

            foreach (var item in FunctionKeywords)
                keywords.Add(item.Key, item.Value.Invoke(contract));

            var stubble = new StubbleBuilder().Configure(
                settings => {
                settings.SetIgnoreCaseOnKeyLookup(true);
                settings.SetMaxRecursionDepth(8);
                settings.SetDefaultTags(new Tags("##", "##"));
            }).Build();

            return stubble.Render(file, keywords);
        }
    }
}
