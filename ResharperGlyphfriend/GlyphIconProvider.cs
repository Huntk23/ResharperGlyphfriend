using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Css.Impl;
using JetBrains.UI.Icons;
using JetBrains.UI.Icons.ImageSourceIcons;

namespace ResharperGlyphfriend
{
    [DeclaredElementIconProvider]
    public class GlyphIconProvider : IDeclaredElementIconProvider
    {
        public IconId GetImageId(IDeclaredElement declaredElement, PsiLanguageType languageType, out bool canApplyExtensions)
        {
            if (declaredElement.GetElementType() == CssDeclaredElementType.CssClass)
            {
                canApplyExtensions = false;

                ImageSourceIconId value;
                if (GlyphfriendStorage.Glyphs.TryGetValue(declaredElement.ShortName, out value))
                {
                    return value;
                }
            }

            canApplyExtensions = true;

            return null;
        }
    }
}