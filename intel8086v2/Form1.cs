using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intel8086v2
{
    public partial class Form1 : Form
    {
        Intel8086 admin;
        public Form1()
        {
            InitializeComponent();
            admin = new Intel8086(this);
        }
    }
}
