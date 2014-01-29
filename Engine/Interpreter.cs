// --------------------------------------------------------------------------------------------------------------------
// <copyright company="me" file="Interpreter.cs">
//   me
// </copyright>
// <summary>
//   Interprets the parse-tree of an "atom"-program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Engine
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Diagnostics.Contracts;
  using System.Globalization;

  using Nodes;

  /// <summary>
  ///   The invoke host event handler.
  /// </summary>
  /// <param name="sender">
  ///   The sender.
  /// </param>
  /// <param name="e">
  ///   The e.
  /// </param>
  public delegate void InvokeHostEventHandler(object sender, InvokeHostEventArgs e);

  /// <summary>
  ///   Interprets the parse-tree of an "atom"-program.
  /// </summary>
  internal class Interpreter : IInterpreter
  {
    /// <summary>
    ///   The predefined name of names-stack.
    /// </summary>
    private const string PreDefNames = "names";

    /// <summary>
    ///   The predefined name of the program-list.
    /// </summary>
    private const string PreDefProgram = "program";

    /// <summary>
    ///   The predefined name of the values-stack.
    /// </summary>
    private const string PreDefValues = "values";

    /// <summary>
    ///   The names.
    /// </summary>
    private readonly INodeList names = NodesHelpers.NewNodeList();

    /// <summary>
    ///   The values.
    /// </summary>
    private readonly INodeList values = NodesHelpers.NewNodeList();

    /// <summary>
    ///   Initializes a new instance of the <see cref="Interpreter" /> class.
    ///   Constructor.
    /// </summary>
    public Interpreter()
    {
      this.Names.Push(NodesHelpers.NewNode(PreDefNames, NodesHelpers.NewNodeList(NodesHelpers.NewNode("<", this.Names))));
      this.Names.Push(NodesHelpers.NewNode(PreDefValues, NodesHelpers.NewNodeList(NodesHelpers.NewNode("<", this.Values))));
    }

    /// <summary>
    ///   See interface.
    /// </summary>
    public event InvokeHostEventHandler InvokeHost;

    /// <summary>
    ///   Gets value (see interface).
    /// </summary>
    /// <value>The names-stack.</value>
    public INodeList Names
    {
      get
      {
        return this.names;
      }
    }

    /// <summary>
    /// Gets the program.
    /// </summary>
    public INodeList Program { get; private set; }

    /// <summary>
    ///   Gets value (see interface).
    /// </summary>
    /// <value>The values-stack.</value>
    public INodeList Values
    {
      get
      {
        return this.values;
      }
    }

    /// <summary>
    /// See interface.
    /// </summary>
    /// <param name="code">
    /// See interface for parameter "code".
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public bool Run(string code)
    {
      Contract.Assume(2 <= this.Names.Count, "Upon execution at least 2 elements are expected on the names-stack");

      try
      {
        Parser atom = new Parser();

        this.Program = atom.Parse(code);

        if (this.Program == null)
        {
          return true;
        }

        this.Names.RemoveRange(2, this.Names.Count - 2);
        this.Names.Push(NodesHelpers.NewNode(PreDefProgram, NodesHelpers.NewNodeList(NodesHelpers.NewNode("<", this.Program))));
        this.Values.Clear();
        this.Evaluate(this.Program, true);
      }
      catch (Exception e)
      {
        Debug.Print(e.Message);
      }

      return true;
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
    private static int Compute(string operation, int opA, int opB)
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
    /// Actually evaluate the specified parse-tree.
    /// </summary>
    /// <param name="tree">
    /// The parse-tree.
    /// </param>
    /// <param name="preserveLocalNames">
    /// If "true", all locally defined names are preserved after the end of evaluation, if
    ///   "false" they are deleted.
    /// </param>
    private void Evaluate(IEnumerable<INode> tree, bool preserveLocalNames)
    {
      Contract.Requires(tree != null, "Cannot evaluate null-pointer");

      int oldNamesCount = this.Names.Count;

      foreach (INode node in tree)
      {
        switch (node.Value)
        {
          case "+":
          case "-":
          case "*":
          case "/":
          case "<":
          case "<=":
          case ">":
          case ">=":
            {
              INodeList tos = this.Values.Pop(2);
              this.Values.PushInt(Compute(node.Value, tos[1].GetValueInt(), tos[0].GetValueInt()));
              break;
            }

          case "=":
            {
              INodeList tos = this.Values.Pop(2);
              this.Values.PushInt((tos[1].Value == tos[0].Value) ? 1 : 0);
              break;
            }

          case "#":
            {
              INodeList tos = this.Values.Pop(2);
              this.Values.PushInt((tos[1].Value != tos[0].Value) ? 1 : 0);
              break;
            }

          case "Show":
            {
              this.InvokeHost(this, new InvokeHostEventArgs(this.Values.Pop().Value));
              break;
            }

          case "ShowLine":
            {
              this.InvokeHost(this, new InvokeHostEventArgs(this.Values.Pop().Value + Environment.NewLine));
              break;
            }

          case "Let":
            {
              INodeList tos = this.Values.Pop(2);
              this.Names.PushName(tos);
              break;
            }

          case "load":
            {
              INodeList loadedList = this.Names.ListAt(this.Values.Pop().GetHead().Value);

              if ((loadedList != null) && (0 < loadedList.Count))
              {
                this.Values.Push(loadedList[0]);
              }
              else
              {
                this.Values.Push(NodesHelpers.NewNode(string.Empty));
              }

              break;
            }

          case "if":
            {
              INodeList tos = this.Values.Pop(3);
              this.Evaluate((tos[0].GetValueInt() == 0) ? tos[1].SafeList : tos[2].SafeList, false);
              break;
            }

          case "unlocalize":
            {
              oldNamesCount = this.Names.Count;
              break;
            }

          case "listify":
            {
              this.Values.Push(NodesHelpers.NewNode("(", this.Values.Pop(this.Values.Pop().GetValueInt(), true)));
              break;
            }

          case "evaluate":
            {
              this.Evaluate(this.Values.Pop().SafeList, true);
              break;
            }

          case "islist":
            {
              this.Values.PushInt((this.Values.Pop().List == null) ? 0 : 1);
              break;
            }

          case "clone":
            {
              this.Values.Push(NodesHelpers.NewNode(this.Values.Pop().SafeList.Clone()));
              break;
            }

          case "Size":
            {
              INodeList tos = this.Values.Pop(1);
              this.Values.PushInt(tos[0].SafeList.Count);
              break;
            }

          case "Modulo":
            {
              string tos0 = this.Values.Pop().Value;
              string tos1 = this.Values.Pop().Value;
              int result = int.Parse(tos1) % int.Parse(tos0);
              this.Values.Push(NodesHelpers.NewNode(result.ToString(CultureInfo.InvariantCulture)));
              break;
            }

          case "systemglue":
            {
              string tos0 = this.Values.Pop().Value;
              string tos1 = this.Values.Pop().Value;
              string result = tos1 + tos0;
              this.Values.Push(NodesHelpers.NewNode(result));
              break;
            }

          case "systemtrim":
            {
              string previousTos = this.Values.Pop().Value;
              string currentTos = previousTos.Replace("  ", " ");

              while (!currentTos.Equals(previousTos))
              {
                previousTos = currentTos;
                currentTos = previousTos.Replace("  ", " ");
              }

              currentTos = currentTos.Trim();
              this.Values.Push(NodesHelpers.NewNode(currentTos));
              break;
            }

          case "systemitem":
            {
              INodeList tos = this.Values.Pop(2);
              this.Values.Push(tos[1].SafeList.ItemAt(tos[0].GetValueInt()));
              break;
            }

          case "Join":
            {
              INodeList tos = this.Values.Pop(2);
              this.Values.Push(tos[1].Added(tos[0].SafeList));
              break;
            }

          default:
            {
              INodeList list = this.Names.ListAt(node.Value);

              if (list == null)
              {
                this.Values.Push(node);
              }
              else
              {
                this.Evaluate(list[0].SafeList, false);
              }

              break;
            }
        }
      }

      if (!preserveLocalNames)
      {
        this.Names.RemoveRange(oldNamesCount, this.Names.Count - oldNamesCount);
      }
    }
  }
}