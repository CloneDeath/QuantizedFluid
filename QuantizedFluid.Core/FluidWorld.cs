using System.Drawing;
using QuantizedFluid.Core.VelocityHistograms;

namespace QuantizedFluid.Core {
	public class FluidWorld {
		protected FluidLayer Layer { get; set; }
		
		public Size Size { get; }
		public int Width => Size.Width;
		public int Height => Size.Height;
		public int Quantizations { get; }
		
		public FluidWorld(Size size, int quantizations) {
			Size = size;
			Quantizations = quantizations;
			Layer = new FluidLayer(size, quantizations);
		}

		public FluidCell this[Point point] => this[point.X, point.Y];
		public FluidCell this[in int x, in int y] => Layer[x, y];

		public void Step(int numberOfSteps = 1) {
			Layer.NormalizeProbabilities();
			for (var i = 0; i < numberOfSteps; i++) {
				TakeSingleStep();
			}
		}

		protected void TakeSingleStep() {
			var next = new FluidLayer(Size, Quantizations);
			foreach (var fluidCell in Layer.GetCells()) {
				var position = fluidCell.Position;
				var grid = new VelocityGrid(fluidCell.VelocityProbability);
				
				next[position].NumberOfParticles = fluidCell.NumberOfParticles;
				next[position].VelocityProbability = fluidCell.VelocityProbability;
			}

			Layer = next;
		}

		public void NormalizeProbabilities() {
			Layer.NormalizeProbabilities();
		}
	}
}