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
        private void Start(object sender, EventArgs e)
        {
            string input = Input.Text.ToUpper();
            int separation = input.IndexOf(' ');
            separation = (separation == -1) ? input.Length : separation;
            try
            {
                string order = input.Substring(0, separation);
                string command = (input.Length > separation) ? input.Substring(separation + 1) : "";

                switch (order)
                {
                    case "MOV"://transfers data
                        MOV(command);
                        break;
                    case "PUSH"://adds value to the stack
                        PUSH(command);
                        break;
                    case "POP"://return value from the stack
                        POP(command);
                        break;
                    case "XCHG"://exchange value from registers
                        XCHG(command);
                        break;
                    case "XLAT"://return value from address ds:[bx+al] into al;
                        XLAT();
                        break;
                    case "LEA"://return effectiv address
                        LEA(command);
                        break;
                    default:
                        throw new ArgumentException("Command not recognized: " + order);
                }
            }
            catch (Exception except)
            {
                const string caption = "Error";
                var result = MessageBox.Show(except.Message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
