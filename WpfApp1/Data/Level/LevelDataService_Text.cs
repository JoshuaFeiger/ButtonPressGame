using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ButtonPressGame.Data.Level
{
    class LevelDataService_Text : ILevelDataService
    {
        public List<List<double>> ReadLevel(string levelName)
        {
            List<List<double>> levelList = new List<List<double>>();
            string[] lines = File.ReadAllLines($"Data\\Level\\{levelName}");
            foreach (string line in lines)
            {
                double[] lineArray = Array.ConvertAll(line.Split(','), new Converter<string, double>(Double.Parse));
                levelList.Add(lineArray.ToList<double>());
            }
            return levelList;
        }

        public void WriteLevel(List<List<double>> LevelData, string levelName)
        {
            
        }
    }
}
