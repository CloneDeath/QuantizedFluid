using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization1i_Tests_Total : Quantization1i_Tests {
		[Test]
		public void ANewlyCreatedQuantizationIsEmpty() {
			var q = new Quantization1i(10);
			q.Total.Should().Be(0);
		}
		
		[Test]
		public void AddingToAQuantumUpdatesTheTotal() {
			var q = new Quantization1i(10);
			q[0] += 1;
			q.Total.Should().Be(1);
		}

		[Test]
		public void InitializingThroughTheConstructorUpdatesTotal() {
			var q = new Quantization1i(new[]{1, 2, 3});
			q.Total.Should().Be(6);
		}
	}
}