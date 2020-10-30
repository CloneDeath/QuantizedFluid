using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	public class Quantization1iTests {
		[Test]
		public void AbleToCreateAnEmptyQuantization() {
			var q = new Quantization1i(10);
			q.Total.Should().Be(0);
		}

		[Test]
		public void AbleToAddToAQuantum() {
			var q = new Quantization1i(10);
			q[0] += 1;
			q.Total.Should().Be(1);
		}

		[Test]
		public void AbleToCreateANewQuantizationWithAnArray() {
			var q = new Quantization1i(new[]{0, 0, 1});
			q.Quantizations.Should().Be(1);
			q.Total.Should().Be(1);
		}
	}
}