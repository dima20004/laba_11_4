using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba_11_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            int N = Convert.ToInt32(textBox2.Text);
            byte[] asciiBytes1;

            byte[] unicodeBytes = Encoding.ASCII.GetBytes(textBox1.Text);
            asciiBytes1 = new byte[unicodeBytes.Length];

            int L;
            int R;
            for (int j = 0; j < unicodeBytes.Length - 1; j += 2)
            {


                L = Convert.ToInt32(unicodeBytes[j]);
                R = Convert.ToInt32(unicodeBytes[j + 1]);
                int l1 = L;
                int n = N;

                for (int i = N-1; i > 0; i--)
                {
                    if (i == 1)
                    {
                        L = R ^ ((L + i) % 256);

                        R = l1;
                        l1 = L;
                        textBox4.Text += $"Раунд №{i}" + Environment.NewLine + $"L={R} R ={L}" + Environment.NewLine;
                        asciiBytes1[j] = Convert.ToByte(R);
                        asciiBytes1[j + 1] = Convert.ToByte(L);
                        break;
                    }

                    L = R ^ ((L + i) % 256);

                    R = l1;
                    l1 = L;
                    textBox4.Text += $"Раунд №{i}" + Environment.NewLine + $"L={L} R ={R}" + Environment.NewLine;

                }
                asciiBytes1[j] = Convert.ToByte(R);
                asciiBytes1[j + 1] = Convert.ToByte(L);

            }
            string s = System.Text.Encoding.ASCII.GetString(asciiBytes1);
            textBox4.Text += Environment.NewLine + "Расшифрованное слово " + s;















        }
    }
}
