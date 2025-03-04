using System.ComponentModel;

namespace GameLauncher
{
    public partial class DetailsForm : Form
    {
        private readonly Game? game;

        public DetailsForm(Game? game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {
            selectLauncherDialog.InitialDirectory = Path.GetPathRoot(Environment.SystemDirectory);
            selectGameDialog.InitialDirectory = Path.GetPathRoot(Environment.SystemDirectory);
            if (game != null)
            {
                Text = "Edit Game";
                gameNameTextBox.Text = game.Name;
                processNameTextBox.Text = game.ProcessName;
                launcherExecutableTextBox.Text = game.LauncherExecutable;
                gameExecutableTextBox.Text += game.GameExecutable;
                gridPictureBox.ImageLocation = game.GridPath;
                heroPictureBox.ImageLocation = game.HeroPath;
                logoPictureBox.ImageLocation = game.LogoPath;
                deleteButton.Visible = true;
            }
        }

        private void gridPictureBox_Click(object sender, EventArgs e)
        {
            new ImageDownloaderForm(gameNameTextBox.Text, ImageType.GRID, gridPictureBox).ShowDialog(this);
        }

        private void heroPictureBox_Click(object sender, EventArgs e)
        {
            new ImageDownloaderForm(gameNameTextBox.Text, ImageType.HERO, heroPictureBox).ShowDialog(this);
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {
            new ImageDownloaderForm(gameNameTextBox.Text, ImageType.LOGO, logoPictureBox).ShowDialog(this);
        }

        private void launcherPathTextBox_Click(object sender, EventArgs e)
        {
            ShowSelectDialog(selectLauncherDialog, game?.LauncherExecutable);
        }

        private void CancelKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void gamePathText_Click(object sender, EventArgs e)
        {
            ShowSelectDialog(selectGameDialog, game?.GameExecutable);
        }

        private async void ShowSelectDialog(OpenFileDialog dialog, string? path)
        {
            await Task.Run(() =>
            {
                if (path != null)
                {
                    dialog.InitialDirectory = Path.GetDirectoryName(path);
                }
                dialog.ShowDialog(this);
            });
        }

        private void selectLauncherDialog_FileOk(object sender, CancelEventArgs e)
        {
            launcherExecutableTextBox.Text = selectLauncherDialog.FileName;
        }

        private void selectGameDialog_FileOk(object sender, CancelEventArgs e)
        {
            gameExecutableTextBox.Text = selectGameDialog.FileName;
        }

        private void gameExecutableTextBox_TextChanged(object sender, EventArgs e)
        {
            if (game == null)
            {
                processNameTextBox.Text = Path.GetFileName(gameExecutableTextBox.Text);
            }
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            if (!IsUserLoggedIn()) return;

            bool error = AnyEmpty(gameNameTextBox, launcherExecutableTextBox, processNameTextBox, gameExecutableTextBox);
            if (error)
            {
                MessageBox.Show(this, "All fields must be filled!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Game game = new(gameNameTextBox.Text, launcherExecutableTextBox.Text, gameExecutableTextBox.Text,
                processNameTextBox.Text, heroPictureBox.ImageLocation, gridPictureBox.ImageLocation, logoPictureBox.ImageLocation);

            await StorageManager.Save(game);
            MessageBox.Show(this, game == null ? "Game saved!" : "Game updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private static bool AnyEmpty(params TextBox[] textBoxes)
        {
            foreach (var box in textBoxes)
            {
                if (box.Text.Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (IsUserLoggedIn() && game != null)
            {
                DialogResult result = MessageBox.Show(this, "Are you sure you want to delete this game?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    StorageManager.Delete(game);
                    MessageBox.Show(this, "Game deleted!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }

        private bool IsUserLoggedIn()
        {
            if (!StorageManager.IsUserLoggedIn())
            {
                MessageBox.Show(this, "Steam is not open or the user is not logged in!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
