using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonPressGame.Data.Level
{
    public interface ILevelDataService
    {
        List<List<double>> ReadLevel(string levelName);
        void WriteLevel(List<List<double>> LevelData, string levelName);
    }
}
