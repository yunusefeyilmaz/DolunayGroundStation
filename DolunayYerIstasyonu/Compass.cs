using DolunayYerIstasyonu.Properties;

namespace DolunayYerIstasyonu
{
    public class Compass
    {
        protected static void RotateAndTranslate(Graphics pe, Image img, double alphaRot, double alphaTrs, Point ptImg, int deltaPx, Point ptRot, float scaleFactor)
        {
            double beta = 0;
            double d = 0;
            float deltaXRot = 0;
            float deltaYRot = 0;
            float deltaXTrs = 0;
            float deltaYTrs = 0;

            // Rotation

            if (ptImg != ptRot)
            {
                // Internal coefficients
                if (ptRot.X != 0)
                {
                    beta = Math.Atan((double)ptRot.Y / (double)ptRot.X);
                }

                d = Math.Sqrt((ptRot.X * ptRot.X) + (ptRot.Y * ptRot.Y));

                // Computed offset
                deltaXRot = (float)(d * (Math.Cos(alphaRot - beta) - Math.Cos(alphaRot) * Math.Cos(alphaRot + beta) - Math.Sin(alphaRot) * Math.Sin(alphaRot + beta)));
                deltaYRot = (float)(d * (Math.Sin(beta - alphaRot) + Math.Sin(alphaRot) * Math.Cos(alphaRot + beta) - Math.Cos(alphaRot) * Math.Sin(alphaRot + beta)));
            }

            // Translation

            // Computed offset
            deltaXTrs = (float)(deltaPx * (Math.Sin(alphaTrs)));
            deltaYTrs = (float)(-deltaPx * (-Math.Cos(alphaTrs)));

            Rectangle rect = new Rectangle(ptRot.X - 50, ptRot.Y - 50, img.Width, (int)(img.Height / 5.5));
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(rect);
            pe.SetClip(path);
            // Rotate image support
            pe.RotateTransform((float)(alphaRot * 180 / Math.PI));

            // Display image

            pe.DrawImage(img, (ptImg.X + deltaXRot + deltaXTrs) * scaleFactor, (ptImg.Y + deltaYRot + deltaYTrs) * scaleFactor, img.Width * scaleFactor, img.Height * scaleFactor);
            pe.ResetClip();
            // Put image support as found
            pe.RotateTransform((float)(-alphaRot * 180 / Math.PI));
        }

        public static Bitmap DrawCompass(double yaw, double pitch, double roll, Size s)
        {
            double maxRadius = s.Width > s.Height ? s.Height / 2 : s.Width / 2;
            Bitmap horizonBackground = Resources.Horizon_GroundSky;
            horizonBackground = new Bitmap(horizonBackground, 100, 550);
            double sizeMultiplier = maxRadius / 250;

            Bitmap result = null;
            SolidBrush drawBrushBlack = new SolidBrush(Color.FromArgb(50, 50, 50));
            SolidBrush drawBrushRed = new SolidBrush(Color.FromArgb(240, 255, 0, 0));
            SolidBrush drawBrushOrange = new SolidBrush(Color.FromArgb(255, 255, 150, 0));
            SolidBrush drawBrushBlue = new SolidBrush(Color.FromArgb(255, 255, 250, 255));
            double outerradius = (((maxRadius - sizeMultiplier * 50) / maxRadius) * maxRadius);
            double innerradius = (((maxRadius - sizeMultiplier * 70) / maxRadius) * maxRadius);
            double degreeRadius = outerradius + 35 * sizeMultiplier;
            double dirRadius = innerradius - 30 * sizeMultiplier;
            double TriRadius = outerradius + sizeMultiplier;

            if (s.Width * s.Height > 0)
            {
                result = new Bitmap(s.Width, s.Height);
                using (Font font2 = new Font("Arial", (float)(30 * sizeMultiplier), FontStyle.Bold))
                {
                    using (Font font1 = new Font("Arial", (float)(25 * sizeMultiplier)))
                    {
                        using (Pen PenBlack = new Pen(Color.FromArgb(255, 0, 0, 0), ((int)(sizeMultiplier) < 4 ? 4 : (int)(sizeMultiplier))))
                        {
                            using (Pen penorange = new Pen(Color.FromArgb(255, 150, 0), ((int)(sizeMultiplier) < 1 ? 1 : (int)(sizeMultiplier))))
                            {
                                using (Pen penred = new Pen(Color.FromArgb(255, 0, 0), ((int)(sizeMultiplier) < 1 ? 1 : (int)(sizeMultiplier * 2))))
                                {
                                    using (Pen pen1 = new Pen(Color.FromArgb(0, 0, 0), (int)(sizeMultiplier * 5)))
                                    {
                                        using (Pen pen2 = new Pen(Color.FromArgb(0, 0, 0), ((int)(sizeMultiplier) < 1 ? 1 : (int)(sizeMultiplier))))
                                        {
                                            using (Pen pen3 = new Pen(Color.FromArgb(0, 0, 0, 0), ((int)(sizeMultiplier) < 1 ? 1 : (int)(sizeMultiplier))))
                                            {
                                                using (Graphics g = Graphics.FromImage(result))
                                                {
                                                    // Calculate some image information.
                                                    double sourcewidth = s.Width;
                                                    double sourceheight = s.Height;
                                                    // Center X
                                                    int xcenterpoint = (int)(s.Width / 2);
                                                    int ycenterpoint = (int)((s.Height / 2));
                                                    Point cntr = new Point(xcenterpoint, ycenterpoint);

                                                    // Center
                                                    int pointScale = 190;
                                                    Point pA1 = new Point(xcenterpoint, ycenterpoint - (int)(sizeMultiplier * pointScale));
                                                    Point pB1 = new Point(xcenterpoint - (int)(sizeMultiplier * 7), ycenterpoint - (int)(sizeMultiplier * pointScale));
                                                    Point pC1 = new Point(xcenterpoint, ycenterpoint - (int)(sizeMultiplier * pointScale * 1.3));
                                                    Point pB2 = new Point(xcenterpoint + (int)(sizeMultiplier * 7), ycenterpoint - (int)(sizeMultiplier * pointScale));

                                                    Point[] a2 = new Point[] { pA1, pB1, pC1 };
                                                    Point[] a3 = new Point[] { pA1, pB2, pC1 };

                                                    // Attitude 
                                                    Point ptBoule = new Point((int)(innerradius / 1.3), -(int)(horizonBackground.Height / 3.1));
                                                    Point ptRotation = new Point(xcenterpoint, ycenterpoint);

                                                    RotateAndTranslate(g, horizonBackground, roll, 0, ptBoule, (int)(-pitch * horizonBackground.Height / 7), ptRotation, 1);

                                                    double[] Cos = new double[360];
                                                    double[] Sin = new double[360];

                                                    // Draw center cross
                                                    g.DrawLine(pen2, new Point(((int)(xcenterpoint - (sizeMultiplier * 20))), ycenterpoint), new Point(((int)(xcenterpoint + (sizeMultiplier * 20))), ycenterpoint));
                                                    g.DrawLine(pen2, new Point(xcenterpoint, (int)(ycenterpoint - (sizeMultiplier * 20))), new Point(xcenterpoint, ((int)(ycenterpoint + (sizeMultiplier * 20)))));

                                                    // Prepare before and after for the red triangle
                                                    for (int d = 0; d < 360; d++)
                                                    {
                                                        double angleInRadians = ((((double)d) + 270d) - yaw) / 180F * Math.PI;
                                                        Cos[d] = Math.Cos(angleInRadians);
                                                        Sin[d] = Math.Sin(angleInRadians);
                                                    }

                                                    for (int d = 0; d < 360; d++)
                                                    {
                                                        Point p1 = new Point((int)(outerradius * Cos[d]) + xcenterpoint, (int)(outerradius * Sin[d]) + ycenterpoint);
                                                        Point p2 = new Point((int)(innerradius * Cos[d]) + xcenterpoint, (int)(innerradius * Sin[d]) + ycenterpoint);

                                                        // Draw Degree labels
                                                        if (d % 30 == 0)
                                                        {
                                                            g.DrawLine(PenBlack, p1, p2);

                                                            Point p3 = new Point((int)(degreeRadius * Cos[d]) + xcenterpoint, (int)(degreeRadius * Sin[d]) + ycenterpoint);
                                                            SizeF s1 = g.MeasureString(d.ToString(), font1);
                                                            p3.X = p3.X - (int)(s1.Width / 2);
                                                            p3.Y = p3.Y - (int)(s1.Height / 2);

                                                            g.DrawString(d.ToString(), font1, drawBrushBlack, p3);
                                                            Point pA = new Point((int)(TriRadius * Cos[d]) + xcenterpoint, (int)(TriRadius * Sin[d]) + ycenterpoint);

                                                            int width = (int)(sizeMultiplier * 4);
                                                            int dp = d + width > 359 ? d + width - 360 : d + width;
                                                            int dm = d - width < 0 ? d - width + 360 : d - width;

                                                            Point pB = new Point((int)((TriRadius - (20 * sizeMultiplier)) * Cos[dm]) + xcenterpoint, (int)((TriRadius - (20 * sizeMultiplier)) * Sin[dm]) + ycenterpoint);
                                                            Point pC = new Point((int)((TriRadius - (20 * sizeMultiplier)) * Cos[dp]) + xcenterpoint, (int)((TriRadius - (20 * sizeMultiplier)) * Sin[dp]) + ycenterpoint);

                                                            Pen p = PenBlack;
                                                            Brush b = drawBrushBlue;
                                                            if (d == 0)
                                                            {
                                                                p = penred;
                                                                b = drawBrushRed;
                                                            }
                                                            Point[] a = new Point[] { pA, pB, pC };

                                                            g.DrawPolygon(p, a);
                                                            g.FillPolygon(b, a);
                                                        }
                                                        else if (d % 2 == 0)
                                                        {
                                                            g.DrawLine(pen2, p1, p2);
                                                        }

                                                        // Draw N, E, S, W
                                                        if (d % 90 == 0)
                                                        {
                                                            string dir = (d == 0 ? "N" : (d == 90 ? "E" : (d == 180 ? "S" : "W")));
                                                            Point p4 = new Point((int)(dirRadius * Cos[d]) + xcenterpoint, (int)(dirRadius * Sin[d]) + ycenterpoint);
                                                            SizeF s2 = g.MeasureString(dir, font1);
                                                            p4.X = p4.X - (int)(s2.Width / 2);
                                                            p4.Y = p4.Y - (int)(s2.Height / 2);

                                                            g.DrawString(dir, font1, d == 0 ? drawBrushRed : drawBrushBlack, p4);
                                                        }
                                                    }

                                                    g.DrawPolygon(penred, a2);
                                                    g.FillPolygon(drawBrushRed, a2);
                                                    g.DrawPolygon(penred, a3);
                                                    g.FillPolygon(drawBrushBlack, a3);
                                                    string deg = Math.Round(yaw, 2).ToString("0.00") + "°";
                                                    SizeF s3 = g.MeasureString(deg, font1);

                                                    g.DrawString(deg, font2, drawBrushRed, new Point(xcenterpoint - (int)(s3.Width / 2), +ycenterpoint - (int)(sizeMultiplier * 255)));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

    }
}
