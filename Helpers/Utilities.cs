// --------------------------------------------------------------------------------------------------------------------
// <copyright company="me" file="Utilities.cs">
//   me
// </copyright>
// <summary>
//   Miscellaneous helper-methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Helpers
{
  #region

  using System;
  using System.Collections.Generic;
  using System.Diagnostics.Contracts;
  using System.IO;
  using System.Linq;
  using System.Windows.Forms;

  #endregion

  /// <summary>
  ///   Miscellaneous helper-methods.
  /// </summary>
  public static class Utilities
  {
    /// <summary>
    /// Checks the specified condition.
    /// </summary>
    /// <param name="condition">
    /// If set to <c>false</c> an exception is thrown.
    /// </param>
    /// <returns>
    /// The value of the parameter "cond".
    /// </returns>
    public static bool Check(bool condition)
    {
      if (!condition)
      {
        throw new ArgumentException("Assertion failed");
      }

      return true;
    }

    /// <summary>
    ///   Returns the concatenated code of all "atom"-files delivered by "CollectFiles".
    /// </summary>
    /// <returns>
    ///   The concatenated code.
    /// </returns>
    public static string CollectCode()
    {
      return CollectFiles(new[] { "atm" }).Aggregate(string.Empty, (result, currentFile) => result + File.ReadAllText(currentFile) + "\r\n");
    }

    /// <summary>
    /// The collect directory items.
    /// </summary>
    /// <param name="directory">
    /// The directory.
    /// </param>
    /// <returns>
    /// The directory items.
    /// </returns>
    public static ICollection<string> CollectDirectoryItems(string directory)
    {
      List<string> result = new List<string>();

      foreach (string curItem in Directory.GetDirectories(directory))
      {
        result.AddRange(CollectDirectoryItems(curItem + "\\"));
      }

      result.AddRange(Directory.GetFiles(directory));

      return result;
    }

    /// <summary>
    /// Collect filenames with given extensions in certain standard directories.
    /// </summary>
    /// <param name="extensions">
    /// Allowed extensions.
    /// </param>
    /// <returns>
    /// The filenames found.
    /// </returns>
    public static ICollection<string> CollectFiles(string[] extensions)
    {
      Contract.Requires(extensions != null);
      
      ICollection<string> items = CollectDirectoryItems(Application.StartupPath + "\\..\\");
      List<string> result = new List<string>();

      FilterFilesByExtension(items, extensions, result);

      return result;
    }

    /// <summary>
    /// Performs computation according to the specified operation and parameters.
    /// </summary>
    /// <param name="operation">
    /// The operation.
    /// </param>
    /// <param name="opA">
    /// Operand a.
    /// </param>
    /// <param name="opB">
    /// Operand b.
    /// </param>
    /// <returns>
    /// Result of the computation.
    /// </returns>
    public static int Compute(string operation, int opA, int opB)
    {
      int result = 0;

      switch (operation)
      {
        case "+":
          result = opA + opB;
          break;
        case "-":
          result = opA - opB;
          break;
        case "*":
          result = opA * opB;
          break;
        case "/":
          result = opA / opB;
          break;
        case "=":
          result = (opA == opB) ? 1 : 0;
          break;
        case "#":
          result = (opA != opB) ? 1 : 0;
          break;
        case "<":
          result = (opA < opB) ? 1 : 0;
          break;
        case "<=":
          result = (opA <= opB) ? 1 : 0;
          break;
        case ">":
          result = (opA > opB) ? 1 : 0;
          break;
        case ">=":
          result = (opA >= opB) ? 1 : 0;
          break;
      }

      return result;
    }

    /// <summary>
    /// Searches for the specified file.
    /// </summary>
    /// <param name="fileSpecification">
    /// File to be searched for.
    /// </param>
    /// <param name="defaultValue">
    /// Default value.
    /// </param>
    /// <returns>
    /// The path to the file or the default path, if the file could not be found.
    /// </returns>
    public static string FilePath(string fileSpecification, string defaultValue)
    {
      string testPath = fileSpecification;

      if (!File.Exists(testPath))
      {
        string fileName = Path.GetFileName(fileSpecification);

        testPath = Application.StartupPath + "\\" + fileName;

        if (!File.Exists(testPath))
        {
          testPath = Application.StartupPath + "\\..\\" + fileName;

          if (!File.Exists(testPath))
          {
            testPath = defaultValue;
          }
        }
      }

      return testPath;
    }

    /// <summary>
    /// Reads an entire text-file and returns contents as a string.
    /// </summary>
    /// <param name="filePath">
    /// Path of the file to be read.
    /// </param>
    /// <returns>
    /// The content of the file.
    /// </returns>
    public static string ReadFile(string filePath)
    {
      return string.IsNullOrEmpty(filePath = FilePath(filePath, string.Empty)) ? string.Empty : File.ReadAllText(filePath);
    }

    /// <summary>
    /// Writes text to file
    /// </summary>
    /// <param name="filePath">
    /// The file-path.
    /// </param>
    /// <param name="txt">
    /// The text to be written.
    /// </param>
    public static void WriteFile(string filePath, string txt)
    {
      File.WriteAllText(FilePath(filePath, filePath), txt);
    }

    /// <summary>
    /// Filters filenames by extensions.
    /// </summary>
    /// <param name="files">
    /// Filenames to be filtered.
    /// </param>
    /// <param name="extensions">
    /// Allowed extensions.
    /// </param>
    /// <param name="result">
    /// All Filenames having one of the allowed extensions.
    /// </param>
    private static void FilterFilesByExtension(IEnumerable<string> files, IEnumerable<string> extensions, ICollection<string> result)
    {
      Contract.Requires(files != null);
      Contract.Requires(extensions != null);
      
      foreach (string curFile in files)
      {
        foreach (string curExtension in extensions)
        {
          if (curFile.EndsWith(curExtension, StringComparison.OrdinalIgnoreCase))
          {
            result.Add(curFile);
          }
        }
      }
    }
  }
}