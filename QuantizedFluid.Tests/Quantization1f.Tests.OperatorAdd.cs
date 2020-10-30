using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization1f_Tests_OperatorAdd : Quantization1f_Tests {
		[Test]
		public void AbleToAddTwoTogether() {
			var q1 = new Quantization1f(new[]{0, 11f, 1.8f});
			var q2 = new Quantization1f(new[]{12, 11.1f, .18f});

			var result = q1 + q2;

			result[-1].Should().Be(12);
			result[0].Should().Be(22.1f);
			result[1].Should().Be(1.98f);
		}
	}
}
