namespace SistemaAcademia
{
    internal interface IBancoUser
    {
        Usuario BuscarUsuario(string nomedeusuario);
        Usuario CriarUsuario(Usuario user);
        Usuario AlterarUsuario(Usuario u);
        Usuario DeletarUsuario(string id);
    }
}