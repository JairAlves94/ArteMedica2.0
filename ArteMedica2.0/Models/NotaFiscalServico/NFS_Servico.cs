using System;

namespace ArteMedica2._0.Models
{
    public class NFS_Servico
    {
        public string Codigo { get; set; }

        public string CodigoTributacao { get; set; }

        public string Discriminacao { get; set; }

        public string CNAE { get; set; }

        public NFS_ISS ISS { get; set; }

        public NFS_Valor Valor { get; set; }

        public NFS_Servico()
        {
            Codigo = "";
            CodigoTributacao = "";
            Discriminacao = "";
            CNAE = "";
            ISS = new NFS_ISS();
            Valor = new NFS_Valor();
        }
    }
}
