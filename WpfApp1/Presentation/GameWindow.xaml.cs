using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ButtonPressGame.Presentation;

namespace ButtonPressGame
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private GameWindowModel _gameWindowModel;

        public GameWindow()
        {
            _gameWindowModel = new GameWindowModel();

            DataContext = _gameWindowModel;

            InitializeComponent();
        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            

            _gameWindowModel.ButtonPressed(ConvertObjectToName(sender));
        }


        //A little database takes the different buttons and converts them into names;
        //if a different window with different names is used, the object names can be edited here instead of the ViewModel.
        private string ConvertObjectToName(object sender)
        {
            string nameOfObject = "NO_NAME";
            if (sender.ToString() == "System.Windows.Controls.Button: UpButton")
            {
                nameOfObject = "UpButton";
            }
            else if(sender.ToString() == "System.Windows.Controls.Button: DownButton")
            {
                nameOfObject = "DownButton";
            }
            else if (sender.ToString() == "System.Windows.Controls.Button: LeftButton")
            {
                nameOfObject = "LeftButton";
            }
            else if(sender.ToString() == "System.Windows.Controls.Button: RightButton")
            {
                nameOfObject = "RightButton";
            }
            return nameOfObject;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _gameWindowModel.MainLoop();
        }
    }
}
