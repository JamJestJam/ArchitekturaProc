using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intel8086v2
{
    partial class Intel8086
    {
        public Intel8086(Form form)
        {
            Form = form;
            CreateInputBox();
            CreateButtons();
            CreateNumInfoBox();
            CreateHalvRegistersBox();
            CreateRegistersBox();
            EventInit();
            Reset(null, null);
        }
        private void CreateRegistersBox()
        {
            //register number
            int i = 0;
            foreach (string name in registersNames)
            {
                //data 
                Label label = new Label();
                label.Location = new Point(BigRegisterPositionX, ElementPositionY(i));
                label.Name = name;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Size = new Size(RegisterWidth, ElementsHeight);
                label.BorderStyle = BorderStyle.FixedSingle;
                LabelsList.Add(name, label);
                Form.Controls.Add(label);

                //label
                label = new Label();
                label.Location = new Point(BigRegistersLabelPositionX, ElementPositionY(i));
                label.Size = new Size(LabelWidth, ElementsHeight);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BorderStyle = BorderStyle.FixedSingle;
                label.Text = name;
                label.Name = name + "Label";
                LabelsList.Add(name + "Label", label);
                Form.Controls.Add(label);
                //increase register number
                i++;
            }
        }
        private void CreateHalvRegistersBox()
        {
            //register number
            int i = 0;
            foreach (string name in HalvRegistersName)
            {
                //data
                Label label = new Label();
                label.Location = new Point(HalvRegisterPositionX, ElementPositionY(i));
                label.Name = name;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Size = new Size(RegisterWidth, ElementsHeight);
                label.BorderStyle = BorderStyle.FixedSingle;
                LabelsList.Add(name, label);
                Form.Controls.Add(label);

                //label
                label = new Label();
                label.Location = new Point(HalvRegistersLabelPositionX, ElementPositionY(i));
                label.Size = new Size(LabelWidth, ElementsHeight);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BorderStyle = BorderStyle.FixedSingle;
                label.Text = name;
                label.Name = name + "Label";
                LabelsList.Add(name + "Label", label);
                Form.Controls.Add(label);
                //increase register number
                i++;
            }
        }
        private void CreateInputBox()
        {
            //data
            Input = new TextBox();
            Input.Location = new Point(InputPositionX, ElementPositionY(0));
            Input.Name = "Request";
            Input.Text = "Mov ax, bx";
            Input.TextAlign = HorizontalAlignment.Center;
            Input.Size = new Size(InputWidth, ElementsHeight);
            Input.BorderStyle = BorderStyle.FixedSingle;
            Form.Controls.Add(Input);

            //label
            Label label = new Label();
            label.Location = new Point(InputsLabelPositionX, ElementPositionY(0));
            label.Size = new Size(LabelWidth, ElementsHeight);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Text = "Req";
            label.Name = "Request Label";
            LabelsList.Add("Request Label", label);
            Form.Controls.Add(label);
        }
        private void CreateNumInfoBox()
        {
            //number
            int i = 1;
            foreach (string name in Inputs)
            {
                //data
                Label label = new Label();
                label.Location = new Point(InputPositionX, ElementPositionY(i));
                label.Name = name;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Size = new Size(InputWidth, ElementsHeight);
                label.Text = "0";
                label.BorderStyle = BorderStyle.FixedSingle;
                LabelsList.Add(name, label);
                Form.Controls.Add(label);

                //label
                label = new Label();
                label.Location = new Point(InputsLabelPositionX, ElementPositionY(i));
                label.Size = new Size(LabelWidth, ElementsHeight);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BorderStyle = BorderStyle.FixedSingle;
                label.Text = name;
                label.Name = name + "Label";
                LabelsList.Add(name + "Label", label);
                Form.Controls.Add(label);
                //increase number
                i++;
            }
        }
        private void CreateButtons()
        {
            //input number
            int i = Inputs.Count + 1;
            foreach (string name in Buttons)
            {
                //button
                Button button = new Button();
                button.TabIndex = 5;
                button.Text = name;
                button.Name = name;
                button.Location = new Point(InputPositionX - 1, ElementPositionY(i) - 1);
                button.Size = new Size(ButtonWidth + 2, ButtonDoubleHeight + 2);
                ButtonsList.Add(name, button);
                Form.Controls.Add(button);

                //increase input number
                i += 2;
            }
        }
    }
}
