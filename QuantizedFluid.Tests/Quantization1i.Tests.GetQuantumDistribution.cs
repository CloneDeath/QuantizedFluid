using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization1i_Tests_GetDistribution : Quantization1i_Tests {
		[Test]
		public void ASimpleEvenQuantizationHasAnEvenDistribution() {
			var q = new Quantization1i(new []{2, 2, 2});

			var distribution = q.GetDistribution();

			distribution[-1].Should().BeApproximately(0.333f, 0.0001f);
			distribution[0].Should().BeApproximately(0.333f, 0.0001f);
			distribution[1].Should().BeApproximately(0.333f, 0.0001f);
		}
	}
}