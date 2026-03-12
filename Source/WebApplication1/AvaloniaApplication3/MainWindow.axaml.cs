using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaApplication3;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public async void GetMainMonitorResolution(object sender, RoutedEventArgs args)
    {
        string resolution = $"{this.Screens.Primary.Bounds.Width}x{this.Screens.Primary.Bounds.Height}";
        tbResolution.Text = resolution;

        List<string> listOfActiveWindows = new();
        
        Process[] processes = Process.GetProcesses().OrderBy(_=>_.MainWindowTitle).ToArray();
        Process[] processesWithWindows = Process.GetProcesses()
            .Where(p=> p.MainWindowHandle != 0)
            .ToArray();
        
        listOfActiveWindows.AddRange(GetActiveWindows().Select(_=>_).OrderBy(_=>_));
        tbListOfActiveWindows.Text = string.Join('\r', listOfActiveWindows);
    }
    
    public async void PopUpNewWindow(object sender, RoutedEventArgs args)
    {
        var newWindow = new Window
        {
            Title = "New Window",
            Width = 400,
            Height = 300,
            Content = new TextBlock
            {
                Text = "This is a new window!",
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
            }
        };
        newWindow.Show();
    }

    public List<string> GetActiveWindows()
    {
        List<string> processNames = new ();
        try
        {
            var startInfoHostName = new ProcessStartInfo
            {
                FileName = "hostname",
                Arguments = $"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            
            string hostname = string.Empty;
            
            using (var xpropProcess = Process.Start(startInfoHostName))
            {
                string output = xpropProcess.StandardOutput.ReadToEnd();
                string error = xpropProcess.StandardError.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(output))
                {
                    hostname = output.Trim();
                    Console.WriteLine($"Hostname: {hostname}");
                }
            }
            
            var startInfo = new ProcessStartInfo
            {
                FileName = "wmctrl",
                Arguments = $"-l",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using (var xpropProcess = Process.Start(startInfo))
            {
                string output = xpropProcess.StandardOutput.ReadToEnd();
                string error = xpropProcess.StandardError.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(output))
                {
                    var newLineList = output.Split('\n');
                    foreach (var line in newLineList)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            // Get index of line after hostname until end of the line
                            int startIndex = line.IndexOf(hostname) + hostname.Length;
                            int endIndex = line.Length - startIndex;
                            string process = line.Substring(startIndex, endIndex);
                            processNames.Add(process);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., access denied or process without a window)
            Console.WriteLine($"Could not access process: {ex.Message}");
        }
        return processNames;
    }
}