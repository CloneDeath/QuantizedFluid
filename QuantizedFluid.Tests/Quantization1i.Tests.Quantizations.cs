using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization1i_Tests_Quantizations : Quantization1i_Tests {
		[Test]
		public void QuantizationsIsThePassedInValue() {
			var q = new Quantization1i(4);
			q.Quantizations.Should().Be(4);
		}

		[Test]
		public void IfAnArrayIsPassedIn_QuantizationsIsCorrectlyCalculated() {
			var q = new Quantization1i(new[]{0, 0, 0, 0, 0});
			q.Quantizations.Should().Be(2);
		}
	}
}