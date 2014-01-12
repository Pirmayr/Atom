// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInterpreter.cs" company="me">
//   me  
// </copyright>
// <summary>
//   The Interpreter interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Engine
{
  using Nodes;

  /// <summary>
  /// The Interpreter interface.
  /// </summary>
  public interface IInterpreter
  {
    /// <summary>
    ///   The "InvokeHost" event.
    /// </summary>
    event InvokeHostEventHandler InvokeHost;

    /// <summary>
    ///   Gets the names-stack.
    /// </summary>
    /// <value>The names-stack.</value>
    INodeList Names { get; }

    /// <summary>
    ///   Gets the values-stack.
    /// </summary>
    /// <value>The values-stack.</value>
    INodeList Values { get; }

    /// <summary>
    ///   Runs the current "atom"-code.
    /// </summary>
    /// <returns>
    ///   The <see cref="bool" />.
    /// </returns>
    bool Run();
  }
}