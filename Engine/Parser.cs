// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parser.cs" company="me">
//   me
// </copyright>
// <summary>
//   Parser for the "atom"-language.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Atom
{
  #region

  using Nodes;

  #endregion

  /// <summary>
  ///   Parser for the "atom"-language.
  /// </summary>
  internal class Parser
  {
    /// <summary>
    ///   The character representing the end of string.
    /// </summary>
    private const char EndOfString = '\0';

    /// <summary>
    ///   The current character in the code.
    /// </summary>
    private char currentCharacter;

    /// <summary>
    ///   Current symbol read.
    /// </summary>
    private Symbol currentSymbol;

    /// <summary>
    ///   The value of the current symbol read.
    /// </summary>
    private string currentValue;

    /// <summary>
    ///   Terminal symbols.
    /// </summary>
    private enum Symbol
    {
      /// <summary>
      ///   The 'Null'-symbol.
      /// </summary>
      Null, 

      /// <summary>
      ///   End of string.
      /// </summary>
      Eos, 

      /// <summary>
      ///   A word.
      /// </summary>
      Word, 

      /// <summary>
      ///   Left parenthesis.
      /// </summary>
      LeftParenthesis, 

      /// <summary>
      ///   Right parenthesis.
      /// </summary>
      RightParenthesis, 
    }

    /// <summary>
    /// Parses the specified code.
    /// </summary>
    /// <param name="code">
    /// The code.
    /// </param>
    /// <returns>
    /// When the code could be parsed successfully, the return value is "true", else the return value is "false".
    /// </returns>
    /// <remarks>
    /// Grammar: Atom = { word | '(' Atom ')' .
    /// </remarks>
    public INodeList Parse(string code)
    {
      this.GetChr(ref code);
      this.GetSym(ref code);

      return this.ParseAtom(ref code);
    }

    /// <summary>
    /// Returns the next character in the code.
    /// </summary>
    /// <param name="code">
    /// The code.
    /// </param>
    private void GetChr(ref string code)
    {
      this.currentCharacter = EndOfString;

      if (!string.IsNullOrEmpty(code))
      {
        this.currentCharacter = code[0];
        code = code.Remove(0, 1);
      }
    }

    /// <summary>
    /// Gets the next symbol in the specified code.
    /// </summary>
    /// <param name="code">
    /// The code.
    /// </param>
    private void GetSym(ref string code)
    {
      while ((this.currentCharacter != EndOfString) && char.IsWhiteSpace(this.currentCharacter))
      {
        this.GetChr(ref code);
      }

      this.currentValue = string.Empty;
      this.currentSymbol = Symbol.Null;

      switch (this.currentCharacter)
      {
        case EndOfString:
          this.currentSymbol = Symbol.Eos;
          break;
        case '(':
          this.currentSymbol = Symbol.LeftParenthesis;
          this.currentValue += this.currentCharacter;
          this.GetChr(ref code);
          break;
        case ')':
          this.currentSymbol = Symbol.RightParenthesis;
          this.currentValue += this.currentCharacter;
          this.GetChr(ref code);
          break;
        case '\'':
          this.currentSymbol = Symbol.Word;
          this.GetChr(ref code);

          while ((this.currentCharacter != '\'') && (this.currentCharacter != EndOfString))
          {
            this.currentValue += this.currentCharacter;
            this.GetChr(ref code);
          }

          if (this.currentCharacter != EndOfString)
          {
            this.GetChr(ref code);
          }

          break;
        default:
          this.currentSymbol = Symbol.Word;

          while ((this.currentCharacter != '(') && (this.currentCharacter != ')') && (this.currentCharacter != '\'') && (this.currentCharacter != EndOfString) && !char.IsWhiteSpace(this.currentCharacter))
          {
            this.currentValue += this.currentCharacter;
            this.GetChr(ref code);
          }

          break;
      }
    }

    /// <summary>
    /// Parses the specified code.
    /// </summary>
    /// <param name="code">
    /// The code.
    /// </param>
    /// <returns>
    /// When the code could be parsed successfully, the return value is "true", else the return value is "false".
    /// </returns>
    private INodeList ParseAtom(ref string code)
    {
      INodeList result = NodesHelpers.NewNodeList();

      while ((this.currentSymbol == Symbol.Word) || (this.currentSymbol == Symbol.LeftParenthesis))
      {
        INode newNode = NodesHelpers.NewNode(this.currentValue);

        result.AddElement(newNode);

        if (this.currentSymbol == Symbol.LeftParenthesis)
        {
          this.GetSym(ref code);
          newNode.List = this.ParseAtom(ref code);

          if (this.currentSymbol == Symbol.RightParenthesis)
          {
            this.GetSym(ref code);
          }
          else
          {
            return null;
          }
        }
        else
        {
          this.GetSym(ref code);
        }
      }

      return result;
    }
  }
}