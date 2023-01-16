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
        private List<Player> Players { get; set; }

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
            if (newPlayer.PlayerNumber == null)
            {
                throw new ArgumentException("Player does not have a number.");
            }
            foreach (Player playerNum in Players)
            {
                for (int x = 0; x < Players.Count; x++)
                {
                    if (playerNum.PlayerNumber == Players[x].PlayerNumber)
                    {
                        throw new ArgumentException("Player is already on the list.");
                    }
                }
            }
            Players.Add(newPlayer);
        }
    }
}
