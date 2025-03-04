using System.Reflection;

namespace GameLauncher
{
    public enum ImageType
    {
        [ImageTypeAttr(180, 120)] GRID,
        [ImageTypeAttr(180, 180)] LOGO,
        [ImageTypeAttr(180, 320)] HERO
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ImageTypeAttr : Attribute
    {
        internal ImageTypeAttr(int height, int width)
        {
            Height = height;
            Width = width;
        }
        public int Height { get; private set; }
        public int Width { get; private set; }

    }

    public static class ImageTypes
    {
        public static int GetHeight(this ImageType type)
        {
            return GetAttr(type).Height;
        }

        public static int GetWidth(this ImageType type)
        {
            return GetAttr(type).Width;
        }

        private static ImageTypeAttr GetAttr(ImageType type)
        {
            FieldInfo? info = ForValue(type);
            if (info == null)
            {
                throw new ArgumentException("Couldn't find the field's info");
            }
            ImageTypeAttr? attr = (ImageTypeAttr?) Attribute.GetCustomAttribute(info, typeof(ImageTypeAttr));
            if (attr == null) {
                throw new ArgumentException("Couldn't find the field's attribute");
            }

            return attr;
        }

        private static FieldInfo? ForValue(ImageType type)
        {
            string? name = Enum.GetName(typeof(ImageType), type);
            return name == null ? throw new ArgumentException("Couldn't find the field's name") : typeof(ImageType).GetField(name);
        }
    }
}
