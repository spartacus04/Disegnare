using Poligoni.CanvasTools;
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

        public static Tool useTool(Point point)
        {
            DialogResult result;

            //In questo switch non è presente il case 2 dato che viene gestito nella classe del form
            switch ((int)currentTool)
            {
                case 0:
                    return null;    //Il puntatore non ha utilizzo quindi il metodo restituisce null
                case 1:
                    return new Pencil(point, 5, color); //Restituisce una un quadrato
                case 3:
                    string polyInputSides = "", polyInputDim = "";
                    int lati, dim;

                    result = DialogResult.Ignore;

                    do
                    {
                        do
                        {
                            result = ShowInputDialog(ref polyInputSides, "Inserisci il numero di lati");
                            if (result == DialogResult.Cancel) return null;
                        } while (!int.TryParse(polyInputSides, out lati) && !(result == DialogResult.OK));
                    } while (lati < 3); //Richiesta in input dei dati

                    result = DialogResult.Ignore;

                    do
                    {
                        result = ShowInputDialog(ref polyInputDim, "Inserisci la grandezza del lato");
                        if (result == DialogResult.Cancel) return null;
                    } while (!int.TryParse(polyInputDim, out dim) && !(result == DialogResult.OK)); //Richiesta in input dei dati

                    return new Polygon(point, dim * 50, color, backColor, lati);    //Disegna un poligono
                case 4:
                    string circleInputDim = "";
                    int radious;

                    result = DialogResult.Ignore;

                    do
                    {
                        result = ShowInputDialog(ref circleInputDim, "Inserisci il raggio");
                        if (result == DialogResult.Cancel) return null;
                    } while (!int.TryParse(circleInputDim, out radious) && !(result == DialogResult.OK)); //Richiesta in input dei dati

                    return new Circle(point, radious * 10, color, backColor);

                case 5:
                    return new Pencil(point, 25, Color.White);  //Restituisce un quadrato bianco, che disegnato sopra gli altri elementi funziona come gomma
            }
            return null;
        }

        //Questo metodo viene usato per richiedere in input un determinato valore tramite una dialogbox
        private static DialogResult ShowInputDialog(ref string input, string question)
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