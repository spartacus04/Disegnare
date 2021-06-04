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
                if (tool != null)
                    tool.draw(graphics);
            }

            //Disegna preview della linea
            if (line != null && line.point2 != new Point(0, 0))
                line.draw(graphics);
        }

        #endregion draw

        #region input

        private bool isDrawing = false;
        private Line line;

        //Questo metodo viene richiamato ogni volta che il mouse viene premuto
        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (Settings.currentTool == Settings.ToolType.pointer) return;  //Se lo strumento attuale è il puntatore non eseguire il resto del metodo
            //Controllo se il tasto premuto è il tasto di sinistra
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = e.Location;
                //Se lo strumento selezionato non è la linea allora aggiungilo alla lista degli strumenti
                if (Settings.currentTool != Settings.ToolType.line)
                {
                    if((Settings.currentTool == Settings.ToolType.circle || Settings.currentTool == Settings.ToolType.polygon) && Settings.useTool(mousePos) != null)
                    {
                        Tool tool = Settings.useTool(mousePos);
                        if (tool.canHold)
                            isDrawing = true;
                        toDraw.Add(tool);
                    }
                }
                else
                {
                    //Altrimenti crea un nuovo oggetto linea che verra mostrato temporaneamente
                    line = new Line(mousePos, new Point(0, 0), 0, Settings.color);
                    isDrawing = line.canHold;
                }
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
                //Se lo strumento selezionato non è la linea allora aggiungilo alla lista degli strumenti
                if (Settings.currentTool != Settings.ToolType.line && Settings.useTool(mousePos).canHold)
                {
                    Tool tool = Settings.useTool(mousePos);
                    if (tool.canHold)
                        isDrawing = true;
                    if (tool != null) toDraw.Add(tool);
                }
                else
                {
                    //Altrimenti modifica la linea con la seconda posizione desiderata
                    line = new Line(line.point, mousePos, 3, Settings.color);
                    isDrawing = line.canHold;
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
                //Se lo strumento selezionato non è la linea allora aggiungilo alla lista degli strumenti
                if (Settings.currentTool != Settings.ToolType.line)
                {
                    Tool tool = Settings.useTool(mousePos);
                    if(tool != null)
                    toDraw.Add(tool);
                }
                else
                {
                    //Altrimenti modifica la linea e poi la aggiunge alla lista degli oggetti da disegnare
                    line = new Line(line.point, mousePos, 3, Settings.color);
                    toDraw.Add(line);
                    line = null;
                }
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

        #endregion UI
    }
}