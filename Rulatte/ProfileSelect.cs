using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using FormStone;
using Newtonsoft.Json;

namespace Rulatte
{
    public partial class ProfileSelect : ReturnControl<Profile>
    {
        [Browsable(false)]
        public SaveFileDialog saveDiage { get; set; }
        public ProfileSelect()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (saveDiage.ShowDialog(this) == DialogResult.OK)
            {
                pathTextBox.Text = saveDiage.FileName;
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var read = new FileStream(pathTextBox.Text, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan))
                {
                    var ret = Profile.Formatter.Deserialize(read);
                    ret.sourcePath = pathTextBox.Text;
                    Return(ret);
                }
            }
            catch (IOException ex)
            {
                ErrorLabel.Text = ex.Message;
            }
            catch (JsonException ex)
            {
                ErrorLabel.Text = ex.Message;
            }
        }

        private void NewProfileButton_Click(object sender, EventArgs e)
        {
            var path = pathTextBox.Text;
            var name = Path.GetFileNameWithoutExtension(path);

            var ret = new Profile(name,path);
            bool ok = false;
            try
            {
                using (var write = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
                {
                    Profile.Formatter.Serialize(ret,write);
                }
                ok = true;
            }
            catch (IOException ex)
            {
                ErrorLabel.Text = ex.Message;
            }
            catch (JsonException ex)
            {
                ErrorLabel.Text = ex.Message;
            }
            if (ok)
                Return(ret);
        }

        private void ProfileSelect_Load(object sender, EventArgs e)
        {
            pathTextBox.Text = Properties.Settings.Default.RecentProfile;
        }
        public void SetPath(string s)
        {
            pathTextBox.Text = s;
        }
    }
}
