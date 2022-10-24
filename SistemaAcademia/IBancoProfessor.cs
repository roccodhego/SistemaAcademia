using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademia
{
    internal interface IBancoProfessor
    {
        Professor BuscarProfessor(string nomeprofessor);
        Professor CriarProfessor(Professor user);
        Professor AlterarUsuario(Professor p);
        Professor DeletarUsuario(string id);
    }

}
