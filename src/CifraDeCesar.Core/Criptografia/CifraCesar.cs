using System.Text;

namespace CifraDeCesar.Core.Criptografia;

public static class CifraCesar
{
    private const int TamanhoAlfabeto = 26;

    public static string Criptografar(string texto, int chave)
    {
        return Transformar(texto, chave, false);
    }

    public static string Descriptografar(string texto, int chave)
    {
        return Transformar(texto, chave, true);
    }

    private static string Transformar(string texto, int chave, bool descriptografar)
    {
        ArgumentNullException.ThrowIfNull(texto);

        // O resto mantém a chave dentro das 26 posições, inclusive para valores negativos.
        int deslocamento = chave % TamanhoAlfabeto;
        if (deslocamento < 0)
        {
            deslocamento += TamanhoAlfabeto;
        }

        if (descriptografar)
        {
            deslocamento = (TamanhoAlfabeto - deslocamento) % TamanhoAlfabeto;
        }

        var resultado = new StringBuilder(texto.Length);
        foreach (char caractere in texto)
        {
            if (caractere is >= 'A' and <= 'Z')
            {
                resultado.Append((char)('A' + (caractere - 'A' + deslocamento) % TamanhoAlfabeto));
            }
            else if (caractere is >= 'a' and <= 'z')
            {
                resultado.Append((char)('a' + (caractere - 'a' + deslocamento) % TamanhoAlfabeto));
            }
            else
            {
                resultado.Append(caractere);
            }
        }

        return resultado.ToString();
    }
}