using System.Windows;

namespace WindowsPowerSuite.App.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : ModernWpf.Controls.Window
{
    public MainWindow()
    {
        InitializeComponent();

        // TODO: Set DataContext to MainWindowViewModel
        // DataContext = App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
    }
}
