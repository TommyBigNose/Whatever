using AvaloniaApplication1.Services;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    public string ButtonText { get; } = "Click me!";
}