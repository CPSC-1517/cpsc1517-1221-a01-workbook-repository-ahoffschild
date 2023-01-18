using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
    public class Team
    {
        private const int teamLimit = 23;
        private string _name;
        private string _city;
        private string _arena;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                string lettersOnlyPattern = @"^[a-zA-Z]$";
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Error: empty string.");
                }
                if (Regex.IsMatch(value, lettersOnlyPattern))
                {
                    throw new ArgumentNullException("Error: must have only letters.");
                }
                _name = value.Trim();
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Error: empty string.");
                }
                if (value.Trim().Length < 3)
                {
                    throw new ArgumentNullException("Error: must have 3 or more characters.");
                }
                _city = value.Trim();
            }
        }
        public string Arena
        {
            get { return _arena; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Error: empty string.");
                }
                _arena = value.Trim();
            }
        }
        public Conference Conference { get; set; }
        public Division Division { get; set; }
        public List<Player> Players { get; private set; }

        public Team(string name, string city, string arena, Conference conference, Division division)
        {
            Name = name;
            City = city;
            Arena = arena;
            Conference = conference;
            Division = division;
            Players = new List<Player>();
        }

        public Team(string name)
        {
            Name = name;
        }

        public void AddPlayer(Player newPlayer)
        {
            if (newPlayer == null)
            {
                throw new ArgumentException("Player cannot be null.");
            }
            foreach (Player playerNum in Players)
            {
                if (playerNum.PlayerNumber == newPlayer.PlayerNumber)
                {
                    throw new ArgumentException("Player is already on the list.");
                }
            }
            if (Players.Count >= teamLimit)
            {
                throw new ArgumentException($"Team has {teamLimit} players already.");
            }
            Players.Add(newPlayer);
        }
    }
}
