using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Agenda.IO.Model
{
    public class AtividadesModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public TipoListaStatus? Status { get; set; }
    }

    [XmlType("AtividadesModel")]
    public class AtividadesApiModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Status { get; set; }
    }

    public class AtividadeUpload
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public TipoListaStatus? Status { get; set; }
    }
}
