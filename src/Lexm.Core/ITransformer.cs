using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lexm.Core
{
    public interface ITransformer
    {
         string Transform(IToken[] rpn);
    }

    public class GoogleTranformer : ITransformer
    {
        public string Transform(IToken[] rpn)
        {
            var stack = new Stack<string>();

            for (int i = 0; i < rpn.Length; i++)
            {
                if (rpn[i].Type == LexemeType.Word)
                {
                    stack.Push(((TokenWord)rpn[i]).Value);
                }
                else if (rpn[i].Type == LexemeType.OR)
                {
                    var right = stack.Pop();
                    var left = stack.Pop();

                    stack.Push(new StringBuilder()
                        .Append(left)
                        .Append(" | ")
                        .Append(right).ToString());
                }
                else if (rpn[i].Type == LexemeType.AND)
                {
                    var right = stack.Pop();
                    var left = stack.Pop();

                    stack.Push(new StringBuilder()
                        .Append(left)
                        .Append(" ")
                        .Append(right).ToString());
                }
            }

            return stack.Pop();
        }
    }

    public class YandexTransformer : ITransformer
    {
        public string Transform(IToken[] rpn)
        {
            var stack = new Stack<string>();

            for (int i = 0; i < rpn.Length; i++)
            {
                if (rpn[i].Type == LexemeType.Word)
                {
                    stack.Push(((TokenWord)rpn[i]).Value);
                }
                else if (rpn[i].Type == LexemeType.OR)
                {
                    var right = stack.Pop();
                    var left = stack.Pop();

                    stack.Push(new StringBuilder()
                        .Append("(")
                        .Append(left)
                        .Append(" | ")
                        .Append(right)
                        .Append(")").ToString());
                }
                else if (rpn[i].Type == LexemeType.AND)
                {
                    var right = stack.Pop();
                    var left = stack.Pop();

                    stack.Push(new StringBuilder()
                        .Append(left)
                        .Append(" + ")
                        .Append(right).ToString());
                }
            }

            return stack.Pop();
        }
    }
}
