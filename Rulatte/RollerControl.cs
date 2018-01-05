using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WhetStone.Looping;

namespace Rulatte
{
    public partial class RollerControl : UserControl
    {
        public Profile profile { get; set; }
        public SaveFileDialog saveDialog { get; set; }
        private readonly IDictionary<Labor, LaborControl> _controlDict = new Dictionary<Labor, LaborControl>();
        public RollerControl()
        {
            InitializeComponent();
        }
        private Control wrap(Labor l)
        {
            var ret = new LaborControl(l);
            _controlDict[l] = ret;
            ret.LaborChanged += OnLaborChanged;
            return ret;
        }
        private void RollerControl_Load(object sender, EventArgs e)
        {
            ProfileNameLinkLabel.Text = profile.name;
            laborListFlowLayoutPanel.Controls.Clear();

            var controls = Enumerable.Select(profile.labors, wrap).ToArray();

            laborListFlowLayoutPanel.Controls.AddRange(controls);

            this.ParentForm.Closed += (o, args) => profile.save();
        }
        private void resetSaveTimer()
        {
            saveTimer.Stop();
            saveTimer.Start();
        }
        private void OnLaborChanged(object sender, LaborChangedEventArgs args)
        {
            switch (args.change)
            {
                case LaborChange.Remove:
                    profile.labors.Remove(args.labor);
                    _controlDict.Remove(args.labor);
                    laborListFlowLayoutPanel.Controls.Remove((Control)sender);
                    break;
                default:
                    break;
            }
            resetSaveTimer();
        }

        private void saveTimer_Tick(object sender, EventArgs e)
        {
            saveTimer.Stop();
            profile.save();
        }

        private void ProfileNameLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dialog = new TextInputForm { initialValue = ProfileNameLinkLabel.Text, Text = "Choose new name" };
            if (dialog.ShowDialog(out string newName) == DialogResult.OK)
            {
                profile.name = newName;
                ProfileNameLinkLabel.Text = profile.name;
            }
            resetSaveTimer();
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            saveTimer.Stop();
            profile.save();
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                profile.sourcePath = saveDialog.FileName;
                profile.save();
            }
        }

        private void newLaborButton_Click(object sender, EventArgs e)
        {
            var newLabor = new Labor("???");
            profile.labors.Add(newLabor);

            var cont = wrap(newLabor);
            laborListFlowLayoutPanel.Controls.Add(cont);

            resetSaveTimer();
        }

        private void rollButton_Click(object sender, EventArgs e)
        {
            foreach (var control in _controlDict.Values)
            {
                control.LightOff();
            }
            var roller = new Roller(this);
            if (!roller.picker.candidates.Any())
                return;
            Thread t = new Thread(roller.Do);
            t.Start();
        }

        public LaborControl GetControl(Labor l)
        {
            return _controlDict[l];
        }
    }
    public class Roller
    {
        public Roller(RollerControl owner, LaborPicker picker = null, int rolls = 15, TimeSpan lightTime = default(TimeSpan), Color lightColor = default(Color), Color pickedColor = default(Color))
        {
            this.owner = owner;
            this.picker = picker ?? new LaborPicker(owner.profile);
            this.rolls = rolls;
            this.lightTime = lightTime.Ticks == 0 ? new TimeSpan(0, 0, 0, 0, 200) : lightTime;
            this.lightColor = lightColor.IsEmpty ? Color.Beige : lightColor;
            this.pickedColor = pickedColor.IsEmpty ? Color.GreenYellow : pickedColor;
        }
        public LaborPicker picker { get; }
        public RollerControl owner { get; }
        public int rolls { get; }
        public TimeSpan lightTime { get; }
        public Color lightColor { get; }
        public Color pickedColor { get; }

        public (Labor labor, double weight) light(Color light, (Labor labor, double weight) prev = default((Labor labor, double weight)), bool darken = true)
        {
            var (labor,w) = picker.pick(prev);
            var control = owner.GetControl(labor);
            control.Invoke((Action)(() => control.LightOn(light)));
            if (darken)
            {
                Thread.Sleep(lightTime);
                control.Invoke((Action)(() => control.LightOff()));
            }
            return (labor,w);
        }
        public void Do()
        {
            (Labor labor, double weight) prev = (null, 0);
            foreach (var _ in range.Range(rolls-1))
            {
                prev = light(lightColor, prev);
            }
            light(pickedColor, darken:false);
        }
    }
}