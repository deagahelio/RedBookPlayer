using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace RedBookPlayer
{
    public class App : Application
    {
        public static Settings Settings;

        static App()
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName));
        }

        public override void Initialize()
        {
            AppDomain.CurrentDomain.UnhandledException += (e, f) =>
            {
                Console.WriteLine(((Exception)f.ExceptionObject).ToString());
            };

            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
                desktop.ShutdownMode = ShutdownMode.OnMainWindowClose;

                Settings = Settings.Load("settings.json");
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}