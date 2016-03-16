using System.Collections.Generic;
using System.Text;

namespace Lexm.Core
{
    public interface ISpliter
    {
        IToken[] Split(string str);
    }

    public class LexemeSpliter : ISpliter
    {
        public IToken[] Split(string str)
        {
            Queue<IToken> tokens = new Queue<IToken>();
            StringBuilder buffer = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    Flush(buffer, tokens);
                }
                else if (str[i] == '(')
                {
                    Flush(buffer, tokens);
                    tokens.Enqueue(new TokenOper(LexemeType.BeginBracket));
                }
                else if (str[i] == ')')
                {
                    Flush(buffer, tokens);
                    tokens.Enqueue(new TokenOper(LexemeType.EndBracket));
                }
                else
                {
                    buffer.Append(str[i]);
                }
            }

            Flush(buffer, tokens);
            return tokens.ToArray();
        }

        private void Flush(StringBuilder buf, Queue<IToken> tokens)
        {
            if (buf.Length == 0)
            {
                return;
            }

            var str = buf.ToString();

            if (str == "AND")
            {
                tokens.Enqueue(new TokenOper(LexemeType.AND));
            }
            else if (str == "OR")
            {
                tokens.Enqueue(new TokenOper(LexemeType.OR));
            }
            else
            {
                tokens.Enqueue(new TokenWord(str));
            }
            buf.Clear();
        }

    }
}
