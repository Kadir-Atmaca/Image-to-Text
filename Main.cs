using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTT_and_TTP
{
    public partial class D1
    {
        public static void PngToTxt(string imagePath, string txtPath)
        {
            Bitmap image = new Bitmap(imagePath);
            using (StreamWriter writer = new StreamWriter(txtPath))
            {
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color pixelColor = image.GetPixel(x, y);
                        writer.WriteLine($"{x},{y},{pixelColor.R},{pixelColor.G},{pixelColor.B}");
                    }
                }
            }
        }
        public static void TxtToPng(string txtPath, string imagePath)
        {
            string[] lines = File.ReadAllLines(txtPath);
            string[] dimensions = lines[lines.Length - 1].Split(',');
            int width = int.Parse(dimensions[0]) + 1;
            int height = int.Parse(dimensions[1]) + 1;

            Bitmap image = new Bitmap(width, height);
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                int x = int.Parse(values[0]);
                int y = int.Parse(values[1]);
                int r = int.Parse(values[2]);
                int g = int.Parse(values[3]);
                int b = int.Parse(values[4]);

                Color pixelColor = Color.FromArgb(r, g, b);
                image.SetPixel(x, y, pixelColor);
            }

            image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}

