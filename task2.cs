using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Windows.Forms;
using Microsoft.Win32;
namespace Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Kvachenok"))
                {
                    if (key != null)
                    {
                        Object obj = key.GetValue("P5");
                        if (obj is string[] vstr)
                        {
                            string output = string.Join("\n", vstr);
                            MessageBox.Show(output, "Вміст параметра P5");
                        }
                        else
                        {
                            MessageBox.Show("Параметр P5 не знайдено або має неправильний тип!", "Помилка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Гілку реєстру не знайдено!", "Помилка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"Software\Kvachenok", true))
                {
                    if (key != null)
                    {
                        string[] outputStr = { "Я - перспективна студентка кафедри комп’ютерної інженерії!" };
                        key.SetValue("P6", outputStr, RegistryValueKind.MultiString);
                        MessageBox.Show("Параметр P6 успішно створено!", "Успіх");
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося створити або відкрити гілку реєстру!", "Помилка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
