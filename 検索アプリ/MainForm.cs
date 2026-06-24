using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MovieSearchApp
{
    public partial class MainForm : Form
    {
        private readonly MovieRepository _repository = new MovieRepository();
        private List<Movie> _currentMovies = new List<Movie>();
        private string _sortColumnName = "";
        private bool _sortAscending = true;
        private readonly Random _random = new Random();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _repository.InitializeDatabase();
            LoadAllMovies();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var movies = _repository.Search(
                txtSearchTitle.Text.Trim(),
                txtSearchActorName.Text.Trim(),
                txtSearchGenre.Text.Trim(),
                txtSearchNicePoint.Text.Trim(),
                rbAndSearch.Checked
            );

            DisplayMovies(movies);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearchConditions();
            LoadAllMovies();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new MovieEditForm())
            {
                form.Text = "新規登録";

                if (form.ShowDialog() == DialogResult.OK)
                {
                    var movie = new Movie
                    {
                        Title = form.MovieTitle,
                        ActorName = form.ActorName,
                        Genre = form.Genre,
                        NicePoint = form.NicePoint,
                        Rating = form.Rating,
                        Url = form.Url
                    };

                    _repository.Add(movie);
                    LoadAllMovies();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedMovie = GetSelectedMovie();

            if (selectedMovie == null)
            {
                MessageBox.Show("編集する行を選択してください。");
                return;
            }

            using (var form = new MovieEditForm())
            {
                form.Text = "編集";

                form.SetMovieData(
                    selectedMovie.Title,
                    selectedMovie.ActorName,
                    selectedMovie.Genre,
                    selectedMovie.NicePoint,
                    selectedMovie.Rating,
                    selectedMovie.Url
                );

                if (form.ShowDialog() == DialogResult.OK)
                {
                    selectedMovie.Title = form.MovieTitle;
                    selectedMovie.ActorName = form.ActorName;
                    selectedMovie.Genre = form.Genre;
                    selectedMovie.NicePoint = form.NicePoint;
                    selectedMovie.Rating = form.Rating;
                    selectedMovie.Url = form.Url;

                    _repository.Update(selectedMovie);
                    LoadAllMovies();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedMovie = GetSelectedMovie();

            if (selectedMovie == null)
            {
                MessageBox.Show("削除する行を選択してください。");
                return;
            }

            var result = MessageBox.Show(
                $"「{selectedMovie.Title} / {selectedMovie.ActorName}」を削除しますか？",
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                _repository.Delete(selectedMovie.Id);
                LoadAllMovies();
            }
        }

        private void dgvMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            var value = dgvMovies.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

            if (!string.IsNullOrEmpty(value))
            {
                Clipboard.SetText(value);
            }
        }

        private void dgvMovies_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {
                return;
            }

            var columnName = dgvMovies.Columns[e.ColumnIndex].Name;

            if (string.IsNullOrWhiteSpace(columnName) || columnName == "Id")
            {
                return;
            }

            if (_sortColumnName == columnName)
            {
                _sortAscending = !_sortAscending;
            }
            else
            {
                _sortColumnName = columnName;
                _sortAscending = true;
            }

            SortCurrentMovies(columnName, _sortAscending);
        }

        private void SortCurrentMovies(string columnName, bool ascending)
        {
            IEnumerable<Movie> sortedMovies;

            switch (columnName)
            {
                case "Title":
                    sortedMovies = ascending
                        ? _currentMovies.OrderBy(movie => movie.Title)
                        : _currentMovies.OrderByDescending(movie => movie.Title);
                    break;

                case "ActorName":
                    sortedMovies = ascending
                        ? _currentMovies.OrderBy(movie => movie.ActorName)
                        : _currentMovies.OrderByDescending(movie => movie.ActorName);
                    break;

                case "Genre":
                    sortedMovies = ascending
                        ? _currentMovies.OrderBy(movie => movie.Genre)
                        : _currentMovies.OrderByDescending(movie => movie.Genre);
                    break;

                case "NicePoint":
                    sortedMovies = ascending
                        ? _currentMovies.OrderBy(movie => movie.NicePoint)
                        : _currentMovies.OrderByDescending(movie => movie.NicePoint);
                    break;

                case "Rating":
                    sortedMovies = ascending
                        ? _currentMovies.OrderBy(movie => movie.Rating)
                        : _currentMovies.OrderByDescending(movie => movie.Rating);
                    break;

                case "Url":
                    sortedMovies = ascending
                        ? _currentMovies.OrderBy(movie => movie.Url)
                        : _currentMovies.OrderByDescending(movie => movie.Url);
                    break;

                default:
                    return;
            }

            _currentMovies = sortedMovies.ToList();

            dgvMovies.DataSource = null;
            dgvMovies.DataSource = _currentMovies;

            DisplayMovies(_currentMovies);
        }

        private void btnTrend_Click(object sender, EventArgs e)
        {
            var actorRanking = _repository.GetActorRanking();
            var genreRanking = _repository.GetGenreRanking();
            var nicePointRanking = _repository.GetNicePointRanking();

            using (var form = new TrendForm(actorRanking, genreRanking, nicePointRanking))
            {
                form.ShowDialog();
            }
        }

        private void btnMoodPick_Click(object sender, EventArgs e)
        {
            var actorName = txtSearchActorName.Text.Trim();
            var genre = txtSearchGenre.Text.Trim();
            var nicePoint = txtSearchNicePoint.Text.Trim();

            if (string.IsNullOrWhiteSpace(actorName)
                && string.IsNullOrWhiteSpace(genre)
                && string.IsNullOrWhiteSpace(nicePoint))
            {
                MessageBox.Show(
                    "出演者名・ジャンル・僕的ナイスポイントのどれかを入力してください。",
                    "気分で選ぶ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            var movies = _repository.Search(
                "",
                actorName,
                genre,
                nicePoint,
                rbAndSearch.Checked
            );

            if (movies.Count == 0)
            {
                MessageBox.Show(
                    "条件に合う作品が見つかりませんでした。",
                    "気分で選ぶ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DisplayMovies(new List<Movie>());
                return;
            }

            var selectedMovie = movies[_random.Next(movies.Count)];

            DisplayMovies(new List<Movie> { selectedMovie });
        }

        private void LoadAllMovies()
        {
            var movies = _repository.GetAll();
            DisplayMovies(movies);
        }

        private void DisplayMovies(List<Movie> movies)
        {
            _currentMovies = movies;

            dgvMovies.DataSource = null;
            dgvMovies.DataSource = _currentMovies;

            if (dgvMovies.Columns["Id"] != null)
            {
                dgvMovies.Columns["Id"].Visible = false;
            }

            if (dgvMovies.Columns["Title"] != null)
            {
                dgvMovies.Columns["Title"].HeaderText = "作品名";
            }

            if (dgvMovies.Columns["ActorName"] != null)
            {
                dgvMovies.Columns["ActorName"].HeaderText = "出演者名";
            }

            if (dgvMovies.Columns["Genre"] != null)
            {
                dgvMovies.Columns["Genre"].HeaderText = "ジャンル";
            }

            if (dgvMovies.Columns["NicePoint"] != null)
            {
                dgvMovies.Columns["NicePoint"].HeaderText = "僕的ナイスポイント";
            }

            if (dgvMovies.Columns["Rating"] != null)
            {
                dgvMovies.Columns["Rating"].HeaderText = "評価";
            }

            if (dgvMovies.Columns["Url"] != null)
            {
                dgvMovies.Columns["Url"].HeaderText = "URL";
            }
        }

        private void ClearSearchConditions()
        {
            txtSearchTitle.Clear();
            txtSearchActorName.Clear();
            txtSearchGenre.Clear();
            txtSearchNicePoint.Clear();
        }

        private Movie? GetSelectedMovie()
        {
            if (dgvMovies.CurrentRow == null)
            {
                return null;
            }

            return dgvMovies.CurrentRow.DataBoundItem as Movie;
        }

        private void lblSearchRating_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}