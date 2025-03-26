namespace Aiko_teste.Util
{
    public interface IUtil
    {
        Task<string> CriarArquivo(string conteudo, string nomeArquivo, int formatoArquivo);
    }
}
