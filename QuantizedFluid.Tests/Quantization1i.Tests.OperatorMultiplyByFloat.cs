using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization1i_Tests_OperatorMultiplyByFloat : Quantization1i_Tests {
		[Test]
		public void WhenMultiplyingByAFloat_EachValueIsMultipliedCorrectly() {
			var q = new Quantization1i(new[]{0, 1, 53, 12, 2});

			var result = q * 0.5f;

			result.GetValues().Should().BeEquivalentTo(new[] {0, 0.5f, 26.5f, 6, 1});
		}
	}
}