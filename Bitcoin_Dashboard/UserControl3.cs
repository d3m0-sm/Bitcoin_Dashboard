﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NBitcoin;

namespace Bitcoin_Dashboard
{
    public partial class UserControl3 : UserControl
    {
        private int[] outputAnzahl = new int[12];
        private int[] inputAnzahl = new int[12];
        private long value;

        public UserControl3()
        {
            InitializeComponent();
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(44, 43, 60);
            chart1.BackColor = Color.FromArgb(76, 75, 105);
            btnBlockBericht.BackColor = Color.FromArgb(76, 75, 105);
            btnBlockBericht.ForeColor = Color.White;
            btnBlockBericht.FlatStyle = FlatStyle.Flat;
            btnBlockBericht.FlatAppearance.BorderSize = 0;

            fillArray(inputAnzahl);
            fillArray(outputAnzahl);

            
        }

        private void btnBlockBericht_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;
                analyzeTransactions(Convert.ToInt32(textBoxBlockbericht.Text));
            }
            catch
            {
                lblError.Text = "Wrong Value (To high, to low, wrong format?)";
                lblError.Visible = true;
            }
            
            label3.Text = Convert.ToString(BitcoinToolbox.getBestBlockHeight());
        }

        private void fillArray(int[] oiAnzahl)
        {
            for (int i = 0; i < 12; i++)
            {
                oiAnzahl[i] = 0;
            }
        }

        private void fillChart()
        {

            chart1.Series["Outputs"].Points.Clear();
            chart1.Series["Outputs"].Points.AddXY("0", outputAnzahl[0]);
            chart1.Series["Outputs"].Points.AddXY("1", outputAnzahl[1]);
            chart1.Series["Outputs"].Points.AddXY("2", outputAnzahl[2]);
            chart1.Series["Outputs"].Points.AddXY("3", outputAnzahl[3]);
            chart1.Series["Outputs"].Points.AddXY("4", outputAnzahl[4]);
            chart1.Series["Outputs"].Points.AddXY("5", outputAnzahl[5]);
            chart1.Series["Outputs"].Points.AddXY("6", outputAnzahl[6]);
            chart1.Series["Outputs"].Points.AddXY("7", outputAnzahl[7]);
            chart1.Series["Outputs"].Points.AddXY("8", outputAnzahl[8]);
            chart1.Series["Outputs"].Points.AddXY("9", outputAnzahl[9]);
            chart1.Series["Outputs"].Points.AddXY("10", outputAnzahl[10]);
            chart1.Series["Outputs"].Points.AddXY("> 10", outputAnzahl[11]);


            chart1.Series["Inputs"].Points.Clear();
            chart1.Series["Inputs"].Points.AddXY("0", inputAnzahl[0]);
            chart1.Series["Inputs"].Points.AddXY("1", inputAnzahl[1]);
            chart1.Series["Inputs"].Points.AddXY("2", inputAnzahl[2]);
            chart1.Series["Inputs"].Points.AddXY("3", inputAnzahl[3]);
            chart1.Series["Inputs"].Points.AddXY("4", inputAnzahl[4]);
            chart1.Series["Inputs"].Points.AddXY("5", inputAnzahl[5]);
            chart1.Series["Inputs"].Points.AddXY("6", inputAnzahl[6]);
            chart1.Series["Inputs"].Points.AddXY("7", inputAnzahl[7]);
            chart1.Series["Inputs"].Points.AddXY("8", inputAnzahl[8]);
            chart1.Series["Inputs"].Points.AddXY("9", inputAnzahl[9]);
            chart1.Series["Inputs"].Points.AddXY("10", inputAnzahl[10]);
            chart1.Series["Inputs"].Points.AddXY("> 10", inputAnzahl[11]);

        }

        public void analyzeTransactions(int height)
        {
            fillArray(outputAnzahl);
            fillArray(inputAnzahl);

            value = 0;

            List<Transaction> blockTxs = BitcoinToolbox.getBlockTransactions(height);
            label2.Text = Convert.ToString(blockTxs.Count);

            foreach (Transaction tx in blockTxs)
            {
                switch (tx.Outputs.Count)
                {
                    case 0:
                        outputAnzahl[0] += 1;
                        break;

                    case 1:
                        outputAnzahl[1] += 1;
                        break;

                    case 2:
                        outputAnzahl[2] += 1;
                        break;

                    case 3:
                        outputAnzahl[3] += 1;
                        break;

                    case 4:
                        outputAnzahl[4] += 1;
                        break;

                    case 5:
                        outputAnzahl[5] += 1;
                        break;

                    case 6:
                        outputAnzahl[6] += 1;
                        break;

                    case 7:
                        outputAnzahl[7] += 1;
                        break;

                    case 8:
                        outputAnzahl[8] += 1;
                        break;

                    case 9:
                        outputAnzahl[9] += 1;
                        break;

                    case 10:
                        outputAnzahl[10] += 1;
                        break;

                    case int n when (n > 10):
                        outputAnzahl[11] += 1;
                        break;

                    default:
                        break;
                }


                switch (tx.Inputs.Count)
                {
                    case 0:
                        inputAnzahl[0] += 1;
                        break;

                    case 1:
                        inputAnzahl[1] += 1;
                        break;

                    case 2:
                        inputAnzahl[2] += 1;
                        break;

                    case 3:
                        inputAnzahl[3] += 1;
                        break;

                    case 4:
                        inputAnzahl[4] += 1;
                        break;

                    case 5:
                        inputAnzahl[5] += 1;
                        break;

                    case 6:
                        inputAnzahl[6] += 1;
                        break;

                    case 7:
                        inputAnzahl[7] += 1;
                        break;

                    case 8:
                        inputAnzahl[8] += 1;
                        break;

                    case 9:
                        inputAnzahl[9] += 1;
                        break;

                    case 10:
                        inputAnzahl[10] += 1;
                        break;

                    case int n when (n > 10):
                        inputAnzahl[11] += 1;
                        break;

                    default:
                        break;
                }

                value += tx.Outputs.Transaction.TotalOut.Satoshi;
            }

            fillChart();
            label1.Text = Convert.ToString(value/(decimal)100000000);

        }

        private void UserControl3_VisibleChanged(object sender, EventArgs e)
        {
           
        }
    }
}
