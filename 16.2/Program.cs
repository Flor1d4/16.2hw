using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._2
{
    internal class Program
    {
        
        #region vector
        public struct Vector3
        {
            public float x;
            public float y;
            public float z;

            public Vector3(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public static Vector3 operator *(float multiplier, Vector3 vector)
            {
                return new Vector3(vector.x * multiplier, vector.y * multiplier, vector.z * multiplier);
            }

            public static Vector3 operator +(Vector3 vector1, Vector3 vector2)
            {
                return new Vector3(vector1.x + vector2.x, vector1.y + vector2.y, vector1.z + vector2.z);
            }

            public static Vector3 operator -(Vector3 vector1, Vector3 vector2)
            {
                return new Vector3(vector1.x - vector2.x, vector1.y - vector2.y, vector1.z - vector2.z);
            }

            public override string ToString()
            {
                return $"({x}, {y}, {z})";
            }
        }
#endregion

        #region Color
        struct RGBColor
        {
            public int R { get; set; }
            public int G { get; set; }
            public int B { get; set; }

            // инициализации цвета
            public RGBColor(int r, int g, int b)
            {
                R = r;
                G = g;
                B = b;
            }

           //HEX 
            public string ToHex()
            {
                return "#" + R.ToString("X2") + G.ToString("X2") + B.ToString("X2");
            }

            //HSL 
            public void ToHSL(out double h, out double s, out double l)
            {
                double r = (double)R / 255;
                double g = (double)G / 255;
                double b = (double)B / 255;

                double max = Math.Max(Math.Max(r, g), b);
                double min = Math.Min(Math.Min(r, g), b);

                double delta = max - min;

                
                if (delta == 0)
                {
                    h = 0;
                }
                else if (max == r)
                {
                    h = ((g - b) / delta) % 6;
                }
                else if (max == g)
                {
                    h = (b - r) / delta + 2;
                }
                else
                {
                    h = (r - g) / delta + 4;
                }
                h = Math.Round(h * 60);

                
                l = (max + min) / 2;

                 
                if (delta == 0)
                {
                    s = 0;
                }
                else
                {
                    s = delta / (1 - Math.Abs(2 * l - 1));
                }
                s = Math.Round(s * 100);
                l = Math.Round(l * 100);
            }

            // CMYK 
            public void ToCMYK(out double c, out double m, out double y, out double k)
            {
                double r = (double)R / 255;
                double g = (double)G / 255;
                double b = (double)B / 255;

                k = 1 - Math.Max(Math.Max(r, g), b);
                c = (1 - r - k) / (1 - k);
                m = (1 - g - k) / (1 - k);
                y = (1 - b - k) / (1 - k);

                c = Math.Round(c * 100);
                m = Math.Round(m * 100);
                y = Math.Round(y * 100);
                k = Math.Round(k * 100);
            }
        }
        #endregion

        static void Main(string[] args)
        {
            Vector3 vector1 = new Vector3(1, 2, 3);
            Vector3 vector2 = new Vector3(4, 5, 6);

            Vector3 result1 = 2 * vector1;
            Console.WriteLine(result1);

            Vector3 result2 = vector1 + vector2;
            Console.WriteLine(result2); 

            Vector3 result3 = vector2 - vector1;
            Console.WriteLine(result3); 

            Console.WriteLine("--------------");

            RGBColor color = new RGBColor(255, 0, 0);
            Console.WriteLine("RGB: ({0}, {1}, {2})", color.R, color.G, color.B);
            Console.WriteLine("HEX: {0}", color.ToHex());
            double h, s, l;
            color.ToHSL(out h, out s, out l);
            Console.WriteLine("HSL: ({0}%, {1}%, {2}%)");
        }
    }
}
