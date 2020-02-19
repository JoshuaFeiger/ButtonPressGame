using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonPressGame.Models
{
    public class Button
    {

        public Button()
        {
            _isActive = true;
        }

        private double _countdownTimer;

        public double CountdownTimer
        {
            get { return _countdownTimer; }
            set
            {
                _countdownTimer = value;
                if (CountdownTimer < 0)
                {
                    LoadNext();
                }
            }
        }

        private List<double> _buttonTimeList;

        public List<double> ButtonTimeList
        {
            get { return _buttonTimeList; }
            set { _buttonTimeList = value; }
        }

        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }


        public void LoadNext()
        {
            if (_buttonTimeList.ToArray().Length <= 1 && _buttonTimeList.ToArray().Length >= 0)
            {
                _countdownTimer = 0;
                _isActive = false;
            }
            else
            {
                _buttonTimeList.RemoveAt(0);
                _countdownTimer = _countdownTimer + _buttonTimeList[0];
                _isActive = true;
            }
        }

    }
}
