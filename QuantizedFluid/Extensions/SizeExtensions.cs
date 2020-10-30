using System.Collections.Generic;
using System.Drawing;

namespace QuantizedFluid.Extensions {
	public static class SizeExtensions {
		public static IEnumerable<Point> GetPoints(this Size self) {
			for (var x = 0; x < self.Width; x++) {
				for (var y = 0; y < self.Height; y++) {
					yield return new Point(x, y);
				}
			}
		}
	}
}