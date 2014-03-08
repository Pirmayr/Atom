// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Node.cs" company="me">
//   me
// </copyright>
// <summary>
//   Represents nodes in a node-list. Node-lists are used in
//   different parts of the application:
//   * The parse-tree.
//   * The value-stack.
//   * The name-stack.
//   * Lists in 'atom'-programs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Nodes
{
  using System.Collections.Generic;

  /// <summary>
  ///   Represents nodes in a node-list. Node-lists are used in
  ///   different parts of the application:
  ///   * The parse-tree.
  ///   * The value-stack.
  ///   * The name-stack.
  ///   * Lists in 'atom'-programs.
  /// </summary>
  internal class Node : INode
  {
    /// <summary>
    ///   The value.
    /// </summary>
    private readonly string value = string.Empty;

    /// <summary>
    ///   The list.
    /// </summary>
    private NodeList list;

    /// <summary>
    ///   Initializes a new instance of the <see cref="Node" /> class.
    /// </summary>
    public Node()
    {
      this.CachedNode = null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class.
    /// </summary>
    /// <param name="value">
    /// The value of the node.
    /// </param>
    public Node(string value)
    {
      this.value = value;
      this.CachedNode = null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class.
    /// </summary>
    /// <param name="list">
    /// The list, that is associated with the node.
    /// </param>
    public Node(NodeList list)
    {
      this.list = list;
      this.CachedNode = null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class.
    /// </summary>
    /// <param name="value">
    /// The value of the node.
    /// </param>
    /// <param name="list">
    /// The list, that is associated with the node.
    /// </param>
    public Node(string value, NodeList list)
    {
      this.value = value;
      this.list = list;
      this.CachedNode = null;
    }

    /// <summary>
    /// Gets or sets the cached node.
    /// </summary>
    public INode CachedNode { get; set; }

    /// <summary>
    ///   Gets or sets value (see interface).
    /// </summary>
    public string Comment { get; set; }

    /// <summary>
    ///   Gets or sets the list, that is associated with the node.
    /// </summary>
    /// <value>The list.</value>
    public INodeList List
    {
      get
      {
        return this.list;
      }

      set
      {
        this.list = value as NodeList;
      }
    }

    /// <summary>
    ///   Gets either the list, that is associated with the node,
    ///   or, if no list is associated with the node,
    ///   the node itself wrapped in a list.
    /// </summary>
    /// <value>The list.</value>
    public INodeList SafeList
    {
      get
      {
        NodeList result = this.list;

        if (result == null)
        {
          result = new NodeList();
          result.AddElement(this);
        }

        return result;
      }
    }

    /// <summary>
    ///   Gets the value of the node.
    /// </summary>
    /// <value>The value.</value>
    public string Value
    {
      get
      {
        return this.value;
      }
    }

    /// <summary>
    /// Returns the list associated with this node joined with the given list.
    /// </summary>
    /// <param name="tail">
    /// List to be added.
    /// </param>
    /// <returns>
    /// Joined list.
    /// </returns>
    public INode Added(IEnumerable<INode> tail)
    {
      this.List = this.SafeList.Joined(tail) as NodeList;
      return this;
    }

    /// <summary>
    ///   The head of the list, that is associated with the node,
    ///   or the node itself if there is no list associated with
    ///   the node.
    /// </summary>
    /// <value>
    ///   The head.
    /// </value>
    /// <returns>
    ///   The <see cref="INode" />.
    /// </returns>
    public INode GetHead()
    {
      return this.SafeList[0];
    }

    /// <summary>
    ///   Returns the node-value as an integer.
    /// </summary>
    /// <value>
    ///   The node-value as an integer.
    /// </value>
    /// <returns>
    ///   The <see cref="int" />.
    /// </returns>
    public int GetValueInt()
    {
      int result;

      if (int.TryParse(this.Value, out result))
      {
        return result;
      }

      return 0;
    }
  }
}