using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Convertors.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int _player;
        private int _computer;
        private int _computerScore;
        private int _playerScore;

        private Random _rand;
        public MainViewModel()
        {
            Player = 0;
            Computer = 0;
            PlayerScore = 0;
            ComputerScore = 0;
            _rand = new Random();
            Play = new ParametrizedRelayCommand(
                (param) =>
                {
                    if (param is string)
                    {
                        switch (param)
                        {
                            case "1": Player = 1; break;
                            case "2": Player = 2; break;
                            case "3": Player = 3; break;
                            default: Player = 0; break;
                        }
                        Computer = _rand.Next(3) + 1;
                    }
                    if((Player == 1 && Computer == 2)||(Player == 2 && Computer == 3) || (Player == 3 && Computer == 1))
                    {
                        PlayerScore++;
                    }
                    if((Computer == 1 && Player == 2) || (Computer == 2 && Player == 3) || (Computer == 3 && Player == 1))
                    {
                        ComputerScore++;
                    }
                },
                (param) => true
            );
        }
        public int PlayerScore
        {
            get => _playerScore;
            set
            {
                _playerScore = value;
                NotifyPropertyChanged();
            }
        }
        public int ComputerScore
        {
            get => _computerScore;
            set
            {
                _computerScore = value;
                NotifyPropertyChanged();
            }
        }
        public int Player
        {
            get => _player;
            set
            {
                _player = value;
                NotifyPropertyChanged();
            }
        }
        public int Computer
        {
            get => _computer;
            set
            {
                _computer = value;
                NotifyPropertyChanged();
            }
        }

        public ParametrizedRelayCommand Play { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
