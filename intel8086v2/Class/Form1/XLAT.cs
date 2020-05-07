using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intel8086v2
{
    partial class Intel8086
    {
        private void XLAT()
        {
            int result = HexToDec(LabelsList["AL"].Text) + HexToDec(LabelsList["BX"].Text);
            CalcRamAddr($"[{result}]", out result);
            LabelsList["AL"].Text = RamContent[result];
        }
    }
}
