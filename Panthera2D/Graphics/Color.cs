using System;
using System.Runtime.InteropServices;

namespace Panthera2D.Graphics
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [Serializable]
    public struct Color
    {

        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public Color(byte r, byte g, byte b, byte a = 255)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }

        public Color(float r, float g, float b, float a = 1f)
        {
            this.R = (byte)(r * 255);
            this.G = (byte)(g * 255);
            this.B = (byte)(b * 255);
            this.A = (byte)(a * 255);
        }

        public override string ToString()
        {
            return $"RGBA({R},{G},{B},{A})";
        }

        public static Color FromHSL(float h, float s, float l)
        {
            float r = 0, g = 0, b = 0;
            if (l != 0)
            {
                if (s == 0)
                    r = g = b = l;
                else
                {
                    float temp2;
                    if (l < 0.5)
                        temp2 = l * (1.0f + s);
                    else
                        temp2 = l + s - (l * s);

                    float temp1 = 2.0f * l - temp2;

                    r = GetColorComponent(temp1, temp2, h + 1.0f / 3.0f);
                    g = GetColorComponent(temp1, temp2, h);
                    b = GetColorComponent(temp1, temp2, h - 1.0f / 3.0f);
                }
            }

            return new Color(r, g, b);
        }

        private static float GetColorComponent(float temp1, float temp2, float temp3)
        {
            if (temp3 < 0.0f)
                temp3 += 1.0f;
            else if (temp3 > 1.0f)
                temp3 -= 1.0f;

            if (temp3 < 1.0f / 6.0f)
                return temp1 + (temp2 - temp1) * 6.0f * temp3;
            else if (temp3 < 0.5f)
                return temp2;
            else if (temp3 < 2.0f / 3.0f)
                return temp1 + ((temp2 - temp1) * ((2.0f / 3.0f) - temp3) * 6.0f);
            else
                return temp1;
        }

        public static Color operator /(Color a, Color b)
        {
            Color result = new Color();
            result.R = (byte)((a.R + b.R) / 2);
            result.G = (byte)((a.G + b.G) / 2);
            result.B = (byte)((a.B + b.B) / 2);
            result.A = (byte)((a.A + b.A) / 2);

            return result;
        }

        public static Color operator +(Color a, Color b)
        {
            Color result = new Color();

            result.R = (byte)(MathF.Min(a.R + b.R, byte.MaxValue));
            result.G = (byte)(MathF.Min(a.G + b.G, byte.MaxValue));
            result.B = (byte)(MathF.Min(a.B + b.B, byte.MaxValue));
            result.A = (byte)(MathF.Min(a.A + b.A, byte.MaxValue));

            return result;
        }

        #region ReadOnly Colors

        public static readonly Color AliceBlue = new Color(0.9411765f, 0.972549f, 1f);
        public static readonly Color AntiqueWhite = new Color(0.9803922f, 0.9215686f, 0.8431373f);
        public static readonly Color Aquamarine = new Color(0.4980392f, 1f, 0.8313726f);
        public static readonly Color Azure = new Color(0.9411765f, 1f, 1f);
        public static readonly Color Beige = new Color(0.9607843f, 0.9607843f, 0.8627451f);
        public static readonly Color Bisque = new Color(1f, 0.8941177f, 0.7686275f);
        public static readonly Color Black = new Color(0f, 0f, 0f);
        public static readonly Color BlanchedAlmond = new Color(1f, 0.9215686f, 0.8039216f);
        public static readonly Color Blue = new Color(0f, 0f, 1f);
        public static readonly Color BlueViolet = new Color(0.5411765f, 0.1686275f, 0.8862745f);
        public static readonly Color Brown = new Color(0.6470588f, 0.1647059f, 0.1647059f);
        public static readonly Color BurlyWood = new Color(0.8705882f, 0.7215686f, 0.5294118f);
        public static readonly Color CadetBlue = new Color(0.372549f, 0.6196079f, 0.627451f);
        public static readonly Color Chartreuse = new Color(0.4980392f, 1f, 0f);
        public static readonly Color Chocolate = new Color(0.8235294f, 0.4117647f, 0.1176471f);
        public static readonly Color Coral = new Color(1f, 0.4980392f, 0.3137255f);
        public static readonly Color CornflowerBlue = new Color(0.3921569f, 0.5843138f, 0.9294118f);
        public static readonly Color Cornsilk = new Color(1f, 0.972549f, 0.8627451f);
        public static readonly Color Crimson = new Color(0.8627451f, 0.07843138f, 0.2352941f);
        public static readonly Color DarkBlue = new Color(0f, 0f, 0.5450981f);
        public static readonly Color DarkCyan = new Color(0f, 0.5450981f, 0.5450981f);
        public static readonly Color DarkGoldenrod = new Color(0.7215686f, 0.5254902f, 0.04313726f);
        public static readonly Color DarkGreen = new Color(0f, 0.3921569f, 0f);
        public static readonly Color DarkKhaki = new Color(0.7411765f, 0.7176471f, 0.4196078f);
        public static readonly Color DarkMagenta = new Color(0.5450981f, 0f, 0.5450981f);
        public static readonly Color DarkOliveGreen = new Color(0.3333333f, 0.4196078f, 0.1843137f);
        public static readonly Color DarkOrange = new Color(1f, 0.5490196f, 0f);
        public static readonly Color DarkOrchid = new Color(0.6f, 0.1960784f, 0.8f);
        public static readonly Color DarkRed = new Color(0.5450981f, 0f, 0f);
        public static readonly Color DarkSalmon = new Color(0.9137255f, 0.5882353f, 0.4784314f);
        public static readonly Color DarkSeaGreen = new Color(0.5607843f, 0.7372549f, 0.5607843f);
        public static readonly Color DarkSlateBlue = new Color(0.282353f, 0.2392157f, 0.5450981f);
        public static readonly Color DarkTurquoise = new Color(0f, 0.8078431f, 0.8196079f);
        public static readonly Color DarkViolet = new Color(0.5803922f, 0f, 0.827451f);
        public static readonly Color DeepPink = new Color(1f, 0.07843138f, 0.5764706f);
        public static readonly Color DeepSkyBlue = new Color(0f, 0.7490196f, 1f);
        public static readonly Color DodgerBlue = new Color(0.1176471f, 0.5647059f, 1f);
        public static readonly Color FireBrick = new Color(0.6980392f, 0.1333333f, 0.1333333f);
        public static readonly Color FloralWhite = new Color(1f, 0.9803922f, 0.9411765f);
        public static readonly Color ForestGreen = new Color(0.1333333f, 0.5450981f, 0.1333333f);
        public static readonly Color Gainsboro = new Color(0.8627451f, 0.8627451f, 0.8627451f);
        public static readonly Color GhostWhite = new Color(0.972549f, 0.972549f, 1f);
        public static readonly Color Gold = new Color(1f, 0.8431373f, 0f);
        public static readonly Color Goldenrod = new Color(0.854902f, 0.6470588f, 0.1254902f);
        public static readonly Color Green = new Color(0f, 1f, 0f);
        public static readonly Color GreenYellow = new Color(0.6784314f, 1f, 0.1843137f);
        public static readonly Color Honeydew = new Color(0.9411765f, 1f, 0.9411765f);
        public static readonly Color HotPink = new Color(1f, 0.4117647f, 0.7058824f);
        public static readonly Color IndianRed = new Color(0.8039216f, 0.3607843f, 0.3607843f);
        public static readonly Color Indigo = new Color(0.2941177f, 0f, 0.509804f);
        public static readonly Color Ivory = new Color(1f, 1f, 0.9411765f);
        public static readonly Color Khaki = new Color(0.9411765f, 0.9019608f, 0.5490196f);
        public static readonly Color Lavender = new Color(0.9019608f, 0.9019608f, 0.9803922f);
        public static readonly Color LavenderBlush = new Color(1f, 0.9411765f, 0.9607843f);
        public static readonly Color LawnGreen = new Color(0.4862745f, 0.9882353f, 0f);
        public static readonly Color LemonChiffon = new Color(1f, 0.9803922f, 0.8039216f);
        public static readonly Color LightBlue = new Color(0.6784314f, 0.8470588f, 0.9019608f);
        public static readonly Color LightCoral = new Color(0.9411765f, 0.5019608f, 0.5019608f);
        public static readonly Color LightCyan = new Color(0.8784314f, 1f, 1f);
        public static readonly Color LightGoldenrodYellow = new Color(0.9803922f, 0.9803922f, 0.8235294f);
        public static readonly Color LightGreen = new Color(0.5647059f, 0.9333333f, 0.5647059f);
        public static readonly Color LightPink = new Color(1f, 0.7137255f, 0.7568628f);
        public static readonly Color LightSalmon = new Color(1f, 0.627451f, 0.4784314f);
        public static readonly Color LightSeaGreen = new Color(0.1254902f, 0.6980392f, 0.6666667f);
        public static readonly Color LightSkyBlue = new Color(0.5294118f, 0.8078431f, 0.9803922f);
        public static readonly Color LightSteelBlue = new Color(0.6901961f, 0.7686275f, 0.8705882f);
        public static readonly Color LightYellow = new Color(1f, 1f, 0.8784314f);
        public static readonly Color Lime = new Color(0f, 1f, 0f);
        public static readonly Color LimeGreen = new Color(0.1960784f, 0.8039216f, 0.1960784f);
        public static readonly Color Linen = new Color(0.9803922f, 0.9411765f, 0.9019608f);
        public static readonly Color Maroon = new Color(0.5019608f, 0f, 0f);
        public static readonly Color MediumAquamarine = new Color(0.4f, 0.8039216f, 0.6666667f);
        public static readonly Color MediumBlue = new Color(0f, 0f, 0.8039216f);
        public static readonly Color MediumOrchid = new Color(0.7294118f, 0.3333333f, 0.827451f);
        public static readonly Color MediumPurple = new Color(0.5764706f, 0.4392157f, 0.8588235f);
        public static readonly Color MediumSeaGreen = new Color(0.2352941f, 0.7019608f, 0.4431373f);
        public static readonly Color MediumSlateBlue = new Color(0.4823529f, 0.4078431f, 0.9333333f);
        public static readonly Color MediumSpringGreen = new Color(0f, 0.9803922f, 0.6039216f);
        public static readonly Color MediumTurquoise = new Color(0.282353f, 0.8196079f, 0.8f);
        public static readonly Color MediumVioletRed = new Color(0.7803922f, 0.08235294f, 0.5215687f);
        public static readonly Color MidnightBlue = new Color(0.09803922f, 0.09803922f, 0.4392157f);
        public static readonly Color MintCream = new Color(0.9607843f, 1f, 0.9803922f);
        public static readonly Color MistyRose = new Color(1f, 0.8941177f, 0.8823529f);
        public static readonly Color Moccasin = new Color(1f, 0.8941177f, 0.7098039f);
        public static readonly Color NavajoWhite = new Color(1f, 0.8705882f, 0.6784314f);
        public static readonly Color Navy = new Color(0f, 0f, 0.5019608f);
        public static readonly Color OldLace = new Color(0.9921569f, 0.9607843f, 0.9019608f);
        public static readonly Color Olive = new Color(0.5019608f, 0.5019608f, 0f);
        public static readonly Color OliveDrab = new Color(0.4196078f, 0.5568628f, 0.1372549f);
        public static readonly Color Orange = new Color(1f, 0.6470588f, 0f);
        public static readonly Color OrangeRed = new Color(1f, 0.2705882f, 0f);
        public static readonly Color Orchid = new Color(0.854902f, 0.4392157f, 0.8392157f);
        public static readonly Color PaleGoldenrod = new Color(0.9333333f, 0.9098039f, 0.6666667f);
        public static readonly Color PaleGreen = new Color(0.5960785f, 0.9843137f, 0.5960785f);
        public static readonly Color PaleTurquoise = new Color(0.6862745f, 0.9333333f, 0.9333333f);
        public static readonly Color PaleVioletRed = new Color(0.8588235f, 0.4392157f, 0.5764706f);
        public static readonly Color PapayaWhip = new Color(1f, 0.9372549f, 0.8352941f);
        public static readonly Color PeachPuff = new Color(1f, 0.854902f, 0.7254902f);
        public static readonly Color Peru = new Color(0.8039216f, 0.5215687f, 0.2470588f);
        public static readonly Color Pink = new Color(1f, 0.7529412f, 0.7960784f);
        public static readonly Color Plum = new Color(0.8666667f, 0.627451f, 0.8666667f);
        public static readonly Color PowderBlue = new Color(0.6901961f, 0.8784314f, 0.9019608f);
        public static readonly Color Purple = new Color(0.5019608f, 0f, 0.5019608f);
        public static readonly Color RebeccaPurple = new Color(0.4f, 0.2f, 0.6f);
        public static readonly Color Red = new Color(1f, 0f, 0f);
        public static readonly Color RosyBrown = new Color(0.7372549f, 0.5607843f, 0.5607843f);
        public static readonly Color RoyalBlue = new Color(0.254902f, 0.4117647f, 0.8823529f);
        public static readonly Color SaddleBrown = new Color(0.5450981f, 0.2705882f, 0.07450981f);
        public static readonly Color Salmon = new Color(0.9803922f, 0.5019608f, 0.4470588f);
        public static readonly Color SandyBrown = new Color(0.9568627f, 0.6431373f, 0.3764706f);
        public static readonly Color SeaGreen = new Color(0.1803922f, 0.5450981f, 0.3411765f);
        public static readonly Color Seashell = new Color(1f, 0.9607843f, 0.9333333f);
        public static readonly Color Sienna = new Color(0.627451f, 0.3215686f, 0.1764706f);
        public static readonly Color Silver = new Color(0.7529412f, 0.7529412f, 0.7529412f);
        public static readonly Color SkyBlue = new Color(0.5294118f, 0.8078431f, 0.9215686f);
        public static readonly Color SlateBlue = new Color(0.4156863f, 0.3529412f, 0.8039216f);
        public static readonly Color Snow = new Color(1f, 0.9803922f, 0.9803922f);
        public static readonly Color SpringGreen = new Color(0f, 1f, 0.4980392f);
        public static readonly Color SteelBlue = new Color(0.2745098f, 0.509804f, 0.7058824f);
        public static readonly Color Tan = new Color(0.8235294f, 0.7058824f, 0.5490196f);
        public static readonly Color Teal = new Color(0f, 0.5019608f, 0.5019608f);
        public static readonly Color Thistle = new Color(0.8470588f, 0.7490196f, 0.8470588f);
        public static readonly Color Tomato = new Color(1f, 0.3882353f, 0.2784314f);
        public static readonly Color Transparent = new Color(1f, 0f, 0f, 0f);
        public static readonly Color Turquoise = new Color(0.2509804f, 0.8784314f, 0.8156863f);
        public static readonly Color Violet = new Color(0.9333333f, 0.509804f, 0.9333333f);
        public static readonly Color Wheat = new Color(0.9607843f, 0.8705882f, 0.7019608f);
        public static readonly Color White = new Color(1f, 1f, 1f);
        public static readonly Color WhiteSmoke = new Color(0.9607843f, 0.9607843f, 0.9607843f);
        public static readonly Color Yellow = new Color(1f, 1f, 0f);
        public static readonly Color YellowGreen = new Color(0.6039216f, 0.8039216f, 0.1960784f);
        #endregion

    }
}
