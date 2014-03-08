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
  public delegate void InvokeHostEventHandler(object sender, InvokeHostEventArgs e);

  /// <summary>
  ///   The handle predefined atom delegate.
  /// </summary>
  /// <param name="node">The currently evaluated node.</param>
  /// <param name="namesCount">
  ///   Number of named items at the beginning of the current block.
  /// </param>
  /// <param name="currentElementIndex">
  ///   The index of the current element of the currently evaluated block.
  /// </param>
  public delegate void PredefinedAtomHandler(INode node, ref int namesCount, ref int currentElementIndex);

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
    ///   The predefined atom delegates.
    /// </summary>
    private readonly Dictionary<string, PredefinedAtomHandler> predefinedAtomDelegates = new Dictionary<string, PredefinedAtomHandler>();

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
      PredefinedAtoms predefinedAtoms = new PredefinedAtoms(this);

      this.predefinedAtomDelegates.Add("#", predefinedAtoms.NotEquals);
      this.predefinedAtomDelegates.Add("=", predefinedAtoms.Equals);
      this.predefinedAtomDelegates.Add("<", predefinedAtoms.IsLess);
      this.predefinedAtomDelegates.Add("<=", predefinedAtoms.IsLessOrEqual);
      this.predefinedAtomDelegates.Add(">", predefinedAtoms.IsGreater);
      this.predefinedAtomDelegates.Add(">=", predefinedAtoms.IsGreaterOrEqual);
      this.predefinedAtomDelegates.Add("Clear", predefinedAtoms.Clear);
      this.predefinedAtomDelegates.Add("Clone", predefinedAtoms.Clone);
      this.predefinedAtomDelegates.Add("Evaluate", predefinedAtoms.Evaluate);
      this.predefinedAtomDelegates.Add("Set", predefinedAtoms.Set);
      this.predefinedAtomDelegates.Add("Glue", predefinedAtoms.Glue);
      this.predefinedAtomDelegates.Add("If", predefinedAtoms.If);
      this.predefinedAtomDelegates.Add("IsList", predefinedAtoms.IsList);
      this.predefinedAtomDelegates.Add("Item", predefinedAtoms.Item);
      this.predefinedAtomDelegates.Add("Join", predefinedAtoms.Join);
      this.predefinedAtomDelegates.Add("Let", predefinedAtoms.Let);
      this.predefinedAtomDelegates.Add("Listify", predefinedAtoms.Listify);
      this.predefinedAtomDelegates.Add("Load", predefinedAtoms.Load);
      this.predefinedAtomDelegates.Add("Modulo", predefinedAtoms.Modulo);
      this.predefinedAtomDelegates.Add("Show", predefinedAtoms.Show);
      this.predefinedAtomDelegates.Add("ShowLine", predefinedAtoms.ShowLine);
      this.predefinedAtomDelegates.Add("Size", predefinedAtoms.Size);
      this.predefinedAtomDelegates.Add("Add", predefinedAtoms.Add);
      this.predefinedAtomDelegates.Add("Sub", predefinedAtoms.Sub);
      this.predefinedAtomDelegates.Add("Mul", predefinedAtoms.Mul);
      this.predefinedAtomDelegates.Add("Div", predefinedAtoms.Div);
      this.predefinedAtomDelegates.Add("Push", predefinedAtoms.Push);
      this.predefinedAtomDelegates.Add("RepeatIf", predefinedAtoms.RepeatIf);

      this.Names.Push(NodesHelpers.NewNode(PreDefNames, NodesHelpers.NewNodeList(NodesHelpers.NewNode("<", this.Names))));
      this.Names.Push(NodesHelpers.NewNode(PreDefValues, NodesHelpers.NewNodeList(NodesHelpers.NewNode("<", this.Values))));
    }

    /// <summary>
    ///   See interface.
    /// </summary>
    public event InvokeHostEventHandler InvokeHost;

    /// <summary>
    ///   Gets some value (see interface).
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
    ///   Gets list of values (stack).
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
    /// Actually evaluate the specified parse-tree.
    /// </summary>
    /// <param name="tree">
    /// The parse-tree.
    /// </param>
    /// <param name="preserveLocalNames">
    /// If "true", all locally defined names are preserved after the end of evaluation, if "false" they are deleted.
    /// </param>
    public void Evaluate(INodeList tree, bool preserveLocalNames)
    {
      Contract.Requires(tree != null, "Cannot evaluate null-pointer");

      ClearCachedNodes(tree);

      int oldNamesCount = this.Names.Count;
      bool firstLoop = true;
      bool useNodeCache = false;
      int currentIndex = 0;

      while (currentIndex < tree.Count)
      {
        if (currentIndex == 0)
        {
          if (firstLoop)
          {
            firstLoop = false;
          }
          else
          {
            useNodeCache = true;
          }
        }

        INode node = tree[currentIndex++];
        string currentValue = node.Value;

        if (this.predefinedAtomDelegates.ContainsKey(currentValue))
        {
          this.predefinedAtomDelegates[node.Value](node, ref oldNamesCount, ref currentIndex);
        }
        else
        {
          INodeList list = null;

          if (currentValue != "(")
          {
            INode foundNode;

            if (useNodeCache)
            {
              foundNode = node.CachedNode ?? this.names.NodeAt(currentValue);
              node.CachedNode = foundNode;
            }
            else
            {
              foundNode = this.Names.NodeAt(currentValue);
            }

            if (foundNode != null)
            {
              list = foundNode.List;
            }
          }

          if (list == null)
          {
            this.Values.Push(node);
          }
          else
          {
            this.Evaluate(list[0].SafeList, false);
          }
        }
      }

      if (!preserveLocalNames)
      {
        this.Names.RemoveRange(oldNamesCount, this.Names.Count - oldNamesCount);
      }

      ClearCachedNodes(tree);
    }

    /// <summary>
    /// The fire invoke host.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    public void FireInvokeHost(string value)
    {
      this.InvokeHost(this, new InvokeHostEventArgs(value));
    }

    /// <summary>
    /// The is predefined atom.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public bool IsPredefinedAtom(string value)
    {
      return this.predefinedAtomDelegates.ContainsKey(value);
    }

    /// <summary>
    ///   The predefined atoms.
    /// </summary>
    /// <returns>
    ///   The Collection of predefined atoms.
    /// </returns>
    public IEnumerable<string> PredefinedAtoms()
    {
      return this.predefinedAtomDelegates.Keys;
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
        INodeList program = atom.Parse(code);

        if (program == null)
        {
          return true;
        }

        this.Names.RemoveRange(2, this.Names.Count - 2);
        this.Names.Push(NodesHelpers.NewNode(PreDefProgram, NodesHelpers.NewNodeList(NodesHelpers.NewNode("<", program))));
        this.Values.Clear();

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        this.Evaluate(program, true);
        stopwatch.Stop();
        this.FireInvokeHost(string.Format("Program run in {0} ms", stopwatch.ElapsedMilliseconds));
      }
      catch (Exception e)
      {
        Debug.Print(e.Message);
      }

      return true;
    }

    /// <summary>
    /// The clear cached nodes.
    /// </summary>
    /// <param name="tree">
    /// The tree.
    /// </param>
    private static void ClearCachedNodes(IEnumerable<INode> tree)
    {
      foreach (INode currentNode in tree)
      {
        currentNode.CachedNode = null;
      }
    }
  }
}