using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonPressGame.Data.User
{
    public interface IUserDataService
    {
        List<string> ReadUserData(string UserFile);
        void WriteUserData(List<string> UserData, string UserFile);

        List<(double, string)> ReadHighScoresFile(string HighScoresFile);
        List<string> ReadHighScoresFileAsText(string HighScoresFile);
        void WriteHighScoresFile(List<(double, string)> HighScores, string HighScoresFile);
    }
}
