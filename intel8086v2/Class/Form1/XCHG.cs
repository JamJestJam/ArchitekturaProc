using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace intel8086v2
{
    partial class Intel8086
    {
        private void XCHG(string order)
        {
            order = Regex.Replace(order, " ", "");
            string[] division = order.Split(',');

            if (division.Length != 2)
            {
                throw new ArgumentException("XCHG requires two arguments");
            }

            if (registersNames.Contains(division[0]))
            {
                if (registersNames.Contains(division[1]))
                {
                    string tmp = LabelsList[division[0]].Text;
                    LabelsList[division[0]].Text = LabelsList[division[1]].Text;
                    LabelsList[division[1]].Text = tmp;
                }
                else if (CalcRamAddr(division[1], out int addr))
                {
                    string tmp = LabelsList[division[0]].Text;
                    LabelsList[division[0]].Text = RamContent[addr];
                    RamContent[addr] = tmp;
                }
                else
                {
                    if (HalvRegistersName.Contains(division[1]))
                    {
                        throw new ArgumentException("it is not possible to transfer information between registers of different sizes");
                    }
                    else
                    {
                        throw new ArgumentException("not recognized: " + division[1]);
                    }
                }
            }
            else if (HalvRegistersName.Contains(division[0]))
            {
                if (HalvRegistersName.Contains(division[1]))
                {
                    string tmp = LabelsList[division[0]].Text;
                    LabelsList[division[0]].Text = LabelsList[division[1]].Text;
                    LabelsList[division[1]].Text = tmp;
                }
                else if (CalcRamAddr(division[1], out int addr))
                {
                    string tmp = LabelsList[division[0]].Text;
                    LabelsList[division[0]].Text = RamContent[addr];
                    RamContent[addr] = tmp;
                }
                else
                {
                    if (registersNames.Contains(division[1]))
                    {
                        throw new ArgumentException("it is not possible to transfer information between registers of different sizes");
                    }
                    else
                    {
                        throw new ArgumentException("not recognized: " + division[1]);
                    }
                }
            }
            else if (CalcRamAddr(division[0], out int addr))
            {
                if (registersNames.Contains(division[1]))
                {
                    string tmp = RamContent[addr];
                    RamContent[addr] = LabelsList[division[1]].Text;
                    LabelsList[division[1]].Text = tmp;
                }
                else if (HalvRegistersName.Contains(division[1]))
                {
                    string tmp = RamContent[addr];
                    RamContent[addr] = LabelsList[division[1]].Text;
                    LabelsList[division[1]].Text = tmp;
                }
                else if (CalcRamAddr(division[1], out int addrOut))
                {
                    string tmp = RamContent[addr];
                    RamContent[addr] = RamContent[addrOut];
                    RamContent[addrOut] = tmp;
                }
                else
                {
                    throw new ArgumentException("not recognized: " + division[1]);
                }
            }
            else
            {
                throw new ArgumentException("not recognized: " + division[0]);
            }
        }
    }
}
