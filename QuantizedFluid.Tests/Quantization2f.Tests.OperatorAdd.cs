using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization2f_Tests_OperatorAdd : Quantization2f_Tests {
		[Test]
		public void AbleToAddTwoQuantizations() {
			var q1 = new Quantization2f(new[]{1.0f, 2.0f, 3.0f}, new[]{4.0f, 0.5f, 1.5f});
			var q2 = new Quantization2f(new[]{10.0f, 11.0f, 12.0f}, new[]{.5f, 1.5f, 31});

			var result = q1 + q2;
			
			result.GetXValues().Should().BeEquivalentTo(new[]{11f, 13, 15});
			result.GetYValues().Should().BeEquivalentTo(new[]{4.5f, 2, 32.5f});
		}
	}
}