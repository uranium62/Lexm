using Lexm.Core;
using Lexm.Core.Extensions;
using NUnit.Framework;

namespace Lexm.Test
{
    [TestFixture]
    public class SyntaxTreeBuilderTest
    {
        [Test]
        public void OneLevelSyntaxTree()
        {
            /*
                      OR
                    /     \
                  Купить   AND
                          /    \
                       Продать  Снять
            */
            var str = "Купить OR Продать AND Снять";

            var tree = str.ToSyntaxTree();

            Assert.That(tree.Type == LexemeType.OR);
            Assert.That(
                tree.Left.Type == LexemeType.Word &&
                tree.Left.Value == "Купить");

            Assert.That(tree.Right.Type == LexemeType.AND);
            Assert.That(
                tree.Right.Right.Type == LexemeType.Word &&
                tree.Right.Right.Value == "Снять");
            Assert.That(
                tree.Right.Left.Type == LexemeType.Word &&
                tree.Right.Left.Value == "Продать");
        }

        [Test]
        public void TwoLevelSyntaxTree()
        {
            /*
                        AND
                      /     \
                   Купить    OR
                           /    \
                         Вода   Сок
            */

            var str = "Купить AND (Вода OR Сок)";

            var tree = str.ToSyntaxTree();

            Assert.That(tree.Type == LexemeType.AND);
            Assert.That(
                tree.Left.Type == LexemeType.Word && 
                tree.Left.Value == "Купить");

            Assert.That(tree.Right.Type == LexemeType.OR);
            Assert.That(
                tree.Right.Right.Type == LexemeType.Word &&
                tree.Right.Right.Value == "Сок");
            Assert.That(
                tree.Right.Left.Type == LexemeType.Word &&
                tree.Right.Left.Value == "Вода");
        }
    }
}
