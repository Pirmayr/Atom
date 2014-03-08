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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.OutputTextBox = new System.Windows.Forms.TextBox();
      this.ModulesListBox = new System.Windows.Forms.ListBox();
      this.MainPanel = new System.Windows.Forms.Panel();
      this.EditPanel = new System.Windows.Forms.Panel();
      this.EditHelperPanel = new System.Windows.Forms.Panel();
      this.EditCtl = new ScintillaNET.Scintilla();
      this.OutputPanel = new System.Windows.Forms.Panel();
      this.OutputHelperPanel = new System.Windows.Forms.Panel();
      this.ModulesPanel = new System.Windows.Forms.Panel();
      this.ModulesHelperPanel = new System.Windows.Forms.Panel();
      this.NamesHelperPanel = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.NavigationTreeView = new Atom.NavigationTreeView();
      this.panel2 = new System.Windows.Forms.Panel();
      this.HelpTextBox = new System.Windows.Forms.TextBox();
      this.ModuleHelperPanel = new System.Windows.Forms.Panel();
      this.MainToolStrip = new System.Windows.Forms.ToolStrip();
      this.RunButton = new System.Windows.Forms.ToolStripButton();
      this.ReplaceButton = new System.Windows.Forms.ToolStripButton();
      this.ReplacementTextBox = new System.Windows.Forms.ToolStripTextBox();
      this.OriginalTextBox = new System.Windows.Forms.ToolStripTextBox();
      this.MainToolStripPanel = new System.Windows.Forms.Panel();
      this.MainPanel.SuspendLayout();
      this.EditPanel.SuspendLayout();
      this.EditHelperPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditCtl)).BeginInit();
      this.OutputPanel.SuspendLayout();
      this.OutputHelperPanel.SuspendLayout();
      this.ModulesPanel.SuspendLayout();
      this.ModulesHelperPanel.SuspendLayout();
      this.NamesHelperPanel.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.ModuleHelperPanel.SuspendLayout();
      this.MainToolStrip.SuspendLayout();
      this.MainToolStripPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // OutputTextBox
      // 
      this.OutputTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.OutputTextBox.Location = new System.Drawing.Point(0, 0);
      this.OutputTextBox.Margin = new System.Windows.Forms.Padding(0);
      this.OutputTextBox.Multiline = true;
      this.OutputTextBox.Name = "OutputTextBox";
      this.OutputTextBox.ReadOnly = true;
      this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.OutputTextBox.Size = new System.Drawing.Size(360, 204);
      this.OutputTextBox.TabIndex = 2;
      // 
      // ModulesListBox
      // 
      this.ModulesListBox.BackColor = System.Drawing.Color.WhiteSmoke;
      this.ModulesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.ModulesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ModulesListBox.FormattingEnabled = true;
      this.ModulesListBox.IntegralHeight = false;
      this.ModulesListBox.ItemHeight = 14;
      this.ModulesListBox.Location = new System.Drawing.Point(0, 0);
      this.ModulesListBox.Margin = new System.Windows.Forms.Padding(0);
      this.ModulesListBox.Name = "ModulesListBox";
      this.ModulesListBox.ScrollAlwaysVisible = true;
      this.ModulesListBox.Size = new System.Drawing.Size(343, 86);
      this.ModulesListBox.TabIndex = 4;
      this.ModulesListBox.SelectedValueChanged += new System.EventHandler(this.ModulesListBoxSelectedValueChanged);
      // 
      // MainPanel
      // 
      this.MainPanel.BackColor = System.Drawing.Color.Black;
      this.MainPanel.Controls.Add(this.EditPanel);
      this.MainPanel.Controls.Add(this.OutputPanel);
      this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainPanel.Location = new System.Drawing.Point(343, 34);
      this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
      this.MainPanel.Name = "MainPanel";
      this.MainPanel.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
      this.MainPanel.Size = new System.Drawing.Size(361, 314);
      this.MainPanel.TabIndex = 5;
      // 
      // EditPanel
      // 
      this.EditPanel.BackColor = System.Drawing.Color.Black;
      this.EditPanel.Controls.Add(this.EditHelperPanel);
      this.EditPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EditPanel.Location = new System.Drawing.Point(1, 0);
      this.EditPanel.Margin = new System.Windows.Forms.Padding(0);
      this.EditPanel.Name = "EditPanel";
      this.EditPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
      this.EditPanel.Size = new System.Drawing.Size(360, 110);
      this.EditPanel.TabIndex = 7;
      // 
      // EditHelperPanel
      // 
      this.EditHelperPanel.BackColor = System.Drawing.SystemColors.Control;
      this.EditHelperPanel.Controls.Add(this.EditCtl);
      this.EditHelperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EditHelperPanel.Location = new System.Drawing.Point(0, 0);
      this.EditHelperPanel.Margin = new System.Windows.Forms.Padding(0);
      this.EditHelperPanel.Name = "EditHelperPanel";
      this.EditHelperPanel.Size = new System.Drawing.Size(360, 109);
      this.EditHelperPanel.TabIndex = 7;
      // 
      // EditCtl
      // 
      this.EditCtl.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.EditCtl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EditCtl.Location = new System.Drawing.Point(0, 0);
      this.EditCtl.Name = "EditCtl";
      this.EditCtl.Size = new System.Drawing.Size(360, 109);
      this.EditCtl.Styles.BraceBad.Size = 9F;
      this.EditCtl.Styles.BraceLight.Size = 9F;
      this.EditCtl.Styles.ControlChar.Size = 9F;
      this.EditCtl.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
      this.EditCtl.Styles.Default.Size = 9F;
      this.EditCtl.Styles.IndentGuide.Size = 9F;
      this.EditCtl.Styles.LastPredefined.Size = 9F;
      this.EditCtl.Styles.LineNumber.Size = 9F;
      this.EditCtl.Styles.Max.Size = 9F;
      this.EditCtl.TabIndex = 1;
      // 
      // OutputPanel
      // 
      this.OutputPanel.BackColor = System.Drawing.SystemColors.Control;
      this.OutputPanel.Controls.Add(this.OutputHelperPanel);
      this.OutputPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.OutputPanel.Location = new System.Drawing.Point(1, 110);
      this.OutputPanel.Margin = new System.Windows.Forms.Padding(0);
      this.OutputPanel.Name = "OutputPanel";
      this.OutputPanel.Size = new System.Drawing.Size(360, 204);
      this.OutputPanel.TabIndex = 7;
      // 
      // OutputHelperPanel
      // 
      this.OutputHelperPanel.Controls.Add(this.OutputTextBox);
      this.OutputHelperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.OutputHelperPanel.Location = new System.Drawing.Point(0, 0);
      this.OutputHelperPanel.Margin = new System.Windows.Forms.Padding(0);
      this.OutputHelperPanel.Name = "OutputHelperPanel";
      this.OutputHelperPanel.Size = new System.Drawing.Size(360, 204);
      this.OutputHelperPanel.TabIndex = 8;
      // 
      // ModulesPanel
      // 
      this.ModulesPanel.Controls.Add(this.ModulesHelperPanel);
      this.ModulesPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.ModulesPanel.Location = new System.Drawing.Point(0, 34);
      this.ModulesPanel.Margin = new System.Windows.Forms.Padding(0);
      this.ModulesPanel.Name = "ModulesPanel";
      this.ModulesPanel.Size = new System.Drawing.Size(343, 314);
      this.ModulesPanel.TabIndex = 6;
      // 
      // ModulesHelperPanel
      // 
      this.ModulesHelperPanel.BackColor = System.Drawing.SystemColors.Control;
      this.ModulesHelperPanel.Controls.Add(this.NamesHelperPanel);
      this.ModulesHelperPanel.Controls.Add(this.ModuleHelperPanel);
      this.ModulesHelperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ModulesHelperPanel.Location = new System.Drawing.Point(0, 0);
      this.ModulesHelperPanel.Margin = new System.Windows.Forms.Padding(0);
      this.ModulesHelperPanel.Name = "ModulesHelperPanel";
      this.ModulesHelperPanel.Size = new System.Drawing.Size(343, 314);
      this.ModulesHelperPanel.TabIndex = 9;
      // 
      // NamesHelperPanel
      // 
      this.NamesHelperPanel.BackColor = System.Drawing.Color.Black;
      this.NamesHelperPanel.Controls.Add(this.panel1);
      this.NamesHelperPanel.Controls.Add(this.panel2);
      this.NamesHelperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.NamesHelperPanel.Location = new System.Drawing.Point(0, 86);
      this.NamesHelperPanel.Margin = new System.Windows.Forms.Padding(0);
      this.NamesHelperPanel.Name = "NamesHelperPanel";
      this.NamesHelperPanel.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
      this.NamesHelperPanel.Size = new System.Drawing.Size(343, 228);
      this.NamesHelperPanel.TabIndex = 9;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.NavigationTreeView);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 1);
      this.panel1.Margin = new System.Windows.Forms.Padding(0);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
      this.panel1.Size = new System.Drawing.Size(343, 138);
      this.panel1.TabIndex = 2;
      // 
      // NavigationTreeView
      // 
      this.NavigationTreeView.BackColor = System.Drawing.Color.WhiteSmoke;
      this.NavigationTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.NavigationTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.NavigationTreeView.Location = new System.Drawing.Point(0, 0);
      this.NavigationTreeView.Margin = new System.Windows.Forms.Padding(0);
      this.NavigationTreeView.Name = "NavigationTreeView";
      this.NavigationTreeView.ShowLines = false;
      this.NavigationTreeView.ShowNodeToolTips = true;
      this.NavigationTreeView.ShowPlusMinus = false;
      this.NavigationTreeView.ShowRootLines = false;
      this.NavigationTreeView.Size = new System.Drawing.Size(343, 137);
      this.NavigationTreeView.TabIndex = 0;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.HelpTextBox);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 139);
      this.panel2.Margin = new System.Windows.Forms.Padding(0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(343, 89);
      this.panel2.TabIndex = 3;
      // 
      // HelpTextBox
      // 
      this.HelpTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.HelpTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.HelpTextBox.Location = new System.Drawing.Point(0, 0);
      this.HelpTextBox.Margin = new System.Windows.Forms.Padding(0);
      this.HelpTextBox.Multiline = true;
      this.HelpTextBox.Name = "HelpTextBox";
      this.HelpTextBox.Size = new System.Drawing.Size(343, 89);
      this.HelpTextBox.TabIndex = 1;
      // 
      // ModuleHelperPanel
      // 
      this.ModuleHelperPanel.BackColor = System.Drawing.SystemColors.Control;
      this.ModuleHelperPanel.Controls.Add(this.ModulesListBox);
      this.ModuleHelperPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.ModuleHelperPanel.Location = new System.Drawing.Point(0, 0);
      this.ModuleHelperPanel.Margin = new System.Windows.Forms.Padding(0);
      this.ModuleHelperPanel.Name = "ModuleHelperPanel";
      this.ModuleHelperPanel.Size = new System.Drawing.Size(343, 86);
      this.ModuleHelperPanel.TabIndex = 10;
      // 
      // MainToolStrip
      // 
      this.MainToolStrip.BackColor = System.Drawing.SystemColors.Control;
      this.MainToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainToolStrip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MainToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
      this.MainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunButton,
            this.ReplaceButton,
            this.ReplacementTextBox,
            this.OriginalTextBox});
      this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
      this.MainToolStrip.Name = "MainToolStrip";
      this.MainToolStrip.Padding = new System.Windows.Forms.Padding(0);
      this.MainToolStrip.Size = new System.Drawing.Size(704, 33);
      this.MainToolStrip.TabIndex = 10;
      this.MainToolStrip.Text = "toolStrip1";
      // 
      // RunButton
      // 
      this.RunButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.RunButton.Image = ((System.Drawing.Image)(resources.GetObject("RunButton.Image")));
      this.RunButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.RunButton.Name = "RunButton";
      this.RunButton.Size = new System.Drawing.Size(32, 30);
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
      this.ReplaceButton.Size = new System.Drawing.Size(53, 30);
      this.ReplaceButton.Text = "Replace";
      this.ReplaceButton.Click += new System.EventHandler(this.ReplaceButtonClick);
      // 
      // ReplacementTextBox
      // 
      this.ReplacementTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.ReplacementTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.ReplacementTextBox.Margin = new System.Windows.Forms.Padding(3);
      this.ReplacementTextBox.Name = "ReplacementTextBox";
      this.ReplacementTextBox.Size = new System.Drawing.Size(159, 27);
      // 
      // OriginalTextBox
      // 
      this.OriginalTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.OriginalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.OriginalTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.OriginalTextBox.Margin = new System.Windows.Forms.Padding(3);
      this.OriginalTextBox.Name = "OriginalTextBox";
      this.OriginalTextBox.Size = new System.Drawing.Size(159, 27);
      // 
      // MainToolStripPanel
      // 
      this.MainToolStripPanel.BackColor = System.Drawing.Color.Black;
      this.MainToolStripPanel.Controls.Add(this.MainToolStrip);
      this.MainToolStripPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.MainToolStripPanel.Location = new System.Drawing.Point(0, 0);
      this.MainToolStripPanel.Margin = new System.Windows.Forms.Padding(0);
      this.MainToolStripPanel.Name = "MainToolStripPanel";
      this.MainToolStripPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
      this.MainToolStripPanel.Size = new System.Drawing.Size(704, 34);
      this.MainToolStripPanel.TabIndex = 11;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(704, 348);
      this.Controls.Add(this.MainPanel);
      this.Controls.Add(this.ModulesPanel);
      this.Controls.Add(this.MainToolStripPanel);
      this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Atom";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormFormClosing);
      this.MainPanel.ResumeLayout(false);
      this.EditPanel.ResumeLayout(false);
      this.EditHelperPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.EditCtl)).EndInit();
      this.OutputPanel.ResumeLayout(false);
      this.OutputHelperPanel.ResumeLayout(false);
      this.OutputHelperPanel.PerformLayout();
      this.ModulesPanel.ResumeLayout(false);
      this.ModulesHelperPanel.ResumeLayout(false);
      this.NamesHelperPanel.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ModuleHelperPanel.ResumeLayout(false);
      this.MainToolStrip.ResumeLayout(false);
      this.MainToolStrip.PerformLayout();
      this.MainToolStripPanel.ResumeLayout(false);
      this.MainToolStripPanel.PerformLayout();
      this.ResumeLayout(false);

    }

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
    private System.Windows.Forms.Panel NamesHelperPanel;
    private System.Windows.Forms.Panel ModuleHelperPanel;
    private System.Windows.Forms.ToolStrip MainToolStrip;
    private System.Windows.Forms.ToolStripButton RunButton;
    private System.Windows.Forms.ToolStripTextBox OriginalTextBox;
    private System.Windows.Forms.ToolStripTextBox ReplacementTextBox;
    private System.Windows.Forms.ToolStripButton ReplaceButton;
    private NavigationTreeView NavigationTreeView;
    private System.Windows.Forms.Panel MainToolStripPanel;
    private System.Windows.Forms.TextBox HelpTextBox;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private ScintillaNET.Scintilla EditCtl;
  }
}

