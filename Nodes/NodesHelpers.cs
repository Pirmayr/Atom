// --------------------------------------------------------------------------------------------------------------------
// <copyright company="me" file="NodesHelpers.cs">
//   me
// </copyright>
// <summary>
//   Description of MyClass.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Nodes
{
  using System.Collections.Generic;

  /// <summary>
  ///   Description of MyClass.
  /// </summary>
  public static class NodesHelpers
  {
    /// <summary>
    /// Initializes a new node.
    /// </summary>
    /// <param name="value">
    /// The value of the node.
    /// </param>
    /// <returns>
    /// The <see cref="INode"/>.
    /// </returns>
    public static INode NewNode(string value)
    {
      return new Node(value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class.
    /// </summary>
    /// <param name="list">
    /// The list, that is associated with the node.
    /// </param>
    /// <returns>
    /// The <see cref="INode"/>.
    /// </returns>
    public static INode NewNode(IEnumerable<INode> list)
    {
      return new Node(list as NodeList);
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
    /// <returns>
    /// The <see cref="INode"/>.
    /// </returns>
    public static INode NewNode(string value, IEnumerable<INode> list)
    {
      return new Node(value, list as NodeList);
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="NodeList" /> class.
    /// </summary>
    /// <returns>
    ///   The <see cref="INodeList" />.
    /// </returns>
    public static INodeList NewNodeList()
    {
      return new NodeList();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NodeList"/> class.
    /// </summary>
    /// <param name="node">
    /// First node to initialize the list with.
    /// </param>
    /// <returns>
    /// The <see cref="INodeList"/>.
    /// </returns>
    public static IEnumerable<INode> NewNodeList(INode node)
    {
      return new NodeList(node);
    }
  }
}