using System.Drawing;
using System.Windows.Forms;

namespace MovieSearchApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblTitle;

        private GroupBox grpSearch;
        private Label lblSearchTitle;
        private TextBox txtSearchTitle;
        private Label lblSearchActorName;
        private TextBox txtSearchActorName;
        private Label lblSearchGenre;
        private TextBox txtSearchGenre;
        private Label lblSearchNicePoint;
        private TextBox txtSearchNicePoint;
        private Button btnTrend;
        private Button btnMoodPick;

        private Button btnSearch;
        private Button btnClear;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvMovies;
        private RadioButton rbOrSearch;
        private RadioButton rbAndSearch;

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
            grpSearch = new GroupBox();
            lblSearchTitle = new Label();
            txtSearchTitle = new TextBox();
            lblSearchActorName = new Label();
            txtSearchActorName = new TextBox();
            lblSearchGenre = new Label();
            txtSearchGenre = new TextBox();
            lblSearchNicePoint = new Label();
            txtSearchNicePoint = new TextBox();
            btnSearch = new Button();
            btnMoodPick = new Button();
            btnClear = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnTrend = new Button();
            dgvMovies = new DataGridView();
            rbOrSearch = new RadioButton();
            rbAndSearch = new RadioButton();
            grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(246, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "作品・出演者検索ソフト";
            lblTitle.Click += lblTitle_Click;
            // 
            // grpSearch
            // 
            grpSearch.Controls.Add(lblSearchTitle);
            grpSearch.Controls.Add(txtSearchTitle);
            grpSearch.Controls.Add(lblSearchActorName);
            grpSearch.Controls.Add(txtSearchActorName);
            grpSearch.Controls.Add(lblSearchGenre);
            grpSearch.Controls.Add(txtSearchGenre);
            grpSearch.Controls.Add(lblSearchNicePoint);
            grpSearch.Controls.Add(txtSearchNicePoint);
            grpSearch.Controls.Add(rbOrSearch);
            grpSearch.Controls.Add(rbAndSearch);
            grpSearch.Font = new Font("Yu Gothic UI", 10F);
            grpSearch.Location = new Point(23, 70);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(950, 120);
            grpSearch.TabIndex = 1;
            grpSearch.TabStop = false;
            grpSearch.Text = "検索条件";
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.Location = new Point(20, 30);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(51, 19);
            lblSearchTitle.TabIndex = 0;
            lblSearchTitle.Text = "作品名";
            // 
            // txtSearchTitle
            // 
            txtSearchTitle.Location = new Point(95, 27);
            txtSearchTitle.Name = "txtSearchTitle";
            txtSearchTitle.Size = new Size(200, 25);
            txtSearchTitle.TabIndex = 1;
            // 
            // lblSearchActorName
            // 
            lblSearchActorName.AutoSize = true;
            lblSearchActorName.Location = new Point(320, 30);
            lblSearchActorName.Name = "lblSearchActorName";
            lblSearchActorName.Size = new Size(65, 19);
            lblSearchActorName.TabIndex = 2;
            lblSearchActorName.Text = "出演者名";
            // 
            // txtSearchActorName
            // 
            txtSearchActorName.Location = new Point(405, 27);
            txtSearchActorName.Name = "txtSearchActorName";
            txtSearchActorName.Size = new Size(200, 25);
            txtSearchActorName.TabIndex = 3;
            // 
            // lblSearchGenre
            // 
            lblSearchGenre.AutoSize = true;
            lblSearchGenre.Location = new Point(630, 30);
            lblSearchGenre.Name = "lblSearchGenre";
            lblSearchGenre.Size = new Size(52, 19);
            lblSearchGenre.TabIndex = 4;
            lblSearchGenre.Text = "ジャンル";
            // 
            // txtSearchGenre
            // 
            txtSearchGenre.Location = new Point(705, 27);
            txtSearchGenre.Name = "txtSearchGenre";
            txtSearchGenre.Size = new Size(200, 25);
            txtSearchGenre.TabIndex = 5;
            // 
            // lblSearchNicePoint
            // 
            lblSearchNicePoint.AutoSize = true;
            lblSearchNicePoint.Location = new Point(20, 70);
            lblSearchNicePoint.Name = "lblSearchNicePoint";
            lblSearchNicePoint.Size = new Size(111, 19);
            lblSearchNicePoint.TabIndex = 6;
            lblSearchNicePoint.Text = "僕的ナイスポイント";
            // 
            // txtSearchNicePoint
            // 
            txtSearchNicePoint.Location = new Point(155, 67);
            txtSearchNicePoint.Name = "txtSearchNicePoint";
            txtSearchNicePoint.Size = new Size(300, 25);
            txtSearchNicePoint.TabIndex = 7;



            rbOrSearch.AutoSize = true;
            rbOrSearch.Checked = true;
            rbOrSearch.Location = new Point(480, 68);
            rbOrSearch.Name = "rbOrSearch";
            rbOrSearch.Size = new Size(75, 23);
            rbOrSearch.TabIndex = 8;
            rbOrSearch.TabStop = true;
            rbOrSearch.Text = "OR検索";
            rbOrSearch.UseVisualStyleBackColor = true;

            rbAndSearch.AutoSize = true;
            rbAndSearch.Location = new Point(570, 68);
            rbAndSearch.Name = "rbAndSearch";
            rbAndSearch.Size = new Size(85, 23);
            rbAndSearch.TabIndex = 9;
            rbAndSearch.Text = "AND検索";
            rbAndSearch.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Yu Gothic UI", 10F);
            btnSearch.Location = new Point(23, 205);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(105, 35);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Yu Gothic UI", 10F);
            btnClear.Location = new Point(138, 205);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(105, 35);
            btnClear.TabIndex = 3;
            btnClear.Text = "条件クリア";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Yu Gothic UI", 10F);
            btnAdd.Location = new Point(298, 205);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(105, 35);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "新規登録";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Yu Gothic UI", 10F);
            btnEdit.Location = new Point(413, 205);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(105, 35);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "編集";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Yu Gothic UI", 10F);
            btnDelete.Location = new Point(528, 205);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(105, 35);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "削除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;


            btnTrend.Font = new Font("Yu Gothic UI", 10F);
            btnTrend.Location = new Point(643, 205);
            btnTrend.Name = "btnTrend";
            btnTrend.Size = new Size(105, 35);
            btnTrend.TabIndex = 8;
            btnTrend.Text = "傾向分析";
            btnTrend.UseVisualStyleBackColor = true;
            btnTrend.Click += btnTrend_Click;


            btnMoodPick.Font = new Font("Yu Gothic UI", 10F);
            btnMoodPick.Location = new Point(758, 205);
            btnMoodPick.Name = "btnMoodPick";
            btnMoodPick.Size = new Size(120, 35);
            btnMoodPick.TabIndex = 9;
            btnMoodPick.Text = "気分で選ぶ";
            btnMoodPick.UseVisualStyleBackColor = true;
            btnMoodPick.Click += btnMoodPick_Click;
            // 
            // dgvMovies
            // 
            dgvMovies.AllowUserToAddRows = false;
            dgvMovies.AllowUserToDeleteRows = false;
            dgvMovies.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMovies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovies.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgvMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovies.Location = new Point(23, 260);
            dgvMovies.MultiSelect = false;
            dgvMovies.Name = "dgvMovies";
            dgvMovies.ReadOnly = true;
            dgvMovies.RowHeadersVisible = false;
            dgvMovies.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvMovies.Size = new Size(950, 318);
            dgvMovies.TabIndex = 8;
            dgvMovies.CellClick += dgvMovies_CellClick;
            dgvMovies.ColumnHeaderMouseClick += dgvMovies_ColumnHeaderMouseClick;

            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(grpSearch);
            Controls.Add(lblTitle);
            Controls.Add(btnSearch);
            Controls.Add(btnClear);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(dgvMovies);
            Controls.Add(btnTrend);
            Controls.Add(btnMoodPick);
            MinimumSize = new Size(1000, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "作品・出演者検索ソフト";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMovies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}