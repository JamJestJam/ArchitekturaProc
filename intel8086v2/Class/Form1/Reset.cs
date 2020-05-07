using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intel8086v2
{
    partial class Intel8086
    {
        private void Reset(object sender, EventArgs e)
        {
            foreach (string name in registersNames)
            {
                LabelsList[name].Text = "0";
            }
            for (int i = 0; i <= 1114097; i++)
            {
                RamContent[i] = "0";
            }
            LabelsList["CX"].Text = "1";
            LabelsList["SP"].Text = "FFFE";
            LabelsList["DS"].Text = "700";
            LabelsList["SS"].Text = "700";
            LabelsList["CS"].Text = "700";
            LabelsList["ES"].Text = "700";
            LabelsList["IP"].Text = "100";
        }
    }
}
