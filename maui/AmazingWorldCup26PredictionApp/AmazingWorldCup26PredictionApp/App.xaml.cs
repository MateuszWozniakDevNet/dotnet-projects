namespace AmazingWorldCup26PredictionApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "AmazingWorldCup26PredictionApp" };
        }
    }
}
