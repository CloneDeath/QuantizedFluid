using CorePixelEngine;
using QuantizedFluid.Core;

namespace QuantizedFluid {
	public class FluidWorldVisualizer : PixelGameEngine {
		private readonly FluidWorld _world;

		public FluidWorldVisualizer(FluidWorld world) {
			_world = world;
		}

		protected override string sAppName => "Fluid World Visualizer";
		
		public override bool OnUserCreate() {
			SetPixels();
			return true;
		}

		public override bool OnUserUpdate(float elapsedTime) {
			_world.Step();
			SetPixels();
			return true;
		}

		protected void SetPixels() {
			for (var x = 0; x < _world.Width; x++) {
				for (var y = 0; y < _world.Height; y++) {
					var count = _world[x, y].NumberOfParticles;
					Draw(x, y, new Pixel(0, 0, count));
				}
			}
		}
	}
}