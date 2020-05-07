using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intel8086v2
{
    partial class Intel8086
    {
        private void PUSH(string order)
        {
            string result;
            if (registersNames.Contains(order))
            {
                result = LabelsList[order].Text;
            }
            else if (HalvRegistersName.Contains(order))
            {
                result = LabelsList[order].Text;
            }
            else if (CalcRamAddr(order, out int Addr))
            {
                result = RamContent[Addr];
            }
            else
            {
                result = DecToHex(HexToDec(order));
            }

            CalcRamAddr("SS:[SP]", out int addr);
            RamContent[addr] = result;
            int number = HexToDec(LabelsList["SP"].Text);
            LabelsList["SP"].Text = DecToHex(number - 2);
        }

        private void POP(string order)
        {
            int number = HexToDec(LabelsList["SP"].Text);
            LabelsList["SP"].Text = DecToHex(number + 2);
            CalcRamAddr("SS:[SP]", out int addr);
            string result = RamContent[addr];

            if (registersNames.Contains(order))
            {
                LabelsList[order].Text = result;
            }
            else if (HalvRegistersName.Contains(order))
            {
                LabelsList[order].Text = result;
            }
            else if (CalcRamAddr(order, out int Addr))
            {
                RamContent[Addr] = result;
            }
            else
            {
                throw new ArgumentException("Cannot be saved in: " + order);
            }
        }
    }
}
