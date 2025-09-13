using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using AvaloniaApplication1.Services;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    private ITestService _testService;
    private IProgressBar _progressBar;
    private MainWindowViewModel  _mainWindowViewModel;
    private DispatcherTimer _timer;
    
    public MainWindow(ITestService testService, MainWindowViewModel mainWindowViewModel, IProgressBar progressBar)
    {
        _testService = testService;
        _mainWindowViewModel = mainWindowViewModel;
        _progressBar = progressBar;
        InitializeComponent();
        UseViewModel();
        
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(100);
        _timer.Tick += (sender, args) => ClickHandler(sender, null);
        _timer.Start();
    }

    private void UseViewModel()
    {
        tbHeader.Text = _mainWindowViewModel.Greeting;
        btnClickMe.Content = _mainWindowViewModel.ButtonText;
        btnGuid.Content = _mainWindowViewModel.ButtonGuidText;
    }
    
    public void ClickHandler(object sender, RoutedEventArgs args)
    {
        _testService.Test();
        // _timer.Start();
        Console.WriteLine("I've been clicked!");
        tbButtonMessage.Text = "Button clicked!";
        _progressBar.Increment(10.0f);
        pbClickProgress.Value = _progressBar.GetValue();
        // if (pbClickProgress.Value >= 100.0)
        // {
        //     pbClickProgress.Value = 0;
        // }
        // pbClickProgress.Value += 10.0;
    }

    /// <summary>
    /// https://docs.avaloniaui.net/docs/concepts/services/clipboard
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public async void GenerateRandomGuid(object sender, RoutedEventArgs args)
    {
        _timer.Stop();
        string guid = Guid.CreateVersion7().ToString();
        await TopLevel.GetTopLevel(this).Clipboard.SetTextAsync(guid);
        tbGuidBlock.Text = guid;
    }
}