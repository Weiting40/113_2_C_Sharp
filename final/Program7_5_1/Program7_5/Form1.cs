using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        // 使用 List<string> 方便操作球隊與冠軍資料
        List<string> teams = new List<string>();
        List<string> winners = new List<string>();

        // 定義球隊資料結構
        public class TeamData
        {
            public string TeamName { get; set; }
            public List<int> WinningYears { get; set; } = new List<int>();

            public int WinCount => WinningYears.Count;

            public TeamData(string name)
            {
                TeamName = name;
            }
        }

        List<TeamData> teamDataList = new List<TeamData>();

        public Form1()
        {
            InitializeComponent();
        }

        // 表單載入事件，啟動時讀取資料
        private void Form1_Load(object sender, EventArgs e)
        {
            readTeams();
            readWinner();
            BuildTeamDataList();
            DisplayTeamsInListBox();
        }

        // 讀取 Teams.txt 檔案，使用檔案對話框讓使用者選擇
        private void readTeams()
        {
            MessageBox.Show("請選擇球隊資料檔案", "選擇檔案", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "請選擇 Teams.txt 檔案";
            openFileDialog.Filter = "文字檔案 (*.txt)|*.txt";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory; // 預設目錄為執行目錄

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    teams = File.ReadAllLines(openFileDialog.FileName).ToList();
                    if (teams.Count == 0)
                    {
                        MessageBox.Show("檔案是空的！");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取 Teams 檔案錯誤：" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("沒有選擇 Teams.txt 檔案");
            }
        }

        // 讀取 WorldSeriesWinners.txt 檔案，使用檔案對話框讓使用者選擇
        private void readWinner()
        {
            MessageBox.Show("請選擇冠軍紀錄資料檔案", "選擇檔案", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "請選擇 WorldSeriesWinners.txt 檔案";
            openFileDialog.Filter = "文字檔案 (*.txt)|*.txt";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory; // 預設目錄為執行目錄

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    winners = File.ReadAllLines(openFileDialog.FileName).ToList();
                    if (winners.Count == 0)
                    {
                        MessageBox.Show("冠軍檔案是空的！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取冠軍檔案錯誤：" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("沒有選擇 WorldSeriesWinners.txt 檔案");
            }
        }

        // 建立 teamDataList，把球隊和冠軍年份配對
        private void BuildTeamDataList()
        {
            teamDataList.Clear();

            // 將所有球隊加入 teamDataList
            foreach (var team in teams)
            {
                teamDataList.Add(new TeamData(team));
            }

            // 從1903年開始紀錄冠軍年份，1904和1994年無世界大賽，跳過
            int year = 1903;
            for (int i = 0; i < winners.Count; i++)
            {
                if (year == 1904 || year == 1994)
                {
                    year++;
                }

                string winner = winners[i];

                TeamData team = teamDataList.FirstOrDefault(t => t.TeamName == winner);
                if (team != null)
                {
                    team.WinningYears.Add(year);
                }

                year++;
            }
        }

        // 顯示球隊名稱至 ListBox
        private void DisplayTeamsInListBox()
        {
            listBox1.Items.Clear();
            foreach (var team in teamDataList.OrderBy(t => t.TeamName))
            {
                listBox1.Items.Add(team.TeamName);
            }
        }

        // 使用者點選 ListBox 中球隊名稱，顯示該隊冠軍次數與年份
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            string selectedTeamName = listBox1.SelectedItem.ToString();
            TeamData selectedTeam = teamDataList.FirstOrDefault(t => t.TeamName == selectedTeamName);

            if (selectedTeam != null)
            {
                label1.Text = $"【{selectedTeam.TeamName}】共獲得 {selectedTeam.WinCount} 次冠軍\n" +
                              $"獲勝年份：{string.Join(", ", selectedTeam.WinningYears)}";
            }
        }

        // 按鈕事件，手動讀取並顯示資料
        private void btnLoad_Click(object sender, EventArgs e)
        {
            readTeams();
            readWinner();
            BuildTeamDataList();
            DisplayTeamsInListBox();
        }
    }
}



