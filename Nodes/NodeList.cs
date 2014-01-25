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
    ///   The help suffix.
    /// </summary>
    private const string HelpSuffix = "-help";

    /// <summary>
    ///   Initializes a new instance of the <see cref="NodeList" /> class.
    /// </summary>
    public NodeList()
    {
      this.IsSafeList = false;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NodeList"/> class.
    /// </summary>
    /// <param name="node">
    /// First node to initialize the list with.
    /// </param>
    public NodeList(INode node)
    {
      this.IsSafeList = false;
      this.AddElement(node as Node);
    }

    /// <summary>
    ///   Gets or sets a value indicating whether this instance is safe list.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is safe list; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    ///   A safe list is a list, that was created in "INode.SafeList"
    ///   as a wrapper for a node.
    /// </remarks>
    public bool IsSafeList { get; set; }

    /// <summary>
    /// Indexer for this list.
    /// </summary>
    /// <param name="key">
    /// The key.
    /// </param>
    /// <returns>
    /// The <see cref="INode"/>.
    /// </returns>
    public new INode this[int key]
    {
      get
      {
        return base[key];
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
    /// Returns the list-item at the specified location.
    /// </summary>
    /// <param name="index">
    /// The index of the list-item.
    /// </param>
    /// <returns>
    /// The list-item.
    /// </returns>
    public INode ItemAt(int index)
    {
      if (index < this.Count)
      {
        return this[index];
      }

      return new Node();
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
    public INodeList Joined(INodeList list)
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
    /// <returns>
    /// List ("null" if no list could be found).
    /// </returns>
    /// <remarks>
    /// The element is searched downwards from the top of stack.
    /// </remarks>
    public INodeList ListAt(string name)
    {
      for (int i = this.Count - 1; 0 <= i; --i)
      {
        INode curNode = this[i];

        if (curNode.Value == name)
        {
          return curNode.List;
        }
      }

      return null;
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
    /// <remarks>
    /// - This function essentially implements the "let"-command of "atom".
    ///   - The TOS of the stack-fragment contains the name as a list element, whereas TOS - 1 is the value.
    /// </remarks>
    public void PushName(INodeList topOfStack)
    {
      this.Push(new Node(topOfStack[0].GetHead().Value, new NodeList(topOfStack[1])));
      this.Push(new Node(topOfStack[0].GetHead().Value + HelpSuffix, new NodeList(topOfStack[0].SafeList.ItemAt(1))));
    }

    public INodeList Clone()
    {
      return this.MemberwiseClone() as INodeList;
    }
  }
}