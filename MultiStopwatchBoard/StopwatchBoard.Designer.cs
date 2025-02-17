namespace MultiStopwatchBoard
{
    partial class StopwatchBoard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AddStopwatchBtn = new Button();
            SuspendLayout();
            // 
            // AddStopwatchBtn
            // 
            AddStopwatchBtn.Location = new Point(581, 56);
            AddStopwatchBtn.Name = "AddStopwatchBtn";
            AddStopwatchBtn.Size = new Size(174, 29);
            AddStopwatchBtn.TabIndex = 0;
            AddStopwatchBtn.Text = "Add Stopwatch";
            AddStopwatchBtn.UseVisualStyleBackColor = true;
            AddStopwatchBtn.Click += GenerateStopwatch;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddStopwatchBtn);
            Name = "StopwatchBoard";
            Text = "Stopwatch Board";
            ResumeLayout(false);
        }

        #endregion

        private Button AddStopwatchBtn;
    }
}
