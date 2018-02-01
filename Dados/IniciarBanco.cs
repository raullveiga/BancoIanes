using System.Linq;

namespace Ianes.Dados
{
    public class IniciarBanco
    {
        public static void Inicializar(IanesContexto contexto){
            contexto.Database.EnsureCreated();

            if(contexto.Areas.Any())
                return;

            
        }
    }
}