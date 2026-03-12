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
        // await TopLevel.GetTopLevel(this).Clipboard.SetTextAsync(guid);
        tbResolution.Text = resolution;

        List<string> listOfActiveWindows = new();
        
        Process[] processes = Process.GetProcesses().OrderBy(_=>_.MainWindowTitle).ToArray();
        Process[] processesWithWindows = Process.GetProcesses()
            .Where(p=> p.MainWindowHandle != 0)
            .ToArray();
        
        listOfActiveWindows.AddRange(processesWithWindows.Select(_=>_.ProcessName).OrderBy(_=>_));
        GetActiveWindows();
        tbListOfActiveWindows.Text = string.Join('\r', listOfActiveWindows);
    }

    public void GetActiveWindows()
    {
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
                    Console.WriteLine($"{newLineList}");
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., access denied or process without a window)
            Console.WriteLine($"Could not access process: {ex.Message}");
        }
    }
}