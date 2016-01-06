using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Imaging;
using JetBrains.ProjectModel;
using JetBrains.UI.Icons.ImageSourceIcons;

namespace ResharperGlyphfriend
{
    [SolutionComponent]
    public class GlyphfriendStorage
    {
        private static Dictionary<string, ImageSourceIconId> _glyphs;

        internal static Dictionary<string, ImageSourceIconId> Glyphs
        {
            get { return _glyphs; }
            set { _glyphs = value; }
        }

        public GlyphfriendStorage()
        {
            LoadGlyphs();
        }

        private void LoadGlyphs()
        {
            _glyphs = _glyphs ?? new Dictionary<string, ImageSourceIconId>();

            foreach (var manifestResourceName in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                string exactResourceName = manifestResourceName.Split('.')[3];

                var glyphStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(manifestResourceName);

                if (glyphStream != null)
                {
                    var glyphsBitmap = BitmapFrame.Create(glyphStream);

                    _glyphs.Add(exactResourceName, new ImageSourceIconId(glyphsBitmap));
                }
            }
        }
    }
}