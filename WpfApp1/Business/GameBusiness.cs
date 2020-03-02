using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ButtonPressGame.Data.Level;
using ButtonPressGame.Models;
using ButtonPressGame.Data.User;
using ButtonPressGame.Presentation;

namespace ButtonPressGame.Buisness
{
    class GameBusiness
    {
        private string _highScoreDefaultPath = "Data\\User\\HighScores_Level_01.txt";
        private string _levelDefaultName = "Level_01.txt";

        public GameBusiness()
        {
            InitializeDataService();
            InitializeGame();
        }

        ILevelDataService _levelDataService;
        IUserDataService _userDataService;
        private void InitializeDataService()
        {
            //
            // instantiate the data service
            //
            _levelDataService = new LevelDataService_Text();
            _userDataService = new UserDataService_Text();
        }

        private List<List<double>> _level;

        public List<List<double>> Level
        {
            get { return _level; }
            set { _level = value; }
        }

        private List<(double, string)> _highScores;

        public List<(double, string)> HighScores
        {
            get 
            {
                _highScores = _userDataService.ReadHighScoresFile(_highScoreDefaultPath);
                return _highScores;
            }
            set 
            { 
                _highScores = value;
                _userDataService.WriteHighScoresFile(_highScores, _highScoreDefaultPath);
            }
        }

        private void InitializeGame()
        {
            _level = _levelDataService.ReadLevel(_levelDefaultName);
        }

        private List<string> _highScoreAsString;

        public List<string> HighScoreAsString
        {
            get 
            {
                _highScoreAsString = _userDataService.ReadHighScoresFileAsText(_highScoreDefaultPath);
                return _highScoreAsString;
            }
            set {  }
        }
    }
}
