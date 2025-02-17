using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ModelosColor
{
    public class ImageProcessor
    {
        private Bitmap originalImage;

        public ImageProcessor(Bitmap image)
        {
            originalImage = image;
        }

        public Bitmap ConvertToGrayscale()
        {
            Bitmap grayImage = new Bitmap(originalImage.Width, originalImage.Height);
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    grayImage.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
                }
            }
            return grayImage;
        }

        public Bitmap ConvertToSepia()
        {
            Bitmap sepiaImage = new Bitmap(originalImage.Width, originalImage.Height);
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);
                    int tr = (int)(pixelColor.R * 0.393 + pixelColor.G * 0.769 + pixelColor.B * 0.189);
                    int tg = (int)(pixelColor.R * 0.349 + pixelColor.G * 0.686 + pixelColor.B * 0.168);
                    int tb = (int)(pixelColor.R * 0.272 + pixelColor.G * 0.534 + pixelColor.B * 0.131);

                    tr = Math.Min(255, tr);
                    tg = Math.Min(255, tg);
                    tb = Math.Min(255, tb);

                    sepiaImage.SetPixel(x, y, Color.FromArgb(tr, tg, tb));
                }
            }
            return sepiaImage;
        }

        public Bitmap ConvertToNegative()
        {
            Bitmap negativeImage = new Bitmap(originalImage.Width, originalImage.Height);
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);
                    int r = 255 - pixelColor.R;
                    int g = 255 - pixelColor.G;
                    int b = 255 - pixelColor.B;

                    negativeImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return negativeImage;
        }

        public Bitmap ConvertToRedDominant()
        {
            Bitmap redImage = new Bitmap(originalImage.Width, originalImage.Height);
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixelColor = originalImage.GetPixel(x, y);
                    int r = pixelColor.R;
                    int g = (int)(pixelColor.G * 0.5);
                    int b = (int)(pixelColor.B * 0.5);

                    redImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return redImage;
        }
    }
}
