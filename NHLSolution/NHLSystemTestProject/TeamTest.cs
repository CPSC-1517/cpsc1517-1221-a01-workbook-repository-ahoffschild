using System.Security.Cryptography.X509Certificates;

namespace NHLSystemTestProject
{
    [TestClass]
    public class TeamTest
    {
        [TestMethod]
        [DataRow("Oilers", "Edmonton", "Rogers Place", Conference.Western, Division.Pacific)]
        [DataRow("Flames", "Calgary", "Scotiabank Saddledome", Conference.Western, Division.Pacific)]
        [DataRow("Canucks", "Vancouver", "Rogers Arena", Conference.Western, Division.Pacific)]
        [DataRow("Maple Leafs", "Toronto", "Scotiabank Arena", Conference.Eastern, Division.Atlantic)]
        [DataRow("Senators", "Ottawa", "Canadian Tire Center", Conference.Eastern, Division.Atlantic)]
        [DataRow("Canadiens", "Montreal", "Centre Bell", Conference.Eastern, Division.Atlantic)]
        [DataRow("Jets", "Winnipeg", "Canada Life Centre", Conference.Western, Division.Central)]
        public void Name_ValidName_Name(
            string teamName,
            string city,
            string arena,
            Conference conference,
            Division division)
        {
            //Arrange
            //Act
            Team currentTeam = new Team(teamName, city, arena, conference, division);
            //Assert
            Assert.AreEqual(teamName, currentTeam.Name);
            Assert.AreEqual(city, currentTeam.City);
            Assert.AreEqual(arena, currentTeam.Arena);
            Assert.AreEqual(conference, currentTeam.Conference);
            Assert.AreEqual(division, currentTeam.Division);
        }
        [TestMethod]
        [DataRow(null, "Name cannot be blank.")]
        [DataRow("", "Name cannot be blank.")]
        [DataRow("     ", "Name cannot be blank.")]

        public void Name_InvalidName_ThrowsArgumentNullException(
            string teamName,
            string expectedErrorMessage,
            string city,
            string arena,
            Conference conference,
            Division division
            )
        {
            try
            {
                Team currentTeam = new Team(teamName, city, arena, conference, division);
                Assert.Fail("An ArgumentNullException should have been thrown");
            }
            catch(ArgumentNullException ex)
            {
                StringAssert.Contains(ex.Message, expectedErrorMessage);
            }
        }
    }
}