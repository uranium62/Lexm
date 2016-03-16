using System;

namespace Lexm.Core.Extensions
{
    public static class TokenExt
    {
        public static IToken[] ToRPN(this IToken[] arr)
        {
            return new RpnParser().Parse(arr);
        }

        public static SyntaxNode ToSyntaxTree(this IToken[] rpn)
        {
            return new SyntaxTreeBuilder(rpn).Build();
        }

        public static string ToGoogleSearchQuery(this IToken[] rpn)
        {
            return new GoogleTranformer().Transform(rpn);
        }

        public static string ToYandexSearchQuery(this IToken[] rpn)
        {
            return new YandexTransformer().Transform(rpn);
        }
    }
}
