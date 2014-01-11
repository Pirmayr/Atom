// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Host.cs" company="Me">
//   Copyright (c) Me. All rights reserved.
// </copyright>
// <summary>
//   Host for scripting.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Atom
{
  using System;
  using CSScriptLibrary;
  using Helpers;

  /// <summary>
  ///   Host for scripting.
  /// </summary>
  public sealed class Host : MarshalByRefObject, IDisposable
  {
    /// <summary>
    ///   The host-object being accessible by scripts.
    /// </summary>
    private static Host host;

    /// <summary>
    ///   Helper-object for executing scripts.
    /// </summary>
    private readonly AsmHelper assemblyHelper;

    /// <summary>
    /// Initializes a new instance of the <see cref="Host"/> class.
    /// </summary>
    /// <param name="form">
    /// The form.
    /// </param>
    /// <param name="interpreter">
    /// The interpreter.
    /// </param>
    public Host(MainForm form, Interpreter interpreter)
    {
      this.TheForm = form;
      this.TheInterpreter = interpreter;
      this.assemblyHelper = new AsmHelper(CSScript.Load(Utilities.FilePath("Script.cs", string.Empty), null, true));
    }

    /// <summary>
    ///   Gets or sets the form.
    /// </summary>
    /// <value>The form.</value>
    public MainForm TheForm { get; set; }

    /// <summary>
    ///   Gets or sets the interpreter.
    /// </summary>
    /// <value>The interpreter.</value>
    public Interpreter TheInterpreter { get; set; }

    /// <summary>
    ///   Gets the assembly-helper.
    /// </summary>
    /// <value>The helper.</value>
    private AsmHelper TheHelper
    {
      get
      {
        return this.assemblyHelper;
      }
    }

    /// <summary>
    ///   Invokes this instance.
    /// </summary>
    public static void Invoke()
    {
      host.TheHelper.Invoke("*." + host.TheInterpreter.Values.Pop().Value, host);
    }

    /// <summary>
    /// Runs the specified form and interpreter.
    /// </summary>
    /// <param name="form">
    /// The form.
    /// </param>
    /// <param name="interpreter">
    /// The interpreter.
    /// </param>
    public static void Run(MainForm form, Interpreter interpreter)
    {
      host = new Host(form, interpreter);
    }

    /// <summary>
    ///   Implements the "Dispose"-method of the "IDispose"-interface.
    /// </summary>
    public void Dispose()
    {
      this.assemblyHelper.Dispose();
    }
  }
}