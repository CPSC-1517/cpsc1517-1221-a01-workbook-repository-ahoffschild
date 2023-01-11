using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NHLSystemClassLibrary
{
    internal class Team
    {
        private string Name 
        {
            get { return Name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Error: empty string.");
                }
                else if (Regex.IsMatch, @"[a-zA-Z]+$")
                Name = value; 
            }
        }
        private string City { get; set; }
        private string Arena { get; set; }
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
    }
}
