using Poligoni.CanvasTools;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Poligoni.DrawSettings
{
    internal static class Settings
    {
        public enum ToolType { pointer, pencil, line, polygon, circle, rubber }

        static public Color color = Color.Black;
        static public Color backColor = Color.White;
        static public ToolType currentTool = ToolType.pointer;
        static public int lineStrenght = 3;

        public static Tool useTool(Point point, Tool _tool = null)
        {

            //In questo switch non è presente il case 2 dato che viene gestito nella classe del form
            switch ((int)currentTool)
            {
                case 1:
                    return new Pencil(point, color); //Restituisce una un quadrato
                case 2:
                    return new Line(point, color);
                case 3:
                    return new Polygon(point, color, backColor);    //Disegna un poligono
                case 4:
                    return new Circle(point, color, backColor);
                case 5:
                    return new Pencil(point, Color.White, true);  //Restituisce un quadrato bianco, che disegnato sopra gli altri elementi funziona come gomma
            }
            return null;
        }

        //Questo metodo viene usato per richiedere in input un determinato valore tramite una dialogbox
        public static DialogResult ShowInputDialog(ref string input, string question)
        {
            System.Drawing.Size size = new System.Drawing.Size(300, 100);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Input";

            Label label = new Label();
            label.Text = question;
            label.Size = new Size(size.Width - 10, 20);
            label.Location = new Point(5, 15);
            inputBox.Controls.Add(label);

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 37);
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 69);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 69);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();

            input = textBox.Text;
            return result;
        }
    }
}