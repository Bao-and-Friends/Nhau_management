using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RestaurantClientUI
{
	public class RoundedPanel : Panel
	{
		private int cornerRadius = 22;

		[DefaultValue(22)]
		public int CornerRadius
		{
			get { return cornerRadius; }
			set
			{
				cornerRadius = Math.Max(1, value);
				ApplyRoundedCorners();
			}
		}

		public RoundedPanel()
		{
			Resize += (s, e) => ApplyRoundedCorners();
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			ApplyRoundedCorners();
		}

		private void ApplyRoundedCorners()
		{
			if (Width <= 1 || Height <= 1 || !IsHandleCreated)
				return;

			int r = Math.Min(
				cornerRadius,
				Math.Min(Width, Height) / 2
			);

			int d = r * 2;

			using (GraphicsPath path = new GraphicsPath())
			{
				path.AddArc(0, 0, d, d, 180, 90);
				path.AddArc(Width - d - 1, 0, d, d, 270, 90);
				path.AddArc(
					Width - d - 1,
					Height - d - 1,
					d, d, 0, 90
				);
				path.AddArc(0, Height - d - 1, d, d, 90, 90);
				path.CloseFigure();

				Region oldRegion = Region;
				Region = new Region(path);
				if (oldRegion != null)
					oldRegion.Dispose();
			}
		}
	}
}