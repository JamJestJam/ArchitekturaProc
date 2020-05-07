using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intel8086v2
{
    partial class Intel8086
    {
        private void MOV(string order)
        {
            order = Regex.Replace(order, " ", "");
            string[] division = order.Split(',');

            if (division.Length != 2)
            {
                throw new ArgumentException("MOV requires two arguments");
            }
            if (registersNames.Contains(division[0]))
            {
                if (registersNames.Contains(division[1]))
                {
                    LabelsList[division[0]].Text = LabelsList[division[1]].Text;
                }
                else if (CalcRamAddr(division[1], out int addr))
                {
                    LabelsList[division[0]].Text = RamContent[addr];
                }
                else
                {
                    if (HalvRegistersName.Contains(division[1]))
                    {
                        throw new ArgumentException("it is not possible to transfer information between registers of different sizes");
                    }
                    else
                    {
                        LabelsList[division[0]].Text = DecToHex(HexToDec(division[1]));
                    }
                }
            }
            else if (HalvRegistersName.Contains(division[0]))
            {
                if (HalvRegistersName.Contains(division[1]))
                {
                    LabelsList[division[0]].Text = LabelsList[division[1]].Text;
                }
                else if (CalcRamAddr(division[1], out int addr))
                {
                    LabelsList[division[0]].Text = RamContent[addr];
                }
                else
                {
                    if (registersNames.Contains(division[1]))
                    {
                        throw new ArgumentException("it is not possible to transfer information between registers of different sizes");
                    }
                    else
                    {
                        LabelsList[division[0]].Text = DecToHex(HexToDec(division[1]));
                    }
                }
            }
            else if (CalcRamAddr(division[0], out int addr))
            {
                if (registersNames.Contains(division[1]))
                {
                    RamContent[addr] = LabelsList[division[1]].Text;
                }
                else if (HalvRegistersName.Contains(division[1]))
                {
                    RamContent[addr] = LabelsList[division[1]].Text;
                }
                else if (CalcRamAddr(division[1], out int addrOut))
                {
                    RamContent[addr] = RamContent[addrOut];
                }
                else
                {
                    RamContent[addr] = DecToHex(HexToDec(division[1]));
                }
            }
            else
            {
                throw new ArgumentException("not recognized: " + division[0]);
            }
        }
    }
}
