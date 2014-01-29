// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationTreeViewHelper.cs" company="me">
//   me
// </copyright>
// <summary>
//   The navigation tree view helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Atom
{
  using System.Collections.Generic;
  using System.Windows.Forms;
  using Nodes;

  /// <summary>
  ///   The navigation tree view helper.
  /// </summary>
  internal class NavigationTreeViewHelper
  {
    /// <summary>
    ///   The view.
    /// </summary>
    private readonly TreeView view;

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationTreeViewHelper"/> class.
    /// </summary>
    /// <param name="view">
    /// The view.
    /// </param>
    public NavigationTreeViewHelper(TreeView view)
    {
      this.view = view;
    }

    /// <summary>
    /// The navigation tree view before expand.
    /// </summary>
    /// <param name="e">
    /// The e.
    /// </param>
    public void InitializeNode(TreeViewCancelEventArgs e)
    {
      TreeNode node = e.Node;
      INodeList list = node.Tag as INodeList;

      if (list != null)
      {
        node.Nodes.Clear();

        foreach (INode curNode in list)
        {
          TreeNode newNode = new TreeNode(curNode.Value) { Tag = curNode.List };

          if (curNode.List != null)
          {
            newNode.Nodes.Add(string.Empty);
          }

          node.Nodes.Add(newNode);
        }

        node.Tag = null;
      }
    }

    /// <summary>
    /// The rebuild navigation tree.
    /// </summary>
    /// <param name="list">
    /// The list.
    /// </param>
    public void RebuildNavigationTree(IEnumerable<INode> list)
    {
      this.view.Nodes.Clear();

      foreach (INode curNode in list)
      {
        TreeNode newNode = new TreeNode(curNode.Value) { Tag = curNode.List };

        if (curNode.List != null)
        {
          newNode.Nodes.Add(string.Empty);
        }

        this.view.Nodes.Add(newNode);
      }
    }
  }
}