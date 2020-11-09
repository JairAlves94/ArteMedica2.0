using System;

namespace ArteMedica2._0.Models
{
    public class NFS_Tomador
    {
        public string cpfCnpj { get; set; }

        public string razaoSocial { get; set; }

        public string nomeFantasia { get; set; }

        public string inscricaoMunicipal { get; set; }
        
        public string email { get; set; }

        public Endereco Endereco { get; set; }

    }
}
