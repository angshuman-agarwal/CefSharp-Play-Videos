using System.IO;
using System.Windows;
using CefSharp;

namespace CefSharp_Video_Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Browser.Loaded += Browser_Loaded;
        }

        private void Browser_Loaded(object sender, RoutedEventArgs e)
        {
            Browser.LoadHtml(File.ReadAllText(@"file:///C:/Users/jimmy/source/repos/CefSharp_Video_Sample/bin/Debug/Video.html"));
        }
    }
}
