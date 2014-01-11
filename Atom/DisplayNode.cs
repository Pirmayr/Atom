// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisplayNode.cs" company="me">
//   me
// </copyright>
// <summary>
//   The display node.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Atom
{
  using Nodes;

  /// <summary>
  ///   The display node.
  /// </summary>
  internal class DisplayNode
  {
    /// <summary>
    ///   The node.
    /// </summary>
    private readonly INode node;

    /// <summary>
    /// Initializes a new instance of the <see cref="DisplayNode"/> class.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    public DisplayNode(INode node)
    {
      this.node = node;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    public string Value
    {
      get
      {
        return this.node.Value;
      }
    }
  }
}