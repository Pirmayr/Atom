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
    ///   The list.
    /// </summary>
    private NodeList list;

    /// <summary>
    ///   The value.
    /// </summary>
    private string value = string.Empty;

    /// <summary>
    ///   Initializes a new instance of the <see cref="Node" /> class.
    /// </summary>
    public Node()
    {
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
    }

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
          result = new NodeList { IsSafeList = true };
          result.AddElement(this);
        }

        return result;
      }
    }

    /// <summary>
    ///   Gets or sets the value of the node.
    /// </summary>
    /// <value>The value.</value>
    public string Value
    {
      get
      {
        return this.value;
      }

      set
      {
        this.value = value;
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
    public INode Added(INodeList tail)
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