using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchitektuaV._001
{
    public partial class Form1 : Form
    {
        //RAM
        Dictionary<int, string> RAM = new Dictionary<int, string>();
        //textbox location
        int TextBoxLocationX = 300;
        int TextBoxLocationY = 25;
        //list textboxs
        Dictionary<string, TextBox> TextBoxs = new Dictionary<string, TextBox>();
        //list registers names
        List<string> RegistrsNames = new List<string> { "AX", "BX", "CX", "DX", "BP", "SP", "SI", "DI", "CS", "SS", "DS", "ES" };
        List<string> RegisterHalvesName = new List<string> { "AH", "AL", "BH", "BL", "CH", "CL", "DH", "DL" };

        public Form1()
        {
            TextBox tmp = new TextBox();
            for (int i = 0; i < RegistrsNames.Count; i++)
            {
                //
                //Add new 16b textbox
                //
                tmp = new TextBox();
                tmp.Location = new System.Drawing.Point(TextBoxLocationX, 10 + (TextBoxLocationY * i));
                tmp.TextAlign = HorizontalAlignment.Center;
                tmp.Name = RegistrsNames[i];
                tmp.Size = new System.Drawing.Size(103, 20);
                tmp.TabIndex = 1;
                tmp.Text = "0000000000000000";
                tmp.ReadOnly = true;
                tmp.TextChanged += new System.EventHandler(this.RegisterOnchager16);
                tmp.TextChanged += new System.EventHandler(this.RegisterToLover);
                tmp.Click += new System.EventHandler(this.ToDecimal);

                this.Controls.Add(tmp);
                TextBoxs.Add(RegistrsNames[i], tmp);
                //
                //Add new label to textbox
                //
                tmp = new TextBox();
                tmp.Location = new System.Drawing.Point(TextBoxLocationX - 30, 10 + (TextBoxLocationY * i));
                tmp.TextAlign = HorizontalAlignment.Center;
                tmp.Name = 'L' + RegistrsNames[i];
                tmp.Size = new System.Drawing.Size(25, 20);
                tmp.TabIndex = 1;
                tmp.Text = RegistrsNames[i];
                tmp.ReadOnly = true;

                this.Controls.Add(tmp);
                TextBoxs.Add('L' + RegistrsNames[i], tmp);
            }

            for (int i = 0; i < RegisterHalvesName.Count; i++)
            {
                //
                //Add new 8b textbox
                //
                tmp = new TextBox();
                tmp.Location = new System.Drawing.Point(TextBoxLocationX - 90, 10 + (TextBoxLocationY * i));
                tmp.TextAlign = HorizontalAlignment.Center;
                tmp.Name = RegisterHalvesName[i];
                tmp.Size = new System.Drawing.Size(55, 20);
                tmp.TabIndex = 1;
                tmp.Text = "00000000";
                tmp.ReadOnly = true;
                tmp.TextChanged += new System.EventHandler(this.RegisterOnchager8);
                tmp.TextChanged += new System.EventHandler(this.RegisterToBiger);
                tmp.Click += new System.EventHandler(this.ToDecimal);

                this.Controls.Add(tmp);
                TextBoxs.Add(RegisterHalvesName[i], tmp);
                //
                //Add new label to textbox
                //
                tmp = new TextBox();
                tmp.Location = new System.Drawing.Point(TextBoxLocationX - 120, 10 + (TextBoxLocationY * i));
                tmp.TextAlign = HorizontalAlignment.Center;
                tmp.Name = 'L' + RegisterHalvesName[i];
                tmp.Size = new System.Drawing.Size(25, 20);
                tmp.TabIndex = 1;
                tmp.Text = RegisterHalvesName[i];
                tmp.ReadOnly = true;

                this.Controls.Add(tmp);
                TextBoxs.Add('L' + RegisterHalvesName[i], tmp);
            }
            //
            //input request
            //
            tmp = new TextBox();
            tmp.Location = new System.Drawing.Point(10, 10);
            tmp.Text = "MOV";
            tmp.Name = "Request";
            tmp.Size = new System.Drawing.Size(103, 20);
            tmp.TabIndex = 1;

            this.Controls.Add(tmp);
            TextBoxs.Add("Request", tmp);
            //
            //label to textbox
            //
            tmp = new TextBox();
            tmp.Location = new System.Drawing.Point(115, 10);
            tmp.TextAlign = HorizontalAlignment.Center;
            tmp.Name = "LRequest";
            tmp.Size = new System.Drawing.Size(50, 20);
            tmp.TabIndex = 1;
            tmp.Text = "Request";
            tmp.ReadOnly = true;

            this.Controls.Add(tmp);
            TextBoxs.Add("LRequest", tmp);
            //
            //input A
            //
            tmp = new TextBox();
            tmp.Location = new System.Drawing.Point(10, 35);
            tmp.Text = "AH";
            tmp.Name = "Input_A";
            tmp.Size = new System.Drawing.Size(103, 20);
            tmp.TabIndex = 1;
            tmp.GotFocus += new System.EventHandler(this.OnFocusInput);
            tmp.TextChanged += new System.EventHandler(this.onChangeInput);
            tmp.LostFocus += new System.EventHandler(this.OnLostFocusInput);

            this.Controls.Add(tmp);
            TextBoxs.Add("Input_A", tmp);
            //
            //label to textbox
            //
            tmp = new TextBox();
            tmp.Location = new System.Drawing.Point(115, 35);
            tmp.TextAlign = HorizontalAlignment.Center;
            tmp.Name = "LInput_A";
            tmp.Size = new System.Drawing.Size(50, 20);
            tmp.TabIndex = 1;
            tmp.Text = "Input_A";
            tmp.ReadOnly = true;

            this.Controls.Add(tmp);
            TextBoxs.Add("LInput_A", tmp);
            //
            //Input B
            //
            tmp = new TextBox();
            tmp.Location = new System.Drawing.Point(10, 60);
            tmp.Text = "00000101";
            tmp.Name = "Input_B";
            tmp.Size = new System.Drawing.Size(103, 20);
            tmp.TabIndex = 1;
            tmp.GotFocus += new System.EventHandler(this.OnFocusInput);
            tmp.TextChanged += new System.EventHandler(this.onChangeInput);
            tmp.LostFocus += new System.EventHandler(this.OnLostFocusInput);

            this.Controls.Add(tmp);
            TextBoxs.Add("Input_B", tmp);
            //
            //label to textbox
            //
            tmp = new TextBox();
            tmp.Location = new System.Drawing.Point(115, 60);
            tmp.TextAlign = HorizontalAlignment.Center;
            tmp.Name = "LInput_B";
            tmp.Size = new System.Drawing.Size(50, 20);
            tmp.TabIndex = 1;
            tmp.Text = "Input_B";
            tmp.ReadOnly = true;

            this.Controls.Add(tmp);
            TextBoxs.Add("LInput_B", tmp);
            //
            //proces button
            //
            Button button = new Button();
            button.Location = new System.Drawing.Point(10, 85);
            button.Name = "Buton";
            button.Size = new System.Drawing.Size(155, 50);
            button.TabIndex = 0;
            button.Text = "Start";
            button.UseVisualStyleBackColor = true;
            button.Click += new System.EventHandler(this.Tick);

            this.Controls.Add(button);

            //
            //Decimal
            //
            tmp = new TextBox();
            tmp.Location = new System.Drawing.Point(10, 135);
            tmp.Name = "Decimal";
            tmp.Size = new System.Drawing.Size(103, 20);
            tmp.TabIndex = 1;
            tmp.ReadOnly = true;
            tmp.TextAlign = HorizontalAlignment.Center;
            tmp.Text = "0000";

            this.Controls.Add(tmp);
            TextBoxs.Add("Decimal", tmp);
            //
            //label to textbox
            //
            tmp = new TextBox();
            tmp.Location = new System.Drawing.Point(115, 135);
            tmp.TextAlign = HorizontalAlignment.Center;
            tmp.Name = "LDecimal";
            tmp.Size = new System.Drawing.Size(50, 20);
            tmp.TabIndex = 1;
            tmp.Text = "Decimal";
            tmp.ReadOnly = true;

            this.Controls.Add(tmp);
            TextBoxs.Add("LDecimal", tmp);
            //
            //Address
            //
            tmp = new TextBox();
            tmp.Location = new System.Drawing.Point(10, 185);
            tmp.Name = "Address";
            tmp.Size = new System.Drawing.Size(155, 20);
            tmp.TabIndex = 1;
            tmp.TextAlign = HorizontalAlignment.Center;
            tmp.Text = "00000000000000000000";
            tmp.ReadOnly = true;
            tmp.TextChanged += new System.EventHandler(this.RegisterOnchager20);

            this.Controls.Add(tmp);
            TextBoxs.Add("Address", tmp);
            //
            //label to textbox
            //
            tmp = new TextBox();
            tmp.Location = new System.Drawing.Point(10, 160);
            tmp.TextAlign = HorizontalAlignment.Center;
            tmp.Name = "LAddress";
            tmp.Size = new System.Drawing.Size(155, 20);
            tmp.TabIndex = 1;
            tmp.Text = "Address";
            tmp.ReadOnly = true;

            this.Controls.Add(tmp);
            TextBoxs.Add("LAddress", tmp);

            //
            //Decimal
            //
            tmp = new TextBox();
            tmp.Location = new System.Drawing.Point(10, 210);
            tmp.Name = "Output";
            tmp.Size = new System.Drawing.Size(103, 20);
            tmp.TabIndex = 1;
            tmp.ReadOnly = true;
            tmp.TextAlign = HorizontalAlignment.Center;
            tmp.Text = "0000000000000000";

            this.Controls.Add(tmp);
            TextBoxs.Add("Output", tmp);
            //
            //label to textbox
            //
            tmp = new TextBox();
            tmp.Location = new System.Drawing.Point(115, 210);
            tmp.TextAlign = HorizontalAlignment.Center;
            tmp.Name = "LOutput";
            tmp.Size = new System.Drawing.Size(50, 20);
            tmp.TabIndex = 1;
            tmp.Text = "Output";
            tmp.ReadOnly = true;

            this.Controls.Add(tmp);
            TextBoxs.Add("LOutput", tmp);

            InitializeComponent();
        }
        /// <summary>
        /// check if data is binary and the lenght is 20
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterOnchager20(object sender, EventArgs e)
        {
            TextBoxs.TryGetValue(((TextBox)sender).Name, out TextBox tmp);
            string text = tmp.Text;

            if (text.Length > 20)
                text = text.Substring(text.Length - 20, 20);
            for (int i = 0; i < text.Length; i++)
            {
                if (!(text[i] == '0' || text[i] == '1'))
                {
                    throw new Exception("Register have incorrect data");
                }
            }
            for (int i = 0; i < 20 - text.Length; i++)
            {
                text = '0' + text;
            }

            tmp.Text = text;
        }
        /// <summary>
        /// check if data is binary and the lenght is 16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterOnchager16(object sender, EventArgs e)
        {
            TextBoxs.TryGetValue(((TextBox)sender).Name, out TextBox tmp);
            string text = tmp.Text;

            if (text.Length > 16)
                text = text.Substring(text.Length - 16, 16);
            for (int i = 0; i < text.Length; i++)
            {
                if (!(text[i] == '0' || text[i] == '1'))
                {
                    throw new Exception("Register have incorrect data");
                }
            }
            for (int i = 0; i < 16 - text.Length; i++)
            {
                text = '0' + text;
            }

            tmp.Text = text;
        }
        /// <summary>
        /// check if data is binary and the lenght is 8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterOnchager8(object sender, EventArgs e)
        {
            TextBoxs.TryGetValue(((TextBox)sender).Name, out TextBox tmp);
            string text = tmp.Text;

            if (text.Length > 8)
                text = text.Substring(text.Length-8, 8);
            for (int i = 0; i < text.Length; i++)
            {
                if (!(text[i] == '0' || text[i] == '1'))
                {
                    throw new Exception("Register have incorrect data");
                }
            }
            for (int i = 0; i < 8 - text.Length; i++)
            {
                text = '0' + text;
            }

            tmp.Text = text;
        }
        /// <summary>
        /// transfer data to from halv to whole register
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterToBiger(object sender, EventArgs e)
        {
            TextBoxs.TryGetValue(((TextBox)sender).Name, out TextBox small);
            TextBoxs.TryGetValue(small.Name.Substring(0, 1) + "X", out TextBox big);
            TextBoxs.TryGetValue(small.Name.Substring(0, 1) + "H", out TextBox smallH);
            TextBoxs.TryGetValue(small.Name.Substring(0, 1) + "L", out TextBox smallL);

            big.Text = smallH.Text + smallL.Text;
        }
        /// <summary>
        /// transfer data to halvs registers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterToLover(object sender, EventArgs e)
        {
            TextBoxs.TryGetValue(((TextBox)sender).Name, out TextBox big);

            if (TextBoxs.TryGetValue(big.Name.Substring(0, 1) + "H", out TextBox smallH) &&
                TextBoxs.TryGetValue(big.Name.Substring(0, 1) + "L", out TextBox smallL))
            {

                smallH.Text = big.Text.Substring(0, 8);
                smallL.Text = big.Text.Substring(8, 8);
            }
        }

        private string oldValue = "";
        /// <summary>
        /// entrance service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFocusInput(object sender, EventArgs e)
        {
            TextBoxs.TryGetValue(((TextBox)sender).Name, out TextBox tmp);
            oldValue = tmp.Text.ToString();
        }
        /// <summary>
        /// entrance service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onChangeInput(object sender, EventArgs e)
        {
            TextBoxs.TryGetValue(((TextBox)sender).Name, out TextBox tmp);
            if (tmp.Text.Length > 16)
                tmp.Text = oldValue;
            oldValue = tmp.Text;
        }
        /// <summary>
        /// entrance service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLostFocusInput(object sender, EventArgs e)
        {
            oldValue = "";
        }

        private void ToDecimal(object sender, EventArgs e)
        {
            int number = 0;
            TextBoxs.TryGetValue(((TextBox)sender).Name, out TextBox tmp);
            for (int i = tmp.Text.Length - 1; i >= 0; i--)
            {
                if (tmp.Text[i] == '1')
                {
                    number += (int)Math.Pow(2, (tmp.Text.Length - i) - 1);
                }
            }
            TextBoxs.TryGetValue("Decimal", out TextBox Out);
            Out.Text = number.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Tick(object sender, EventArgs e)
        {
            TextBoxs.TryGetValue("Request", out TextBox In);
            TextBoxs.TryGetValue("Input_A", out TextBox InA);
            TextBoxs.TryGetValue("Input_B", out TextBox InB);

            switch (In.Text)
            {
                case "MOV":
                    string tmp = "";
                    if (InB.Text.All(char.IsDigit))
                    {
                        tmp = InB.Text;
                    }
                    else
                    {
                        TextBoxs.TryGetValue(InB.Text, out TextBox data);
                        tmp = data.Text;
                    }
                    TextBoxs.TryGetValue(InA.Text, out TextBox Out);
                    Out.Text = tmp;
                    break;
            }
        }
    }
}
