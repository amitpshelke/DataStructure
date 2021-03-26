using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
      TOURNAMENT WINNER
      
      There's an algorithms tournament taking place in which teams of programmers compete against each other to solve algorithmic problems as fast as possible.
      Teams compete in a round robin, where each team faces off against all other teams. Only two teams compete against each other at a time, and for each
      competition, one team is designated the home team, while the other team is the away team. In each competition there's always one winner and one loser; there
      are no ties. A team receives 3 points if it wins and 0 points if it loses. The winner of the tournament is the team that receives the most amount of points.
      
      Given an array of pairs representing the teams that have competed against each other and an array containing the results of each competition, write a
      function that returns the winner of the tournament. The input arrays are named competitions and results, respectively.

      The competitions array has elements in the form of [homeTeam, awayTeam], where each team is a string of at most 30 characters representing the name of the team. 
      The results array contains information about the winner of each corresponding competition in the competitions array. Specifically, results[i] denotes
      the winner of competitions[i], where a 1 in the results array means that the home team in the corresponding competition won and a 0 means that the away team won.

      
      It's guaranteed that exactly one team will win the tournament and that each team will compete against all other teams exactly once. It's also guaranteed
      that the tournament will always have at least two teams.

      INPUT

      competitions = [
                      ["HTML", "C#"],
                      ["C#", "Python"],
                      ["Python", "HTML"],
                     ]

      results =[0,0,1]

      OUTPUT

      "Python"

        // C# beats HTML, Python Beats C#, and Python Beats HTML.</span><span class="CodeEditor-promptComment">// HTML - 0 points 
        // C# -  3 points
        // Python -  6 points

     
    */
    class A3
    {
        public int HOME_TEAM_WON = 1;

        public string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            string currentBestTeam = "";
            Dictionary<string, int> scores = new Dictionary<string, int>();

            for (int idx = 0; idx < competitions.Count; idx++)
            {
                List<string> competition = competitions[idx];

                int result = results[idx];
                string homeTeam = competition[0];
                string awayTeam = competition[1];

                string winningTeam = (result == HOME_TEAM_WON) ? homeTeam : awayTeam;

                updateScores(winningTeam, 3, scores);

                if (scores[winningTeam] > scores[currentBestTeam])
                    currentBestTeam = winningTeam;
            }

            return currentBestTeam;
        }

        private void updateScores(string team, int points, Dictionary<string, int> scores)
        {
            if (!scores.ContainsKey(team))
                scores[team] = 0;

            scores[team] = scores[team] + points;
        }
    }
}
