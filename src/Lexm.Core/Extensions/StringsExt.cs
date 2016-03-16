namespace Lexm.Core.Extensions
{
    public static class StringsExt
    {
        public static IToken[] ToLexemeTokens(this string str)
        {
            return new LexemeSpliter().Split(str);
        }

        public static IToken[] ToRPN(this string str)
        {
            return str.ToLexemeTokens().ToRPN();
        }

        public static SyntaxNode ToSyntaxTree(this string str)
        {
            return str.ToLexemeTokens().ToRPN().ToSyntaxTree();
        }

        public static string ToGoogleSearchQuery(this string str)
        {
            return str.ToLexemeTokens().ToRPN().ToGoogleSearchQuery();
        }

        public static string ToYandexSearchQuery(this string str)
        {
            return str.ToLexemeTokens().ToRPN().ToYandexSearchQuery();
        }
    }
}
