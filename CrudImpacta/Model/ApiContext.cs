
using CrudImpacta.Entidades;
using Microsoft.EntityFrameworkCore;


namespace CrudImpacta.Model
{
    public class ApiContext : DbContext
    {
        
         protected readonly IConfiguration Configuration;

        public ApiContext(IConfiguration configuration) 
        {
           Configuration =  configuration;
               
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            options.UseInMemoryDatabase("CentroCusto");
        }
        public DbSet<CentroCusto> CentroCusto {get ; set;}

    }
}