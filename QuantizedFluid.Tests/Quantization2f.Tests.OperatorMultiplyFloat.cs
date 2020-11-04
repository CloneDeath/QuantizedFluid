using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization2f_Tests_OperatorMultiplyFloat : Quantization2f_Tests {
		[Test]
		public void AbleToMultiplyAQuantizationByAFloat() {
			var q2 = new Quantization2f(new[]{1.0f, 2.0f, 3.0f}, new[]{4.0f, 0.5f, 1.5f});

			var result = q2 * 0.5f;
			
			result.GetXValues().Should().BeEquivalentTo(new[]{0.5f, 1, 1.5f});
			result.GetYValues().Should().BeEquivalentTo(new[]{2, 0.25f, 0.75f});
		}
	}
}