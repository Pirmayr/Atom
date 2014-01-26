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
  using System.Diagnostics.Contracts;
  using System.IO;
  using System.Linq;
  using System.Windows.Forms;

  using Atom.Annotations;
  using Atom.Properties;

  using Engine;

  using Nodes;

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
    ///   Initializes a new instance of the <see cref="MainForm" /> class.
    /// </summary>
    public MainForm()
    {
      try
      {
        this.InitializeComponent();
        this.UpdateFilesList();

        if (Utilities.IsUnix())
        {
          this.ValuesBindingSource.DataSource = this.interpreter.Values;
          this.NamesBindingSource.DataSource = this.interpreter.Names;
        }
        else
        {
          this.ValuesBindingSource.DataSource = GetDisplayList(this.interpreter.Values);
          this.NamesBindingSource.DataSource = GetDisplayList(this.interpreter.Names);
        }

        this.ValuesGridView.DataSource = this.ValuesBindingSource;
        this.NamesGridView.DataSource = this.NamesBindingSource;
        this.interpreter.InvokeHost += this.OnInterpreterInvokehost;
      }
      catch (Exception e)
      {
        MessageBox.Show(Resources.MSG_COULD_NOT_INITIATE_PROGRAM + e.Message, string.Empty, MessageBoxButtons.OK, 0, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign, false);
      }
    }

    /// <summary>
    /// Adds the specified message to the message-window.
    /// </summary>
    /// <param name="msg">
    /// The message.
    /// </param>
    [UsedImplicitly]
    public void AddMsg(string msg)
    {
      this.OutputTextBox.Text += msg;
    }

    /// <summary>
    /// Adds the specified message to the message-window and issues a newline.
    /// </summary>
    /// <param name="msg">
    /// The message.
    /// </param>
    [UsedImplicitly]
    public void AddMsgLine(string msg)
    {
      this.OutputTextBox.Text += msg + Environment.NewLine;
    }

    /// <summary>
    /// The get display list.
    /// </summary>
    /// <param name="list">
    /// The list.
    /// </param>
    /// <returns>
    /// The display list.
    /// </returns>
    private static IEnumerable<DisplayNode> GetDisplayList(IEnumerable<INode> list)
    {
      Contract.Requires(list != null);

      return list.Select(currentNode => new DisplayNode(currentNode));
    }

    /// <summary>
    /// The modules list box_ selected value changed.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
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
    private void OnInterpreterInvokehost(object sender, EventArgs e)
    {
      Host.Invoke();
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
    /// The replace button_ click.
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
        this.OutputTextBox.Clear();
        Host.Run(this, this.interpreter);

        if (this.interpreter.Run(Utilities.CollectCode()))
        {
          return;
        }

        this.NamesBindingSource.DataSource = null;
        this.ValuesBindingSource.DataSource = null;

        if (Utilities.IsUnix())
        {
          this.ValuesBindingSource.DataSource = this.interpreter.Values;
          this.NamesBindingSource.DataSource = this.interpreter.Names;
        }
        else
        {
          this.ValuesBindingSource.DataSource = GetDisplayList(this.interpreter.Values);
          this.NamesBindingSource.DataSource = GetDisplayList(this.interpreter.Names);
        }
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
        this.EditCtl.Select(0, 0);
        this.EditCtl.Tag = newPath;
      }
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