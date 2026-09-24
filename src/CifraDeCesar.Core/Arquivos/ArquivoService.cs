using System.Text;
using CifraDeCesar.Core.Criptografia;

namespace CifraDeCesar.Core.Arquivos;

public static class ArquivoService
{
    private static readonly Encoding Utf8SemBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

    public static string CriptografarArquivo(string caminhoEntrada, int chave)
    {
        ValidarArquivoExistente(caminhoEntrada);

        string conteudo = File.ReadAllText(caminhoEntrada, Utf8SemBom);
        string caminhoSaida = CalcularCaminhoCriptografado(caminhoEntrada);

        File.WriteAllText(caminhoSaida, CifraCesar.Criptografar(conteudo, chave), Utf8SemBom);

        return caminhoSaida;
    }

    public static string DescriptografarArquivo(string caminhoEntrada, int chave)
    {
        ValidarArquivoExistente(caminhoEntrada);

        string conteudo = File.ReadAllText(caminhoEntrada, Utf8SemBom);
        string caminhoSaida = CalcularCaminhoDescriptografado(caminhoEntrada);

        File.WriteAllText(caminhoSaida, CifraCesar.Descriptografar(conteudo, chave), Utf8SemBom);

        return caminhoSaida;
    }

    public static string CalcularCaminhoCriptografado(string caminhoEntrada)
    {
        return CalcularCaminhoComSufixo(caminhoEntrada, "_cript");
    }

    public static string CalcularCaminhoDescriptografado(string caminhoEntrada)
    {
        return CalcularCaminhoComSufixo(caminhoEntrada, "_descript");
    }

    private static string CalcularCaminhoComSufixo(string caminhoEntrada, string sufixo)
    {
        ValidarCaminho(caminhoEntrada);

        string diretorio = Path.GetDirectoryName(caminhoEntrada) ?? string.Empty;
        string nomeBase = Path.GetFileNameWithoutExtension(caminhoEntrada);
        string extensao = Path.GetExtension(caminhoEntrada);

        // O sufixo entra antes da extensão e preserva o diretório e o nome-base.
        return Path.Combine(diretorio, nomeBase + sufixo + extensao);
    }

    private static void ValidarArquivoExistente(string caminhoEntrada)
    {
        ValidarCaminho(caminhoEntrada);

        if (!File.Exists(caminhoEntrada))
        {
            throw new FileNotFoundException("O arquivo de entrada não foi encontrado.", caminhoEntrada);
        }
    }

    private static void ValidarCaminho(string caminhoEntrada)
    {
        ArgumentNullException.ThrowIfNull(caminhoEntrada);

        if (string.IsNullOrWhiteSpace(caminhoEntrada))
        {
            throw new ArgumentException("O caminho do arquivo não pode ser vazio.", nameof(caminhoEntrada));
        }
    }
}