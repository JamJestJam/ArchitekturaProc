using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intel8086v2
{
    partial class Intel8086
    {
        private void RandomRegistersContent(object sender, EventArgs e)
        {
            foreach (string name in registersNames)
            {
                if(name!="F")
                    LabelsList[name].Text = DecToHex(R.Next(0, 65535));
            }
        }
    }
}
