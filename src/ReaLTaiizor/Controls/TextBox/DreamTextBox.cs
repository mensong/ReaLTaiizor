﻿#region Imports

using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

#endregion

namespace ReaLTaiizor.Controls
{
    #region DreamTextBox

    public class DreamTextBox : TextBox
    {
        public DreamTextBox()
        {
            ForeColor = Color.FromArgb(40, 218, 255);
            BackColor = Color.FromArgb(41, 41, 41);
            BorderStyle = BorderStyle.FixedSingle;
            Text = string.Empty;
        }

        private Color _ColorA = Color.FromArgb(31, 31, 31);
        public Color ColorA
        {
            get => _ColorA;
            set => _ColorA = value;
        }

        private Color _ColorB = Color.FromArgb(41, 41, 41);
        public Color ColorB
        {
            get => _ColorB;
            set => _ColorB = value;
        }

        private Color _ColorC = Color.FromArgb(51, 51, 51);
        public Color ColorC
        {
            get => _ColorC;
            set => _ColorC = value;
        }

        private Color _ColorD = Color.FromArgb(0, 0, 0, 0);
        public Color ColorD
        {
            get => _ColorD;
            set => _ColorD = value;
        }

        private Color _ColorE = Color.FromArgb(25, 255, 255, 255);
        public Color ColorE
        {
            get => _ColorE;
            set => _ColorE = value;
        }

        private Color _ColorF = Color.Black;
        public Color ColorF
        {
            get => _ColorF;
            set => _ColorF = value;
        }


        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using Bitmap B = new(Width, Height);
            using Graphics G = Graphics.FromImage(B);
            Rectangle R1 = new(0, 0, Width, Height / 2);
            Rectangle R2 = new(0, Height / 2, Width, Height);
            G.DrawRectangle(new(_ColorA), 0, 0, Width - 1, Height - 1);

            Brush GB1 = new LinearGradientBrush(R1, _ColorC, _ColorB, 40.0F);
            Brush GB2 = new LinearGradientBrush(R2, _ColorB, _ColorC, 90.0F);
            G.FillRectangle(GB1, R1);
            G.FillRectangle(GB2, R2);
            //Draw.Gradient(G, _ColorB, _ColorC, 1, 1, Width - 2, Height - 2);

            Pen P2 = new(_ColorF, 2);
            G.DrawRectangle(P2, 0, 0, Width, Height);
            SizeF O = G.MeasureString(Text, Font);
            G.DrawString(Text, Font, new SolidBrush(ForeColor), Width / 2 - O.Width / 2, Height / 2 - O.Height / 2);

            //Draw.Blend(G, _ColorD, _ColorE, _ColorD, 0.5, 0, 1, 1, Width - 2, 1);
            Bitmap B1 = B;
            e.Graphics.DrawImage(B1, 0, 0);
        }
    }

    #endregion
}