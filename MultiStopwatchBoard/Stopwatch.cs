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
        private Label _timeDisplay;
        private Button _toggleBtn;
        private Button _resetBtn;
        private Button _deleteBtn;
        private bool _isRunning;
        private bool _oneActiveInstanceOfRunStopwatch;
        private System.Diagnostics.Stopwatch _stopwatch = new();

        private List<System.Windows.Forms.Control> _frontEndElements = [];

        public Stopwatch(StopwatchBoard board)
        {
            _board = board;

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
            _resetBtn.Click += ResetStopwatch;

            // Delete button
            _deleteBtn = new Button();
            _deleteBtn.Text = "Remove";
            _deleteBtn.Width = 120;
            _deleteBtn.Height = 30;
            _deleteBtn.Location = new Point(15 + _timeDisplay.Width + 10 + _toggleBtn.Width + 10 + _resetBtn.Width, _board.GetYPos());
            _deleteBtn.Click += DeleteStopwatch;

            _oneActiveInstanceOfRunStopwatch = false;

            _frontEndElements.Add(_timeDisplay);
            _frontEndElements.Add(_toggleBtn);
            _frontEndElements.Add(_resetBtn);
            _frontEndElements.Add(_deleteBtn);

            foreach (var frontEndElement in _frontEndElements)
            {
                _board.Controls.Add(frontEndElement);
            }
        }

        private void DeleteStopwatch(object? sender, EventArgs e)
        {
            _isRunning = false;

            foreach (var frontEndElement in _frontEndElements)
            {
                _board.Controls.Remove(frontEndElement);
            }

            _board.RemoveStopwatch(this);
        }

        private void ResetStopwatch(object? sender, EventArgs e)
        {
            _isRunning = false;

            _stopwatch.Reset();
            _timeDisplay.Text = "Ready";
            _toggleBtn.Text = "Start/Stop";
        }

        private async void ToggleStopwatch(object? sender, EventArgs e)
        {
            _isRunning = !_isRunning;

            UpdateToggleBtnText();
            if (_isRunning)
            {
                _stopwatch.Start();
                await RunStopwatch();
            }
            else
            {
                _stopwatch.Stop();
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
            _oneActiveInstanceOfRunStopwatch = true;
            while (_isRunning)
            {
                _timeDisplay.Text = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
                await Task.Delay(100);
            }
            _oneActiveInstanceOfRunStopwatch = false;
        }

        internal async void Reposition(int verticalAdjustment)
        {
            int increment = 2;

            for (int totalAdjustment = 0; totalAdjustment < verticalAdjustment; totalAdjustment += increment)
            {
                foreach (var frontEndElement in _frontEndElements)
                {
                    frontEndElement.Top -= increment;
                }

                await Task.Delay(1);
            }
        }
    }
}
