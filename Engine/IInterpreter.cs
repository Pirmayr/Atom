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
    ///   Gets the current program.
    /// </summary>
    /// <value>The values-stack.</value>
    INodeList Program { get; }

    /// <summary>
    /// Runs the current "atom"-code.
    /// </summary>
    /// <param name="code">
    /// The code to be run.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    bool Run(string code);
  }
}