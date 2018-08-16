using System.Windows;

namespace Telephone
{
    public partial class Ask : Window
    {

        public Ask()
        {
            InitializeComponent();
        }

        public void Accept_Click(object sender, RoutedEventArgs e) {
            if (askBox.Text != "") {
                try
                {
                    MainWindow main = Owner as MainWindow;
                    main.answer = int.Parse(askBox.Text);
                    DialogResult = true;
                }
                catch { DialogResult = false; }
            }
        }

    }
}
