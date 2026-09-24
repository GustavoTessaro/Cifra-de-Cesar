using CifraDeCesar.Core.Criptografia;

namespace CifraDeCesar.Tests.Criptografia;

[TestClass]
public sealed class CifraCesarTests
{
    [TestMethod]
    public void Criptografar_DeveDeslocarLetrasMaiusculas()
    {
        Assert.AreEqual("DEF", CifraCesar.Criptografar("ABC", 3));
    }

    [TestMethod]
    public void Criptografar_DeveDeslocarLetrasMinusculas()
    {
        Assert.AreEqual("def", CifraCesar.Criptografar("abc", 3));
    }

    [TestMethod]
    public void Criptografar_DeveRetornarDeZParaA()
    {
        Assert.AreEqual("ABC", CifraCesar.Criptografar("XYZ", 3));
    }

    [TestMethod]
    public void Criptografar_DeveRetornarDezParaA()
    {
        Assert.AreEqual("abc", CifraCesar.Criptografar("xyz", 3));
    }

    [TestMethod]
    public void Descriptografar_DeveReverterTextoCifrado()
    {
        Assert.AreEqual("ABC xyz", CifraCesar.Descriptografar("DEF abc", 3));
    }

    [TestMethod]
    public void Criptografar_DevePreservarEspacos()
    {
        Assert.AreEqual("D E F", CifraCesar.Criptografar("A B C", 3));
    }

    [TestMethod]
    public void Criptografar_DevePreservarNumeros()
    {
        Assert.AreEqual("DEF 123", CifraCesar.Criptografar("ABC 123", 3));
    }

    [TestMethod]
    public void Criptografar_DevePreservarPontuacao()
    {
        Assert.AreEqual("DEF, ABC!", CifraCesar.Criptografar("ABC, XYZ!", 3));
    }

    [TestMethod]
    public void Criptografar_DevePreservarCaracteresAcentuadosEUnicode()
    {
        Assert.AreEqual("Roá, Pxqgr! çãé", CifraCesar.Criptografar("Olá, Mundo! çãé", 3));
    }

    [TestMethod]
    public void Criptografar_ComChaveZero_DevePreservarTexto()
    {
        const string texto = "Abc XYZ 123";

        Assert.AreEqual(texto, CifraCesar.Criptografar(texto, 0));
    }

    [TestMethod]
    public void Criptografar_ComChave26_DevePreservarTexto()
    {
        const string texto = "Abc XYZ 123";

        Assert.AreEqual(texto, CifraCesar.Criptografar(texto, 26));
    }

    [TestMethod]
    public void Criptografar_ComChaveMaiorQue26_DeveNormalizarChave()
    {
        Assert.AreEqual("DEF", CifraCesar.Criptografar("ABC", 29));
    }

    [TestMethod]
    public void Criptografar_ComChaveNegativa_DeveDeslocarCorretamente()
    {
        Assert.AreEqual("XYZ", CifraCesar.Criptografar("ABC", -3));
    }

    [TestMethod]
    public void Criptografar_ComTextoVazio_DeveRetornarTextoVazio()
    {
        Assert.AreEqual(string.Empty, CifraCesar.Criptografar(string.Empty, 3));
    }

    [TestMethod]
    public void Criptografar_DevePreservarMultiplasLinhas()
    {
        Assert.AreEqual("Bcd\nYZA\n123", CifraCesar.Criptografar("Abc\nXYZ\n123", 1));
    }

    [TestMethod]
    public void CriptografarEDescriptografar_DeveRecuperarTextoOriginal()
    {
        const string texto = "Olá, Mundo!\nABC xyz 123";

        string textoCifrado = CifraCesar.Criptografar(texto, 17);

        Assert.AreEqual(texto, CifraCesar.Descriptografar(textoCifrado, 17));
    }

    [TestMethod]
    public void Criptografar_ComIntMaxValue_DeveNormalizarSemOverflow()
    {
        Assert.AreEqual("X", CifraCesar.Criptografar("A", int.MaxValue));
    }

    [TestMethod]
    public void Criptografar_ComIntMinValue_DeveNormalizarSemOverflow()
    {
        Assert.AreEqual("C", CifraCesar.Criptografar("A", int.MinValue));
    }
}