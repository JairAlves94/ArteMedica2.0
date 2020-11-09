using System;

namespace ArteMedica2._0.Models
{
    public class NotaFiscalServico
    {
        public string idIntegracao { get; set; }

        public NFS_Prestador Prestador{ get; set; }

        public NFS_Tomador Tomador{ get; set; }

        public NFS_Servico Servico { get; set; }
    }
}
