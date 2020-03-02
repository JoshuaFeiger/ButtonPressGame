using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonPressGame.Models
{
    public class Player
    {
		public Player()
		{
			_name = "Player1";
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

	}
}
