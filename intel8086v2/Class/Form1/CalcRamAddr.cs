using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intel8086v2
{
    partial class Intel8086
    {
        private bool CalcRamAddr(string RamAddres, out int result, bool number = false)
        {
            result = -1;
            if (RamAddres[RamAddres.Length - 1] != ']')
            {
                return false;
            }
            int division = RamAddres.IndexOf(':');
            int baseregister;
            if (division == -1)
            {
                if (RamAddres[0] != '[')
                    return false;
                baseregister = HexToDec(LabelsList["DS"].Text);
                RamAddres = RamAddres.Substring(1, RamAddres.Length - 2);
            }
            else
            {
                string registerNames = RamAddres.Substring(0, division);
                if (registersNames.Contains(registerNames))
                {
                    baseregister = HexToDec(LabelsList[registerNames].Text);
                }
                else
                {
                    if(number)
                    {
                        baseregister = HexToDec(registerNames);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(registerNames + " register not found");
                    }
                }
                if (RamAddres[division + 1] != '[')
                    return false;
                RamAddres = RamAddres.Substring(division + 2, RamAddres.Length - division - 3);
            }
            result = baseregister * 16;

            string[] spreadAddr = RamAddres.Split('+');
            foreach (string addr in spreadAddr)
            {
                if (registersNames.Contains(addr))
                {
                    result += HexToDec(LabelsList[addr].Text);
                }
                else if (HalvRegistersName.Contains(addr))
                {
                    result += HexToDec(LabelsList[addr].Text);
                }
                else
                {
                    result += HexToDec(addr);
                }
            }
            if (result > 1114097)
                throw new OverflowException($"Memory location with address {DecToHex(result)} does not exist");
            if (result < 0)
                throw new ArgumentException("An error occurred while counting the memory cell");
            return true;
        }
    }
}
