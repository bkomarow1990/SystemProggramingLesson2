using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Task4WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] nums = new int[10000];
        static void GetMin(object elems)
        {
            int[] elems_int = elems as int[];
            int min = elems_int[0];
            for (int i = 0; i < elems_int.Length; i++)
            {
                if (elems_int[i] < min)
                {
                    min = elems_int[i];
                }
            }
            string out_text = $"Min: {min}";
            Console.WriteLine(out_text);
        }
        static void GetMax(object elems)
        {
            int[] elems_int = elems as int[];
            int max = elems_int[0];
            for (int i = 0; i < elems_int.Length; i++)
            {
                if (elems_int[i] > max)
                {
                    max = elems_int[i];
                }
            }
            string out_text = $"Max: {max}";
            Console.WriteLine(out_text);
        }
        private void GetAvg(object obj)
        {
            int[] elems = obj as int[];
            string out_text = $"Average: {elems.Average()}";
            Console.WriteLine(out_text);
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void generateBtn_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < nums.Length; i++)
            {
                numsListBox.Items.Clear();
                nums[i] = rnd.Next(0,1000);
                numsListBox.Items.Add(nums[i]);
            }
        }
    }
}
