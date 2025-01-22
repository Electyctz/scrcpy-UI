using System.ComponentModel;
using System.Drawing.Text;

namespace scrcpy_UI.Helpers
{
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Windows.Forms.Design")]
    public class CustomButton : Button
    {
        public Color BorderColor { get; set; } = Color.FromArgb(25, 27, 28);
        public int BorderSize { get; set; } = 1;

        public CustomButton()
        {
            BackColor = Color.FromArgb(25, 27, 28);
            ForeColor = Color.White;
            Size = new Size(75, 27);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseDownBackColor = BackColor;
            FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 35, 35);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Color backgroundColor;
            if (MouseButtons == MouseButtons.Left && ClientRectangle.Contains(PointToClient(Cursor.Position)))
            {
                backgroundColor = FlatAppearance.MouseDownBackColor;
            }
            else if (ClientRectangle.Contains(PointToClient(Cursor.Position)))
            {
                backgroundColor = FlatAppearance.MouseOverBackColor;
            }
            else
            {
                backgroundColor = BackColor;
            }

            using (SolidBrush brush = new SolidBrush(backgroundColor))
            {
                graphics.FillRectangle(brush, ClientRectangle);
            }

            if (BorderSize > 0)
            {
                using (Pen pen = new Pen(BorderColor, BorderSize))
                {
                    Rectangle borderRect = new Rectangle(0, 0, Width - 1, Height - 1);
                    graphics.DrawRectangle(pen, borderRect);
                }
            }

            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                using (Brush textBrush = new SolidBrush(ForeColor))
                {
                    graphics.DrawString(Text, Font, textBrush, ClientRectangle, stringFormat);
                }
            }
        }
    }
}
