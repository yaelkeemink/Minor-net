using Marco.Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minor.Dag41.Threading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<int> intLijst = new List<int>();
        private void btn1_Click(object sender, EventArgs e)
        {
            intLijst = new List<int>();
            SlowMath math = new SlowMath();
            int invoer1 = int.Parse(txt1.Text);
            int invoer2 = int.Parse(txt2.Text);
            int invoer3 = int.Parse(txt3.Text);
            IAsyncResult txt1Result = math.BeginSquare(invoer1, Update, math);
            IAsyncResult txt2Result = math.BeginSquare(invoer2, Update, math);
            IAsyncResult txt3Result = math.BeginSquare(invoer3, Update, math);
        }

        private void Update(IAsyncResult resultaat)
        {
            SlowMath math = (SlowMath)resultaat.AsyncState;
            lock (intLijst){
                intLijst.Add(math.EndSquare(resultaat));                
            }
            if (intLijst.Count >= 3)
            {
                int uitvoer = intLijst.Sum();
                Invoke((MethodInvoker)(() =>
                {
                    txtresult.Text = uitvoer.ToString();
                }));
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            intLijst = new List<int>();
            SlowMath math = new SlowMath();
            int invoer1 = int.Parse(txt1.Text);
            int invoer2 = int.Parse(txt2.Text);
            int invoer3 = int.Parse(txt3.Text);

            intLijst.Add(await math.SquareAsync(invoer1));
            intLijst.Add(await math.SquareAsync(invoer2));
            intLijst.Add(await math.SquareAsync(invoer3));

            Invoke((MethodInvoker)(() =>
            {
                txtresult.Text = (intLijst.Sum()).ToString();
            }));

        }
    }
}
