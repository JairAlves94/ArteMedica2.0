using System;
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

        private void SendNota(NotaFiscalServico notaFiscalServico = null)
        {
            try
            {
                NotaFiscalServico parameters = new NotaFiscalServico()
                {
                    Prestador = new NFS_Prestador()
                    {
                        cpfCnpj = "14237547000110",
                        Inscricao_municipal = "44575",
                        Codigo_municipio = "3515004"
                    },
                    Tomador = new NFS_Tomador()
                    {
                        cpfCnpj = "07504505000132",
                        razaoSocial = "Acras Tecnologia da Informação LTDA",
                        email = "contato@acras.com.br",
                        Endereco = new Endereco()
                        {
                            descricaoCidade = "Maringa",
                            cep = "80045165",
                            tipoLogradouro = "Rua",
                            logradouro = "Rua Dias da Rocha Filho",
                            tipoBairro = "Centro",
                            codigoCidade = "4115200",
                            complemento = "Prédio 04 - Sala 34C",
                            estado = "PR",
                            numero = "999",
                            bairro = "Alto da XV",
                        }
                    },
                    Servico = new NFS_Servico()
                    {
                        codigo = "14.10",
                        codigoTributacao = "14.10",
                        discriminacao = "Descrição dos serviços prestados, utilize | para quebra de linha na impressão.",
                        cnae = "7490104",
                        codigoCidadeIncidencia = "4115200",
                        descricaoCidadeIncidencia = "MARINGA",
                        iss = new NFS_ISS() 
                        {
                            tipoTributacao = 7,
                            exigibilidade = 1,
                            retido = false,
                            aliquota = 3,
                            aliquotaRetido = 0
                        },
                        deducao = new NFS_Deducao() 
                        {
                            tipo = 0,
                            descricao = "Sem Deduções"
                        },
                        valor = new NFS_Valor() 
                        {
                            servico = 1,
                            deducoes = 0,
                            descontoCondicionado = 0,
                            descontoIncondicionado = 0
                        }
                    }
                };

                var json = new JavaScriptSerializer().Serialize(parameters);

                var client = new RestClient("https://api.sandbox.plugnotas.com.br/nfse");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("accept", "application/json");
                request.AddHeader("x-api-key", "2da392a6-79d2-4304-a8b7-959572c7e44d");
                request.AddHeader("Content-Type", "application/json");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(json);
                IRestResponse response = client.Execute(request);


                //if (result.StatusCode != HttpStatusCode.OK || result.Content.Headers.ContentType.MediaType != "application/pdf")
                //{
                //    throw new Exception($"Não foi possível gerar o boleto."); //colocar mais informações sobre o erro
                //}

                //pdfBytes = result.Content.ReadAsByteArrayAsync().Result;

                //if (pdfBytes == null || pdfBytes.Length == 0)
                //{
                //    throw new Exception($"PDF do boleto gerado vazio. Referência: {ticketCartDetailsView.LastTicketReferenceCodeGeneratedString}");
                //}


            }
            catch (Exception)
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
