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
  using System.Collections.Generic;
  using Nodes;

  /// <summary>
  ///   The Interpreter interface.
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
    /// Determines, if the given value is the name of a predefined atom.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <returns>
    /// If the value is the name of a predefined atom, then "true" is returned, otherwise "false".
    /// </returns>
    bool IsPredefinedAtom(string value);

    /// <summary>
    /// The predefined atoms.
    /// </summary>
    /// <returns>
    /// List of predefined atoms.
    /// </returns>
    IEnumerable<string> PredefinedAtoms();

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