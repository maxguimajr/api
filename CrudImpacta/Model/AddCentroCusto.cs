using System.ComponentModel.DataAnnotations;

namespace CrudImpacta.Model
{
    public class AddCentroCusto
    {
        
         public int Codigo { get; set; }
        public string Nome { get; set; }   
        public DateTime DataInicio {get; set;}
        [Display(Name = "Data de Fim")]
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
        public DateTime DataFim { get; set; }
    }
}