using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void ClickHandler(object sender, RoutedEventArgs args)
    {
        Console.WriteLine("I've been clicked!");
        buttonMessage.Text = "Button clicked!";
        if (pbClickProgress.Value >= 100.0)
        {
            pbClickProgress.Value = 0;
        }
        pbClickProgress.Value += 10.0;
    }
}