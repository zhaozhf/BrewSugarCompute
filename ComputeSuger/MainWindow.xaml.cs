using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComputeSuger
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Test();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (GetValue(textBox1))
            {
                return;
            }

            if (GetValue(textBox4))
            {
                return;
            }

            double volumn = double.Parse(textBox1.Text);

            double carbonVolumn = double.Parse(textBox4.Text);

            label1.Content = string.Format("{0:f1}克", (carbonVolumn * 342 * volumn) / 89.6);
        }

        private bool GetValue(TextBox textBox)
        {
            ComputeTool computeTool = new ComputeTool();
            string testString = textBox.Text.Trim();
            if (!computeTool.judgeDigital(testString))
            {
                MessageBox.Show("请输入数字！");
                textBox.Text = "";
                textBox.Focus();
                return true;
            }
            return false;
        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Test()
        {
            ComputeTool computeTool = new ComputeTool();

            var key = Observable.FromEventPattern<TextChangedEventArgs>(textBox2, "TextChanged");
            var subscribe = key.Subscribe(evt =>
            {
                string testString = textBox2.Text.Trim();
                if (!computeTool.judgeDigital(testString))
                {
                    MessageBox.Show("请输入数字！");
                    textBox2.Text = "";
                    return;
                }

                double a = textBox2.Text == "" ? 0 : double.Parse(textBox2.Text);
                //MessageBox.Show(textBox2.Text);
                double b = textBox3.Text == "" ? 0 : double.Parse(textBox3.Text);
                b = b - a;
                textBox4.Text = b < 0 ? "0" : b.ToString();
            });

            var key2 = Observable.FromEventPattern<TextChangedEventArgs>(textBox3, "TextChanged");
            var subscribe2 = key2.Subscribe(evt =>
            {
                double a = textBox2.Text == "" ? 0 : double.Parse(textBox2.Text);
                //MessageBox.Show(textBox2.Text);
                double b = textBox3.Text == "" ? 0 : double.Parse(textBox3.Text);
                b = b - a;
                textBox4.Text = b < 0 ? "0" : b.ToString();
            });
        }


    }
}
