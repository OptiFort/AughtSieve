using Avalonia.Controls;

namespace AughtSieve.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button1.Click += Button1_Click;

            

        }

        string user,passward;

        private void Button1_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            user = TextBox1.Text;
            passward= TextBox2.Text;


        }
    }
}