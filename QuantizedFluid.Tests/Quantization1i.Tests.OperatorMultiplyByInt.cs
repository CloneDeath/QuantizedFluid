using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization1i_Tests_OperatorMultiplyByInt : Quantization1i_Tests {
		[Test]
		public void AbleToMultipleAQuantizationByAnInteger() {
			var q = new Quantization1i(new[] {0, 1, 10});

			var result = q * 5;

			result[-1].Should().Be(0);
			result[0].Should().Be(5);
			result[1].Should().Be(50);
		}

		[Test]
		public void WhenMultiplying_TheOriginalValueIsUnchanged() {
			var q = new Quantization1i(new[] {0, 1, 10});

			var result = q * 5;

			result[0].Should().Be(5);
			q[0].Should().Be(1);
		}
	}
}