using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization1f_Tests_OperatorMultiplyByFloat : Quantization1f_Tests {
		[Test]
		public void AbleToMultiplyByAFloat() {
			var q = new Quantization1f(new[]{0, 1f, 0.5f});

			var result = q * 1.1f;

			result[-1].Should().Be(0);
			result[0].Should().Be(1.1f);
			result[1].Should().BeApproximately(0.55f, 0.001f);
		}
	}
}