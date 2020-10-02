using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using QuantizedFluid.Core.Extensions;

namespace QuantizedFluid.Core {
	public class FluidLayer {
		protected FluidCell[,] Cells { get; }
		protected Size Size { get; }

		public FluidLayer(Size size, int quantizations) {
			Size = size;
			Cells = new FluidCell[size.Width, size.Height];
			for (var x = 0; x < size.Width; x++) {
				for (var y = 0; y < size.Height; y++) {
					Cells[x, y] = new FluidCell(new Point(x, y), quantizations);
				}
			}
		}
		
		public FluidCell this[Point point] => this[point.X, point.Y];
		public FluidCell this[in int x, in int y] => Cells[x, y];

		public IEnumerable<FluidCell> GetCells() {
			return Size.GetPoints().Select(point => this[point]);
		}

		public void NormalizeProbabilities() {
			foreach (var cell in Cells) {
				cell.NormalizeProbabilities();
			}
		}
	}
}