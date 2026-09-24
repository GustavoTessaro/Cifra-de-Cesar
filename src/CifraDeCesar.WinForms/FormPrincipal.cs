using System.Diagnostics;
using CifraDeCesar.Core.Arquivos;

namespace CifraDeCesar.WinForms;

public partial class FormPrincipal : Form
{
    private string? caminhoUltimaSaida;

    public FormPrincipal()
    {
        InitializeComponent();
    }

    private void SelecionarArquivoButton_Click(object? sender, EventArgs e)
    {
        using var dialogo = new OpenFileDialog
        {
            Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*",
            Title = "Selecionar arquivo de entrada",
            CheckFileExists = true,
            Multiselect = false
        };

        if (dialogo.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        caminhoArquivoTextBox.Text = dialogo.FileName;
        LimparResultado();
    }

    private void CriptografarButton_Click(object? sender, EventArgs e)
    {
        ProcessarArquivo(criptografar: true);
    }

    private void DescriptografarButton_Click(object? sender, EventArgs e)
    {
        ProcessarArquivo(criptografar: false);
    }

    private void AbrirPastaButton_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(caminhoUltimaSaida) || !File.Exists(caminhoUltimaSaida))
        {
            MessageBox.Show(
                this,
                "O arquivo de saída não está disponível.",
                "Arquivo não encontrado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            AtualizarEstadoDoBotaoAbrirPasta();
            return;
        }

        try
        {
            // O Explorer abre destacando o arquivo gerado.
            Process.Start(new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = $"/select,\"{caminhoUltimaSaida}\"",
                UseShellExecute = true
            });
        }
        catch (Exception excecao)
        {
            MostrarErro("Não foi possível abrir a pasta do arquivo de saída.", excecao);
        }
    }

    private void ProcessarArquivo(bool criptografar)
    {
        if (string.IsNullOrWhiteSpace(caminhoArquivoTextBox.Text))
        {
            MessageBox.Show(
                this,
                "Selecione um arquivo de entrada antes de continuar.",
                "Arquivo não selecionado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // A interface apenas encaminha os dados para o serviço do Core.
            caminhoUltimaSaida = criptografar
                ? ArquivoService.CriptografarArquivo(caminhoArquivoTextBox.Text, (int)chaveNumericUpDown.Value)
                : ArquivoService.DescriptografarArquivo(caminhoArquivoTextBox.Text, (int)chaveNumericUpDown.Value);

            statusLabel.Text = criptografar
                ? "Arquivo criptografado com sucesso."
                : "Arquivo descriptografado com sucesso.";
            statusLabel.ForeColor = Color.FromArgb(46, 125, 50);
            saidaLabel.Text = $"Saída: {caminhoUltimaSaida}";
            caminhoToolTip.SetToolTip(saidaLabel, caminhoUltimaSaida);
            AtualizarEstadoDoBotaoAbrirPasta();
        }
        catch (FileNotFoundException)
        {
            MostrarErro("O arquivo selecionado não foi encontrado. Selecione-o novamente.");
        }
        catch (UnauthorizedAccessException)
        {
            MostrarErro("O acesso ao arquivo foi negado. Verifique as permissões da pasta.");
        }
        catch (IOException excecao)
        {
            MostrarErro("Não foi possível ler ou gravar o arquivo.", excecao);
        }
        catch (ArgumentException excecao)
        {
            MostrarErro("O caminho do arquivo não é válido.", excecao);
        }
        catch (Exception excecao)
        {
            MostrarErro("Ocorreu um erro inesperado ao processar o arquivo.", excecao);
        }
    }

    private void LimparResultado()
    {
        caminhoUltimaSaida = null;
        statusLabel.Text = "Selecione um arquivo para começar.";
        statusLabel.ForeColor = Color.FromArgb(45, 45, 45);
        saidaLabel.Text = "Saída: -";
        caminhoToolTip.SetToolTip(saidaLabel, string.Empty);
        AtualizarEstadoDoBotaoAbrirPasta();
    }

    private void AtualizarEstadoDoBotaoAbrirPasta()
    {
        abrirPastaButton.Enabled = !string.IsNullOrWhiteSpace(caminhoUltimaSaida)
            && File.Exists(caminhoUltimaSaida);
    }

    private void MostrarErro(string mensagem, Exception? excecao = null)
    {
        string mensagemCompleta = excecao is null
            ? mensagem
            : $"{mensagem}\n\nDetalhes: {excecao.Message}";

        MessageBox.Show(
            this,
            mensagemCompleta,
            "Não foi possível concluir a operação",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}