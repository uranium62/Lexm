using Lexm.Core;
using Lexm.Core.Exceptions;
using Lexm.Core.Extensions;
using NUnit.Framework;

namespace Lexm.Test
{
    [TestFixture]
    public class RpnParserTest
    {
        [Test]
        public void FirstOperandException()
        {
            var tokens = "AND Яблоко AND Груша OR Слива".ToLexemeTokens();

            Assert.Throws<FirstOperandException>(() =>
            {
                new RpnParser().Parse(tokens);
            });
        }

        [Test]
        public void LastOperandException()
        {
            var tokens = "Яблоко AND Груша OR Слива OR".ToLexemeTokens();

            Assert.Throws<LastOperandException>(() =>
            {
                new RpnParser().Parse(tokens);
            });
        }

        [Test]
        public void ParseOneLevel()
        {
            var tok1 = "Вода OR Сок".ToLexemeTokens();
            var tok2 = "Яблоко AND Груша OR Слива".ToLexemeTokens();
            var tok3 = "Яблоко OR Груша AND Слива".ToLexemeTokens();
            var tok4 = "Купить".ToLexemeTokens();

            var parser = new RpnParser();

            var rpn1 = parser.Parse(tok1);
            var rpn2 = parser.Parse(tok2);
            var rpn3 = parser.Parse(tok3);
            var rpn4 = parser.Parse(tok4);


            Assert.That(rpn1.Length == 3);
            Assert.That(
                rpn1[0].Type == LexemeType.Word && ((TokenWord) rpn1[0]).Value == "Вода" &&
                rpn1[1].Type == LexemeType.Word && ((TokenWord) rpn1[1]).Value == "Сок" &&
                rpn1[2].Type == LexemeType.OR);

            Assert.That(rpn2.Length == 5);
            Assert.That(
                rpn2[0].Type == LexemeType.Word && ((TokenWord)rpn2[0]).Value == "Яблоко" &&
                rpn2[1].Type == LexemeType.Word && ((TokenWord)rpn2[1]).Value == "Груша" &&
                rpn2[2].Type == LexemeType.AND &&
                rpn2[3].Type == LexemeType.Word && ((TokenWord)rpn2[3]).Value == "Слива" &&
                rpn2[4].Type == LexemeType.OR);

            Assert.That(rpn3.Length == 5);
            Assert.That(
                rpn3[0].Type == LexemeType.Word && ((TokenWord)rpn3[0]).Value == "Яблоко" &&
                rpn3[1].Type == LexemeType.Word && ((TokenWord)rpn3[1]).Value == "Груша" &&
                rpn3[2].Type == LexemeType.Word && ((TokenWord)rpn3[2]).Value == "Слива" &&
                rpn3[3].Type == LexemeType.AND &&
                rpn3[4].Type == LexemeType.OR);

            Assert.That(rpn4.Length == 1);
            Assert.That(
                rpn4[0].Type == LexemeType.Word);
        }

        [Test]
        public void ParseTwoLevel()
        {
            var token = "Купить AND (Вода OR Сок)".ToLexemeTokens();

            var rpn = new RpnParser().Parse(token);

            Assert.That(rpn.Length == 5);
            Assert.That(
                rpn[0].Type == LexemeType.Word && ((TokenWord)rpn[0]).Value == "Купить" &&
                rpn[1].Type == LexemeType.Word && ((TokenWord)rpn[1]).Value == "Вода" &&
                rpn[2].Type == LexemeType.Word && ((TokenWord)rpn[2]).Value == "Сок" &&
                rpn[3].Type == LexemeType.OR &&
                rpn[4].Type == LexemeType.AND);
        }

        [Test]
        public void ParseBracketException()
        {
            var tokens1 = "(( Яблоко)".ToLexemeTokens();
            var tokens2 = "Яблоко)".ToLexemeTokens();
            var tokens3 = "Купить AND (Яблоко))".ToLexemeTokens();

            Assert.Throws<BracketCountException>(() =>
            {
                new RpnParser().Parse(tokens1);
            });
            Assert.Throws<BracketCountException>(() =>
            {
                new RpnParser().Parse(tokens2);
            });
            Assert.Throws<BracketCountException>(() =>
            {
                new RpnParser().Parse(tokens3);
            });
        }
    }
}
