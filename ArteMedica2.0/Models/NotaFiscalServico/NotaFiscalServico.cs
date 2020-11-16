using System;
using System.Collections.Generic;

namespace ArteMedica2._0.Models
{
    public class NotaFiscalServico
    {
        public string idIntegracao { get; set; }

        public NFS_Prestador Prestador{ get; set; }

        public NFS_Tomador Tomador{ get; set; }

        public List<NFS_Servico> Servico { get; set; }

        public NotaFiscalServico()
        {
            idIntegracao = "";
            Prestador = new NFS_Prestador();
            Tomador = new NFS_Tomador();
            Servico = new List<NFS_Servico>();
        }
    }
}
