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
    public class ProgressBar : IController, INotifyPropertyChanged
    {
        const char PROGRESS_STATE_CHAR = '█';
        [Serialized]
        private string defaultColor = "white";
        [Serialized]
        private string fillColor = "green";

        [Serialized]
        public int Length { get; set; } = 100;

        [Serialized]
        public string Header { get; set; } = "";

        [Eco, PropReadOnly, UITypeName("StringDisplay")]
        public string Progress { get; set; } = string.Empty;

        // Serialization Purposes
        public ProgressBar() { }

        public ProgressBar(string header, int barLength = 100, string defaultColor = "white", string fillColor = "green")
        {
            this.Header = header;
            this.Reset(barLength, defaultColor, fillColor);
        }

        public void Update(int value, int length)
        {
            var percent = (double)value / (double)length;
            this.Update(percent, "");
        }

        public void Update(double percent, string extraInfo)
        {
            if (percent > 1) { percent  = 1; }
            else if (percent < 0) {  percent = 0; }

            var current = percent * (double)this.Length;
            var start = (int)Math.Round(current);
            StringBuilder progress = new();
            progress.AppendLoc($"<align=left>{this.Header}  ");
            progress.AppendLoc($"<color={this.fillColor}>");
            for (int i = 0; i < start; i++)
            {
                progress.Append(PROGRESS_STATE_CHAR);
            }
            progress.AppendLoc($"</color><color={this.defaultColor}>");
            for (int i = start; i < this.Length; i++)
            {
                progress.Append(PROGRESS_STATE_CHAR);
            }
            progress.AppendLoc($"</color> {percent:0%}</align>\n{extraInfo}");
            this.Progress = progress.ToString();
            this.Changed(nameof(this.Progress));
        }

        public void Reset(int barLength, string defaultColor = "white", string fillColor = "green")
        {
            this.Length = barLength;
            this.defaultColor = defaultColor;
            this.fillColor = fillColor;
            StringBuilder progress = new();
            progress.AppendLoc($"<align=left>{this.Header}");
            progress.AppendLoc($"<color={this.defaultColor}>");
            for (int i = 0; i < this.Length; i++)
            {
                progress.Append(PROGRESS_STATE_CHAR);
            }
            progress.AppendLoc($"</color> 0%</align>");
            this.Progress = progress.ToString();
            this.Changed(nameof(this.Progress));
        }

        #region IController
        private int controllerID;
        ref int IHasUniversalID.ControllerID => ref this.controllerID;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}