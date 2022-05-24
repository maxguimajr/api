using System.ComponentModel.DataAnnotations;

namespace CrudImpacta.Entidades
{
    public class CentroCusto
    {
        public CentroCusto(int codigo, string nome, DateTime dataInicio, DateTime dataFim)
        {
            Codigo = codigo;
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
           
        }
            
        [Key]
        
        public int Codigo { get; set; }
        
        public string Nome { get; set; }

        [Display(Name = "Data de Inicio")]
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
         public DateTime? DataInicio { get; set; }

        [Display(Name = "Data de Fim")]
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
         public DateTime? DataFim { get; set;}
    
    
    }
}