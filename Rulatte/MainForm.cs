using System;
using System.Windows.Forms;
using FormStone;

namespace Rulatte
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            profileSelect1.Returned += ProfileSelectOnReturned;
            profileSelect1.saveDiage = saveFileDialog1;
        }
        private void ProfileSelectOnReturned(object sender, ReturnControlReturnedEventArgs<Profile> eventArgs)
        {
            var profile = eventArgs.data;
            Properties.Settings.Default.RecentProfile = profile.sourcePath;
            Properties.Settings.Default.Save();

            Controls.Remove(profileSelect1);

            var roller = new RollerControl{saveDialog = saveFileDialog1, profile = profile, Dock = DockStyle.Fill};

            Controls.Add(roller);
        }
        public void LoadPath(string s)
        {
            profileSelect1.SetPath(s);
        }
    }
}
