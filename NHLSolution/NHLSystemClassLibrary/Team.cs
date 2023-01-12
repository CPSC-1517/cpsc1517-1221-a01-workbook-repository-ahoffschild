using System;
using System.Collections.Generic;
using System.Linq;
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

        private string Name 
        {
            get { return Name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Error: empty string.");
                }
                if (!value.All(Char.IsLetter))
                {
                    throw new ArgumentNullException("Error: must have only letters.");
                }
                _name = value.Trim();
            }
        }
        private string City
        {
            get { return _city; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Error: empty string.");
                }
                if (value.Length <= 3)
                {
                    throw new ArgumentNullException("Error: must have more than 3 characters.");
                }
                _city = value.Trim();
            }
        }
        private string Arena
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
        private Conference Conference { get; set; }
        private Division Division { get; set; }

        public Team(string name, string city, string arena, Conference conference, Division division)
        {
            Name = name;
            City = city;
            Arena = arena;
            Conference = conference;
            Division = division;
        }

        public Team(string name)
        {
            Name = name;
        }
    }
}
