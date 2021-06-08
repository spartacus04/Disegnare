using Poligoni.CanvasTools;
using Poligoni.DrawSettings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Poligoni
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //Abilito il double buffering per rimuovere sfarfallio
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null,
            panel2, new object[] { true });
        }

        #region draw

        private List<Tool> toDraw = new List<Tool>();   //Lista di oggetti da disegnare

        //Questo metodo disegna gli oggetti nel pannello ogni volta che viene richiamato
        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            //Per ogni oggetto esegue il metodo draw
            Graphics graphics = e.Graphics;
            foreach (Tool tool in toDraw)
            {
                tool.draw(graphics);
            }

            //Disegna preview di un oggetto
            if (preview != null && preview.point.Count >= 2)
                preview.draw(graphics);
        }

        #endregion draw

        #region input

        private bool isDrawing = false;
        private Tool preview;

        //Questo metodo viene richiamato ogni volta che il mouse viene premuto
        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (Settings.currentTool == Settings.ToolType.pointer) return;  //Se lo strumento attuale è il puntatore non eseguire il resto del metodo
            //Controllo se il tasto premuto è 6il tasto di sinistra
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = e.Location;
                preview = Settings.useTool(mousePos);
                isDrawing = true;

                panel2.Invalidate();    //Ricarica il pannello
            }
        }

        //Questo metodo viene richiamato quando il mouse si muove
        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //Controllo se sta disegnando
            if (isDrawing && e.Button == MouseButtons.Left)
            {
                Point mousePos = e.Location;
                preview.setPoint(mousePos);

                //Controllo per disegnare il poligono regolare se il tasto alt è premuto
                if(preview.GetType() == typeof(Polygon))
                {
                    Polygon poly = (Polygon)preview;
                    poly.setRegular(Control.ModifierKeys == Keys.Alt);
                }
                else if(preview.GetType() == typeof(Circle))
                {
                    Circle poly = (Circle)preview;
                    poly.setRegular(Control.ModifierKeys == Keys.Alt);
                }

                panel2.Invalidate();    //Ricarica il pannello
            }
        }

        //Questo metodo viene richiamato quando il mouse smette di essere premuto
        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point mousePos = e.Location;
                preview.setPoint(mousePos);
                //Se lo strumento è un poligono richiedo in input il numero di lati e se il tasto alt è premuto (valido anche per il cerchio) disegno il poligono in modo regolare
                if (preview.GetType() == typeof(Polygon))
                {
                    Polygon poly = (Polygon)preview;
                    poly.setRegular(Control.ModifierKeys == Keys.Alt);
                    string sides = "";
                    int lati = 100;
                    do
                    {
                        DialogResult result;
                        do
                        {
                            result = Settings.ShowInputDialog(ref sides, "Inserisci il numero di lati");
                            if (result == DialogResult.Cancel)
                            {
                                preview = null;
                                isDrawing = false;
                                panel2.Invalidate();
                                return;

                            }
                        } while (!int.TryParse(sides, out lati) && !(result == DialogResult.OK));
                    } while (lati < 3 && poly != null); //Richiesta in input dei dati

                    poly.setSides(lati);
                }
                else if (preview.GetType() == typeof(Circle))
                {
                    Circle poly = (Circle)preview;
                    poly.setRegular(Control.ModifierKeys == Keys.Alt);
                }

                toDraw.Add(preview);
                preview = null;
                panel2.Invalidate();    //Ricarica il pannello

                isDrawing = false;
            }
        }

        #endregion input

        #region UI

        //Da adesso in poi i seguenti metodi sono utilizzati per l'interfaccia grafica(cambiare colore e selezionare gli strumenti

        private void selectButton_Click(object sender, EventArgs e)
        {
            Settings.currentTool = Settings.ToolType.pointer;
        }

        private void penButton_Click(object sender, EventArgs e)
        {
            Settings.currentTool = Settings.ToolType.pencil;
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            Settings.currentTool = Settings.ToolType.line;
        }

        private void PolygonButton_Click(object sender, EventArgs e)
        {
            Settings.currentTool = Settings.ToolType.polygon;
        }

        private void circleBtn_Click(object sender, EventArgs e)
        {
            Settings.currentTool = Settings.ToolType.circle;
        }

        private void RubberButton_Click(object sender, EventArgs e)
        {
            Settings.currentTool = Settings.ToolType.rubber;
        }

        private void ForeColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = ForeColorButton.BackColor;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ForeColorButton.BackColor = dialog.Color;
                    Settings.color = dialog.Color;
                }
            }
        }

        private void backColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = backColorButton.BackColor;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    backColorButton.BackColor = dialog.Color;
                    Settings.backColor = dialog.Color;
                }
            }
        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            toDraw.Clear();
            panel2.Invalidate();
        }

        #endregion UI

        private void ThicknessUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings.lineStrenght = (int)ThicknessUpDown.Value;
        }
    }
}