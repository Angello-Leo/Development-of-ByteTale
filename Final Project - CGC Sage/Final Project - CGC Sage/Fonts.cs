using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project___CGC_Sage
{
    public static class FontManager
    {
        private static PrivateFontCollection fontCollection = new PrivateFontCollection();
        public static Dictionary<string, FontFamily> FontFamilies { get; private set; } = new Dictionary<string, FontFamily>();
        public static FontFamily PixelFontFamily { get; private set; }

        static FontManager()
        {
            string[] fontFiles = new string[]
    {
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperator-Bold.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperator.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperator8-Bold.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperator8.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperatorHB.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperatorHB8.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperatorHBSC.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperatorMono-Bold.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperatorMono8-Bold.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperatorMono8.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperatorMonoHB.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperatorMonoHB8.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperatorSC-Bold.ttf"),
        Path.Combine(Application.StartupPath, "Resources", "UndertaleFont", "PixelOperatorSC.ttf"),
        // Add more if needed
    };

            foreach (var fontFile in fontFiles)
            {
                if (File.Exists(fontFile))
                {
                    try
                    {
                        fontCollection.AddFontFile(fontFile);
                        FontFamily family = fontCollection.Families.Last();
                        if (!FontFamilies.ContainsKey(family.Name))
                        {
                            FontFamilies[family.Name] = family;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load font from: {fontFile}\n{ex.Message}", "Font Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show($"Font file not found:\n{fontFile}", "Missing Font", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (fontCollection.Families.Length > 0)
            {
                PixelFontFamily = fontCollection.Families[0]; // Default
            }
            else
            {
                MessageBox.Show("No fonts were successfully loaded.", "Font Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static Font GetFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font(PixelFontFamily, size, style);
        }

        public static Font GetFont(string familyName, float size, FontStyle style = FontStyle.Regular)
        {
            if (FontFamilies.ContainsKey(familyName))
            {
                return new Font(FontFamilies[familyName], size, style);
            }
            else
            {
                MessageBox.Show($"Font family \"{familyName}\" not found. Using default font.", "Font Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return new Font("Arial", size, style);
            }
        }
    }
}
