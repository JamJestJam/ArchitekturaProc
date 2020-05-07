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
        private void MaxSize16(object sender, EventArgs e)
        {
            Label tmp = ((Label)(sender));
            tmp.Text = DeleteFirstZero(MaxSize(tmp.Text, 4));
        }

        private void MaxSize8(object sender, EventArgs e)
        {
            Label tmp = ((Label)(sender));
            tmp.Text = DeleteFirstZero(MaxSize(tmp.Text, 2));
        }

        private void MaxSize1(object sender, EventArgs e)
        {
            Label tmp = ((Label)(sender));
            if (tmp.Text != "0" && tmp.Text != "1")
                tmp.Text = "0";
        }

        public string MaxSize(string text, int len)
        {
            if (text.Length > len)
            {
                text = text.Substring(text.Length - len, len);
            }
            return text;
        }

        private void HalvToBig(object sender, EventArgs e)
        {
            string name = ((Label)(sender)).Name;
            Label low = LabelsList[name[0] + "L"];
            Label hig = LabelsList[name[0] + "H"]; ;
            Label big = LabelsList[name[0] + "X"]; ;

            big.TextChanged -= BigToHalv;
            big.Text = DeleteFirstZero(hig.Text + low.Text);
            big.TextChanged += BigToHalv;
        }

        private void BigToHalv(object sender, EventArgs e)
        {
            string tmp = ((Label)(sender)).Text;
            Label low = LabelsList[((Label)(sender)).Name.Substring(0, 1) + "L"];
            Label hig = LabelsList[((Label)(sender)).Name.Substring(0, 1) + "H"];

            low.TextChanged -= HalvToBig;
            hig.TextChanged -= HalvToBig;
            if (tmp.Length > 2)
            {
                if (tmp.Length == 3)
                {
                    hig.Text = tmp.Substring(0, 1);
                    low.Text = tmp.Substring(1, 2);
                }
                else
                {
                    hig.Text = tmp.Substring(0, 2);
                    low.Text = tmp.Substring(2, 2);
                }
            }
            else
            {
                hig.Text = "0";
                low.Text = tmp;
            }
            low.TextChanged += HalvToBig;
            hig.TextChanged += HalvToBig;
        }
    }
}
