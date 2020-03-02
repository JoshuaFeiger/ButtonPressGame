using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ButtonPressGame.Data.User
{
    class UserDataService_Text : IUserDataService
    {
        public void WriteHighScoresFile(List<(double, string)> HighScores, string HighScoresFile)
        {
            List<string> HighScoresAsStringList = new List<string>();
            foreach ((double, string) item in HighScores)
            {
                string itemAsString = ($"{item.Item1},{item.Item2}");
                HighScoresAsStringList.Add(itemAsString);
            }
            File.WriteAllLines(HighScoresFile, HighScoresAsStringList);
        }

        public List<(double, string)> ReadHighScoresFile(string HighScoresFile)
        {
            List<(double, string)> HighScores = new List<(double, string)>();
            string[] lines = File.ReadAllLines($"{HighScoresFile}");
            foreach (string line in lines)
            {
                string[] lineAsArray = line.Split(',');
                HighScores.Add((double.Parse(lineAsArray[0]), lineAsArray[1]));
            }
            return HighScores;
        }

        public List<string> ReadHighScoresFileAsText(string HighScoresFile)
        {
            string[] lines = File.ReadAllLines($"{HighScoresFile}");
            return lines.ToList<string>();
        }


        public void WriteUserData(List<string> UserData, string UserFile)
        {
            //stub method; does nothing yet as the UserData has not been implemented yet.
        }

        public List<string> ReadUserData(string UserFile)
        {
            //stub method; does nothing yet as the UserData has not been implemented yet.
            return null;
        }
    }
}
