using System;
using System.Collections.Generic;

namespace Lexm.Core
{
    public class SyntaxNode
    {
        public SyntaxNode Left  { get; set; }
        public SyntaxNode Right { get; set; }

        private readonly IToken _token;

        public SyntaxNode(IToken token)
        {
            _token = token;
        }

        public string Value
        {
            get
            {
                return _token.Type == LexemeType.Word ? ((TokenWord) _token).Value : null;
            }
        }

        public LexemeType Type
        {
            get { return _token.Type; }
        }
    }

    public class SyntaxTreeBuilder
    {
        private readonly IToken[] _rpn;

        public SyntaxTreeBuilder(IToken[] rpn)
        {
            if (rpn == null)
            {
                throw new ArgumentNullException("rpn");
            }

            _rpn = rpn;
        }

        public SyntaxNode Build()
        {
            var stack = new Stack<SyntaxNode>();

            for (int i = 0; i < _rpn.Length; i++)
            {
                if (_rpn[i].Type == LexemeType.Word)
                {
                    stack.Push(new SyntaxNode(_rpn[i]));
                }
                else
                {
                    var node = new SyntaxNode(_rpn[i]);
                    node.Right = stack.Pop();
                    node.Left = stack.Pop();

                    stack.Push(node);
                }
            }

            return stack.Pop();
        }
    }
}
