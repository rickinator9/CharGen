using CharGen.Parsing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen.Test.Parsing
{
    [TestFixture(' ', true)]
    [TestFixture('\t', true)]
    [TestFixture('\n', false)]
    [TestFixture('\r', false)]
    [TestFixture('r', false)]
    public class UtilsSpaceTest
    {
        private char _char;
        private bool _expectedResult;

        public UtilsSpaceTest(char character, bool expectedResult)
        {
            _char = character;
            _expectedResult = expectedResult;
        }

        [Test]
        public void IsCharacterASpace()
        {
            Assert.AreEqual(_expectedResult, Utils.IsSpace(_char));
        }
    }

    [TestFixture(' ', false)]
    [TestFixture('\t', false)]
    [TestFixture('\n', true)]
    [TestFixture('\r', true)]
    [TestFixture('r', false)]
    public class UtilsNewlineTest
    {
        private char _char;
        private bool _expectedResult;

        public UtilsNewlineTest(char character, bool expectedResult)
        {
            _char = character;
            _expectedResult = expectedResult;
        }

        [Test]
        public void IsCharacterANewline()
        {
            Assert.AreEqual(_expectedResult, Utils.IsNewline(_char));
        }
    }

    [TestFixture(' ', false)]
    [TestFixture('\t', false)]
    [TestFixture('\n', false)]
    [TestFixture('\r', false)]
    [TestFixture('r', false)]
    [TestFixture('#', true)]
    public class UtilsCommentTest
    {
        private char _char;
        private bool _expectedResult;

        public UtilsCommentTest(char character, bool expectedResult)
        {
            _char = character;
            _expectedResult = expectedResult;
        }

        [Test]
        public void IsCharacterAComment()
        {
            Assert.AreEqual(_expectedResult, Utils.IsComment(_char));
        }
    }
}
