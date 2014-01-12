// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineHelpers.cs" company="me">
//   me  
// </copyright>
// <summary>
//   The engine helpers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Engine
{
  /// <summary>
  /// The engine helpers.
  /// </summary>
  public class EngineHelpers
  {
    /// <summary>
    /// The new interpreter.
    /// </summary>
    /// <returns>
    /// The <see cref="IInterpreter"/>.
    /// </returns>
    public static IInterpreter NewInterpreter()
    {
      return new Interpreter();
    }
  }
}