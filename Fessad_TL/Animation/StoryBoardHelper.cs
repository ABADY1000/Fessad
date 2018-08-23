using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Fessad_TL
{
    public static class StoryBoardHelper
    {
        /// <summary>
        /// StoryBoard method makes the attached page slide in as an entrance
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds">Movement duration</param>
        /// <param name="offset">Where to start and finish the animation</param>
        /// <param name="deceleration"></param>
        public static void AddSlideInFromRigt(this Storyboard storyboard, float seconds, double offset, float deceleration = 0.9f)
        {
            // Make the wanted movement
            var slideAnimation = new ThicknessAnimation
            {
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                DecelerationRatio = deceleration
            };

            // Add it to the wanted property
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));

            // Attach the property to the made storyboard
            storyboard.Children.Add(slideAnimation);
        }

        /// <summary>
        /// StoryBoard method makes the attached page slide out as an exit
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds">Movement duration</param>
        /// <param name="offset">Where to start and finish the animation</param>
        /// <param name="deceleration"></param>
        public static void AddSlideOutToLeft(this Storyboard storyboard, float seconds, double offset, float deceleration = 0.9f)
        {
            // Make the wanted movement
            var slideAnimation = new ThicknessAnimation
            {
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                DecelerationRatio = deceleration
            };

            // Add it to the wanted property
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));

            // Attach the property to the made storyboard
            storyboard.Children.Add(slideAnimation);
        }

        /// <summary>
        /// StoryBoard method makes the attached page Fade In 
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds">Fading duration</param>
        /// <param name="offset">Unnecessery for this animation</param>
        /// <param name="deceleration"></param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds, double offset, float deceleration = 0.9f)
        {
            // Make the wanted movement
            var slideAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };

            // Add it to the wanted property
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Opacity"));

            // Attach the property to the made storyboard
            storyboard.Children.Add(slideAnimation);
        }

        /// <summary>
        /// StoryBoard method makes the attached page Fade Out
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds">Fading duration</param>
        /// <param name="offset">Unnecessery for this animation</param>
        /// <param name="deceleration"></param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds, double offset, float deceleration = 0.9f)
        {
            // Make the wanted movement
            var slideAnimation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(seconds))
            };

            // Add it to the wanted property
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Opacity"));

            // Attach the property to the made storyboard
            storyboard.Children.Add(slideAnimation);
        }

    }
}
