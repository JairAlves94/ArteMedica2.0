using System;

namespace ArteMedica2._0.Models
{
    public class NFS_Tomador
    {
        public string CPFCNPJ { get; set; }

        public string RazaoSocial { get; set; }

        public string InscricaoMunicipal { get; set; }

        public string Email { get; set; }

        public Endereco Endereco { get; set; }

        public NFS_Tomador()
        {
            CPFCNPJ = "";
            RazaoSocial = "";
            InscricaoMunicipal = "";
            Email = "";
            Endereco = new Endereco();
        }
    }
}
