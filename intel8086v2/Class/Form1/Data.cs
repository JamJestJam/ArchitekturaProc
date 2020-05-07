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
        Random R = new Random();
        //form
        Form Form;
        //draw size
        int Width { get { return Form.ClientSize.Width; } }
        int Height { get { return Form.ClientSize.Height; } }
        //length data
        const int ElementsHeight = 20;
        const int ElementsMarginY = 5;
        const int ElementsMarginX = 10;
        const int RegisterWidth = 50;
        const int LabelWidth = 30;
        const int labelMargin = 5;
        const int InputWidth = 150;
        /// <summary>
        /// return item's position
        /// </summary>
        /// <param name="y">element number</param>
        /// <returns></returns>
        int ElementPositionY(int y)
        {
            return ElementsHeight * y + (ElementsMarginY * (y + 1));
        }
        //list of elements
        TextBox Input;
        Dictionary<string, Button> ButtonsList = new Dictionary<string, Button>();
        Dictionary<string, Label> LabelsList = new Dictionary<string, Label>();
        //input list
        List<string> Inputs = new List<string>() {"Hex", "Bin", "Dec" };
        List<string> Buttons = new List<string>() { "Start", "Reset", "Random registers content" };
        //registers list
        //List<string> registersNames = new List<string> { "AX", "BX", "CX", "DX", "BP", "SP", "SI", "DI", "CS", "SS", "DS", "ES", "IP" };
        List<string> registersNames = new List<string> { "AX", "BX", "CX", "DX", "CS", "IP", "SS", "SP", "BP", "SI", "DI", "DS", "ES" };
        List<string> HalvRegistersName = new List<string> { "AH", "AL", "BH", "BL", "CH", "CL", "DH", "DL" };
        //position to draw elements
        /*
        int FlagPositionX { get { return FlagsLabelPositionX + LabelWidth + labelMargin; } }
        int FlagsLabelPositionX { get { return BigRegisterPositionX + RegisterWidth + ElementsMarginX; } }
        int BigRegisterPositionX { get { return BigRegistersLabelPositionX + LabelWidth + labelMargin; } }
        int BigRegistersLabelPositionX { get { return HalvRegisterPositionX + ElementsMarginX + RegisterWidth; } }
        int HalvRegisterPositionX { get { return HalvRegistersLabelPositionX + LabelWidth + labelMargin; } }
        int HalvRegistersLabelPositionX { get { return InputsLabelPositionX + LabelWidth + ElementsMarginX; } }
        */
        int BigRegisterPositionX { get { return BigRegistersLabelPositionX + LabelWidth + labelMargin; } }
        int BigRegistersLabelPositionX { get { return HalvRegisterPositionX + ElementsMarginX + RegisterWidth; } }
        int HalvRegisterPositionX { get { return HalvRegistersLabelPositionX + LabelWidth + labelMargin; } }
        int HalvRegistersLabelPositionX { get { return InputsLabelPositionX + LabelWidth + ElementsMarginX; } }
        int InputsLabelPositionX { get { return InputPositionX + labelMargin + InputWidth; } }
        int InputPositionX { get { return ElementsMarginX; } }
        int ButtonDoubleHeight { get { return ElementPositionY(2) - ElementPositionY(0) - ElementsMarginY; } }
        int ButtonWidth { get { return InputsLabelPositionX + LabelWidth - InputPositionX; } }
        //Ramm Content
        Dictionary<int, string> RamContent = new Dictionary<int, string>();
    }
}
