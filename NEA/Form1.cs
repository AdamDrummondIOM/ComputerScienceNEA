﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA
{
    public partial class RPG : Form
    {
        public delegate void DisplayOption(ref DisplayOption Menu, TableLayoutPanel tblLayout);
        public RPG()
        {
            InitializeComponent();
        }

        //what the program boots into
        private void RPG_Load(object sender, EventArgs e)
        {
            //sort out delegate into initialisetable to choose between the three options?
            //creates the main table for the program to run from
            TableLayoutPanel tblLayout = new TableLayoutPanel();
            //delegate attempt
            DisplayOption Menu = new DisplayOption(InitialiseTable);

            //runs program
            while (true)
            {
              //goes to the specific option for the time in the program
                InitialiseTable(ref Menu, tblLayout);
                //Menu(ref Menu, tblLayout);
            }
        }
        private void InitialiseTable(ref DisplayOption Menu, TableLayoutPanel tblLayout)
        {
            /*sets up the table width (window width), height (window heigh - 39),
            sets it to anchor to all sides so it can be resized, adds 6 rows and 5 columns*/
            tblLayout.Width = Width;
            tblLayout.Height = Height-39;
            tblLayout.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            tblLayout.ColumnCount = 5;
            tblLayout.RowCount = 6;
            //temporary border for testing purposes
            tblLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            //sets each column to be 20% of the width of the window
            for(int i = 0; i < tblLayout.ColumnCount; i++)
            {
                tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            }
            //sets the first row to be 20% of the window height
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            //sets the remaining rows to be 16% of the window height (20% of remaining height)
            for(int i = 1; i < tblLayout.RowCount; i++)
            {
                tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 16));
            }

            //TitleScreen(ref Menu, tblLayout);// replaced with delegate
            //Menu = new DisplayOption(TitleScreen);

            Controls.Add(tblLayout);
        }
        private void TitleScreen(ref DisplayOption Menu, TableLayoutPanel tblLayout)
        {
            /*creates a lable for the title, aligns it to the centre, adds the text,
            sets autosize and anchors for resizing with window, sets font
            and sets location to the the centre of the page spanning 5 columns
            */
            Label lblTitle = new Label();
            lblTitle.Text = "RPG Designer and Player";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Name = "lblTitle";
            lblTitle.AutoSize = true;
            lblTitle.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
            lblTitle.Font = new Font(FontFamily.GenericSansSerif, 24.0F, FontStyle.Bold);
            lblTitle.Location = new Point(this.Width / 2 - 2 * lblTitle.Width, 50);
            tblLayout.SetColumnSpan(lblTitle, 5);
            //adds the title to thye table
            tblLayout.Controls.Add(lblTitle, 0, 0);

            /*creates a button for the Designer option, adds it to the table
            and sets anchors for auto resizing*/
            Button btnDesigner = new Button();
            btnDesigner.Text = "Designer";
            // sort this out
            //btnDesigner.Click += new EventHandler(ButtonClick(ref Menu));
            tblLayout.Controls.Add(btnDesigner, 1, 2);
            btnDesigner.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);

            /*creates a button for the Play option, adds it to the table
            and sets anchors for auto resizing*/
            Button btnPlay = new Button();
            btnPlay.Text = "Play";
            tblLayout.Controls.Add(btnPlay, 3, 2);
            btnPlay.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);

            /*creates a button to quit, adds it to the table, adds EventHandler to quit
            and sets anchors for auto resizing*/
            Button btnQuit = new Button();
            btnQuit.Text = "Quit";
            btnQuit.Click += new EventHandler(Quit);
            tblLayout.Controls.Add(btnQuit, 2, 4);
            btnQuit.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
        }
        private void ButtonClick(object sender, EventArgs e, ref DisplayOption Menu)
        {
          //potential handler for clicking the buttons
        }
        private void DesignerScreen(ref DisplayOption Menu, TableLayoutPanel tblLayout)
        {
          //setup the button controls for Design
        }
        private void PlayScreen(ref DisplayOption Menu, TableLayoutPanel tblLayout)
        {
          //setup the button controls for Play
        }
        private void Quit(object sender, EventArgs e)
        {
            //quits the application.
            Application.Exit();
        }
    }
}
