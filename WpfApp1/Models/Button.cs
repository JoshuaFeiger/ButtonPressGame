using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ButtonPressGame.Models
{
    public class Button
    {
        public Button()
        {
            _isActive = true;
            _color = Brushes.MediumAquamarine;
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
                else if (CountdownTimer < 6)
                {
                    _color = Brushes.Red;
                }
                else if (CountdownTimer < 10)
                {
                    _color = Brushes.Orange;
                }
                else if (CountdownTimer < 15)
                {
                    _color = Brushes.Aquamarine;
                }
                else
                {
                    _color = Brushes.Azure;
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
                _color = Brushes.Aqua;
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

        private System.Windows.Media.SolidColorBrush _color;

        public System.Windows.Media.SolidColorBrush Color
        {
            get { return _color; }
            set { _color = value; }
        }
    }
}
