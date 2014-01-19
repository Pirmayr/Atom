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
  public delegate void InvokeHostEventHandler(object sender, EventArgs e);

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
      this.Names.Push(NodesHelpers.NewNode(PreDefNames, NodesHelpers.NewNodeList(NodesHelpers.NewNode(this.Names))));
      this.Names.Push(NodesHelpers.NewNode(PreDefValues, NodesHelpers.NewNodeList(NodesHelpers.NewNode(this.Values))));
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
        INodeList tree = atom.Parse(code);

        if (tree == null)
        {
          return true;
        }

        this.Names.RemoveRange(2, this.Names.Count - 2);
        this.Names.Push(NodesHelpers.NewNode(PreDefProgram, NodesHelpers.NewNodeList(NodesHelpers.NewNode(tree))));
        this.Values.Clear();
        this.Evaluate(tree, true);
      }
      catch (Exception e)
      {
        Debug.Print(e.Message);
      }

      return false;
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
        INodeList tos;

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
            tos = this.Values.Pop(2);
            this.Values.PushInt(Compute(node.Value, tos[1].GetValueInt(), tos[0].GetValueInt()));
            break;
          case "=":
            tos = this.Values.Pop(2);
            this.Values.PushInt((tos[1].Value == tos[0].Value) ? 1 : 0);
            break;
          case "#":
            tos = this.Values.Pop(2);
            this.Values.PushInt((tos[1].Value != tos[0].Value) ? 1 : 0);
            break;
          case "call":
            this.InvokeHost(this, null);
            break;
          case "let":
            tos = this.Values.Pop(2);
            this.Names.PushName(tos);
            break;
          case "load":
            this.Values.Push(this.Names.ListAt(this.Values.Pop().GetHead().Value)[0]);
            break;
          case "if":
            tos = this.Values.Pop(3);
            this.Evaluate((tos[0].GetValueInt() == 0) ? tos[1].SafeList : tos[2].SafeList, false);
            break;
          case "unlocalize":
            oldNamesCount = this.Names.Count;
            break;
          case "listify":
            this.Values.Push(NodesHelpers.NewNode("(", this.Values.Pop(this.Values.Pop().GetValueInt(), true)));
            break;
          case "eval":
            this.Evaluate(this.Values.Pop().SafeList, true);
            break;
          default:
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

      if (!preserveLocalNames)
      {
        this.Names.RemoveRange(oldNamesCount, this.Names.Count - oldNamesCount);
      }
    }
  }
}