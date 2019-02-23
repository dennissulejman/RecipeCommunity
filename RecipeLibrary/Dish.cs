using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

    }
}
