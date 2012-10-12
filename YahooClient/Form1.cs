using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace YahooService
{
    public partial class Form1 : Form
    {
        private YahooService _service = new YahooService();
        private string _authUrl;

        public Form1()
        {
            InitializeComponent();

            //Testing sample data returned from yahoo compiled into a single file
            XmlSerializer deserializer = new XmlSerializer(typeof(fantasy_content));
            TextReader textReader = new StreamReader(@"C:\Users\Necrosis\Desktop\test.xml");
            fantasy_content content = (fantasy_content)deserializer.Deserialize(textReader);
            textReader.Close();
            mainTextBox.Text = content.ToString();
        }

        private void UpdateTextBox(string result)
        {
            if (mainTextBox.InvokeRequired)
                mainTextBox.Invoke((MethodInvoker)delegate { UpdateTextBox(result); });//(MethodInvoker)delegate { mainTextBox.Text = result; });
            else
                mainTextBox.Text = result.ToString();
        }

        private void RequestTokenButton_Click(object sender, EventArgs e)
        {
            var task = _service.GetRequestToken();
            task.ContinueWith((result) =>
            {
                _authUrl = result.Result;
                UpdateTextBox("Request token Completed");
                VerifierButton.Invoke((MethodInvoker)delegate { VerifierButton.Enabled = true; });
            });
            task.Start();
        }

        private void VerifierButton_Click(object sender, EventArgs e)
        {
            mainTextBox.Visible = false;
            webBrowserPage.Visible = true;
            webBrowserPage.Navigate(HttpUtility.UrlDecode(_authUrl));
            VerifierTextBox.Enabled = true;
            accessTokenButton.Enabled = true;
        }

        private void AccessTokenButton_Click(object sender, EventArgs e)
        {
            webBrowserPage.Visible = false;
            mainTextBox.Visible = true;

            var task = _service.GetAccessToken(VerifierTextBox.Text);
            task.ContinueWith((result) =>
            {
                UpdateTextBox("Access Token Completed");
                EnableAllButtons();
            });
            task.Start();

        }

        private void EnableAllButtons()
        {
            getUserInformationButton.Invoke((MethodInvoker)delegate { getUserInformationButton.Enabled = true; });
            getUserGamesButton.Invoke((MethodInvoker)delegate { getUserGamesButton.Enabled = true; });
            leagueIdTextBox.Invoke((MethodInvoker)delegate { leagueIdTextBox.Enabled = true; });
            getLeagueInfoButton.Invoke((MethodInvoker)delegate { getLeagueInfoButton.Enabled = true; });
            getUserLeaguesButton.Invoke((MethodInvoker)delegate { getUserLeaguesButton.Enabled = true; });
            gamesTextBox.Invoke((MethodInvoker)delegate { gamesTextBox.Enabled = true; });
            getUserTeamsButton.Invoke((MethodInvoker)delegate { getUserTeamsButton.Enabled = true; });
            subresourceTextBox.Invoke((MethodInvoker)delegate { subresourceTextBox.Enabled = true; });           
        }

        private void getUserInformationButton_Click(object sender, EventArgs e)
        {
            var task = _service.GetUsersCollection();
            task.ContinueWith((result) =>
            {
                UpdateTextBox(result.Result.ToString());
            });
            task.Start();
        }

        private void getUserGamesButton_Click(object sender, EventArgs e)
        {
            var task = _service.GetUserResourceGames();
            task.ContinueWith((result) =>
            {
                UpdateTextBox(result.Result.ToString());
            });
            task.Start();
        }

        private void getUserLeaguesButton_Click(object sender, EventArgs e)
        {
            var games = gamesTextBox.Text.Split(',').ToList<string>();
            var task = _service.GetUserResourceLeagues(games);
            task.ContinueWith((result) =>
            {
                UpdateTextBox(result.Result.ToString());
            });
            task.Start();
        }

        private void getUserTeamsButton_Click(object sender, EventArgs e)
        {
            var games = gamesTextBox.Text.Split(',').ToList<string>();
            var task = _service.GetUserResourcesTeams(games);
            task.ContinueWith((result) => UpdateTextBox(result.Result.ToString()));
            task.Start();
        }

        private void getLeagueInfoButton_Click(object sender, EventArgs e)
        {
            var text = String.IsNullOrEmpty(subresourceTextBox.Text) ? "metadata" : subresourceTextBox.Text;

            var task = _service.GetLeagueResource(leagueIdTextBox.Text, text);
            task.ContinueWith((result) => UpdateTextBox(result.Result.ToString()));
            task.Start();
        }





    }
}
