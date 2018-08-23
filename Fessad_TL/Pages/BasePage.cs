using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Fessad_TL.Annotations;

namespace Fessad_TL
{
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new() 
    {
        #region Private members

        private VM mViewModel;

        #endregion  

        #region Public properties
        public AnimationTypes PageLoad { get; set; } = AnimationTypes.SlideAndeFadeInFromRight;

        public AnimationTypes PageUnload { get; set; } = AnimationTypes.SlideAndFadeOutFromLeft;

        public float SlidesSeconds { get; set; } = 0.8f;

        public VM ViewModel
        {
            get { return mViewModel; }
            set
            {
                // return if nothing has changed
                if(mViewModel == value)
                    return;

                // Set the view model
                mViewModel = value;

                // Set the view model into the DataContext of the page
                this.DataContext = mViewModel;
            }
        }
        #endregion

        
        #region Constructo

        public BasePage()
        {
            //If we are animating in, hide to begin with
            // to be honest, I don't know what is the benefit of this line, try to find out later.
            if (this.PageLoad != AnimationTypes.None)
                this.Visibility = Visibility.Collapsed;

            // Setting the action of loading page
            this.Loaded += BasePage_Loaded;

            this.ViewModel = new VM();
        }

        #endregion

        public async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
             await AnimateIn();
        }

        public async Task AnimateIn()
        {
            switch (PageLoad)
            {
                case AnimationTypes.SlideAndeFadeInFromRight:

                    await this.SlideAndFadeInFromRight(1);

                    break;
            }
        }

        public async Task AnimateOut()
        {
            switch (PageUnload)
            {
                case AnimationTypes.SlideAndFadeOutFromLeft:

                    await this.SlideAndFadeOutToRight(1);

                    break;
            }
        }

    }
}
