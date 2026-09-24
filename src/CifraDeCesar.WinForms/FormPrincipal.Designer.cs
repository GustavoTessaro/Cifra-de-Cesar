namespace CifraDeCesar.WinForms;

partial class FormPrincipal
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel layoutPrincipal;
    private Panel cabecalhoPanel;
    private Label tituloLabel;
    private Label subtituloLabel;
    private GroupBox arquivoGroupBox;
    private TableLayoutPanel arquivoLayout;
    private TextBox caminhoArquivoTextBox;
    private Button selecionarArquivoButton;
    private GroupBox chaveGroupBox;
    private FlowLayoutPanel chaveLayout;
    private NumericUpDown chaveNumericUpDown;
    private Label explicacaoChaveLabel;
    private FlowLayoutPanel acoesLayout;
    private Button criptografarButton;
    private Button descriptografarButton;
    private GroupBox statusGroupBox;
    private TableLayoutPanel statusLayout;
    private Label statusLabelTitulo;
    private Label statusLabel;
    private Label saidaLabel;
    private Button abrirPastaButton;
    private ToolTip caminhoToolTip;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        layoutPrincipal = new TableLayoutPanel();
        cabecalhoPanel = new Panel();
        tituloLabel = new Label();
        subtituloLabel = new Label();
        arquivoGroupBox = new GroupBox();
        arquivoLayout = new TableLayoutPanel();
        caminhoArquivoTextBox = new TextBox();
        selecionarArquivoButton = new Button();
        chaveGroupBox = new GroupBox();
        chaveLayout = new FlowLayoutPanel();
        chaveNumericUpDown = new NumericUpDown();
        explicacaoChaveLabel = new Label();
        acoesLayout = new FlowLayoutPanel();
        criptografarButton = new Button();
        descriptografarButton = new Button();
        statusGroupBox = new GroupBox();
        statusLayout = new TableLayoutPanel();
        statusLabelTitulo = new Label();
        statusLabel = new Label();
        saidaLabel = new Label();
        abrirPastaButton = new Button();
        caminhoToolTip = new ToolTip(components);
        ((System.ComponentModel.ISupportInitialize)chaveNumericUpDown).BeginInit();
        layoutPrincipal.SuspendLayout();
        cabecalhoPanel.SuspendLayout();
        arquivoGroupBox.SuspendLayout();
        arquivoLayout.SuspendLayout();
        chaveGroupBox.SuspendLayout();
        chaveLayout.SuspendLayout();
        acoesLayout.SuspendLayout();
        statusGroupBox.SuspendLayout();
        statusLayout.SuspendLayout();
        SuspendLayout();

        layoutPrincipal.ColumnCount = 1;
        layoutPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPrincipal.Controls.Add(cabecalhoPanel, 0, 0);
        layoutPrincipal.Controls.Add(arquivoGroupBox, 0, 1);
        layoutPrincipal.Controls.Add(chaveGroupBox, 0, 2);
        layoutPrincipal.Controls.Add(acoesLayout, 0, 3);
        layoutPrincipal.Controls.Add(statusGroupBox, 0, 4);
        layoutPrincipal.Dock = DockStyle.Fill;
        layoutPrincipal.Location = new Point(0, 0);
        layoutPrincipal.Padding = new Padding(32, 24, 32, 24);
        layoutPrincipal.RowCount = 5;
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutPrincipal.Size = new Size(900, 600);

        cabecalhoPanel.Controls.Add(tituloLabel);
        cabecalhoPanel.Controls.Add(subtituloLabel);
        cabecalhoPanel.Dock = DockStyle.Fill;
        cabecalhoPanel.Margin = new Padding(0, 0, 0, 12);

        tituloLabel.AutoSize = true;
        tituloLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
        tituloLabel.ForeColor = Color.FromArgb(31, 78, 121);
        tituloLabel.Location = new Point(0, 0);
        tituloLabel.Text = "Cifra de César";

        subtituloLabel.AutoSize = true;
        subtituloLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
        subtituloLabel.ForeColor = Color.FromArgb(90, 90, 90);
        subtituloLabel.Location = new Point(3, 42);
        subtituloLabel.Text = "Criptografia e descriptografia de arquivos de texto";

        arquivoGroupBox.Controls.Add(arquivoLayout);
        arquivoGroupBox.Dock = DockStyle.Fill;
        arquivoGroupBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        arquivoGroupBox.Margin = new Padding(0, 0, 0, 12);
        arquivoGroupBox.Padding = new Padding(12, 10, 12, 12);
        arquivoGroupBox.Text = "Arquivo de entrada";

        arquivoLayout.ColumnCount = 2;
        arquivoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        arquivoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        arquivoLayout.Controls.Add(caminhoArquivoTextBox, 0, 0);
        arquivoLayout.Controls.Add(selecionarArquivoButton, 1, 0);
        arquivoLayout.Dock = DockStyle.Fill;
        arquivoLayout.RowCount = 1;
        arquivoLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        caminhoArquivoTextBox.Dock = DockStyle.Fill;
        caminhoArquivoTextBox.BackColor = Color.White;
        caminhoArquivoTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        caminhoArquivoTextBox.Margin = new Padding(0, 4, 10, 4);
        caminhoArquivoTextBox.ReadOnly = true;

        selecionarArquivoButton.Dock = DockStyle.Fill;
        selecionarArquivoButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        selecionarArquivoButton.Text = "Selecionar arquivo...";
        selecionarArquivoButton.UseVisualStyleBackColor = true;
        selecionarArquivoButton.Click += SelecionarArquivoButton_Click;

        chaveGroupBox.Controls.Add(chaveLayout);
        chaveGroupBox.Dock = DockStyle.Fill;
        chaveGroupBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        chaveGroupBox.Margin = new Padding(0, 0, 0, 12);
        chaveGroupBox.Padding = new Padding(12, 10, 12, 12);
        chaveGroupBox.Text = "Chave da cifra";

        chaveLayout.AutoSize = true;
        chaveLayout.Controls.Add(chaveNumericUpDown);
        chaveLayout.Controls.Add(explicacaoChaveLabel);
        chaveLayout.Dock = DockStyle.Fill;
        chaveLayout.FlowDirection = FlowDirection.LeftToRight;
        chaveLayout.WrapContents = false;

        chaveNumericUpDown.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        chaveNumericUpDown.Margin = new Padding(0, 8, 16, 0);
        chaveNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        chaveNumericUpDown.Minimum = new decimal(new int[] { 1000000, 0, 0, int.MinValue });
        chaveNumericUpDown.Size = new Size(120, 27);
        chaveNumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });

        explicacaoChaveLabel.AutoSize = true;
        explicacaoChaveLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        explicacaoChaveLabel.ForeColor = Color.FromArgb(90, 90, 90);
        explicacaoChaveLabel.Margin = new Padding(0, 12, 0, 0);
        explicacaoChaveLabel.Text = "A chave define quantas posições as letras serão deslocadas.";

        acoesLayout.AutoSize = true;
        acoesLayout.Controls.Add(criptografarButton);
        acoesLayout.Controls.Add(descriptografarButton);
        acoesLayout.Dock = DockStyle.Fill;
        acoesLayout.FlowDirection = FlowDirection.LeftToRight;
        acoesLayout.Margin = new Padding(0, 0, 0, 12);
        acoesLayout.WrapContents = false;

        criptografarButton.BackColor = Color.FromArgb(31, 78, 121);
        criptografarButton.FlatStyle = FlatStyle.Flat;
        criptografarButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        criptografarButton.ForeColor = Color.White;
        criptografarButton.Margin = new Padding(0, 4, 12, 4);
        criptografarButton.Size = new Size(160, 38);
        criptografarButton.Text = "Criptografar";
        criptografarButton.TextAlign = ContentAlignment.MiddleCenter;
        criptografarButton.UseVisualStyleBackColor = false;
        criptografarButton.Click += CriptografarButton_Click;

        descriptografarButton.BackColor = Color.FromArgb(235, 235, 235);
        descriptografarButton.FlatStyle = FlatStyle.Flat;
        descriptografarButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        descriptografarButton.ForeColor = Color.FromArgb(45, 45, 45);
        descriptografarButton.Margin = new Padding(0, 4, 0, 4);
        descriptografarButton.Size = new Size(160, 38);
        descriptografarButton.Text = "Descriptografar";
        descriptografarButton.TextAlign = ContentAlignment.MiddleCenter;
        descriptografarButton.UseVisualStyleBackColor = false;
        descriptografarButton.FlatAppearance.BorderColor = Color.FromArgb(190, 190, 190);
        descriptografarButton.FlatAppearance.BorderSize = 1;
        descriptografarButton.Click += DescriptografarButton_Click;

        statusGroupBox.Controls.Add(statusLayout);
        statusGroupBox.Dock = DockStyle.Fill;
        statusGroupBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        statusGroupBox.Margin = new Padding(0);
        statusGroupBox.Padding = new Padding(12, 10, 12, 12);
        statusGroupBox.Text = "Status";

        statusLayout.ColumnCount = 2;
        statusLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        statusLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
        statusLayout.Controls.Add(statusLabelTitulo, 0, 0);
        statusLayout.Controls.Add(abrirPastaButton, 1, 0);
        statusLayout.Controls.Add(statusLabel, 0, 1);
        statusLayout.SetColumnSpan(statusLabel, 2);
        statusLayout.Controls.Add(saidaLabel, 0, 2);
        statusLayout.SetColumnSpan(saidaLabel, 2);
        statusLayout.Dock = DockStyle.Fill;
        statusLayout.RowCount = 3;
        statusLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        statusLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        statusLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        statusLabelTitulo.AutoSize = true;
        statusLabelTitulo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        statusLabelTitulo.ForeColor = Color.FromArgb(90, 90, 90);
        statusLabelTitulo.Margin = new Padding(0, 6, 0, 0);
        statusLabelTitulo.Text = "Resultado da última operação";

        statusLabel.AutoSize = true;
        statusLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        statusLabel.ForeColor = Color.FromArgb(45, 45, 45);
        statusLabel.Margin = new Padding(0, 5, 0, 0);
        statusLabel.Text = "Selecione um arquivo para começar.";

        saidaLabel.AutoEllipsis = true;
        saidaLabel.Dock = DockStyle.Fill;
        saidaLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        saidaLabel.ForeColor = Color.FromArgb(90, 90, 90);
        saidaLabel.Margin = new Padding(0, 2, 0, 0);
        saidaLabel.Text = "Saída: -";

        abrirPastaButton.Dock = DockStyle.Fill;
        abrirPastaButton.Enabled = false;
        abrirPastaButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        abrirPastaButton.Text = "Abrir pasta";
        abrirPastaButton.UseVisualStyleBackColor = true;
        abrirPastaButton.Click += AbrirPastaButton_Click;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        ClientSize = new Size(900, 600);
        Controls.Add(layoutPrincipal);
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        MinimumSize = new Size(760, 520);
        Name = "FormPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Cifra de César - Segurança Computacional";
        ((System.ComponentModel.ISupportInitialize)chaveNumericUpDown).EndInit();
        statusLayout.ResumeLayout(false);
        statusLayout.PerformLayout();
        statusGroupBox.ResumeLayout(false);
        acoesLayout.ResumeLayout(false);
        chaveLayout.ResumeLayout(false);
        chaveLayout.PerformLayout();
        chaveGroupBox.ResumeLayout(false);
        arquivoLayout.ResumeLayout(false);
        arquivoLayout.PerformLayout();
        arquivoGroupBox.ResumeLayout(false);
        cabecalhoPanel.ResumeLayout(false);
        cabecalhoPanel.PerformLayout();
        layoutPrincipal.ResumeLayout(false);
        ResumeLayout(false);
    }
}