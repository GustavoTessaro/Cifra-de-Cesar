using System.Text;
using CifraDeCesar.Core.Arquivos;

namespace CifraDeCesar.Tests.Arquivos;

[TestClass]
public sealed class ArquivoServiceTests
{
    private string diretorioTemporario = string.Empty;

    [TestInitialize]
    public void Inicializar()
    {
        diretorioTemporario = Path.Combine(Path.GetTempPath(), "CifraDeCesarTests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(diretorioTemporario);
    }

    [TestCleanup]
    public void Limpar()
    {
        if (Directory.Exists(diretorioTemporario))
        {
            Directory.Delete(diretorioTemporario, recursive: true);
        }
    }

    [TestMethod]
    public void CriptografarArquivo_DeveCriarArquivoComConteudoCifradoEmUtf8()
    {
        string caminhoEntrada = CriarArquivo("mensagem.txt", "Olá, Mundo!\nABC xyz 123");

        string caminhoSaida = ArquivoService.CriptografarArquivo(caminhoEntrada, 3);

        Assert.IsTrue(File.Exists(caminhoSaida));
        Assert.AreEqual(
            "Roá, Pxqgr!\nDEF abc 123",
            File.ReadAllText(caminhoSaida, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false)));
        Assert.AreEqual("mensagem_cript.txt", Path.GetFileName(caminhoSaida));
    }

    [TestMethod]
    public void CriptografarArquivo_DevePreservarExtensaoENomeComMultiplosPontos()
    {
        string caminhoEntrada = CriarArquivo("arquivo.exemplo.txt", "ABC");

        string caminhoSaida = ArquivoService.CriptografarArquivo(caminhoEntrada, 1);

        Assert.AreEqual("arquivo.exemplo_cript.txt", Path.GetFileName(caminhoSaida));
        Assert.AreEqual("BCD", File.ReadAllText(caminhoSaida));
    }

    [TestMethod]
    public void DescriptografarArquivo_DeveCriarArquivoComSufixoDescript()
    {
        string caminhoEntrada = CriarArquivo("mensagem_cript.txt", "DEF, Roá!");

        string caminhoSaida = ArquivoService.DescriptografarArquivo(caminhoEntrada, 3);

        Assert.IsTrue(File.Exists(caminhoSaida));
        Assert.AreEqual("mensagem_cript_descript.txt", Path.GetFileName(caminhoSaida));
        Assert.AreEqual("ABC, Olá!", File.ReadAllText(caminhoSaida));
    }

    [TestMethod]
    public void CriptografarEDescriptografarArquivo_DeveRecuperarConteudoOriginal()
    {
        const string conteudoOriginal = "Olá, Mundo!\r\nABC xyz\r\nçãé 123";
        string caminhoEntrada = CriarArquivo("original.txt", conteudoOriginal);

        string caminhoCriptografado = ArquivoService.CriptografarArquivo(caminhoEntrada, 17);
        string caminhoDescriptografado = ArquivoService.DescriptografarArquivo(caminhoCriptografado, 17);

        Assert.AreEqual(conteudoOriginal, File.ReadAllText(caminhoDescriptografado));
    }

    [TestMethod]
    public void CriptografarArquivo_ComChaveZero_DevePreservarConteudo()
    {
        string caminhoEntrada = CriarArquivo("zero.txt", "Olá, ABC 123");

        string caminhoSaida = ArquivoService.CriptografarArquivo(caminhoEntrada, 0);

        Assert.AreEqual(File.ReadAllText(caminhoEntrada), File.ReadAllText(caminhoSaida));
    }

    [TestMethod]
    public void CriptografarArquivo_ComChaveNegativa_DeveAplicarDeslocamento()
    {
        string caminhoEntrada = CriarArquivo("negativo.txt", "ABC xyz");

        string caminhoSaida = ArquivoService.CriptografarArquivo(caminhoEntrada, -3);

        Assert.AreEqual("XYZ uvw", File.ReadAllText(caminhoSaida));
    }

    [TestMethod]
    public void CriptografarArquivo_ComArquivoVazio_DeveCriarSaidaVazia()
    {
        string caminhoEntrada = CriarArquivo("vazio.txt", string.Empty);

        string caminhoSaida = ArquivoService.CriptografarArquivo(caminhoEntrada, 3);

        Assert.IsTrue(File.Exists(caminhoSaida));
        Assert.AreEqual(string.Empty, File.ReadAllText(caminhoSaida));
    }

    [TestMethod]
    public void CriptografarArquivo_ComArquivoInexistente_DeveLancarFileNotFoundException()
    {
        string caminhoEntrada = Path.Combine(diretorioTemporario, "inexistente.txt");

        Assert.Throws<FileNotFoundException>(
            () => ArquivoService.CriptografarArquivo(caminhoEntrada, 3));
    }

    [TestMethod]
    public void CriptografarArquivo_ComCaminhoVazio_DeveLancarArgumentException()
    {
        Assert.Throws<ArgumentException>(
            () => ArquivoService.CriptografarArquivo(string.Empty, 3));
    }

    [TestMethod]
    public void CriptografarArquivo_ComCaminhoComEspacos_DeveLancarArgumentException()
    {
        Assert.Throws<ArgumentException>(
            () => ArquivoService.CriptografarArquivo("   ", 3));
    }

    [TestMethod]
    public void CriptografarArquivo_ComCaminhoNulo_DeveLancarArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => ArquivoService.CriptografarArquivo(null!, 3));
    }

    private string CriarArquivo(string nome, string conteudo)
    {
        string caminho = Path.Combine(diretorioTemporario, nome);
        File.WriteAllText(caminho, conteudo, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        return caminho;
    }
}