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
        private void Format(object sender, EventArgs e)
        {
            string value = ((Label)(sender)).Text;

            LabelsList["Hex"].Text = value;
            LabelsList["Bin"].Text = HexToBin(value);
            LabelsList["Dec"].Text = HexToDec(value).ToString();
        }

        public string DecToHex(int Dec)
        {
            string result = "";
            while (Dec > 0)
            {
                int tmp = Dec % 16;
                result += NumberToHex(tmp);
                Dec = (Dec - tmp) / 16;
            }
            char[] array = result.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        public string HexToBin(string Hex)
        {
            string result = "";
            foreach (char tmp in Hex)
            {
                result += HexToBin(tmp);
            }

            return result;
        }

        public int BinToDec(string bin)
        {
            bin = DeleteFirstZero(bin);
            int result = 0;
            for (int i = 0; i < bin.Length; i++)
            {
                if (bin[i] == '1')
                {
                    result += (int)Math.Pow(2, bin.Length - i - 1);
                }
            }

            return result;
        }

        public string BinToHex(string bin)
        {
            return DecToHex(BinToDec(bin));
        }

        public int HexToDec(string Hex)
        {
            int result = 0;
            foreach (char tmp in Hex)
            {
                result *= 16;
                result += HexToNumber(tmp);
            }
            return result;
        }

        private string DeleteFirstZero(string text)
        {
            while (text.Length > 0 && text[0] == '0')
            {
                text = text.Substring(1);
            }
            if (text.Length == 0)
                text = "0";
            return text;
        }

        private char NumberToHex(int number)
        {
            switch (number)
            {
                case 0: return '0';
                case 1: return '1';
                case 2: return '2';
                case 3: return '3';
                case 4: return '4';
                case 5: return '5';
                case 6: return '6';
                case 7: return '7';
                case 8: return '8';
                case 9: return '9';
                case 10: return 'A';
                case 11: return 'B';
                case 12: return 'C';
                case 13: return 'D';
                case 14: return 'E';
                case 15: return 'F';
                default:
                    throw new ArgumentOutOfRangeException("Unnow argument: " + number);
            }
        }

        private int HexToNumber(char Hex)
        {
            switch (Hex)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                case 'A': return 10;
                case 'B': return 11;
                case 'C': return 12;
                case 'D': return 13;
                case 'E': return 14;
                case 'F': return 15;
                default:
                    throw new ArgumentOutOfRangeException("Unnow argument: " + Hex);
            }
        }

        private string HexToBin(char Hex)
        {
            switch (Hex)
            {
                case '0': return "0000";
                case '1': return "0001";
                case '2': return "0010";
                case '3': return "0011";
                case '4': return "0100";
                case '5': return "0101";
                case '6': return "0110";
                case '7': return "0111";
                case '8': return "1000";
                case '9': return "1001";
                case 'A': return "1010";
                case 'B': return "1011";
                case 'C': return "1100";
                case 'D': return "1101";
                case 'E': return "1110";
                case 'F': return "1111";
                default:
                    throw new ArgumentOutOfRangeException("Unnow argument: " + Hex);
            }
        }
    }
}
