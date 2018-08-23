using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Fessad_TL
{
    class WindowViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The window this view model control
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow drop shadow
        /// </summary>
        private int mOuterMargin = 0;

        /// <summary>
        /// The radius of edges of the window
        /// </summary>
        private int mWindowRdius = 10;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        #endregion

        // TODO: Fix the issue of uncapability of graping window when in maximum.
        #region Public Properties

        /// <summary>
        /// The minimum allowed window width
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 800;

        /// <summary>
        /// The minimum allowed window height
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 500;

        /// <summary>
        /// The size of the seen border
        /// </summary>
        public int ResizeBorder { get { return BorderLess ? 0 : 6; } }

        public Thickness ResizeBorderThickness
        {
            get { return new Thickness(ResizeBorder + OuterMarginSize);}
        }

        //public Thickness InnerContentBorderThickness
        //{                                           
        //    get { return new Thickness(ResizeBorder); }
        //}

        public Thickness InnerContentBorderThickness
        {
            get { return new Thickness(0); }
        }


        /// <summary>
        /// Return the outer margine to allow drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMargin; }
            set { mOuterMargin = value; }
        }

        public Thickness OuterMarginSizeThickness
        {
            get { return new Thickness(OuterMarginSize); }
        }

        /// <summary>
        /// Return the radius of the window edges
        /// </summary>
        public int WindowRadius
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRdius; }
            set { mWindowRdius = value; }
        }

        public CornerRadius WindowCornerRadius
        {
            get { return new CornerRadius(WindowRadius); }
        }


        public int TitleHeight { get; set; } = 25;

        public GridLength TitleHeightGridLength
        {
            get{ return new GridLength(TitleHeight + ResizeBorder); }
        }

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.ChatPage;

        /// <summary>
        /// True if the window should be borderless becuase it is doucked or maximized
        /// </summary>
        public bool BorderLess { get { return ( mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked ); } }

        #endregion

        #region Commands

        /// <summary>
        /// Command to maximize app window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// Command to minimize app window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Command to close app window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Command to show app menu
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion  

        #region Constructor

        /// <summary>
        /// Defult Constructor
        /// </summary>
        /// <param name="window">The window will be working on</param>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            //Listen to the change in window state
            mWindow.StateChanged += (sender, e) =>
            {
                WindowResized();  
            };

            // Making the commands
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState = mWindow.WindowState == WindowState.Maximized ?  WindowState.Normal :WindowState.Maximized);
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            var resizer = new WindowResizer(mWindow);

            resizer.WindowDockChanged += (dock) =>
            {
                // Store last position
                mDockPosition = dock;

                // Fire off resize events
                WindowResized();
            };
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            // Add the window position so it is "to screen"
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        private void WindowResized()
        {
            OnPropertyChanged(nameof(ResizeBorder));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
        }

        #endregion

    }
}
