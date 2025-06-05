using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        List<string> teams = new List<string>();
        List<string> winners = new List<string>();

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

        private void Form1_Load(object sender, EventArgs e)
        {
            readTeams();
            readWinner();
            BuildTeamDataList();
            DisplayTeamsInListBox();
        }

        private void readTeams()
        {
            MessageBox.Show("請選擇球隊資料檔案", "選擇檔案", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "請選擇 Teams.txt 檔案";
            openFileDialog.Filter = "文字檔案 (*.txt)|*.txt";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    teams = File.ReadAllLines(openFileDialog.FileName).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取 Teams 檔案錯誤：" + ex.Message);
                }
            }
        }

        private void readWinner()
        {
            MessageBox.Show("請選擇冠軍紀錄資料檔案", "選擇檔案", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "請選擇 WorldSeriesWinners.txt 檔案";
            openFileDialog.Filter = "文字檔案 (*.txt)|*.txt";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    winners = File.ReadAllLines(openFileDialog.FileName).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取冠軍檔案錯誤：" + ex.Message);
                }
            }
        }

        private void BuildTeamDataList()
        {
            teamDataList.Clear();
            foreach (var team in teams.Distinct())
            {
                teamDataList.Add(new TeamData(team));
            }

            int year = 1903;
            for (int i = 0; i < winners.Count; i++)
            {
                if (year == 1904 || year == 1994)
                {
                    year++;
                }

                string winner = winners[i];

                if (!teams.Contains(winner))
                {
                    teams.Add(winner); // 若新球隊未加入過，也加入 teams
                    teamDataList.Add(new TeamData(winner));
                }

                TeamData team = teamDataList.FirstOrDefault(t => t.TeamName == winner);
                if (team != null)
                {
                    if (!team.WinningYears.Contains(year))
                        team.WinningYears.Add(year);
                }

                year++;
            }
        }

        private void DisplayTeamsInListBox()
        {
            listBox1.Items.Clear();
            foreach (var team in teamDataList.OrderBy(t => t.TeamName))
            {
                listBox1.Items.Add(team.TeamName);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            string selectedTeamName = listBox1.SelectedItem.ToString();
            TeamData selectedTeam = teamDataList.FirstOrDefault(t => t.TeamName == selectedTeamName);

            if (selectedTeam != null)
            {
                label1.Text = $"【{selectedTeam.TeamName}】共獲得 {selectedTeam.WinCount} 次冠軍\n" +
                              $"獲勝年份：{string.Join(", ", selectedTeam.WinningYears.OrderBy(y => y))}";
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            readTeams();
            readWinner();
            BuildTeamDataList();
            DisplayTeamsInListBox();
        }

        // 新增資料按鈕事件：讀入2010年以後的冠軍隊伍
        private void btnAddData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("請選擇 2010 年以後的新增冠軍資料檔案", "新增資料", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "新增冠軍資料";
            openFileDialog.Filter = "文字檔案 (*.txt)|*.txt";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var newWinnerLines = File.ReadAllLines(openFileDialog.FileName).ToList();
                    int startYear = 2010;

                    foreach (var line in newWinnerLines)
                    {
                        if (startYear == 1994) startYear++; // Just in case

                        string winner = line.Trim();
                        winners.Add(winner); // 加入總冠軍列表

                        if (!teams.Contains(winner))
                        {
                            teams.Add(winner);
                            teamDataList.Add(new TeamData(winner));
                        }

                        TeamData team = teamDataList.FirstOrDefault(t => t.TeamName == winner);
                        if (team != null && !team.WinningYears.Contains(startYear))
                        {
                            team.WinningYears.Add(startYear);
                        }

                        startYear++;
                    }

                    DisplayTeamsInListBox(); // 更新顯示
                    MessageBox.Show("資料新增完成！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新增資料錯誤：" + ex.Message);
                }
            }
        }

        // 離開按鈕事件：儲存所有更新後資料並關閉
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllLines("Teams.txt", teams.Distinct().OrderBy(t => t));
                File.WriteAllLines("WorldSeriesWinners.txt", winners);
                MessageBox.Show("資料已成功儲存，程式即將結束！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存資料錯誤：" + ex.Message);
            }

            Application.Exit();
        }
    }
}
