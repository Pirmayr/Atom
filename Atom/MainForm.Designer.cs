namespace Atom
{
  /// <summary>
  /// The main-form of the application.
  /// </summary>
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows TheForm Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.OutputTextBox = new System.Windows.Forms.TextBox();
      this.ModulesListBox = new System.Windows.Forms.ListBox();
      this.MainPanel = new System.Windows.Forms.Panel();
      this.EditPanel = new System.Windows.Forms.Panel();
      this.EditHelperPanel = new System.Windows.Forms.Panel();
      this.EditCtl = new System.Windows.Forms.TextBox();
      this.OutputPanel = new System.Windows.Forms.Panel();
      this.OutputHelperPanel = new System.Windows.Forms.Panel();
      this.ModulesPanel = new System.Windows.Forms.Panel();
      this.ModulesHelperPanel = new System.Windows.Forms.Panel();
      this.NamesHelperPanel = new System.Windows.Forms.Panel();
      this.NamesGridView = new System.Windows.Forms.DataGridView();
      this.ModuleHelperPanel = new System.Windows.Forms.Panel();
      this.StackHelperPanel = new System.Windows.Forms.Panel();
      this.ValuesGridView = new System.Windows.Forms.DataGridView();
      this.ValuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.NamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.MainToolStrip = new System.Windows.Forms.ToolStrip();
      this.RunButton = new System.Windows.Forms.ToolStripButton();
      this.ReplaceButton = new System.Windows.Forms.ToolStripButton();
      this.ReplacementTextBox = new System.Windows.Forms.ToolStripTextBox();
      this.OriginalTextBox = new System.Windows.Forms.ToolStripTextBox();
      this.MainPanel.SuspendLayout();
      this.EditPanel.SuspendLayout();
      this.EditHelperPanel.SuspendLayout();
      this.OutputPanel.SuspendLayout();
      this.OutputHelperPanel.SuspendLayout();
      this.ModulesPanel.SuspendLayout();
      this.ModulesHelperPanel.SuspendLayout();
      this.NamesHelperPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.NamesGridView)).BeginInit();
      this.ModuleHelperPanel.SuspendLayout();
      this.StackHelperPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ValuesGridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ValuesBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NamesBindingSource)).BeginInit();
      this.MainToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // OutputTextBox
      // 
      this.OutputTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.OutputTextBox.Location = new System.Drawing.Point(0, 2);
      this.OutputTextBox.Margin = new System.Windows.Forms.Padding(0);
      this.OutputTextBox.Multiline = true;
      this.OutputTextBox.Name = "OutputTextBox";
      this.OutputTextBox.ReadOnly = true;
      this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.OutputTextBox.Size = new System.Drawing.Size(392, 279);
      this.OutputTextBox.TabIndex = 2;
      this.OutputTextBox.WordWrap = false;
      // 
      // ModulesListBox
      // 
      this.ModulesListBox.BackColor = System.Drawing.Color.WhiteSmoke;
      this.ModulesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.ModulesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ModulesListBox.FormattingEnabled = true;
      this.ModulesListBox.IntegralHeight = false;
      this.ModulesListBox.ItemHeight = 18;
      this.ModulesListBox.Location = new System.Drawing.Point(0, 0);
      this.ModulesListBox.Margin = new System.Windows.Forms.Padding(0);
      this.ModulesListBox.Name = "ModulesListBox";
      this.ModulesListBox.ScrollAlwaysVisible = true;
      this.ModulesListBox.Size = new System.Drawing.Size(444, 247);
      this.ModulesListBox.TabIndex = 4;
      this.ModulesListBox.SelectedValueChanged += new System.EventHandler(this.ModulesListBoxSelectedValueChanged);
      // 
      // MainPanel
      // 
      this.MainPanel.Controls.Add(this.EditPanel);
      this.MainPanel.Controls.Add(this.OutputPanel);
      this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainPanel.Location = new System.Drawing.Point(446, 42);
      this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
      this.MainPanel.Name = "MainPanel";
      this.MainPanel.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
      this.MainPanel.Size = new System.Drawing.Size(394, 433);
      this.MainPanel.TabIndex = 5;
      // 
      // EditPanel
      // 
      this.EditPanel.BackColor = System.Drawing.SystemColors.Control;
      this.EditPanel.Controls.Add(this.EditHelperPanel);
      this.EditPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EditPanel.Location = new System.Drawing.Point(2, 0);
      this.EditPanel.Margin = new System.Windows.Forms.Padding(0);
      this.EditPanel.Name = "EditPanel";
      this.EditPanel.Size = new System.Drawing.Size(392, 152);
      this.EditPanel.TabIndex = 7;
      // 
      // EditHelperPanel
      // 
      this.EditHelperPanel.Controls.Add(this.EditCtl);
      this.EditHelperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EditHelperPanel.Location = new System.Drawing.Point(0, 0);
      this.EditHelperPanel.Margin = new System.Windows.Forms.Padding(0);
      this.EditHelperPanel.Name = "EditHelperPanel";
      this.EditHelperPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
      this.EditHelperPanel.Size = new System.Drawing.Size(392, 152);
      this.EditHelperPanel.TabIndex = 7;
      // 
      // EditCtl
      // 
      this.EditCtl.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.EditCtl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EditCtl.Location = new System.Drawing.Point(0, 0);
      this.EditCtl.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
      this.EditCtl.Multiline = true;
      this.EditCtl.Name = "EditCtl";
      this.EditCtl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.EditCtl.Size = new System.Drawing.Size(392, 150);
      this.EditCtl.TabIndex = 0;
      // 
      // OutputPanel
      // 
      this.OutputPanel.BackColor = System.Drawing.SystemColors.Control;
      this.OutputPanel.Controls.Add(this.OutputHelperPanel);
      this.OutputPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.OutputPanel.Location = new System.Drawing.Point(2, 152);
      this.OutputPanel.Margin = new System.Windows.Forms.Padding(0);
      this.OutputPanel.Name = "OutputPanel";
      this.OutputPanel.Size = new System.Drawing.Size(392, 281);
      this.OutputPanel.TabIndex = 7;
      // 
      // OutputHelperPanel
      // 
      this.OutputHelperPanel.Controls.Add(this.OutputTextBox);
      this.OutputHelperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.OutputHelperPanel.Location = new System.Drawing.Point(0, 0);
      this.OutputHelperPanel.Margin = new System.Windows.Forms.Padding(0);
      this.OutputHelperPanel.Name = "OutputHelperPanel";
      this.OutputHelperPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
      this.OutputHelperPanel.Size = new System.Drawing.Size(392, 281);
      this.OutputHelperPanel.TabIndex = 8;
      // 
      // ModulesPanel
      // 
      this.ModulesPanel.Controls.Add(this.ModulesHelperPanel);
      this.ModulesPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.ModulesPanel.Location = new System.Drawing.Point(0, 42);
      this.ModulesPanel.Margin = new System.Windows.Forms.Padding(0);
      this.ModulesPanel.Name = "ModulesPanel";
      this.ModulesPanel.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
      this.ModulesPanel.Size = new System.Drawing.Size(446, 433);
      this.ModulesPanel.TabIndex = 6;
      // 
      // ModulesHelperPanel
      // 
      this.ModulesHelperPanel.Controls.Add(this.NamesHelperPanel);
      this.ModulesHelperPanel.Controls.Add(this.ModuleHelperPanel);
      this.ModulesHelperPanel.Controls.Add(this.StackHelperPanel);
      this.ModulesHelperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ModulesHelperPanel.Location = new System.Drawing.Point(0, 0);
      this.ModulesHelperPanel.Margin = new System.Windows.Forms.Padding(0);
      this.ModulesHelperPanel.Name = "ModulesHelperPanel";
      this.ModulesHelperPanel.Size = new System.Drawing.Size(444, 433);
      this.ModulesHelperPanel.TabIndex = 9;
      // 
      // NamesHelperPanel
      // 
      this.NamesHelperPanel.Controls.Add(this.NamesGridView);
      this.NamesHelperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.NamesHelperPanel.Location = new System.Drawing.Point(0, 247);
      this.NamesHelperPanel.Margin = new System.Windows.Forms.Padding(0);
      this.NamesHelperPanel.Name = "NamesHelperPanel";
      this.NamesHelperPanel.Size = new System.Drawing.Size(444, 0);
      this.NamesHelperPanel.TabIndex = 9;
      // 
      // NamesGridView
      // 
      this.NamesGridView.AllowUserToAddRows = false;
      this.NamesGridView.AllowUserToDeleteRows = false;
      this.NamesGridView.AllowUserToResizeColumns = false;
      this.NamesGridView.AllowUserToResizeRows = false;
      this.NamesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.NamesGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.NamesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
      this.NamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.NamesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.NamesGridView.GridColor = System.Drawing.SystemColors.Control;
      this.NamesGridView.Location = new System.Drawing.Point(0, 0);
      this.NamesGridView.Margin = new System.Windows.Forms.Padding(0);
      this.NamesGridView.Name = "NamesGridView";
      this.NamesGridView.RowHeadersVisible = false;
      this.NamesGridView.RowTemplate.Height = 24;
      this.NamesGridView.Size = new System.Drawing.Size(444, 0);
      this.NamesGridView.TabIndex = 8;
      // 
      // ModuleHelperPanel
      // 
      this.ModuleHelperPanel.Controls.Add(this.ModulesListBox);
      this.ModuleHelperPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.ModuleHelperPanel.Location = new System.Drawing.Point(0, 0);
      this.ModuleHelperPanel.Margin = new System.Windows.Forms.Padding(0);
      this.ModuleHelperPanel.Name = "ModuleHelperPanel";
      this.ModuleHelperPanel.Size = new System.Drawing.Size(444, 247);
      this.ModuleHelperPanel.TabIndex = 10;
      // 
      // StackHelperPanel
      // 
      this.StackHelperPanel.Controls.Add(this.ValuesGridView);
      this.StackHelperPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.StackHelperPanel.Location = new System.Drawing.Point(0, 246);
      this.StackHelperPanel.Margin = new System.Windows.Forms.Padding(0);
      this.StackHelperPanel.Name = "StackHelperPanel";
      this.StackHelperPanel.Size = new System.Drawing.Size(444, 187);
      this.StackHelperPanel.TabIndex = 11;
      // 
      // ValuesGridView
      // 
      this.ValuesGridView.AllowUserToAddRows = false;
      this.ValuesGridView.AllowUserToDeleteRows = false;
      this.ValuesGridView.AllowUserToResizeColumns = false;
      this.ValuesGridView.AllowUserToResizeRows = false;
      this.ValuesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.ValuesGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.ValuesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
      this.ValuesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ValuesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ValuesGridView.GridColor = System.Drawing.SystemColors.Control;
      this.ValuesGridView.Location = new System.Drawing.Point(0, 0);
      this.ValuesGridView.Margin = new System.Windows.Forms.Padding(0);
      this.ValuesGridView.Name = "ValuesGridView";
      this.ValuesGridView.RowHeadersVisible = false;
      this.ValuesGridView.RowTemplate.Height = 24;
      this.ValuesGridView.Size = new System.Drawing.Size(444, 187);
      this.ValuesGridView.TabIndex = 7;
      // 
      // MainToolStrip
      // 
      this.MainToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
      this.MainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunButton,
            this.ReplaceButton,
            this.ReplacementTextBox,
            this.OriginalTextBox});
      this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
      this.MainToolStrip.Name = "MainToolStrip";
      this.MainToolStrip.Padding = new System.Windows.Forms.Padding(2, 7, 2, 5);
      this.MainToolStrip.Size = new System.Drawing.Size(840, 42);
      this.MainToolStrip.TabIndex = 10;
      this.MainToolStrip.Text = "toolStrip1";
      // 
      // RunButton
      // 
      this.RunButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.RunButton.Image = ((System.Drawing.Image)(resources.GetObject("RunButton.Image")));
      this.RunButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.RunButton.Name = "RunButton";
      this.RunButton.Size = new System.Drawing.Size(37, 27);
      this.RunButton.Text = "Run";
      this.RunButton.Click += new System.EventHandler(this.RunButtonClick);
      // 
      // ReplaceButton
      // 
      this.ReplaceButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ReplaceButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.ReplaceButton.Image = ((System.Drawing.Image)(resources.GetObject("ReplaceButton.Image")));
      this.ReplaceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ReplaceButton.Name = "ReplaceButton";
      this.ReplaceButton.Size = new System.Drawing.Size(62, 27);
      this.ReplaceButton.Text = "Replace";
      this.ReplaceButton.Click += new System.EventHandler(this.ReplaceButtonClick);
      // 
      // ReplacementTextBox
      // 
      this.ReplacementTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ReplacementTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.ReplacementTextBox.Margin = new System.Windows.Forms.Padding(3);
      this.ReplacementTextBox.Name = "ReplacementTextBox";
      this.ReplacementTextBox.Size = new System.Drawing.Size(137, 24);
      // 
      // OriginalTextBox
      // 
      this.OriginalTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.OriginalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.OriginalTextBox.Margin = new System.Windows.Forms.Padding(3);
      this.OriginalTextBox.Name = "OriginalTextBox";
      this.OriginalTextBox.Size = new System.Drawing.Size(137, 24);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(840, 475);
      this.Controls.Add(this.MainPanel);
      this.Controls.Add(this.ModulesPanel);
      this.Controls.Add(this.MainToolStrip);
      this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Atom";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormFormClosing);
      this.MainPanel.ResumeLayout(false);
      this.EditPanel.ResumeLayout(false);
      this.EditHelperPanel.ResumeLayout(false);
      this.EditHelperPanel.PerformLayout();
      this.OutputPanel.ResumeLayout(false);
      this.OutputHelperPanel.ResumeLayout(false);
      this.OutputHelperPanel.PerformLayout();
      this.ModulesPanel.ResumeLayout(false);
      this.ModulesHelperPanel.ResumeLayout(false);
      this.NamesHelperPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.NamesGridView)).EndInit();
      this.ModuleHelperPanel.ResumeLayout(false);
      this.StackHelperPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ValuesGridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ValuesBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NamesBindingSource)).EndInit();
      this.MainToolStrip.ResumeLayout(false);
      this.MainToolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    private System.Windows.Forms.BindingSource NamesBindingSource;
    private System.Windows.Forms.BindingSource ValuesBindingSource;

    #endregion

    private System.Windows.Forms.TextBox OutputTextBox;
    private System.Windows.Forms.ListBox ModulesListBox;
    private System.Windows.Forms.Panel MainPanel;
    private System.Windows.Forms.Panel ModulesPanel;
    private System.Windows.Forms.Panel EditPanel;
    private System.Windows.Forms.Panel OutputPanel;
    private System.Windows.Forms.Panel EditHelperPanel;
    private System.Windows.Forms.Panel OutputHelperPanel;
    private System.Windows.Forms.Panel ModulesHelperPanel;
    private System.Windows.Forms.DataGridView ValuesGridView;
    private System.Windows.Forms.DataGridView NamesGridView;
    private System.Windows.Forms.TextBox EditCtl;
    private System.Windows.Forms.Panel NamesHelperPanel;
    private System.Windows.Forms.Panel ModuleHelperPanel;
    private System.Windows.Forms.Panel StackHelperPanel;
    private System.Windows.Forms.ToolStrip MainToolStrip;
    private System.Windows.Forms.ToolStripButton RunButton;
    private System.Windows.Forms.ToolStripTextBox OriginalTextBox;
    private System.Windows.Forms.ToolStripTextBox ReplacementTextBox;
    private System.Windows.Forms.ToolStripButton ReplaceButton;
  }
}

