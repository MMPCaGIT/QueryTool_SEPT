﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPLETE_FLAT_UI
{
    public partial class LuckDraw : Form
    {
        public LuckDraw()
        {
            InitializeComponent();
        }
        // The Label controls we will animate and their properties.
        private List<Label> AnimateLabels = new List<Label>();
        private List<int> AnimateStartXs = new List<int>();
        private List<int> AnimateStartYs = new List<int>();
        private List<float> AnimateDxs = new List<float>();
        private List<float> AnimateDys = new List<float>();
        private List<float> AnimateXs = new List<float>();
        private List<float> AnimateYs = new List<float>();
        private List<int> AnimateTotalTicks = new List<int>();
        private List<int> AnimateTicksToGo = new List<int>();

        // Make lists of the controls to move.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Move down 20 pixels in 1 second.
            StoreAnimationInfo(lblTitle1, 0, 20, 500);

            // Move right 40 pixels in 2 seconds.
            StoreAnimationInfo(lblTitle2, 40, 0, 1000);

            // Move left 40 pixels in 2 seconds.
            StoreAnimationInfo(lblTitle3, -40, 0, 1000);

            // Move up 20 pixels in 1 second.
            StoreAnimationInfo(lblTitle4, 0, -20, 500);
        }

        // Store information to move a label.
        private void StoreAnimationInfo(Label lbl, float dx, float dy, float milliseconds)
        {
            // Calculate the number of times the Timer will tick.
            int ticks = (int)(milliseconds / tmrMoveLabels.Interval);

            // Add the values.
            AnimateLabels.Add(lbl);
            AnimateStartXs.Add((int)(lbl.Location.X - dx));
            AnimateStartYs.Add((int)(lbl.Location.Y - dy));
            AnimateDxs.Add(dx / ticks);
            AnimateDys.Add(dy / ticks);
            AnimateTotalTicks.Add(ticks);
        }

        // Move the labels to the start positions and start animating them.
        private void btnAnimate_Click_1(object sender, EventArgs e)
        {
            //lblTitle1.Location = new Point(lblTitle1.Location.x+1, lblTitle1.Location.)

            //    for (int i = 0; i < AnimateLabels.Count; i++)
            //    {
            //        AnimateXs.Add(AnimateStartXs[i]);
            //        AnimateYs.Add(AnimateStartYs[i]);
            //        AnimateLabels[i].Location =
            //            new Point((int)AnimateXs[i], (int)AnimateYs[i]);
            //        AnimateLabels[i].Visible = true;
            //        AnimateTicksToGo.Add(AnimateTotalTicks[i]);
            //    }

            //    tmrMoveLabels.Enabled = true;
            //int count = 0;
            Label orgLocation = lblTitle1;
            //while(count!= 10)
            //{
            for(int index = 0; index < 2; index++){ 
            for (int i = 0; i < 31; i++)
            {
                lblTitle1.Location = new Point(lblTitle1.Location.X, lblTitle1.Location.Y + 1);
                //Thread.Sleep(500);
            }

            lblTitle1.Location = new Point(lblTitle1.Location.X, lblTitle1.Location.Y - 30);
        }
            //for (int i = 0; i < 21; i++)
            //{
            //    lblTitle1.Location = new Point(lblTitle1.Location.X, lblTitle1.Location.Y -1);
            //    //Thread.Sleep(500);
            //}
            //}
            //while (count != 10)
            //{
            //    lblTitle1.Location = new Point(lblTitle1.Location.X, lblTitle1.Location.Y - 1);
            //    count++;
            //}

        }
        // Move the labels.
        private void tmrMoveLabels_Tick_1(object sender, EventArgs e)
        {
            bool done_moving = true;
            DateTime now = DateTime.Now;
            for (int i = 0; i < AnimateLabels.Count; i++)
            {
                if (AnimateTicksToGo[i]-- > 0)
                {
                    done_moving = false;
                    AnimateXs[i] += AnimateDxs[i];
                    AnimateYs[i] += AnimateDys[i];
                    AnimateLabels[i].Location =
                        new Point((int)AnimateXs[i], (int)AnimateYs[i]);
                }
            }

            // If all labels are done moving, disable the Timer.
            if (done_moving)
            {
                tmrMoveLabels.Enabled = false;
                tmrHideLabels.Enabled = true;
            }
        }

        // Hide the controls.
        private void tmrHideLabels_Tick_1(object sender, EventArgs e)
        {
            foreach (Label lbl in AnimateLabels) lbl.Visible = false;
            tmrHideLabels.Enabled = false;
            btnAnimate.Enabled = true;
        }
    }
}
