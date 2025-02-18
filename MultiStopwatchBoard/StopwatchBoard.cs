namespace MultiStopwatchBoard
{
    public partial class StopwatchBoard : Form
    {
        private int _currentYPosition = 10; // y-pos for where stopwatch should appear
        private List<Stopwatch> _stopwatchesOnBoard = [];

        public StopwatchBoard()
        {
            InitializeComponent();
        }

        public int GetYPos()
        {
            return _currentYPosition;
        }

        // Lower the position for the next stopwatch
        private void UpdateYPos()
        {
            _currentYPosition += 50;
        }

        // Add a new stopwatch to the board
        private void GenerateStopwatch(object sender, EventArgs e)
        {
            _stopwatchesOnBoard.Add(new Stopwatch(this));
            UpdateYPos();
        }

        internal void RemoveStopwatch(Stopwatch stopwatch)
        {
            int stopwatchPos = _stopwatchesOnBoard.IndexOf(stopwatch);
            _stopwatchesOnBoard.Remove(stopwatch);

            for (int i = stopwatchPos; i < _stopwatchesOnBoard.Count; i++)
            {
                Stopwatch sw = _stopwatchesOnBoard[i];
                sw.Reposition(50);
            }

            RepositionYPos();
        }

        private void RepositionYPos()
        {
            _currentYPosition -= 50;
        }
    }
}
