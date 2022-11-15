namespace SolutionCreatorApp
{
    public partial class TextEdit : Form
    {
        public TextEdit(string text)
        {
            InitializeComponent();
            this.text_txt.Text = text;
        }

        public string EditorText => this.text_txt.Text;

        private void ok_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
