using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace RecipeWPFUI
{
    public class Dish
    {
        public int DishId { get; set; }
        public byte[] Picture { get; set; }
        public string DishName { get; set; }
        public ICollection<DishIngredientAssembly> DishIngredientAssemblies { get; set; } = new List<DishIngredientAssembly>();
        public string Instructions { get; set; }
        public Cuisine Cuisine { get; set; }

        public byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

    }
}
