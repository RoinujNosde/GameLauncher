using craftersmine.SteamGridDBNet;

namespace GameLauncher
{

    public delegate void SetImagePath(string path);

    public partial class ImageDownloaderForm : Form
    {
        private const int MaxImagesPerGame = 10;
        private readonly ImageType imageType;
        private readonly PictureBox pictureBox;

        public ImageDownloaderForm(string gameName, ImageType imageType, PictureBox pictureBox)
        {
            InitializeComponent();
            nameTextBox.Text = gameName;
            this.imageType = imageType;
            this.pictureBox = pictureBox;
            if (nameTextBox.Text.Length > 0)
            {
                searchButton_Click(this, new EventArgs());
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = nameTextBox.Text.Length > 0;
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            searchButton.Enabled = false;
            nameTextBox.Enabled = false;
            SteamGridDbGame[] games = await Program.SteamGridDb.SearchForGamesAsync(nameTextBox.Text);
            if (games.Length == 0)
            {
                MessageBox.Show(this, $"{nameTextBox.Text} not found");
                nameTextBox.Enabled = true;
                this.Cursor = Cursors.Default;
                return;
            }
            imagesPanel.Controls.Clear();
            foreach (var game in games)
            {
                var id = game.Id;
                SteamGridDbObject[] images = imageType switch
                {
                    ImageType.GRID => await Program.SteamGridDb.GetGridsByGameIdAsync(id),
                    ImageType.LOGO => await Program.SteamGridDb.GetLogosByGameIdAsync(id),
                    ImageType.HERO => await Program.SteamGridDb.GetHeroesByGameIdAsync(id),
                    _ => [],
                };
                if (!Visible) break;
                if (images.Length == 0)
                {
                    nameTextBox.Enabled = true;
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(this, $"No images found for {game.Name} (ID: {id})");
                    return;
                }
                for (int i = 0; i < images.Length && i < MaxImagesPerGame; i++)
                {
                    var image = images[i];
                    PictureBox box = new()
                    {
                        Width = imageType.GetWidth(),
                        Height = imageType.GetHeight(),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Cursor = Cursors.Hand
                    };
                    try
                    {
                        box.Image = Image.FromStream(await image.GetImageAsStreamAsync(false));
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    box.Click += (object? sender, EventArgs e) =>
                    {
                        string path = Path.GetTempPath() + $"{image.Id}." + image.Format.ToString().Replace("Jpeg", "jpg");
                        box.Image.Save(path);
                        pictureBox.ImageLocation = path;
                        Close();
                    };

                    imagesPanel.Controls.Add(box);
                }
            }
            nameTextBox.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void ImageDownloaderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.SteamGridDb.CancelPendingRequests();
        }
    }
}
