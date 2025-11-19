namespace PayUni;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationRequest? activationRequest)
    {
        var window = base.CreateWindow(activationRequest);

        const int newWidth = 540;
        const int newHeight = 720;

        window.Width = newWidth;
        window.Height = newHeight;

        return window;
    }
}
