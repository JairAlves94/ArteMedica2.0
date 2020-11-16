using System;

namespace ArteMedica2._0.Models
{
    public class NFS_Tomador
    {
        public string CPFCNPJ { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string InscricaoMunicipal { get; set; }

        public string InscricaoEstadual { get; set; }

        public string Email { get; set; }

        public Endereco Endereco { get; set; }

        public string DDD { get; set; }

        public string Telefone { get; set; }

        public NFS_Tomador()
        {
            CPFCNPJ = "";
            RazaoSocial = "";
            NomeFantasia = "";
            InscricaoMunicipal = "";
            InscricaoEstadual = "";
            Email = "";
            Endereco = new Endereco();
            DDD = "";
            Telefone = "";
        }
    }
}
