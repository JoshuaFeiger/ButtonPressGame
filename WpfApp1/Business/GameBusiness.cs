using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ButtonPressGame.Data.Level;
using ButtonPressGame.Models;

namespace ButtonPressGame.Buisness
{
    class GameBusiness
    {
        public GameBusiness()
        {
            InitializeDataService();
            InitializeGame();
        }

        ILevelDataService _dataService;
        private void InitializeDataService()
        {
            //
            // instantiate the data service
            //
            _dataService = new LevelDataService_Text();
        }

        private void InitializeGame()
        {
            _level = _dataService.ReadLevel("Level_01.txt");
        }
        private List<List<double>> _level;

        public List<List<double>> Level
        {
            get { return _level; }
            set { _level = value; }
        }
    }
}
