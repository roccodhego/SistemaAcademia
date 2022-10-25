using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademia
{
    internal interface IBancoProfessor
    {
        Professor CriarProfessor(Professor user);
        Professor BuscarProfessor(string nomedeprofessor);
        Professor AlterarProfessor(Professor p);
        Professor ExcluirProfessor(string id);
    }
}
