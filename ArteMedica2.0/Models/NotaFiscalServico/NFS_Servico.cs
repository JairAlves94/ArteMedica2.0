using System;

namespace ArteMedica2._0.Models
{
    public class NFS_Servico
    {
        public string Codigo { get; set; }

        public string CodigoTributacao { get; set; }

        public string Discriminacao { get; set; }

        public string CNAE { get; set; }

        public string CodigoCidadeIncidencia { get; set; }

        public string DescricaoCidadeIncidencia { get; set; }

        public string DescricaoLC116 { get; set; }

        public NFS_ISS ISS { get; set; }

        public NFS_Deducao Deducao { get; set; }

        public NFS_Retencao Retencao { get; set; }

        public NFS_Valor Valor { get; set; }

        public NFS_Servico()
        {
            Codigo = "";
            CodigoTributacao = "";
            Discriminacao = "";
            CNAE = "";
            CodigoCidadeIncidencia = "";
            DescricaoCidadeIncidencia = "";
            DescricaoLC116 = "";
            ISS = new NFS_ISS();
            Deducao = new NFS_Deducao();
            Retencao = new NFS_Retencao();
            Valor = new NFS_Valor();
        }
    }
}
