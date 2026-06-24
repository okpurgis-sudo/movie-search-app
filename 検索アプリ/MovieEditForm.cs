using System;
using System.Windows.Forms;

namespace MovieSearchApp
{
    public partial class MovieEditForm : Form
    {
        public string MovieTitle => txtTitle.Text.Trim();

        public string ActorName => txtActorName.Text.Trim();

        public string Genre => txtGenre.Text.Trim();

        public string NicePoint => txtNicePoint.Text.Trim();

        public int Rating => (int)numRating.Value;

        public string Url => txtUrl.Text.Trim();

        public MovieEditForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("作品名を入力してください。");
                txtTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtActorName.Text))
            {
                MessageBox.Show("出演者名を入力してください。");
                txtActorName.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void SetMovieData(
            string title,
            string actorName,
            string genre,
            string nicePoint,
            int rating,
            string url)
        {
            txtTitle.Text = title;
            txtActorName.Text = actorName;
            txtGenre.Text = genre;
            txtNicePoint.Text = nicePoint;
            numRating.Value = Math.Clamp(rating, 1, 5);
            txtUrl.Text = url;
        }
    }
}