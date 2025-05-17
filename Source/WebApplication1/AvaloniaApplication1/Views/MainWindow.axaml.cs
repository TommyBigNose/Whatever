using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Services;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    private ITestService _testService;
    private MainWindowViewModel  _mainWindowViewModel;
    
    public MainWindow(ITestService testService, MainWindowViewModel mainWindowViewModel)
    {
        _testService = testService;
        _mainWindowViewModel = mainWindowViewModel;
        InitializeComponent();
        UseViewModel();
    }

    private void UseViewModel()
    {
        tbHeader.Text = _mainWindowViewModel.Greeting;
        btnClickMe.Content = _mainWindowViewModel.ButtonText;
    }
    
    public void ClickHandler(object sender, RoutedEventArgs args)
    {
        _testService.Test();
        Console.WriteLine("I've been clicked!");
        tbButtonMessage.Text = "Button clicked!";
        if (pbClickProgress.Value >= 100.0)
        {
            pbClickProgress.Value = 0;
        }
        pbClickProgress.Value += 10.0;
    }
}