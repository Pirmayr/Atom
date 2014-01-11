// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="me">
//   me
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Atom
{
  using System;
  using System.Windows.Forms;

  /// <summary>
  ///   The program.
  /// </summary>
  public static class Program
  {
    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}