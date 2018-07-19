using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsertionSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        long max = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            ///hck

            max = Convert.ToInt64(textBox1.Text);
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                InsertionSorting();

            }).Start();
        }
        public int InsertionSorting()
        {
            panel2.Controls.Clear();
            label2.Text = "";
            int x = 12;
            int y = 20;
            int[] numarray = new int[max];

            Random rnd = new Random();
            int month = rnd.Next(1, 13);
            label2.Text += "Numbers Are :";
            for (int i = 0; i < max; i++)
            {
                numarray[i] = rnd.Next(0, 999);
                label2.Text += numarray[i]+" ";

            }
            for (int k = 0; k < max; k++)
            {
                Console.Write(numarray[k] + " ");
            }
            Console.Write("\n");
            for (int i = 1; i < max; i++)
            {
                int j = i;
                int check = 0;
                while (j > 0)
                {
                    if (numarray[j - 1] > numarray[j])
                    {
                        int temp = numarray[j - 1];
                        numarray[j - 1] = numarray[j];
                        numarray[j] = temp;
                        check = i;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
                // label2.Text+=("Iteration " + i.ToString() + ": ");

                Label labell = new Label();
                labell.BorderStyle = BorderStyle.FixedSingle;
                labell.Text = ("Iteration " + i.ToString() + ": ");
                labell.Location = new Point(x, y);
                panel2.BeginInvoke((MethodInvoker)delegate ()
                {
                    panel2.Controls.Add(labell);
                });
                x += labell.Size.Width;
                //old = labell;
                for (int k = 0; k < max; k++)
                {
                    //label2.Text += (numarray[k] + " ");
                    Label label = new Label();
                    label.BorderStyle = BorderStyle.FixedSingle;
                    if (check>k)
                    {
                        label.ForeColor =Color.Red;
                    }
                    label.Text = (numarray[k] + " ");
                    label.Location = new Point(x,y);
                   // old = label;
                    panel2.BeginInvoke((MethodInvoker)delegate ()
                    {
                        panel2.Controls.Add(label);
                    });
                    x += label.Size.Width;

                }
                y+=labell.Size.Height;
                x = 12;


                //label2.Text += ("\n");
                Thread.Sleep(500);
            }
            Console.WriteLine("Sorted Array");
            for (int i = 0; i < max; i++)
            {
                Console.Write(numarray[i] + " ");
            }
            return 0;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!long.TryParse(textBox1.Text, out long n))
            {
                textBox1.Text = "";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
