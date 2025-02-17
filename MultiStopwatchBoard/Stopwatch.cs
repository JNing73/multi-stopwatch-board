using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiStopwatchBoard
{
    public class Stopwatch
    {
        private Form form;
        private int elapsedTime;
        private Label timeDisplay;
        private Button toggleBtn;

        public Stopwatch(StopwatchBoard parentForm)
        {
            this.form = parentForm;

            elapsedTime = 0;

            // Stopwatch display 
            timeDisplay = new Label();
            timeDisplay.Text = "Ready";
            timeDisplay.Location = new Point(10, parentForm.GetYPos());

            // Stopwatch operation button
            toggleBtn = new Button();
            toggleBtn.Text = "Start/Stop";
            toggleBtn.Width = 120;
            toggleBtn.Height = 30;
            toggleBtn.Location = new Point(15 + timeDisplay.Width, parentForm.GetYPos());

            // Add the stopwatch elements to the form
            form.Controls.Add(timeDisplay);
            form.Controls.Add(toggleBtn);
        }
    }
}
