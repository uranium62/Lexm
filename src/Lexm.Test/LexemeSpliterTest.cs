using Lexm.Core;
using NUnit.Framework;

namespace Lexm.Test
{
    [TestFixture]
    class LexemeSpliterTest
    {
        [Test]
        public void SplitEmpty()
        {
            var str1 = "";
            var str2 = "   ";

            var arr1 = new LexemeSpliter().Split(str1);
            var arr2 = new LexemeSpliter().Split(str2);

            Assert.That(arr1.Length == 0);
            Assert.That(arr2.Length == 0);
        }

        [Test]
        public void SplitOneLevel()
        {
            var str1 = "Вода OR Сок";
            var str2 = "Яблоко AND Груша OR Слива";
            var str3 = "Купить";
            var str4 = "   Продать ";
            var str5 = "к";
            var str6 = "ANDAND";
            var str7 = "AND AND";

            var spliter = new LexemeSpliter();

            var arr1 = spliter.Split(str1);
            var arr2 = spliter.Split(str2);
            var arr3 = spliter.Split(str3);
            var arr4 = spliter.Split(str4);
            var arr5 = spliter.Split(str5);
            var arr6 = spliter.Split(str6);
            var arr7 = spliter.Split(str7);

            Assert.That(arr1.Length == 3);
            Assert.That(
                arr1[0].Type == LexemeType.Word &&
                arr1[1].Type == LexemeType.OR &&
                arr1[2].Type == LexemeType.Word);

            Assert.That(arr2.Length == 5);
            Assert.That(
                arr2[0].Type == LexemeType.Word &&
                arr2[1].Type == LexemeType.AND &&
                arr2[2].Type == LexemeType.Word &&
                arr2[3].Type == LexemeType.OR &&
                arr2[4].Type == LexemeType.Word);

            Assert.That(arr3.Length == 1);
            Assert.That(arr3[0].Type == LexemeType.Word);

            Assert.That(arr4.Length == 1);
            Assert.That(arr4[0].Type == LexemeType.Word);

            Assert.That(arr5.Length == 1);
            Assert.That(arr5[0].Type == LexemeType.Word);

            Assert.That(arr6.Length == 1);
            Assert.That(arr6[0].Type == LexemeType.Word);

            Assert.That(arr7.Length == 2);
            Assert.That(
                arr7[0].Type == LexemeType.AND &&
                arr7[0].Type == LexemeType.AND);
        }

        [Test]
        public void SplitTwoLevel()
        {
            var str = "Купить AND (Вода OR Сок)";

            var arr = new LexemeSpliter().Split(str);

            Assert.That(arr.Length == 7);
            Assert.That(
                arr[0].Type == LexemeType.Word &&
                arr[1].Type == LexemeType.AND &&
                arr[2].Type == LexemeType.BeginBracket &&
                arr[3].Type == LexemeType.Word &&
                arr[4].Type == LexemeType.OR &&
                arr[5].Type == LexemeType.Word &&
                arr[6].Type == LexemeType.EndBracket);
        }

        [Test]
        public void SplitMultLevel()
        {
            var str = "Купить AND (( Дорого OR Дешево) AND (Вода OR Сок))";

            var arr = new LexemeSpliter().Split(str);

            Assert.That(arr.Length == 15);
            Assert.That(
                arr[0].Type == LexemeType.Word &&
                arr[1].Type == LexemeType.AND &&
                arr[2].Type == LexemeType.BeginBracket &&
                arr[3].Type == LexemeType.BeginBracket &&
                arr[4].Type == LexemeType.Word &&
                arr[5].Type == LexemeType.OR &&
                arr[6].Type == LexemeType.Word &&
                arr[7].Type == LexemeType.EndBracket &&
                arr[8].Type == LexemeType.AND &&
                arr[9].Type == LexemeType.BeginBracket &&
                arr[10].Type == LexemeType.Word &&
                arr[11].Type == LexemeType.OR &&
                arr[12].Type == LexemeType.Word &&
                arr[13].Type == LexemeType.EndBracket &&
                arr[14].Type == LexemeType.EndBracket);
        }

        [Test]
        public void SplitCrazy()
        {
            var str = "(((( к ((( тд т.,д )(";

            var arr = new LexemeSpliter().Split(str);

            Assert.That(arr.Length == 12);
            Assert.That(
                arr[0].Type == LexemeType.BeginBracket &&
                arr[1].Type == LexemeType.BeginBracket &&
                arr[2].Type == LexemeType.BeginBracket &&
                arr[3].Type == LexemeType.BeginBracket &&
                arr[4].Type == LexemeType.Word &&
                arr[5].Type == LexemeType.BeginBracket &&
                arr[6].Type == LexemeType.BeginBracket &&
                arr[7].Type == LexemeType.BeginBracket &&
                arr[8].Type == LexemeType.Word &&
                arr[9].Type == LexemeType.Word &&
                arr[10].Type == LexemeType.EndBracket &&
                arr[11].Type == LexemeType.BeginBracket);
        }
    }
}
