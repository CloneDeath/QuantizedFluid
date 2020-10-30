using FluentAssertions;
using NUnit.Framework;
using QuantizedFluid.QuantizedMath;

namespace QuantizedFluid.Tests {
	[TestFixture]
	public class Quantization2f_Tests_ConstructorIEnumerable : Quantization2f_Tests {
		[Test]
		public void AbleToMakeANewQuantization2() {
			var q = new Quantization2f(new[]{0.3f, 1f, 0}, new[]{0.1f, 1f, 0.2f});

			q.Total.Should().Be(1.3f);
		}
	}
}