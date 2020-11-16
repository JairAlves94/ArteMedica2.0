﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArteMedica2._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace ArteMedica2._0.Controllers
{
    [Produces("application/json")]
    [Route("api/NF/[action]")]
    [ApiController]
    public class NFController : ControllerBase
    {
        [HttpPost]
        public void SendNota([FromBody] NotaFiscalServico notaFiscalServico = null)
        {
            try
            {
                var parameters = new NotaFiscalServico()
                {
                    idIntegracao = "XXXYY899",
                    Prestador = new NFS_Prestador()
                    {
                        CPFCNPJ = "08187168000160",

                    },
                    Tomador = new NFS_Tomador()
                    {
                        CPFCNPJ = "99999999999999",
                        RazaoSocial = "Empresa de Teste LTDA",
                        InscricaoMunicipal = "8214100099",
                        Email = "teste@plugnotas.com.br",
                        Endereco = new Endereco()
                        {
                            descricaoCidade = "Maringa",
                            cep = "87020100",
                            tipoLogradouro = "Rua",
                            logradouro = "Barao do rio branco",
                            tipoBairro = "Centro",
                            codigoCidade = "4115200",
                            complemento = "sala 01",
                            estado = "PR",
                            numero = "1001",
                            bairro = "Centro",
                        }
                    },
                    Servico = new List<NFS_Servico>()
                };

                parameters.Servico.Add(new NFS_Servico()
                {
                    Codigo = "14.10",
                    CodigoTributacao = "14.10",
                    Discriminacao = "Descrição dos serviços prestados, utilize | para quebra de linha na impressão.",
                    CNAE = "7490104",
                    CodigoCidadeIncidencia = "4115200",
                    DescricaoCidadeIncidencia = "MARINGA",
                    ISS = new NFS_ISS()
                    {
                        tipoTributacao = 7,
                        exigibilidade = 1,
                        aliquota = 3,
                    },
                    Valor = new NFS_Valor()
                    {
                        servico = 1,
                        descontoCondicionado = 0,
                        descontoIncondicionado = 0
                    }
                });

                var jsonString = "[\n    {\n        \"prestador\": {\n            \"cpfCnpj\": \"" + parameters.Prestador.CPFCNPJ + "\",\n            \"razaoSocial\": \"" + parameters.Prestador.RazaoSocial + "\",\n            \"nomeFantasia\": \"" + parameters.Prestador.NomeFantasia + "\",\n            \"inscricaoMunicipal\": \"" + parameters.Prestador.Inscricao_municipal + "\",\n            \"inscricaoEstadual\": \"" + parameters.Prestador.Inscricao_municipal + "\",\n            \"simplesNacional\": " + parameters.Prestador.SimplesNacional + ",\n            \"incentivoFiscal\": " + parameters.Prestador.IncentivoFiscal + ",\n            \"incentivadorCultural\": " + parameters.Prestador.IncentivadorCultural + ",\n            \"regimeTributario\": " + parameters.Prestador.RegimeTributario + ",\n            \"regimeTributarioEspecial\": " + parameters.Prestador.RegimeTributarioEspecial + ",\n            \"email\": \"" + parameters.Prestador.Email + "\",\n            \"endereco\": {\n                \"descricaoCidade\": \"" + parameters.Prestador.Endereco.descricaoCidade + "\",\n                \"cep\": \"" + parameters.Prestador.Endereco.cep + "\",\n                \"tipoLogradouro\": \"" + parameters.Prestador.Endereco.tipoLogradouro + "\",\n                \"logradouro\": \"" + parameters.Prestador.Endereco.logradouro + "\",\n                \"tipoBairro\": \"" + parameters.Prestador.Endereco.tipoBairro + "\",\n                \"codigoCidade\": \"" + parameters.Prestador.Endereco.codigoCidade + "\",\n                \"complemento\": \"" + parameters.Prestador.Endereco.complemento + "\",\n                \"estado\": \"" + parameters.Prestador.Endereco.estado + "\",\n                \"numero\": \"" + parameters.Prestador.Endereco.numero + "\",\n                \"bairro\": \"" + parameters.Prestador.Endereco.bairro + "\"\n            },\n            \"telefone\": {\n                \"ddd\": \"" + parameters.Prestador.DDD + "\",\n                \"numero\": \"" + parameters.Prestador.Telefone + "\"\n            }\n        },\n        \"tomador\": {\n            \"cpfCnpj\": \"" + parameters.Tomador.CPFCNPJ + "\",\n            \"razaoSocial\": \"" + parameters.Tomador.RazaoSocial + "\",\n            \"nomeFantasia\": \"" + parameters.Tomador.NomeFantasia + "\",\n            \"inscricaoMunicipal\": \"" + parameters.Tomador.InscricaoMunicipal + "\",\n            \"inscricaoEstadual\": \"" + parameters.Tomador.InscricaoEstadual + "\",\n            \"email\": \"" + parameters.Tomador.Email + "\",\n            \"endereco\": {\n                \"descricaoCidade\": \"" + parameters.Tomador.Endereco.descricaoCidade + "\",\n                \"cep\": \"" + parameters.Tomador.Endereco.cep + "\",\n                \"tipoLogradouro\": \"" + parameters.Tomador.Endereco.tipoLogradouro + "\",\n                \"logradouro\": \"" + parameters.Tomador.Endereco.logradouro + "\",\n                \"tipoBairro\": \"" + parameters.Tomador.Endereco.tipoBairro + "\",\n                \"codigoCidade\": \"" + parameters.Tomador.Endereco.codigoCidade + "\",\n                \"complemento\": \"" + parameters.Tomador.Endereco.complemento + "\",\n                \"estado\": \"" + parameters.Tomador.Endereco.estado + "\",\n                \"numero\": \"" + parameters.Tomador.Endereco.numero + "\",\n                \"bairro\": \"" + parameters.Tomador.Endereco.bairro + "\"\n            },\n            \"telefone\": {\n                \"ddd\": \"" + parameters.Tomador.DDD + "\",\n                \"numero\": \"" + parameters.Tomador.Telefone + "\"\n            }\n        },\n        \"servico\": {\n\t\t\"codigo\": \"" + parameters.Servico[0].Codigo + "\",\n\t\t\"descricaoLC116\": \"" + parameters.Servico[0].DescricaoLC116 + "\",\n\t\t\"discriminacao\": \"" + parameters.Servico[0].Discriminacao + "\",\n\t\t\"cnae\": \"" + parameters.Servico[0].CNAE + "\",\n\t\t\"codigoTributacao\": \"" + parameters.Servico[0].CodigoTributacao + "\",\n\t\t\"codigoCidadeIncidencia\": \"" + parameters.Servico[0].CodigoCidadeIncidencia + "\",\n\t\t\"descricaoCidadeIncidencia\": \"" + parameters.Servico[0].DescricaoCidadeIncidencia + "\",\n\t\t\"iss\": {\n\t\t\t\"exigibilidade\": " + parameters.Servico[0].ISS.exigibilidade + ",\n\t\t\t\"retido\": " + parameters.Servico[0].ISS.retido + ",\n\t\t\t\"aliquota\": " + parameters.Servico[0].ISS.aliquota + ",\n\t\t\t\"aliquotaRetido\": " + parameters.Servico[0].ISS.aliquotaRetido + ",\n\t\t\t\"tipoTributacao\": " + parameters.Servico[0].ISS.tipoTributacao + "\n\t\t},\n\t\t\"retencao\": {\n\t\t\t\"pis\": {\n\t\t\t\t\"aliquota\": 0.65\n\t\t\t},\n\t\t\t\"cofins\": {\n\t\t\t\t\"aliquota\": 3\n\t\t\t},\n\t\t\t\"csll\": {\n\t\t\t\t\"aliquota\": 0\n\t\t\t}\n\t\t},\n\t\t\"valor\": {\n\t\t\t\"deducoes\": 0,\n\t\t\t\"baseCalculo\": 0.1,\n\t\t\t\"servico\": 45,\n\t\t\t\"descontoIncondicionado\": 0,\n\t\t\t\"descontoCondicionado\": 0,\n\t\t\t\"liquido\": 0.1\n\t\t}\n\t},\n        \"impressao\": {\n        \t\"camposCustomizados\": {\n        \t\t\"a\": \"1\",\n        \t\t\"b\": \"1|2\",\n        \t\t\"c\": \"1|2|3\",\n        \t\t\"d\": \"\"\n        \t}\n        },\n    \t\"enviarEmail\": true\n    }\n]";

                var client = new RestClient("https://api.sandbox.plugnotas.com.br/nfse");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("x-api-key", "2da392a6-79d2-4304-a8b7-959572c7e44d");
                request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

            }
            catch (Exception e)
            {

            }
        }

    }
}
