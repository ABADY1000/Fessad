using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fessad_TL
{
    public static class PageAniamtions
    {
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideInFromRigt(seconds, page.WindowWidth);
            sb.AddFadeIn(seconds, 0);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int) seconds * 1000);
        }

        public static async Task SlideAndFadeOutToRight(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideOutToLeft(seconds, page.WindowWidth);
            sb.AddFadeOut(seconds, 0);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

    }
}
