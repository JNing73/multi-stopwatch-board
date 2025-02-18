namespace MultiStopwatchBoard
{
    public partial class StopwatchBoard : Form
    {
        private int currentYPosition = 10; // y-pos for where stopwatch should appear
        private List<Stopwatch> _stopwatchesOnBoard = [];

        public StopwatchBoard()
        {
            InitializeComponent();
        }

        public int GetYPos()
        {
            return currentYPosition;
        }

        // Lower the position for the next stopwatch
        private void UpdateYPos()
        {
            currentYPosition += 50;
        }

        // Add a new stopwatch to the board
        private void GenerateStopwatch(object sender, EventArgs e)
        {
            _stopwatchesOnBoard.Add(new Stopwatch(this));
            UpdateYPos();
        }

        internal void RemoveStopwatch(Stopwatch stopwatch)
        {
            _stopwatchesOnBoard.Remove(stopwatch);
        }
    }
}
