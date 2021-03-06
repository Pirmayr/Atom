﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INodeList.cs" company="me">
//   me
// </copyright>
// <summary>
//   A list of nodes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Nodes
{
  using System.Collections.Generic;

  /// <summary>
  ///   A list of nodes.
  /// </summary>
  public interface INodeList : IEnumerable<INode>
  {
    /// <summary>
    ///   Gets the count.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Indexer for this list.
    /// </summary>
    /// <param name="key">
    /// The key.
    /// </param>
    /// <returns>
    /// The <see cref="INode"/>.
    /// </returns>
    INode this[int key] { get; set; }

    /// <summary>
    /// Adds an element to the list.
    /// </summary>
    /// <param name="node">
    /// Element to be added.
    /// </param>
    void AddElement(INode node);

    /// <summary>
    ///   The clear.
    /// </summary>
    void Clear();

    /// <summary>
    ///   Returns a shallow clone of this list.
    /// </summary>
    /// <returns>
    ///   The cloned list.
    /// </returns>
    IEnumerable<INode> Clone();

    /// <summary>
    /// Add given list to this list and returns the joined result.
    /// </summary>
    /// <param name="list">
    /// List to be added to this list.
    /// </param>
    /// <returns>
    /// Joined list.
    /// </returns>
    INodeList Joined(IEnumerable<INode> list);

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
    INodeList ListAt(string name, int limit = 0);

    /// <summary>
    /// The node at.
    /// </summary>
    /// <param name="name">
    /// The name.
    /// </param>
    /// <param name="limit">
    /// The limit.
    /// </param>
    /// <returns>
    /// The <see cref="INode"/>.
    /// </returns>
    INode NodeAt(string name, int limit = 0);

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
    INodeList Pop(int count, bool reverse = false);

    /// <summary>
    ///   Removes the element on the top of stack.
    /// </summary>
    /// <returns>
    ///   The element on the top of stack.
    /// </returns>
    INode Pop();

    /// <summary>
    /// Places specified element onto the top of stack.
    /// </summary>
    /// <param name="node">
    /// The node to be pushed.
    /// </param>
    void Push(INode node);

    /// <summary>
    /// Places specified integer-value onto the top of stack.
    /// </summary>
    /// <param name="value">
    /// The integer-value to be pushed.
    /// </param>
    void PushInt(int value);

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
    void PushName(INodeList topOfStack, int limit);

    /// <summary>
    /// The remove range.
    /// </summary>
    /// <param name="start">
    /// The start.
    /// </param>
    /// <param name="count">
    /// The count.
    /// </param>
    void RemoveRange(int start, int count);
  }
}