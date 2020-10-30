using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization2f_Tests_Normalized : Quantization2f_Tests {
		[Test]
		public void AfterNormalization_TotalIsOne() {
			var q2 = new Quantization2f(new[]{0, 10f, 0}, new[]{5f, 0.5f, 4.5f});

			var result = q2.Normalized;

			result.Total.Should().Be(1);
		}
	}
}