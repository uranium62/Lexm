using System;
using System.Collections.Generic;
using Lexm.Core.Exceptions;

namespace Lexm.Core
{

    public interface IParser
    {
        IToken[] Parse(IToken[] tokens);
    }

    public class RpnParser : IParser
    {
        public IToken[] Parse(IToken[] tokens)
        {
            if (tokens == null)
            {
                throw new ArgumentNullException("tokens");
            }
            if (tokens[0].Type == LexemeType.AND || 
                tokens[0].Type == LexemeType.OR)
            {
                throw new FirstOperandException();
            }
            if (tokens[tokens.Length-1].Type == LexemeType.AND ||
                tokens[tokens.Length-1].Type == LexemeType.OR)
            {
                throw new LastOperandException();
            }           

            Stack<IToken> stack  = new Stack<IToken>();
            Queue<IToken> output = new Queue<IToken>();

            for (int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i].Type)
                {
                    case LexemeType.Word:
                        output.Enqueue(tokens[i]);
                        break;

                   case LexemeType.BeginBracket:
                        stack.Push(tokens[i]);
                        break;

                   case LexemeType.EndBracket:
                        if (stack.Count == 0)
                        {
                            throw new BracketCountException();
                        }

                        while (stack.Peek().Type != LexemeType.BeginBracket)
                        {
                            output.Enqueue(stack.Pop());

                            if (stack.Count == 0)
                            {
                                throw new BracketCountException();
                            }
                        }
                        stack.Pop();
                        break;

                   case LexemeType.AND:
                   case LexemeType.OR:
                        if (stack.Count == 0)
                        {
                            stack.Push(tokens[i]);
                        }
                        else if ((TokenOper) stack.Peek() < (TokenOper) tokens[i])
                        {
                            stack.Push(tokens[i]);
                        }
                        else
                        {
                            while ((stack.Count != 0) && ((TokenOper) stack.Peek() > (TokenOper)tokens[i]))
                            {
                                output.Enqueue(stack.Pop());
                            }
                            stack.Push(tokens[i]);
                        }
                        break;
                }
            }

            while (stack.Count != 0)
            {
                if (stack.Peek().Type == LexemeType.BeginBracket)
                {
                    throw new BracketCountException();
                }

                output.Enqueue(stack.Pop());
            }

            return output.ToArray();
        }
    }
}
