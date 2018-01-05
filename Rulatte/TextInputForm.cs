using System.Windows.Forms;
using FormStone;

namespace Rulatte
{
    public partial class TextInputForm : ReturnForm<string>
    {
        public string initialValue
        {
            set
            {
                textBox.Text = value;
            }
        }
        public TextInputForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            Close(DialogResult.OK, textBox.Text);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close(DialogResult.Cancel);
        }
    }
}
