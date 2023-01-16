using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
    public class Player
    {
        private int _playerNumber;
        private string _playerName;
        private int _gamesPlayed;
        private int _goals;
        private int _assists;

        public int PlayerNumber
        {
            get 
            {
                return _playerNumber;
            }
            set
            {
                if (value < 1 || value > 98)
                {
                    throw new ArgumentException("Player Number must be between 1 and 98.");
                }
                _playerNumber = value;
            }
        }
        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                _playerName = value;
            }
        }
        public int GamesPlayed
        {
            get
            {
                return _gamesPlayed;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Games played cannot be less than 0.");
                }
                _gamesPlayed = value;
            }
        }
        public int Goals
        {
            get
            {
                return _goals;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Goals cannot be less than 0.");
                }
                _goals = value;
            }
        }
        public int Assists
        {
            get
            {
                return _assists;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Assists cannot be less than 0.");
                }
                _assists = value;
            }
        }
        public int Points { get; set; }
        public Position Position {get; set;}

        public Player(int playerNum, string playerName, Position position, int gamesPlayed, int goals, int assists)
        {
            PlayerNumber = playerNum;
            PlayerName = playerName;
            Position = position;
            GamesPlayed = gamesPlayed;
            Goals = goals;
            Assists = assists;
            Points = Goals + Assists;
        }
    }
}
