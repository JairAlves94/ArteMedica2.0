﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArteMedica2._0.Models;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Xml.Linq;
using System.IO;
using RestSharp;
using Nancy.Json;

namespace ArteMedica2._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            SendNota();
            //SendNotaXML();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult PostSendNota(NotaFiscalServico notaFiscalServico)
        {
            SendNota(notaFiscalServico);
            return View();
        }

        private void SendNotaXML()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://webservice.giap.com.br/WSNfsesEmbu/nfseresources/ws/consulta");
            byte[] bytes;
            bytes = Encoding.ASCII.GetBytes("C:/Users/Bluecore/Desktop");
            //request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
            }
        }

        [HttpPost]
        public void SendNota( [FromBody]NotaFiscalServico notaFiscalServico = null)
        {
            try
            {
                var parameters = new NotaFiscalServico()
                {
                    idIntegracao = "XXXYY988",
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

                var jsonString = "[\n  {\n    \"idIntegracao\": \"" + parameters.idIntegracao + "\",\n    \"prestador\": {\n      \"cpfCnpj\": \"" + parameters.Prestador.CPFCNPJ + "\"\n    },\n    \"tomador\": {\n      \"cpfCnpj\": \"" + parameters.Tomador.CPFCNPJ + "\",\n      \"razaoSocial\": \"" + parameters.Tomador.RazaoSocial + "\",\n      \"inscricaoMunicipal\": \"" + parameters.Tomador.InscricaoMunicipal + "\",\n      \"email\": \"" + parameters.Tomador.Email + "\",\n      \"endereco\": {\n        \"descricaoCidade\": \"" + parameters.Tomador.Endereco.descricaoCidade + "\",\n        \"cep\": \"" + parameters.Tomador.Endereco.cep + "\",\n        \"tipoLogradouro\": \"" + parameters.Tomador.Endereco.tipoLogradouro + "\",\n        \"logradouro\": \"" + parameters.Tomador.Endereco.logradouro + "\",\n        \"tipoBairro\": \"" + parameters.Tomador.Endereco.tipoBairro + "\",\n        \"codigoCidade\": \"" + parameters.Tomador.Endereco.codigoCidade + "\",\n        \"complemento\": \"" + parameters.Tomador.Endereco.complemento + "\",\n        \"estado\": \"" + parameters.Tomador.Endereco.estado + "\",\n        \"numero\": \"" + parameters.Tomador.Endereco.numero + "\",\n        \"bairro\": \"" + parameters.Tomador.Endereco.bairro + "\"\n      }\n    },\n    \"servico\": [\n      {\n        \"codigo\": \"" + parameters.Servico[0].Codigo + "\",\n        \"codigoTributacao\": \"" + parameters.Servico[0].CodigoTributacao + "\",\n        \"discriminacao\": \"" + parameters.Servico[0].Discriminacao + ".\",\n        \"cnae\": \"" + parameters.Servico[0].CNAE + "\",\n        \"iss\": {\n          \"tipoTributacao\": " + parameters.Servico[0].ISS.tipoTributacao + ",\n          \"exigibilidade\": " + parameters.Servico[0].ISS.exigibilidade + ",\n          \"aliquota\": " + parameters.Servico[0].ISS.aliquota + "\n        },\n        \"valor\": {\n          \"servico\": " + parameters.Servico[0].Valor.servico + ",\n          \"descontoCondicionado\": " + parameters.Servico[0].Valor.descontoCondicionado + ",\n          \"descontoIncondicionado\": " + parameters.Servico[0].Valor.descontoIncondicionado + "\n        }\n      }\n    ]\n  }\n]";

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
