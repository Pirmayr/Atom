// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INode.cs" company="me">
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
  public interface INode
  {
    /// <summary>
    ///   Gets or sets the list, that is associated with the node.
    /// </summary>
    /// <value>The list.</value>
    INodeList List { get; set; }

    /// <summary>
    ///   Gets either the list, that is associated with the node,
    ///   or, if no list is associated with the node,
    ///   the node itself wrapped in a list.
    /// </summary>
    /// <value>The list.</value>
    INodeList SafeList { get; }

    /// <summary>
    ///   Gets or sets the value of the node.
    /// </summary>
    /// <value>The value.</value>
    string Value { get; set; }

    /// <summary>
    /// The head of the list, that is associated with the node,
    ///   or the node itself if there is no list associated with
    ///   the node.
    /// </summary>
    /// <value>
    /// The head.
    /// </value>
    /// <returns>
    /// The <see cref="INode"/>.
    /// </returns>
    INode GetHead();

    /// <summary>
    /// Gets the value of the head of the list associated with the node, if any.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    int GetValueInt();

    /// <summary>
    /// Returns the list associated with this node joined with the given list.
    /// </summary>
    /// <param name="list">
    /// List to be added.
    /// </param>
    /// <returns>
    /// Joined list.
    /// </returns>
    INode Added(INodeList list);
  }
}