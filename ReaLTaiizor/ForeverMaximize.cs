﻿#region Imports

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

#endregion

namespace ReaLTaiizor
{
	#region ForeverMaximize

	public class ForeverMaximize : Control
	{
		private MouseStateForever State = MouseStateForever.None;
		private int x;

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			State = MouseStateForever.Over;
			Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			State = MouseStateForever.Down;
			Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			State = MouseStateForever.None;
			Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			State = MouseStateForever.Over;
			Invalidate();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			x = e.X;
			Invalidate();
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			switch (FindForm().WindowState)
			{
				case FormWindowState.Maximized:
					FindForm().WindowState = FormWindowState.Normal;
					break;
				case FormWindowState.Normal:
					FindForm().WindowState = FormWindowState.Maximized;
					break;
			}
		}

		[Category("Colors")]
		public Color BaseColor
		{
			get { return _BaseColor; }
			set { _BaseColor = value; }
		}

		[Category("Colors")]
		public Color TextColor
		{
			get { return _TextColor; }
			set { _TextColor = value; }
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Size = new Size(18, 18);
		}

		private Color _BaseColor = Color.FromArgb(45, 47, 49);
		private Color _TextColor = Color.FromArgb(243, 243, 243);

		public ForeverMaximize()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
			DoubleBuffered = true;
			BackColor = Color.White;
			Size = new Size(18, 18);
			Anchor = AnchorStyles.Top | AnchorStyles.Right;
			Font = new Font("Marlett", 12);
			Cursor = Cursors.Hand;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap B = new Bitmap(Width, Height);
			Graphics G = Graphics.FromImage(B);

			Rectangle Base = new Rectangle(0, 0, Width, Height);

			var _with4 = G;
			_with4.SmoothingMode = SmoothingMode.HighQuality;
			_with4.PixelOffsetMode = PixelOffsetMode.HighQuality;
			_with4.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			_with4.Clear(BackColor);

			//-- Base
			_with4.FillRectangle(new SolidBrush(_BaseColor), Base);

			//-- Maximize
			if (FindForm().WindowState == FormWindowState.Maximized)
			{
				_with4.DrawString("2", Font, new SolidBrush(TextColor), new Rectangle(1, 1, Width, Height), ForeverLibrary.CenterSF);
			}
			else if (FindForm().WindowState == FormWindowState.Normal)
			{
				_with4.DrawString("1", Font, new SolidBrush(TextColor), new Rectangle(1, 1, Width, Height), ForeverLibrary.CenterSF);
			}

			//-- Hover/down
			switch (State)
			{
				case MouseStateForever.Over:
					_with4.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), Base);
					break;
				case MouseStateForever.Down:
					_with4.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), Base);
					break;
			}

			base.OnPaint(e);
			G.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(B, 0, 0);
			B.Dispose();
		}
	}

	#endregion
}