// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="me">
//   me
// </copyright>
// <summary>
//   The main form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Atom
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Drawing;
  using System.IO;
  using System.Windows.Forms;
  using Atom.Annotations;
  using Engine;
  using Nodes;
  using ScintillaNET;

  /// <summary>
  ///   The main form.
  /// </summary>
  public partial class MainForm : Form
  {
    /// <summary>
    ///   The interpreter.
    /// </summary>
    private readonly IInterpreter interpreter = EngineHelpers.NewInterpreter();

    /// <summary>
    ///   The output-string. Contents will be shown in the output-window upon termination of a program run.
    /// </summary>
    private string output = string.Empty;

    /// <summary>
    ///   Initializes a new instance of the <see cref="MainForm" /> class.
    /// </summary>
    public MainForm()
    {
      try
      {
        this.InitializeComponent();
        this.UpdateEditCtrlConfiguration();
        this.NavigationTreeView.HelpTextBox = this.HelpTextBox;

        ToolStripProfessionalRenderer renderer = this.MainToolStrip.Renderer as ToolStripProfessionalRenderer;

        if (renderer != null)
        {
          renderer.RoundedEdges = false;
        }

        this.UpdateFilesList();
        this.interpreter.InvokeHost += this.OnInterpreterInvokehost;
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message, string.Empty, MessageBoxButtons.OK, 0, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign, false);
      }
    }

    /// <summary>
    /// Adds the specified message to the output-string.
    /// </summary>
    /// <param name="msg">
    /// The message.
    /// </param>
    [UsedImplicitly]
    public void AddMsg(string msg)
    {
      this.output += msg;
    }

    /// <summary>
    /// Handles the "SelectedValueChanged"-event of the "ModulesListBox".
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The arguments.
    /// </param>
    private void ModulesListBoxSelectedValueChanged(object sender, EventArgs e)
    {
      this.UpdateEditCtrl();
    }

    /// <summary>
    /// Handles the "InvokeHost" event of the interpreter.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The arguments of the event (always null).
    /// </param>
    private void OnInterpreterInvokehost(object sender, InvokeHostEventArgs e)
    {
      // Host.Invoke();
      this.AddMsg(e.Message);
    }

    /// <summary>
    /// The on main form form closing.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
    {
      this.UpdateEditCtrl();
    }

    /// <summary>
    /// The replace button click.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void ReplaceButtonClick(object sender, EventArgs e)
    {
      this.UpdateEditCtrl();
      this.EditCtl.Tag = null;
      Utilities.ReplaceInFiles(this.OriginalTextBox.Text, this.ReplacementTextBox.Text);
      this.UpdateFilesList();
    }

    /// <summary>
    ///   Run current "atom"-code.
    /// </summary>
    private void Run()
    {
      try
      {
        this.UpdateEditCtrl();
        this.output = string.Empty;

        if (!this.interpreter.Run(Utilities.CollectCode()))
        {
          return;
        }

        this.OutputTextBox.Text = this.output;
        this.NavigationTreeView.RebuildNavigationTree(this.interpreter, this.interpreter.Names, this.interpreter.Names);
        this.UpdateEditCtrlConfiguration();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }

    /// <summary>
    /// The run button click.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void RunButtonClick(object sender, EventArgs e)
    {
      this.Run();
    }

    /// <summary>
    ///   The update edit ctrl.
    /// </summary>
    private void UpdateEditCtrl()
    {
      string currentPath = this.EditCtl.Tag as string;

      if ((currentPath != null) && File.Exists(currentPath))
      {
        Utilities.WriteFile(currentPath, this.EditCtl.Text);
      }

      string newPath = this.ModulesListBox.SelectedItem as string;

      if ((newPath != null) && File.Exists(newPath))
      {
        this.EditCtl.Text = Utilities.ReadFile(newPath);
        this.EditCtl.Tag = newPath;
      }
    }

    /// <summary>
    ///   The update edit ctrl configuration.
    /// </summary>
    private void UpdateEditCtrlConfiguration()
    {
      this.EditCtl.Lexing.Lexer = Lexer.Cpp;

      string keywords1 = string.Empty;

      foreach (string curKeyword in this.interpreter.PredefinedAtoms())
      {
        if (!string.IsNullOrEmpty(keywords1))
        {
          keywords1 += " ";
        }

        keywords1 += curKeyword;
      }

      string keywords2 = string.Empty;

      foreach (INode curNode in this.interpreter.Names)
      {
        string curKeyword = curNode.Value;

        if (!this.interpreter.IsPredefinedAtom(curKeyword))
        {
          if (!string.IsNullOrEmpty(keywords2))
          {
            keywords2 += " ";
          }

          keywords2 += curKeyword;
        }
      }

      this.EditCtl.Lexing.Keywords[0] = keywords1;
      this.EditCtl.Lexing.Keywords[1] = keywords2;

      foreach (KeyValuePair<string, int> curStyleName in this.EditCtl.Lexing.StyleNameMap)
      {
        Debug.WriteLine(curStyleName);

        Style curStyle = this.EditCtl.Styles[curStyleName.Key];

        curStyle.ForeColor = Color.Black;
      }

      this.EditCtl.Styles[this.EditCtl.Lexing.StyleNameMap["WORD"]].ForeColor = Color.Red;
      this.EditCtl.Styles[this.EditCtl.Lexing.StyleNameMap["WORD2"]].ForeColor = Color.Blue;
      this.EditCtl.Styles[this.EditCtl.Lexing.StyleNameMap["STRING"]].BackColor = Color.LightYellow;
    }

    /// <summary>
    ///   The update files list.
    /// </summary>
    private void UpdateFilesList()
    {
      string[] extensions = { "atm" };
      IEnumerable<string> files = Utilities.CollectFiles(extensions);

      this.ModulesListBox.Items.Clear();

      foreach (string curFile in files)
      {
        this.ModulesListBox.Items.Add(curFile);
      }

      if (0 < this.ModulesListBox.Items.Count)
      {
        this.ModulesListBox.SelectedIndex = this.ModulesListBox.Items.Count - 1;
      }
    }
  }
}