using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intel8086v2
{
    partial class Intel8086
    {
        private void EventInit()
        {
            ButtonsList["Start"].Click += Start;
            ButtonsList["Reset"].Click += Reset;
            ButtonsList["Random registers content"].Click += RandomRegistersContent;

            foreach (string name in registersNames)
            {
                LabelsList[name].TextChanged += MaxSize16;
                LabelsList[name].Click += Format;
            }
            foreach (string name in HalvRegistersName)
            {
                LabelsList[name].TextChanged += MaxSize8;
                LabelsList[name].TextChanged += HalvToBig;
                LabelsList[name].Click += Format;
            }
            for (int i = 1; i < HalvRegistersName.Count; i += 2)
            {
                LabelsList[HalvRegistersName[i][0] + "X"].TextChanged += BigToHalv;
            }
        }
    }
}
