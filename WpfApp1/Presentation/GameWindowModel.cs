using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ButtonPressGame.Models;
using ButtonPressGame.Buisness;
using System.Threading;
using System.Windows;

namespace ButtonPressGame.Presentation
{
    public class GameWindowModel : ObservableObject
    {
        private GameBusiness _gameBusiness;

        //
        //BUTTONUP OBJECT
        //Instantiated here.
        //
        private Button _buttonUp = new Button();

        public Button ButtonUp
        {
            get { return _buttonUp; }
            set
            {
                _buttonUp = value;
                OnPropertyChanged(nameof(ButtonUp));
            }
        }

        //
        //BUTTONDOWN OBJECT
        //Instantiated here.
        //
        private Button _buttonDown = new Button();

        public Button ButtonDown
        {
            get { return _buttonDown; }
            set
            {
                _buttonDown = value;
                OnPropertyChanged(nameof(ButtonDown));
            }
        }

        //
        //BUTTONLEFT OBJECT
        //Instantiated here.
        //
        private Button _buttonLeft = new Button();

        public Button ButtonLeft
        {
            get { return _buttonLeft; }
            set
            {
                _buttonLeft = value;
                OnPropertyChanged(nameof(ButtonLeft));
            }
        }

        //
        //BUTTONRIGHT OBJECT
        //Instantiated here.
        //
        private Button _buttonRight = new Button();

        public Button ButtonRight
        {
            get { return _buttonRight; }
            set
            {
                _buttonRight = value;
                OnPropertyChanged(nameof(ButtonRight));
            }
        }

        //
        //PLAYER1 OBJECT
        //Instantiated here.
        //

        private Player _player1;

        public Player Player1
        {
            get { return _player1; }
            set { _player1 = value; }
        }


        //
        //SCORE VARIABLE
        //Instantiated here.
        //
        private int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }


        public GameWindowModel()
        {
            _gameBusiness = new GameBusiness();

            //Test values.
            _buttonUp.ButtonTimeList = _gameBusiness.Level[0];
            _buttonDown.ButtonTimeList = _gameBusiness.Level[1];
            _buttonLeft.ButtonTimeList = _gameBusiness.Level[2];
            _buttonRight.ButtonTimeList = _gameBusiness.Level[3];
            _buttonUp.CountdownTimer = _buttonUp.ButtonTimeList[0];
            _buttonDown.CountdownTimer = _buttonDown.ButtonTimeList[0];
            _buttonLeft.CountdownTimer = _buttonLeft.ButtonTimeList[0];
            _buttonRight.CountdownTimer = _buttonRight.ButtonTimeList[0];
        }


        //from https://stackoverflow.com/questions/15879476/creating-a-background-timer-to-run-asynchronously
        // Create a 10 millisecond timer
        private System.Timers.Timer timer = new System.Timers.Timer(10);

        public System.Timers.Timer Timer
        {
            get { return timer; }
            set { timer = value; }
        }


        public void BeginPlay()
        {
            // Hook up the Elapsed event for the timer.
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;

            _player1 = new Player();
        }

        private void OnTimedEvent(object source, EventArgs e)
        {
            System.Timers.Timer timer = (System.Timers.Timer)source;
            _buttonUp.CountdownTimer -= 0.1;
            _buttonDown.CountdownTimer -= 0.1;
            _buttonLeft.CountdownTimer -= 0.1;
            _buttonRight.CountdownTimer -= 0.1;
            OnPropertyChanged(nameof(ButtonUp));
            OnPropertyChanged(nameof(ButtonDown));
            OnPropertyChanged(nameof(ButtonLeft));
            OnPropertyChanged(nameof(ButtonRight));

            if ((_buttonUp.IsActive == false) && (_buttonDown.IsActive == false) && (_buttonLeft.IsActive == false) && (_buttonRight.IsActive == false))
            {
                timer.Dispose();
                int Index = 0;
                List<(double, string)> HighScoresTemp = _gameBusiness.HighScores;
                foreach ((double, string) highScoreData in HighScoresTemp)
                {
                    if (_score > highScoreData.Item1)
                    {
                        HighScoresTemp.Insert(Index, (_score, _player1.Name));
                        break;
                    }
                    Index++;
                }
                _gameBusiness.HighScores = HighScoresTemp;
                HighScoresTemp.RemoveRange(10, (HighScoresTemp.Count() - 10));
                string MessageBoxText = "High scores for this level: \n\n";
                foreach ((double, string) item in HighScoresTemp)
                {
                    MessageBoxText = $"{MessageBoxText}\n{item.Item1}";
                }
                MessageBox.Show(MessageBoxText);
            }
        }

        internal void ButtonPressed(string ButtonName)
        {
            Button buttonObject = ButtonStringToButtonObject(ButtonName);
            if ((buttonObject.CountdownTimer <= 10) && (buttonObject.CountdownTimer >= 0) && (buttonObject.IsActive == true))
            {
                _score += Convert.ToInt32((10 - Math.Abs(buttonObject.CountdownTimer - 5)) * 10);
                OnPropertyChanged("Score");
                buttonObject.LoadNext();
            }
        }

        private Button ButtonStringToButtonObject(string buttonString)
        {
            Button buttonObject = new Button();
            switch (buttonString)
            {
                case "UpButton":
                    buttonObject = _buttonUp;
                    break;
                case "DownButton":
                    buttonObject = _buttonDown;
                    break;
                case "LeftButton":
                    buttonObject = _buttonLeft;
                    break;
                case "RightButton":
                    buttonObject = _buttonRight;
                    break;
                default:
                    throw new Exception("Button couldn't be converted to a Button object in GameWindowModel.");
            }
            return buttonObject;
        }

        public void PauseGame()
        {
            timer.Stop();
        }

        public void UnpauseGame()
        {
            try
            {
                timer.Start();
            }
            catch (Exception)
            {
                //do nothing; the only exceptions that should come up involve the timer having been disposed of.
            }
        }
    }
}
