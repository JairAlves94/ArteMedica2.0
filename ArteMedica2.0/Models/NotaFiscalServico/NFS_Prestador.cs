using System;

namespace ArteMedica2._0.Models
{
    public class NFS_Prestador
    {
        public string CPFCNPJ { get; set; }

        public string RazaoSocial{ get; set; }

        public string NomeFantasia { get; set; }

        public string Inscricao_municipal { get; set; }

        public string Codigo_municipio { get; set; }

        public bool SimplesNacional { get; set; }

        public bool IncentivoFiscal { get; set; }

        public bool IncentivadorCultural { get; set; }

        public double RegimeTributario { get; set; }

        public double RegimeTributarioEspecial { get; set; }

        public string Email { get; set; }

        public Endereco Endereco{ get; set; }

        public string DDD { get; set; }

        public string Telefone { get; set; }

        public NFS_Prestador()
        {
            CPFCNPJ = "";
            RazaoSocial = "";
            NomeFantasia = "";
            Inscricao_municipal = "";
            Codigo_municipio = "";
            SimplesNacional = true;
            IncentivoFiscal = false;
            IncentivadorCultural = false;
            RegimeTributario = 0;
            RegimeTributarioEspecial = 0;
            Email = "";
            Endereco = new Endereco();
            DDD = "";
            Telefone = "";
        }
    }
}
