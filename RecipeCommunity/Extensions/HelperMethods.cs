using System.Drawing;

namespace RecipeCommunity.Extensions
{
    public static class HelperMethods
    {
        public static Image ByteArrayToImage(byte[] bytesArr)
        {
            return (Bitmap)new ImageConverter().ConvertFrom(bytesArr);
        }

        public static byte[] ImageToByteArray(Image image)
        {
            return (byte[])new ImageConverter().ConvertFrom(image);
        }
    }
}
