
namespace GameLauncher
{
    public partial class MainForm : Form
    {
        private readonly Label noGames;

        public MainForm()
        {
            InitializeComponent();
            noGames = new()
            {
                Text = "Your library is empty!",
                AutoSize = true,
                Anchor = AnchorStyles.None,
                Font = new Font(Font.FontFamily, 14, FontStyle.Regular),

            };
            noGames.Location = new Point((Width - noGames.Width) / 2 - (noGames.Width / 2), (Height - noGames.Height) / 2 - (noGames.Height));

            Controls.Add(noGames);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshGames();
        }

        private async void RefreshGames()
        {
            gamesLayoutPanel.Controls.Clear();
            noGames.Visible = false;
            gamesLayoutPanel.Visible = true;

            List<Game> games = await StorageManager.GetGames();

            if (games.Count == 0)
            {
                noGames.Visible = true;
                gamesLayoutPanel.Visible = false;
                return;
            }

            games.Sort((x, y) => x.Name.CompareTo(y.Name));
            HashSet<char> letters = new();
            foreach (var game in games)
            {
                var letter = game.Name[0];
                if (letters.Add(letter))
                {
                    Label letterLabel = new Label();
                    letterLabel.Text = letter.ToString();
                    letterLabel.Font = new Font(letterLabel.Font.FontFamily, 14, FontStyle.Bold);
                    letterLabel.AutoSize = true;
                    if (gamesLayoutPanel.Controls.Count != 0)
                    {
                        gamesLayoutPanel.SetFlowBreak(gamesLayoutPanel.Controls[gamesLayoutPanel.Controls.Count - 1], true);
                    }
                    gamesLayoutPanel.Controls.Add(letterLabel);

                    //Fixing empty space after flow break (https://stackoverflow.com/questions/23448229/strange-empty-spaces-in-flowlayoutpanel)
                    Label dummyLabel = new Label();
                    dummyLabel.Width = 0;
                    dummyLabel.Height = 0;
                    dummyLabel.Margin = new Padding(0, 0, 0, 0);
                    gamesLayoutPanel.Controls.Add(dummyLabel);
                    gamesLayoutPanel.SetFlowBreak(dummyLabel, true);
                }
                PictureBox pictureBox = new PictureBox
                {
                    ImageLocation = game.GridPath,
                    Width = 120,
                    Height = 180,
                    Cursor = Cursors.Hand,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                new ToolTip().SetToolTip(pictureBox, game.Name);
                pictureBox.Click += (object? sender, EventArgs e) =>
                {
                    var details = new DetailsForm(game);
                    details.FormClosed += (object? sender, FormClosedEventArgs e) =>
                    {
                        RefreshGames();
                    };
                    details.ShowDialog(this);

                };

                gamesLayoutPanel.Controls.Add(pictureBox);
            }

        }


        private void addButton_Click(object sender, EventArgs e)
        {
            new DetailsForm(null).ShowDialog(this);
        }

        private async void epicGamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var games = await new EpicGamesImporter().GetGames();
            string test = "";
            foreach (var game in games)
            {
                test += game.Name + "\n";
            }
            MessageBox.Show(test);
        }
    }
}
