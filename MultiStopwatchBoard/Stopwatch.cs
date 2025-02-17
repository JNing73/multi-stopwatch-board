using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiStopwatchBoard
{
    public class Stopwatch
    {
        private readonly StopwatchBoard _board;
        private int _elapsedTime;
        private Label _timeDisplay;
        private Button _toggleBtn;
        private Button _resetBtn;
        private bool _isRunning;
        private bool _oneActiveInstanceOfRunStopwatch;

        public Stopwatch(StopwatchBoard board)
        {
            _board = board;

            _elapsedTime = 0;
            _isRunning = false;

            // Stopwatch display 
            _timeDisplay = new Label();
            _timeDisplay.Text = "Ready";
            _timeDisplay.Location = new Point(10, _board.GetYPos());

            // Stopwatch operation button
            _toggleBtn = new Button();
            _toggleBtn.Text = "Start/Stop";
            _toggleBtn.Width = 120;
            _toggleBtn.Height = 30;
            _toggleBtn.Location = new Point(15 + _timeDisplay.Width, _board.GetYPos());
            _toggleBtn.Click += ToggleStopwatch;

            // Reset button
            _resetBtn = new Button();
            _resetBtn.Text = "Reset";
            _resetBtn.Width = 120;
            _resetBtn.Height = 30;
            _resetBtn.Location = new Point(15 + _timeDisplay.Width + 10 + _toggleBtn.Width, _board.GetYPos());

            _oneActiveInstanceOfRunStopwatch = false;

            // Add the stopwatch elements to the form
            board.Controls.Add(_timeDisplay);
            board.Controls.Add(_toggleBtn);
            board.Controls.Add(_resetBtn);
        }

        private async void ToggleStopwatch(object? sender, EventArgs e)
        {
            _isRunning = !_isRunning;
            
            UpdateToggleBtnText();
            if (_isRunning)
            {
                await RunStopwatch();
            }
        }

        private void UpdateToggleBtnText()
        {
            string toggleText = _isRunning ? "Pause" : "Continue";
            _toggleBtn.Text = toggleText;
        }

        private async Task RunStopwatch()
        {
            // If there is already one instance of this function running
            // prevent more from occuring
            if (_oneActiveInstanceOfRunStopwatch)
            {
                return;
            }
            while (_isRunning)
            {
                _oneActiveInstanceOfRunStopwatch = true;
                _timeDisplay.Text = _elapsedTime.ToString();
                await Task.Delay(1000);
                if (_isRunning)
                {
                    _elapsedTime += 1; // Add one second
                }
            }
            _oneActiveInstanceOfRunStopwatch = false;
            return;
        }
    }
}
