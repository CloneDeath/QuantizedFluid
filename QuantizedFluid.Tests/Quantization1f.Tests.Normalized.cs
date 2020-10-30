using System;
using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization1f_Tests_Normalized : Quantization1f_Tests {
		[Test]
		public void AbleToNormalizeAQuantizationWithOneValue() {
			var q = new Quantization1f(new[]{100f, 0, 0});

			var result = q.Normalized;

			result.GetValues().Should().BeEquivalentTo(new[] {1f, 0, 0});
		}

		[Test]
		public void AbleToNormalizeAQuantizationWithMultipleValues() {
			var q = new Quantization1f(new[]{3.3f, 5, 1.7f});

			var result = q.Normalized;

			result[-1].Should().BeApproximately(.33f, 0.001f);
			result[0].Should().Be(.5f);
			result[1].Should().BeApproximately(.17f, 0.001f);
		}

		[Test]
		public void ANormalizedQuantizationShouldHaveTotalOfOne() {
			var q = new Quantization1f(new[]{100, 0, 20.6f});

			var result = q.Normalized;

			result.Total.Should().Be(1);
		}

		[Test]
		public void IfAllValuesAreZero_ThenAnExceptionIsThrown() {
			var q = new Quantization1f(3);

			new Func<Quantization1f>(() => q.Normalized)
				.Should().ThrowExactly<DivideByZeroException>();
		}
	}
}