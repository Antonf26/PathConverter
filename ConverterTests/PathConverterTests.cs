using System.IO;
using FluentAssertions;
using JsonPathConvert;
using NUnit.Framework;

namespace ConverterTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConvertsSimplePathWithSpace()
        {
            PathConverter.Convert("$.a thing").Should().Be("$.['a thing']");
        }

        [Test]
        public void ConvertsArrayExample()
        {
            PathConverter.Convert("$.te sts[?(@.name == 'test1')]").Should().Be("$.['te sts'][?(@.name == 'test1')]");
        }

        [Test]
        public void ConvertsNestedExample()
        {
            PathConverter.Convert("$.te sts[?(@.na me == 'test1')]").Should().Be("$.['te sts'][?(@.['na me'] == 'test1')]");
        }

        [TestCase("$.bla.bla", "$.bla.bla")]
        [TestCase("$.bla.b la", "$.bla.['b la']")]
        [TestCase("$", "$")]
        [TestCase("$.bla.bla", "$.bla.bla")]
        public void ConvertsExamples(string input, string expected)
        {
            PathConverter.Convert(input).Should().Be(expected);
        }


    }
}