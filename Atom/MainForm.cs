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

  using Atom.Properties;

  using Helpers;

  using Nodes;

  /// <summary>
  ///   The main form.
  /// </summary>
  public partial class MainForm : Form
  {
    /// <summary>
    ///   The interpreter.
    /// </summary>
    private readonly Interpreter interpreter = new Interpreter();

    /// <summary>
    ///   Initializes a new instance of the <see cref="MainForm" /> class.
    /// </summary>
    public MainForm()
    {
      try
      {
        this.InitializeComponent();
        this.UpdateFilesList();
        this.ValuesBindingSource.DataSource = GetDisplayList(this.interpreter.Values); 
        this.ValuesGridView.DataSource = this.ValuesBindingSource;
        this.NamesBindingSource.DataSource = GetDisplayList(this.interpreter.Names);
        this.NamesGridView.DataSource = this.NamesBindingSource;
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
    // ReSharper disable once UnusedMember.Global
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
    // ReSharper disable once UnusedMember.Global
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
    ///   Run current "atom"-code.
    /// </summary>
    private void Run()
    {
      try
      {
        this.UpdateEditCtrl();
        this.OutputTextBox.Clear();

        Parser atom = new Parser();
        string code = Utilities.CollectCode();
        INodeList tree = atom.Parse(code);

        if (tree == null)
        {
          return;
        }

        Host.Run(this, this.interpreter);
        this.interpreter.Execute(tree);

        this.NamesBindingSource.DataSource = null;
        this.NamesBindingSource.DataSource = GetDisplayList(this.interpreter.Names);
        this.ValuesBindingSource.DataSource = null;
        this.ValuesBindingSource.DataSource = GetDisplayList(this.interpreter.Values);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
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
      // Utilities.WriteFile(Resources.TestAtm, this.EditCtl.Text);
      this.UpdateEditCtrl();
    }

    /// <summary>
    /// The on run tool strip menu item click.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void OnRunToolStripMenuItemClick(object sender, EventArgs e)
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
      ICollection<string> files = Utilities.CollectFiles(extensions);

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