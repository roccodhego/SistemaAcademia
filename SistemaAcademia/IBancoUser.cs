namespace SistemaAcademia
{
    internal interface IBancoUser
    {
        Usuario BuscarUsuario(string nomedeusuario);
        Usuario CriarUsuario(Usuario user);
    }
}