// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeList.cs" company="me">
//   me
// </copyright>
// <summary>
//   A list of nodes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Nodes
{
  using System.Collections.Generic;
  using System.Diagnostics.Contracts;
  using System.Globalization;

  /// <summary>
  ///   A list of nodes.
  /// </summary>
  internal class NodeList : List<Node>, INodeList
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="NodeList" /> class.
    /// </summary>
    public NodeList()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NodeList"/> class.
    /// </summary>
    /// <param name="node">
    /// First node to initialize the list with.
    /// </param>
    public NodeList(INode node)
    {
      this.AddElement(node as Node);
    }

    /// <summary>
    /// Indexer for this list. If the index is out of range, a new empty node is returned.
    /// </summary>
    /// <param name="index">
    /// The index.
    /// </param>
    /// <returns>
    /// The node at the given index.
    /// </returns>
    public new INode this[int index]
    {
      get
      {
        return ((0 <= index) && (index < this.Count)) ? base[index] : new Node();
      }

      set
      {
        if ((0 <= index) && (index < this.Count))
        {
          base[index] = (Node)value;
        }
      }
    }

    /// <summary>
    /// The add.
    /// </summary>
    /// <param name="node">
    /// The node.
    /// </param>
    public void AddElement(INode node)
    {
      this.Add(node as Node);
    }

    /// <summary>
    ///   Summary see interface.
    /// </summary>
    /// <returns>
    ///   Return value see interface.
    /// </returns>
    public IEnumerable<INode> Clone()
    {
      return this.MemberwiseClone() as INodeList;
    }

    /// <summary>
    ///   The get enumerator.
    /// </summary>
    /// <returns>
    ///   The enumerator>.
    /// </returns>
    public new IEnumerator<INode> GetEnumerator()
    {
      return base.GetEnumerator();
    }

    /// <summary>
    /// Add given list to this list and returns the joined result.
    /// </summary>
    /// <param name="list">
    /// List to be added to this list.
    /// </param>
    /// <returns>
    /// Joined list.
    /// </returns>
    public INodeList Joined(IEnumerable<INode> list)
    {
      NodeList actualList = list as NodeList;

      if (actualList != null)
      {
        this.AddRange(actualList);
      }

      return this;
    }

    /// <summary>
    /// Searches for the element identified by the specified name.
    /// </summary>
    /// <param name="name">
    /// The name of the element.
    /// </param>
    /// <param name="limit">
    /// The limit.
    /// </param>
    /// <returns>
    /// List ("null" if no list could be found).
    /// </returns>
    /// <remarks>
    /// The element is searched downwards from the top of stack.
    /// </remarks>
    public INodeList ListAt(string name, int limit = 0)
    {
      INode node = this.NodeAt(name, limit);

      return (node == null) ? null : node.List;
    }

    /// <summary>
    /// See interface.
    /// </summary>
    /// <param name="name">
    /// Name: See interface.
    /// </param>
    /// <param name="limit">
    /// The limit.
    /// </param>
    /// <returns>
    /// Return value: See interface.
    /// </returns>
    public INode NodeAt(string name, int limit = 0)
    {
      int index = this.FindLastIndex(this.Count - 1, this.Count - limit, x => x.Value == name);

      return (0 <= index) ? this[index] : null;
    }

    /// <summary>
    /// Removes multiple items from the top of stack and returns them as a list.
    /// </summary>
    /// <param name="count">
    /// The number of items.
    /// </param>
    /// <param name="reverse">
    /// If "true" the list will be reversed, otherwise the order remains unchanged.
    /// </param>
    /// <returns>
    /// Items list.
    /// </returns>
    public INodeList Pop(int count, bool reverse = false)
    {
      Contract.Assume(count <= this.Count);

      NodeList result = new NodeList();

      for (int i = 0; i < count; ++i)
      {
        result.AddElement(this.Pop() as Node);
      }

      if (reverse)
      {
        result.Reverse();
      }

      return result;
    }

    /// <summary>
    ///   Removes the element on the top of stack.
    /// </summary>
    /// <returns>
    ///   The element on the top of stack.
    /// </returns>
    public INode Pop()
    {
      Contract.Assume(0 < this.Count);

      int upperBound = this.Count - 1;
      INode result = this[upperBound];

      this.RemoveAt(upperBound);

      return result;
    }

    /// <summary>
    /// Places specified element onto the top of stack.
    /// </summary>
    /// <param name="node">
    /// The node to be pushed.
    /// </param>
    public void Push(INode node)
    {
      this.AddElement(node as Node);
    }

    /// <summary>
    /// Places specified integer-value onto the top of stack.
    /// </summary>
    /// <param name="value">
    /// The integer-value to be pushed.
    /// </param>
    public void PushInt(int value)
    {
      this.Push(new Node(value.ToString(CultureInfo.InvariantCulture)));
    }

    /// <summary>
    /// Pushes value as a named value onto this stack. Both, name and value, are contained in the stack-fragment specified.
    /// </summary>
    /// <param name="topOfStack">
    /// Stack-fragment with Name and value.
    /// </param>
    /// <param name="limit">
    /// The limit.
    /// </param>
    /// <remarks>
    /// - This function essentially implements the "let"-command of "atom".
    ///   - The TOS of the stack-fragment contains the name as a list element, whereas TOS - 1 is the value.
    /// </remarks>
    public void PushName(INodeList topOfStack, int limit)
    {
      NodeList newList = new NodeList(topOfStack[1]);
      INode tos = topOfStack[0];
      INode head = tos.GetHead();
      string name = head.Value;
      INode node = this.NodeAt(name, limit);

      if (node != null)
      {
        node.List = newList;
      }
      else
      {
        this.Push(new Node(name, newList) { Comment = head.Comment });
      }
    }
  }
}