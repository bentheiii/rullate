using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rulatte
{
    public partial class LaborControl : UserControl
    {
        public event LaborControlLaborChanged LaborChanged;
        private bool _disableChangeEvent = false;
        public double totalWeights { private get; set; }
        public Labor inner { get; }
        public LaborControl() : this(null) { }
        public LaborControl(Labor inner)
        {
            this.inner = inner;
            InitializeComponent();
        }
        public void sync()
        {
            _disableChangeEvent = true;

            enabledCheckBox.Checked = inner.enabled;
            weightNumericUpDown.Value = (decimal)inner.weight;
            laborNameLabel.Text = inner.name;
            if (totalWeights != 0)
                oddsLabel.Text = (inner.effectiveWeight / totalWeights).ToString("P1");
            linkLabel.Font = new Font(DefaultFont, inner.link == null ? FontStyle.Strikeout : FontStyle.Regular);

            _disableChangeEvent = false;
        }
        private void LaborControl_Load(object sender, EventArgs e)
        {
            sync();
        }
        private void informOfChange(LaborChange change)
        {
            LaborChanged.Invoke(this, new LaborChangedEventArgs(inner, change));
        }
        private void laborNameLabel_Click(object sender, EventArgs e)
        {
            var dialog = new TextInputForm{initialValue = laborNameLabel.Text, Text = "Choose new name"};
            if (dialog.ShowDialog(out string newName) == DialogResult.OK)
            {
                inner.name = newName;
                sync();
                informOfChange(LaborChange.NameChanged);
            }
        }

        private void enabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_disableChangeEvent)
                return;
            inner.enabled = enabledCheckBox.Checked;
            informOfChange(LaborChange.EnabledChanged);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            informOfChange(LaborChange.Remove);
        }

        public void LightOn(Color color)
        {
            BackColor = color;
        }
        public void LightOff()
        {
            BackColor = SystemColors.Control;
        }

        private void weightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_disableChangeEvent)
                return;
            inner.weight = (double)weightNumericUpDown.Value;
            informOfChange(LaborChange.WeightChanged);
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
            {
                var dialog = new TextInputForm { initialValue = inner.link, Text = "Choose new link" };
                if (dialog.ShowDialog(out string newLink) == DialogResult.OK)
                {
                    inner.link = newLink;
                    sync();
                    informOfChange(LaborChange.LinkChanged);
                }
            }
            else
            {
                if (inner.link == null)
                    return;
                System.Diagnostics.Process.Start(inner.link);
            }
        }
    }


    [Flags]
    public enum LaborChange { NameChanged = 1, EnabledChanged = 2, WeightChanged = 4, Remove = 8, LinkChanged = 16}
    public class LaborChangedEventArgs : EventArgs
    {
        public LaborChangedEventArgs(Labor labor, LaborChange change)
        {
            this.labor = labor;
            this.change = change;
        }
        public Labor labor { get; }
        public LaborChange change { get; }
    }
    public delegate void LaborControlLaborChanged(object sender, LaborChangedEventArgs args);
}
