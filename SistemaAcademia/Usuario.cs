using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademia
{
    public enum status // Aqui ficará os status
    {
        ativo = 1,
        
    }

    public class Usuario
    {
        public Int32 id;
        public string nome;
        public string username;
        public string senha;
        public string status; // depois 
        // public status status { get; set; } 
        public Int32 nivel;

    }
}
