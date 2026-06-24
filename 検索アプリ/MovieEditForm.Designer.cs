using System.Drawing;
using System.Windows.Forms;

namespace MovieSearchApp
{
    partial class MovieEditForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblActorName;
        private TextBox txtActorName;
        private Label lblGenre;
        private TextBox txtGenre;
        private Label lblNicePoint;
        private TextBox txtNicePoint;
        private Label lblRating;
        private NumericUpDown numRating;
        private Label lblUrl;
        private TextBox txtUrl;
        private Button btnSave;
        private Button btnCancel;
        private Button btnTrend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblActorName = new Label();
            txtActorName = new TextBox();
            lblGenre = new Label();
            txtGenre = new TextBox();
            lblNicePoint = new Label();
            txtNicePoint = new TextBox();
            lblRating = new Label();
            numRating = new NumericUpDown();
            lblUrl = new Label();
            txtUrl = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            btnTrend = new Button();

            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            SuspendLayout();

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Yu Gothic UI", 10F);
            lblTitle.Location = new Point(24, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(51, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "作品名";

            txtTitle.Font = new Font("Yu Gothic UI", 10F);
            txtTitle.Location = new Point(145, 21);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(360, 25);
            txtTitle.TabIndex = 1;

            lblActorName.AutoSize = true;
            lblActorName.Font = new Font("Yu Gothic UI", 10F);
            lblActorName.Location = new Point(24, 65);
            lblActorName.Name = "lblActorName";
            lblActorName.Size = new Size(65, 19);
            lblActorName.TabIndex = 2;
            lblActorName.Text = "出演者名";

            txtActorName.Font = new Font("Yu Gothic UI", 10F);
            txtActorName.Location = new Point(145, 62);
            txtActorName.Name = "txtActorName";
            txtActorName.Size = new Size(360, 25);
            txtActorName.TabIndex = 3;

            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Yu Gothic UI", 10F);
            lblGenre.Location = new Point(24, 106);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(55, 19);
            lblGenre.TabIndex = 4;
            lblGenre.Text = "ジャンル";

            txtGenre.Font = new Font("Yu Gothic UI", 10F);
            txtGenre.Location = new Point(145, 103);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(360, 25);
            txtGenre.TabIndex = 5;

            lblNicePoint.AutoSize = true;
            lblNicePoint.Font = new Font("Yu Gothic UI", 10F);
            lblNicePoint.Location = new Point(24, 150);
            lblNicePoint.Name = "lblNicePoint";
            lblNicePoint.Size = new Size(122, 19);
            lblNicePoint.TabIndex = 6;
            lblNicePoint.Text = "僕的ナイスポイント";

            txtNicePoint.Font = new Font("Yu Gothic UI", 10F);
            txtNicePoint.Location = new Point(145, 147);
            txtNicePoint.Multiline = true;
            txtNicePoint.Name = "txtNicePoint";
            txtNicePoint.ScrollBars = ScrollBars.Vertical;
            txtNicePoint.Size = new Size(360, 80);
            txtNicePoint.TabIndex = 7;

            lblRating.AutoSize = true;
            lblRating.Font = new Font("Yu Gothic UI", 10F);
            lblRating.Location = new Point(24, 246);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(37, 19);
            lblRating.TabIndex = 8;
            lblRating.Text = "評価";

            numRating.Font = new Font("Yu Gothic UI", 10F);
            numRating.Location = new Point(145, 244);
            numRating.Maximum = 5;
            numRating.Minimum = 1;
            numRating.Name = "numRating";
            numRating.Size = new Size(80, 25);
            numRating.TabIndex = 9;
            numRating.Value = 3;

            lblUrl.AutoSize = true;
            lblUrl.Font = new Font("Yu Gothic UI", 10F);
            lblUrl.Location = new Point(24, 292);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(32, 19);
            lblUrl.TabIndex = 10;
            lblUrl.Text = "URL";

            txtUrl.Font = new Font("Yu Gothic UI", 10F);
            txtUrl.Location = new Point(145, 289);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(360, 25);
            txtUrl.TabIndex = 11;

            btnSave.Font = new Font("Yu Gothic UI", 10F);
            btnSave.Location = new Point(299, 340);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(95, 32);
            btnSave.TabIndex = 12;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            btnCancel.Font = new Font("Yu Gothic UI", 10F);
            btnCancel.Location = new Point(410, 340);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(95, 32);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "キャンセル";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 395);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblActorName);
            Controls.Add(txtActorName);
            Controls.Add(lblGenre);
            Controls.Add(txtGenre);
            Controls.Add(lblNicePoint);
            Controls.Add(txtNicePoint);
            Controls.Add(lblRating);
            Controls.Add(numRating);
            Controls.Add(lblUrl);
            Controls.Add(txtUrl);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MovieEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "作品データ";

            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
