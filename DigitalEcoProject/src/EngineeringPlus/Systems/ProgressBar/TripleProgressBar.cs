namespace Eco.Mods.TextUI
{
    using System;
    using System.ComponentModel;
    using System.Text;
    using Eco.Core.Controller;
    using Eco.Core.Systems;
    using Eco.Gameplay.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Logging;
    using Eco.Shared.Networking;
    using Eco.Shared.Serialization;

    [Serialized]
    public class TripleProgressBar : IController, INotifyPropertyChanged
    {
        [Serialized] const char PROGRESS_STATE_CHAR = '█';
        [Serialized] private string backgroundColor = "white";
        [Serialized] private string fillAColor = "blue";
        [Serialized] private string fillBColor = "yellow";
        [Serialized] private string fillMainColor = "green";
        [Serialized] public int Length { get; set; } = 100;
        [Serialized] public string HeaderA { get; set; } = "";
        [Serialized] public string HeaderB { get; set; } = "";
        [Serialized] public string HeaderMain { get; set; } = "";

        [Eco, PropReadOnly, UITypeName("StringPlaque")]
        public string Progress { get; set; } = string.Empty;

        // Serialization Purposes
        public TripleProgressBar() { }

        public TripleProgressBar(string headerA, string headerB, string headerMain, int barLength = 100, string backgroundColor = "white", string fillAColor = "blue", string fillBColor = "yellow", string fillMainColor = "green")
        {
            this.HeaderA = headerA;
            this.HeaderB = headerB;
            this.HeaderMain = headerMain;
            this.Reset(barLength, backgroundColor, fillAColor, fillBColor, fillMainColor);
        }

        public void Update(double percentA, double percentB, double percentMain)
        {
            percentA = Math.Clamp(percentA, 0, 1);
            percentB = Math.Clamp(percentB, 0, 1);
            percentMain = Math.Clamp(percentMain, 0, 1);

            var startA = (int)Math.Round(percentA * (double)this.Length);
            var startB = (int)Math.Round(percentB * (double)this.Length);
            var startMain = (int)Math.Round(percentMain * (double)this.Length);

            StringBuilder progress = new();

            progress.AppendLoc($"<align=left>{this.HeaderMain} {percentMain:0%}</align>\n");

            progress.AppendLoc($"<align=left><color={this.fillMainColor}>");
            for (int i = 0; i < startMain; i++)
            {
                progress.Append(PROGRESS_STATE_CHAR);
            }
            progress.AppendLoc($"</color><color={this.fillAColor}>");
            for (int i = startMain; i < startA; i++)
            {
                progress.Append(PROGRESS_STATE_CHAR);
            }
            progress.AppendLoc($"</color><color={this.backgroundColor}>");
            for (int i = startA; i < this.Length; i++)
            {
                progress.Append(PROGRESS_STATE_CHAR);
            }
            progress.AppendLoc($"</color> {percentA:0%} {this.HeaderA}</align>");

            progress.Append("\n");

            progress.AppendLoc($"<align=left><color={this.fillMainColor}>");
            for (int i = 0; i < startMain; i++)
            {
                progress.Append(PROGRESS_STATE_CHAR);
            }
            progress.AppendLoc($"</color><color={this.fillBColor}>");
            for (int i = startMain; i < startB; i++)
            {
                progress.Append(PROGRESS_STATE_CHAR);
            }
            progress.AppendLoc($"</color><color={this.backgroundColor}>");
            for (int i = startB; i < this.Length; i++)
            {
                progress.Append(PROGRESS_STATE_CHAR);
            }
            progress.AppendLoc($"</color> {percentB:0%} {this.HeaderB}</align>");

            this.Progress = progress.ToString();
            this.Changed(nameof(this.Progress));
        }

        public void Reset(int barLength = 100, string backgroundColor = "white", string fillAColor = "blue", string fillBColor = "yellow", string fillMainColor = "green")
        {
            this.Length = barLength;
            this.backgroundColor = backgroundColor;
            this.fillAColor = fillAColor;
            this.fillBColor = fillBColor;
            this.fillMainColor = fillMainColor;
            this.Update(0, 0, 0);
        }

        #region IController
        private int controllerID;
        ref int IHasUniversalID.ControllerID => ref this.controllerID;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}