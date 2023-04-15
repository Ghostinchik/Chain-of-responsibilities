using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ланцюжок_обов_язків.Class1;

namespace Ланцюжок_обов_язків
{
    public partial class Form1 : Form
    {
        private readonly AutoAssemblyLine _assemblyLine = new AutoAssemblyLine();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string request = textBox1.Text;
            string result = _assemblyLine.AssembleAuto(request);
            MessageBox.Show(result, "Assembly Result");
        }
    }
}
