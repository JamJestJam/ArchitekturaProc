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
        private void LEA(string order)
        {
            order = Regex.Replace(order, " ", "");
            string[] division = order.Split(',');

            if (division.Length != 2)
            {
                throw new ArgumentException("LEA requires two arguments");
            }

            if (CalcRamAddr("0:" + division[1], out int result, true))
            {
                if (registersNames.Contains(division[0]))
                {
                    LabelsList[division[0]].Text = DecToHex(result);
                }
                else
                {
                    throw new ArgumentException("Could not find register: " + division[2]);
                }
            }
            else
            {
                throw new ArgumentException("Could not be changed to address: " + division[1]);
            }
        }
    }
}
