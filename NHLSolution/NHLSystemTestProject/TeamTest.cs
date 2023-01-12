using System.Security.Cryptography.X509Certificates;

namespace NHLSystemTestProject
{
    [TestClass]
    public class TeamTest
    {
        [TestMethod]
        [DataRow("Oilers", Conference.Western, Division.Pacific)]
        [DataRow("Flames", Conference.Western, Division.Pacific)]
        [DataRow("Canucks", Conference.Western, Division.Pacific)]
        [DataRow("Maple Leafs", Conference.Eastern, Division.Atlantic)]
        [DataRow("Senators", Conference.Eastern, Division.Atlantic)]
        [DataRow("Canadiens", Conference.Eastern, Division.Atlantic)]
        [DataRow("Jets", Conference.Western, Division.Central)]
        public void Name_ValidName_Name(
            string teamName,
            Conference conference,
            Division division)
        {
            //Arrange
            //Act
            Team currentTeam = new Team(teamName);
            //Assert
            Assert.AreEqual(teamName, currentTeam.Name);
            Assert.AreEqual(conference, currentTeam.Conference);
            Assert.AreEqual(division, currentTeam.Division);
        }
        [TestMethod]
        [DataRow(null, "Name cannot be blank.")]
        [DataRow("", "Name cannot be blank.")]
        [DataRow("     ", "Name cannot be blank.")]
        public void Name_InvalidName_ThrowsArgumentNullException(string teamName, string expectedErrorMessage)
        {
            try
            {
                Team currentTeam = new Team(teamName);
                Assert.Fail("An ArgumentNullException should have been thrown");
            }
            catch
            {
                StringAssert.Contains(expectedErrorMessage.Message, expectedErrorMessage);
            }
        }
    }
}