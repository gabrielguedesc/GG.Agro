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
            { "AMBEV-CI-TESTIGO-1", (c) => c.Name },
            { "AMBEV-CI-TESTIGO-2", (c) => c.Name },
            { "AMBEV-TESTIGO-1", (c) => c.Name },
            { "AMBEV-TESTIGO-2", (c) => c.Name },
            { "CANTIDAD", (c) => c.Name },
            { "CARGO-AMBEV-1", (c) => c.Name },
            { "CARGO-AMBEV-2", (c) => c.Name },
            { "CARGO-PROVEEDOR-1", (c) => c.Name },
            { "CARGO-PROVEEDOR-2", (c) => c.Name },
            { "DIA", (c) => c.Name },
            { "ENVASE", (c) => c.Name },
            { "FIRMA-AMBEV-TESTIGO-1", (c) => c.Name },
            { "FIRMA-AMBEV-TESTIGO-2", (c) => c.Name },
            { "FIRMA-PROVEEDOR-1", (c) => c.Name },
            { "FIRMA-PROVEEDOR-2", (c) => c.Name },
            { "FIRMA-PROVEEDOR-TESTIGO-1", (c) => c.Name },
            { "FIRMA-PROVEEDOR-TESTIGO-2", (c) => c.Name },
            { "FIRMA-REPRESENTANTE-AMBEV-1", (c) => c.Name },
            { "FIRMA-REPRESENTANTE-AMBEV-2", (c) => c.Name },
            { "INSUMO", (c) => c.Name },
            { "LOCALIDAD", (c) => c.Name },
            { "MES", (c) => c.Name },
            { "PRECIO", (c) => c.Name },
            { "PROVEEDOR-CI-TESTIGO-1", (c) => c.Name },
            { "PROVEEDOR-CI-TESTIGO-2", (c) => c.Name },
            { "PROVEEDOR-DEPOSITO", (c) => c.Name },
            { "PROVEEDOR-DOC", (c) => c.Name },
            { "PROVEEDOR-FERTI", (c) => c.Name },
            { "PROVEEDOR-NOMBRE", (c) => c.Name },
            { "PROVEEDOR-REPRESENTANTE-1", (c) => c.Name },
            { "PROVEEDOR-REPRESENTANTE-2", (c) => c.Name },
            { "PROVEEDOR-REPRESENTANTE-CI-1", (c) => c.Name },
            { "PROVEEDOR-REPRESENTANTE-CI-2", (c) => c.Name },
            { "PROVEEDOR-TESTIGO-1", (c) => c.Name },
            { "PROVEEDOR-TESTIGO-2", (c) => c.Name },
            { "PROVINCIA", (c) => c.Name },
            { "REPRESENTANTE-AMBEV-1", (c) => c.Name },
            { "REPRESENTANTE-AMBEV-2", (c) => c.Name },
            { "REPRESENTANTE-CI-AMBEV-1", (c) => c.Name },
            { "REPRESENTANTE-CI-AMBEV-2", (c) => c.Name },
            { "SUMA-EN-LETRAS", (c) => c.Name },
            { "SUMA-EN-NUMEROS", (c) => c.Name },
            { "TABELA-PRODUTOS", (c) => c.Name },
            { "UNIDAD-DE-MEDIDA-DE-CANTIDAD", (c) => c.Name },
            { "UNIDAD-DE-MEDIDA-DE-PRECIO", (c) => c.Name },
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
