using System;

namespace Lexm.Core
{
    public enum LexemeType
    {
        Word,

        AND,
        OR,

        BeginBracket,
        EndBracket
    }

    public interface IToken
    {
        LexemeType Type { get; }
    }

    public class TokenWord : IToken
    {
        public LexemeType Type { get; }

        public string Value { get; }

        public TokenWord(string value)
        {
            Value = value;
            Type = LexemeType.Word;
        }
    }

    public class TokenOper : IToken
    {
        public LexemeType Type { get; }

        public int Prior { get; }

        public TokenOper(LexemeType type)
        {
            if (type == LexemeType.Word)
            {
                throw new ArgumentException("type");
            }

            switch (type)
            {
                case LexemeType.BeginBracket:
                case LexemeType.EndBracket:
                    Prior = 0;
                    break;

                case LexemeType.OR:
                    Prior = 1;
                    break;

                case LexemeType.AND:
                    Prior = 2;
                    break;
            }

            Type = type;

        }

        public static bool operator >(TokenOper t1, TokenOper t2)
        {
            return t1.Prior > t2.Prior;
        }

        public static bool operator <(TokenOper t1, TokenOper t2)
        {
            return t1.Prior < t2.Prior;
        }
    }
}
