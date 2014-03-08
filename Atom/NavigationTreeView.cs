// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationTreeView.cs" company="me">
//   me
// </copyright>
// <summary>
//   The buffered tree view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Atom
{
  using System;
  using System.Collections.Generic;
  using System.Drawing;
  using System.Runtime.InteropServices;
  using System.Windows.Forms;
  using Engine;
  using Nodes;

  /// <summary>
  ///   The buffered tree view.
  /// </summary>
  internal class NavigationTreeView : TreeView
  {
    /// <summary>
    ///   The "TVM_GETEXTENDEDSTYLE"-message.
    /// </summary>
    private const int TvmSetextendedstyle = 0x1100 + 44;

    /// <summary>
    ///   The "TVS_EX_DOUBLE_BUFFER"-style.
    /// </summary>
    private const int TvsExDoublebuffer = 0x0004;

    /// <summary>
    ///   The currentInterpreter.
    /// </summary>
    private IInterpreter currentInterpreter;

    /// <summary>
    ///   Initializes a new instance of the <see cref="NavigationTreeView" /> class.
    /// </summary>
    public NavigationTreeView()
    {
      this.NodeMouseClick += this.OnNodeMouseClick;
      this.BeforeExpand += this.OnBeforeExpand;
      this.AfterExpand += this.OnAfterExpand;
    }

    /// <summary>
    /// Gets or sets the help text box.
    /// </summary>
    public TextBox HelpTextBox { private get; set; }

    /// <summary>
    /// The rebuild navigation tree.
    /// </summary>
    /// <param name="interpreter">
    /// The currentInterpreter.
    /// </param>
    /// <param name="list">
    /// The list to be displayed in the tree.
    /// </param>
    /// <param name="names">
    /// The list of names.
    /// </param>
    public void RebuildNavigationTree(IInterpreter interpreter, IEnumerable<INode> list, IEnumerable<INode> names)
    {
      this.currentInterpreter = interpreter;
      this.Tag = null;
      this.InitializeNodes(this.Nodes, list);
      this.Tag = names;
    }

    /// <summary>
    /// The on handle created.
    /// </summary>
    /// <param name="e">
    /// The e.
    /// </param>
    protected override void OnHandleCreated(EventArgs e)
    {
      SendMessage(this.Handle, TvmSetextendedstyle, (IntPtr)TvsExDoublebuffer, (IntPtr)TvsExDoublebuffer);
      base.OnHandleCreated(e);
    }

    /// <summary>
    /// The send message.
    /// </summary>
    /// <param name="windowHandle">
    /// The window-handle.
    /// </param>
    /// <param name="msg">
    /// The window-message.
    /// </param>
    /// <param name="wp">
    /// The word-parameter.
    /// </param>
    /// <param name="lp">
    /// The long-parameter.
    /// </param>
    /// <returns>
    /// The message-result/&gt;.
    /// </returns>
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr windowHandle, int msg, IntPtr wp, IntPtr lp);

    /// <summary>
    /// The expand all current node.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    private void ExpandAllCurrentNode(TreeNode node)
    {
      this.BeginUpdate();
      node.ExpandAll();
      this.EndUpdate();
    }

    /// <summary>
    /// The navigation tree view before expand.
    /// </summary>
    /// <param name="e">
    /// The e.
    /// </param>
    private void InitializeNode(TreeViewCancelEventArgs e)
    {
      TreeNode node = e.Node;
      INodeList list = node.Tag as INodeList;

      if (list != null)
      {
        if (!(this.IsName(node.Text) && this.ValueParentExists(node)))
        {
          this.InitializeNodes(node.Nodes, list);
        }

        node.Tag = null;
      }
    }

    /// <summary>
    /// The initialize nodes.
    /// </summary>
    /// <param name="nodes">
    /// The nodes.
    /// </param>
    /// <param name="list">
    /// The list.
    /// </param>
    private void InitializeNodes(TreeNodeCollection nodes, IEnumerable<INode> list)
    {
      nodes.Clear();

      foreach (INode curNode in list)
      {
        TreeNode newNode = new TreeNode(curNode.Value) { Tag = curNode.List };

        if (this.IsName(curNode.Value))
        {
          newNode.ForeColor = Color.Blue;
        }
        else if (this.currentInterpreter.IsPredefinedAtom(curNode.Value))
        {
          newNode.ForeColor = Color.Red;
        }

        newNode.ToolTipText = curNode.Comment;

        if (curNode.List != null)
        {
          newNode.Nodes.Add(string.Empty);
        }

        nodes.Add(newNode);
      }
    }

    /// <summary>
    /// The is name.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    private bool IsName(string value)
    {
      INodeList names = this.Tag as INodeList;

      if (names != null)
      {
        return names.ListAt(value) != null;
      }

      return false;
    }

    /// <summary>
    /// The on after expand.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="treeViewEventArgs">
    /// The tree view event args.
    /// </param>
    private void OnAfterExpand(object sender, TreeViewEventArgs treeViewEventArgs)
    {
      this.ExpandAllCurrentNode(treeViewEventArgs.Node);
    }

    /// <summary>
    /// The on before expand.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="treeViewCancelEventArgs">
    /// The tree view cancel event args.
    /// </param>
    private void OnBeforeExpand(object sender, TreeViewCancelEventArgs treeViewCancelEventArgs)
    {
      this.InitializeNode(treeViewCancelEventArgs);
    }

    /// <summary>
    /// The on node mouse double click.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="treeNodeMouseClickEventArgs">
    /// The tree node mouse click event args.
    /// </param>
    private void OnNodeMouseClick(object sender, TreeNodeMouseClickEventArgs treeNodeMouseClickEventArgs)
    {
      if (this.HelpTextBox != null)
      {
        this.HelpTextBox.Text = treeNodeMouseClickEventArgs.Node.ToolTipText;
      }
    }

    /// <summary>
    /// The value parent exists.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    private bool ValueParentExists(TreeNode node)
    {
      TreeNode currentParent = node.Parent;

      while (currentParent != null)
      {
        if (currentParent.Text == node.Text)
        {
          return true;
        }

        currentParent = currentParent.Parent;
      }

      return false;
    }
  }
}