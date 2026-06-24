using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MovieSearchApp
{
    public class TrendForm : Form
    {
        private readonly DataGridView dgvActors;
        private readonly DataGridView dgvGenres;
        private readonly DataGridView dgvNicePoints;

        private readonly Label lblActors;
        private readonly Label lblGenres;
        private readonly Label lblNicePoints;

        private readonly Button btnClose;

        public TrendForm(
            List<FrequencyItem>? actorRanking,
            List<FrequencyItem>? genreRanking,
            List<FrequencyItem>? nicePointRanking)
        {
            Text = "傾向分析";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(1080, 520);
            MinimumSize = new Size(1080, 520);

            lblActors = new Label();
            lblGenres = new Label();
            lblNicePoints = new Label();

            dgvActors = new DataGridView();
            dgvGenres = new DataGridView();
            dgvNicePoints = new DataGridView();

            btnClose = new Button();

            InitializeLayout();

            dgvActors.AutoGenerateColumns = true;
            dgvGenres.AutoGenerateColumns = true;
            dgvNicePoints.AutoGenerateColumns = true;

            dgvActors.DataSource = actorRanking ?? new List<FrequencyItem>();
            dgvGenres.DataSource = genreRanking ?? new List<FrequencyItem>();
            dgvNicePoints.DataSource = nicePointRanking ?? new List<FrequencyItem>();

            FormatGrid(dgvActors);
            FormatGrid(dgvGenres);
            FormatGrid(dgvNicePoints);
        }

        private void InitializeLayout()
        {
            lblActors.AutoSize = true;
            lblActors.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            lblActors.Location = new Point(20, 20);
            lblActors.Text = "出演者 頻出ランキング";

            dgvActors.Location = new Point(20, 55);
            dgvActors.Size = new Size(320, 390);
            SetupGrid(dgvActors);

            lblGenres.AutoSize = true;
            lblGenres.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            lblGenres.Location = new Point(380, 20);
            lblGenres.Text = "ジャンル 頻出ランキング";

            dgvGenres.Location = new Point(380, 55);
            dgvGenres.Size = new Size(320, 390);
            SetupGrid(dgvGenres);

            lblNicePoints.AutoSize = true;
            lblNicePoints.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            lblNicePoints.Location = new Point(740, 20);
            lblNicePoints.Text = "ナイスポイント 頻出ランキング";

            dgvNicePoints.Location = new Point(740, 55);
            dgvNicePoints.Size = new Size(320, 390);
            SetupGrid(dgvNicePoints);

            btnClose.Text = "閉じる";
            btnClose.Font = new Font("Yu Gothic UI", 10F);
            btnClose.Location = new Point(965, 465);
            btnClose.Size = new Size(95, 32);
            btnClose.Click += btnClose_Click;

            Controls.Add(lblActors);
            Controls.Add(dgvActors);
            Controls.Add(lblGenres);
            Controls.Add(dgvGenres);
            Controls.Add(lblNicePoints);
            Controls.Add(dgvNicePoints);
            Controls.Add(btnClose);
        }

        private void SetupGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormatGrid(DataGridView grid)
        {
            if (grid == null)
            {
                return;
            }

            grid.AutoGenerateColumns = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var wordColumn = grid.Columns["Word"];
            if (wordColumn != null)
            {
                wordColumn.HeaderText = "項目";
                wordColumn.FillWeight = 80;
            }

            var countColumn = grid.Columns["Count"];
            if (countColumn != null)
            {
                countColumn.HeaderText = "回数";
                countColumn.FillWeight = 20;
            }
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}