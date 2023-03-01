using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        const int minPlayerNumber = 1;
        const int maxPlayerNumber = 98;

        public int PlayerNumber
        {
            get 
            {
                return _playerNumber;
            }
            private set
            {
                if (value < minPlayerNumber || value > maxPlayerNumber)
                {
                    throw new ArgumentException($"Player Number must be between {minPlayerNumber} and {maxPlayerNumber}.");
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
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
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
            protected set
            {
                if (!Utilities.IsPositiveOrZero(value))
                {
                    throw new ArgumentException("Games played cannot be less than 0.");
                }
                _gamesPlayed = value;
            }
        }
        public int Goals
        {
            get => _goals;
            private set
            {
                if (!Utilities.IsPositiveOrZero(value))
                {
                    throw new ArgumentException("Goals cannot be less than 0.");
                }
                _goals = value;
            }
        }
        public int Assists
        {
            get => _assists;
            private set
            {
                if (!Utilities.IsPositiveOrZero(value))
                {
                    throw new ArgumentException("Assists cannot be less than 0.");
                }
                _assists = value;
            }
        }
        public int Points
        {
            get => Goals + Assists;
        }
        public Position Position { get; private set; }

        [JsonConstructor]
        public Player(int playerNum, string playerName, Position position, int gamesPlayed, int goals, int assists)
        {
            PlayerNumber = playerNum;
            PlayerName = playerName;
            Position = position;
            GamesPlayed = gamesPlayed;
            Goals = goals;
            Assists = assists;
        }
        public Player(int playerNum, string playerName, Position position)
        {
            PlayerNumber = playerNum;
            PlayerName = playerName;
            Position = position;
            GamesPlayed = 0;
            Goals = 0;
            Assists = 0;
        }
        public Player()
        {
        }
        public void AddGamePlayed()
        {
            GamesPlayed += 1;
        }
        public void AddGoalScored()
        {
            Goals += 1;
        }
        public void AddAssistScored()
        {
            Assists += 1;
        }

        public override string ToString()
        {
            return $"{PlayerNumber},{PlayerName},{Position},{GamesPlayed},{Goals},{Assists}";
        }

        public static Player Parse(string csvLine)
        {
            const char Delimiter = ',';
            const int ExpectedColumnCount = 6;
            string[] tokens = csvLine.ReplaceLineEndings().Split(Delimiter);
            if (tokens.Length != ExpectedColumnCount)
            {
                throw new FormatException($"CSV line must contain exactly {ExpectedColumnCount} values.");
            }
            /* Order of columns are =
             * 0. PlayerNumber
             * 1. PlayerName
             * 2. Position
             * 3. GamesPlayed
             * 4. Goals
             * 5. Assists
             * */
            int playerNumber = int.Parse(tokens[0]);
            string playerName = tokens[1];
            Position position = (Position)Enum.Parse(typeof(Position), tokens[2]);
            int gamesPlayed = int.Parse(tokens[3]);
            int goals = int.Parse(tokens[4]);
            int assists = int.Parse(tokens[5]);
            return new Player(playerNumber, playerName, position, gamesPlayed, goals, assists);
        }

        public static bool TryParse(string csvLine, ref Player currentPlayer)
        {
            bool success = false;
            try
            {
                currentPlayer = Parse(csvLine);
                success = true;
            }
            catch(FormatException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new Exception($"Player TryParse method failed with exception {ex.Message}");
            }
            return success;
        }
    }
}
