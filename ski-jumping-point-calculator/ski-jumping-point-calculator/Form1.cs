using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ski_jumping_point_calculator
{
    public partial class Form1 : Form
    {
        private K_Point kPoint;
        private JumpStyle jumpStyle;
        private Wind wind;
        private Platform platform;
        private Results results;
        private float kPointMultiplier;
        private float bonusPoints;
        private float jumpLength;
        private float jumpPoints;
        private float jumpStylePoints;
        private float windPoints;
        private float platformPoints;
        private List<float> resultsList = new List<float>();


        public Form1()
        {
            InitializeComponent();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            kPoint = new K_Point();
            jumpStyle = new JumpStyle();
            wind = new Wind();
            platform = new Platform();
            results = new Results();
            kPointMultiplier = kPoint.SetKpointMultiplier(int.Parse(txbLength.Text));
            lblKpoint.Text = kPointMultiplier.ToString();
            jumpLength = float.Parse(txbJumpLength.Text);
            bonusPoints = jumpLength - int.Parse(txbLength.Text);
            jumpPoints = (60) + bonusPoints * kPointMultiplier;
            jumpStylePoints = jumpStyle.CountReview(float.Parse(txbR1.Text), float.Parse(txbR2.Text), float.Parse(txbR3.Text), float.Parse(txbR4.Text), float.Parse(txbR5.Text));
            windPoints = wind.CountWind(float.Parse(txbWind1.Text), float.Parse(txbWind2.Text), float.Parse(txbWind3.Text), float.Parse(txbWind4.Text), float.Parse(txbWind5.Text), int.Parse(txbLength.Text), kPointMultiplier);
            platformPoints = platform.CountPlatformChange(float.Parse(txbStartPlatform.Text), kPointMultiplier);
            resultsList.Add(results.CountResult(jumpPoints, jumpStylePoints, windPoints, platformPoints));
            ViewResults();
        }

        public void ViewResults()
        {
            lbResults.Items.Clear();
            foreach (float result in resultsList)
            {
                lbResults.Items.Add(result);
            }
        }
    }
}
