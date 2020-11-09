using System;

namespace ArteMedica2._0.Models
{
    public class NFS_Servico
    {
        public string codigo { get; set; }

        public string codigoTributacao { get; set; }

        public string discriminacao { get; set; }

        public string cnae { get; set; }

        public string codigoCidadeIncidencia { get; set; }

        public string descricaoCidadeIncidencia { get; set; }

        public NFS_ISS iss { get; set; }

        public NFS_Deducao deducao { get; set; }

        public NFS_Retencao retencao { get; set; }

        public NFS_Valor valor { get; set; }

    }
}
