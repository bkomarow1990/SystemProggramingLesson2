using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task1WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void NumsPrint(object nums)
        {
            int[] nums_int = nums as int[];
            for (int i = nums_int[0]; i <= nums_int[1]; i++)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    elemsListBox.Items.Add(i);
                });

            }

        }
        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            ParameterizedThreadStart threadstart = new ParameterizedThreadStart(NumsPrint);
            Thread thread = new Thread(threadstart);
            int[] nums = { Int32.Parse(rightNumTxtBox.Text),Int32.Parse(leftNumTxtBox.Text)};
            thread.Start(nums);
        }
    }
}
