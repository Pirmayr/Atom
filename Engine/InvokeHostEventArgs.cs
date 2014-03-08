// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvokeHostEventArgs.cs" company="me">
//   me
// </copyright>
// <summary>
//   The invoke host event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Engine
{
  /// <summary>
  ///   The invoke host event args.
  /// </summary>
  public class InvokeHostEventArgs
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="InvokeHostEventArgs"/> class.
    /// </summary>
    /// <param name="message">
    /// The message.
    /// </param>
    public InvokeHostEventArgs(string message)
    {
      this.Message = message;
    }

    /// <summary>
    ///   Gets the message to be shown.
    /// </summary>
    public string Message { get; private set; }
  }
}