// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PredefinedAtoms.cs" company="me">
//   me
// </copyright>
// <summary>
//   The predefined atoms.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Engine
{
  using System;
  using System.Globalization;
  using Nodes;

  /// <summary>
  ///   The predefined atoms.
  /// </summary>
  internal class PredefinedAtoms
  {
    /// <summary>
    ///   The interpreter.
    /// </summary>
    private readonly Interpreter interpreter;

    /// <summary>
    /// Initializes a new instance of the <see cref="PredefinedAtoms"/> class.
    /// </summary>
    /// <param name="interpreter">
    /// The interpreter.
    /// </param>
    public PredefinedAtoms(Interpreter interpreter)
    {
      this.interpreter = interpreter;
    }

    /// <summary>
    /// Perform tos-1 + tos-0 and put result on the stack.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Add(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);
      this.interpreter.Values.PushInt(tos[1].GetValueInt() + tos[0].GetValueInt());
    }

    /// <summary>
    /// The clear.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Clear(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList list = this.interpreter.Values.Pop().SafeList;

      list.Clear();
      this.interpreter.Values.Push(NodesHelpers.NewNode("(", list));
    }

    /// <summary>
    /// The clone.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Clone(INode node, ref int namesCount, ref int currentElementIndex)
    {
      this.interpreter.Values.Push(NodesHelpers.NewNode(this.interpreter.Values.Pop().SafeList.Clone()));
    }

    /// <summary>
    /// Perform tos-1 / tos-0 and put result on the stack.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Div(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);
      this.interpreter.Values.PushInt(tos[1].GetValueInt() / tos[0].GetValueInt());
    }

    /// <summary>
    /// The equals.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Equals(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);
      this.interpreter.Values.PushInt((tos[1].Value == tos[0].Value) ? 1 : 0);
    }

    /// <summary>
    /// The evaluate.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Evaluate(INode node, ref int namesCount, ref int currentElementIndex)
    {
      this.interpreter.Evaluate(this.interpreter.Values.Pop().SafeList, true);
    }

    /// <summary>
    /// The system glue.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Glue(INode node, ref int namesCount, ref int currentElementIndex)
    {
      string tos0 = this.interpreter.Values.Pop().Value;
      string tos1 = this.interpreter.Values.Pop().Value;
      string result = tos1 + tos0;
      this.interpreter.Values.Push(NodesHelpers.NewNode(result));
    }

    /// <summary>
    /// The if.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void If(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(3);
      this.interpreter.Evaluate((tos[0].GetValueInt() == 0) ? tos[1].SafeList : tos[2].SafeList, false);
    }

    /// <summary>
    /// If tos-1 is greater than tos-0 then 1 is put on the stack, otherwise 0 is put on the stack.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void IsGreater(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);
      this.interpreter.Values.PushInt((tos[1].GetValueInt() > tos[0].GetValueInt()) ? 1 : 0);
    }

    /// <summary>
    /// If tos-1 is greater or equal to tos-0 then 1 is put on the stack, otherwise 0 is put on the stack.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void IsGreaterOrEqual(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);
      this.interpreter.Values.PushInt((tos[1].GetValueInt() >= tos[0].GetValueInt()) ? 1 : 0);
    }

    /// <summary>
    /// If tos-1 is less than tos-0 then 1 is put on the stack, otherwise 0 is put on the stack.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void IsLess(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);
      this.interpreter.Values.PushInt((tos[1].GetValueInt() < tos[0].GetValueInt()) ? 1 : 0);
    }

    /// <summary>
    /// If tos-1 is less or equal to tos-0 then 1 is put on the stack, otherwise 0 is put on the stack.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void IsLessOrEqual(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);
      this.interpreter.Values.PushInt((tos[1].GetValueInt() <= tos[0].GetValueInt()) ? 1 : 0);
    }

    /// <summary>
    /// The is list.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void IsList(INode node, ref int namesCount, ref int currentElementIndex)
    {
      this.interpreter.Values.PushInt((this.interpreter.Values.Pop().List == null) ? 0 : 1);
    }

    /// <summary>
    /// The system item.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Item(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);
      this.interpreter.Values.Push(tos[1].SafeList[tos[0].GetValueInt()]);
    }

    /// <summary>
    /// The join.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Join(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);

      this.interpreter.Values.Push(tos[1].Added(tos[0].SafeList));
    }

    /// <summary>
    /// The let.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Let(INode node, ref int namesCount, ref int currentElementIndex)
    {
      foreach (INode currentName in this.interpreter.Values.Pop().SafeList)
      {
        INodeList currentStack = NodesHelpers.NewNodeList();

        currentStack.AddElement(NodesHelpers.NewNode(currentName.SafeList));
        currentStack.AddElement(this.interpreter.Values.Pop());
        this.interpreter.Names.PushName(currentStack, namesCount);
      }
    }

    /// <summary>
    /// Converts items on the top of stack to a list.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Listify(INode node, ref int namesCount, ref int currentElementIndex)
    {
      this.interpreter.Values.Push(NodesHelpers.NewNode("(", this.interpreter.Values.Pop(this.interpreter.Values.Pop().GetValueInt(), true)));
    }

    /// <summary>
    /// The load.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Load(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList loadedList = this.interpreter.Names.ListAt(this.interpreter.Values.Pop().GetHead().Value);

      if ((loadedList != null) && (0 < loadedList.Count))
      {
        this.interpreter.Values.Push(loadedList[0]);
      }
      else
      {
        this.interpreter.Values.Push(NodesHelpers.NewNode(string.Empty));
      }
    }

    /// <summary>
    /// The modulo.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Modulo(INode node, ref int namesCount, ref int currentElementIndex)
    {
      string tos0 = this.interpreter.Values.Pop().Value;
      string tos1 = this.interpreter.Values.Pop().Value;
      int result = int.Parse(tos1) % int.Parse(tos0);
      this.interpreter.Values.Push(NodesHelpers.NewNode(result.ToString(CultureInfo.InvariantCulture)));
    }

    /// <summary>
    /// Perform tos-1 * tos-0 and put result on the stack.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Mul(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);
      this.interpreter.Values.PushInt(tos[1].GetValueInt() * tos[0].GetValueInt());
    }

    /// <summary>
    /// The not equals.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void NotEquals(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);
      this.interpreter.Values.PushInt((tos[1].Value != tos[0].Value) ? 1 : 0);
    }

    /// <summary>
    /// In the list at tos-2 put node at tos-1 to the place at index tos-0.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Push(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(3);
      tos[2].SafeList[tos[1].GetValueInt()] = tos[0];
    }

    /// <summary>
    /// The repeat if.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current element index.
    /// </param>
    public void RepeatIf(INode node, ref int namesCount, ref int currentElementIndex)
    {
      if (this.interpreter.Values.Pop().GetValueInt() != 0)
      {
        currentElementIndex = 0;
      }
    }

    /// <summary>
    /// The get.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Set(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);
      this.interpreter.Names.PushName(tos, 0);
    }

    /// <summary>
    /// The show.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Show(INode node, ref int namesCount, ref int currentElementIndex)
    {
      this.interpreter.FireInvokeHost(this.interpreter.Values.Pop().Value);
    }

    /// <summary>
    /// The show line.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void ShowLine(INode node, ref int namesCount, ref int currentElementIndex)
    {
      this.interpreter.FireInvokeHost(this.interpreter.Values.Pop().Value + Environment.NewLine);
    }

    /// <summary>
    /// The size.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names Count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Size(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(1);
      this.interpreter.Values.PushInt(tos[0].SafeList.Count);
    }

    /// <summary>
    /// Perform tos-1 - tos-0 and put result on the stack.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    /// <param name="namesCount">
    /// The names count.
    /// </param>
    /// <param name="currentElementIndex">
    /// The current Element Index.
    /// </param>
    public void Sub(INode node, ref int namesCount, ref int currentElementIndex)
    {
      INodeList tos = this.interpreter.Values.Pop(2);
      this.interpreter.Values.PushInt(tos[1].GetValueInt() - tos[0].GetValueInt());
    }
  }
}