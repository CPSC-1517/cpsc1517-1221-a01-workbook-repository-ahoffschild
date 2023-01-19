using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystemTestProject
{
	[TestClass]
	public class PlayerTest
	{
		[TestMethod]
		[DataRow(97, "Connor McDavid", Position.Centre)]
		[DataRow(93, "Ryan Nugent-Hopkins", Position.Centre)]
		[DataRow(91, "Evander Kane", Position.Left_Wing)]
		public void ConstructorValidData_ShouldPass(int playerNumberT, string playerNameT, Position playerPositionT)
		{
			// Arrange and Act
			Player currentPlayer = new Player(playerNumberT, playerNameT, playerPositionT);
			// Assert
			Assert.AreEqual(playerNumberT, currentPlayer.PlayerNumber);
			Assert.AreEqual(playerNameT, currentPlayer.PlayerName);
			Assert.AreEqual(playerPositionT, currentPlayer.Position);
		}

		[TestMethod]
		[DataRow(0, "Connor McDavid", Position.Centre)]
		[DataRow(99, "Connor McDavid", Position.Centre)]
		public void PlayerNumber_InvalidValue_ThrowsArgumentException(int playerNumberT, string playerNameT, Position positionT)
		{
			try
			{
				Player currentplayer = new Player(playerNumberT, playerNameT, positionT);
				Assert.Fail("An ArgumentException should have been thrown.");
			}
			catch (ArgumentException ex)
			{
				Assert.AreEqual(ex.Message, "Player Number must be between 1 and 98.");
			}
			catch (Exception ex)
			{
				Assert.Fail("Incorrect exception type thrown.");
			}
		}

		[TestMethod]
		[DataRow(97, "", Position.Centre)]
		[DataRow(93, "     ", Position.Centre)]
		[DataRow(91, null, Position.Left_Wing)]
		public void PlayerName_InvalidValue_ThrowsArgumentException(int playerNumberT, string playerNameT, Position positionT)
		{
			try
			{
				Player currentplayer = new Player(playerNumberT, playerNameT, positionT);
				Assert.Fail("An ArgumentException should have been thrown.");
			}
			catch (ArgumentException ex)
			{
				Assert.AreEqual(ex.Message, "Name cannot be empty.");
			}
			catch (Exception ex)
			{
				Assert.Fail("Incorrect exception type thrown.");
			}
		}

		[TestMethod]
		[DataRow(97, "Connor McDavid", Position.Centre, 40, 27, 15)]
		[DataRow(93, "Ryan Nugent-Hopkins", Position.Centre, 50, 30, 12)]
		[DataRow(91, "Evander Kane", Position.Left_Wing, 35, 14, 20)]
		public void Constructor2ValidData_ShouldPass(int playerNumberT, string playerNameT, Position playerPositionT, int gamesPlayedT, int goalsT, int assistsT)
		{
			// Arrange and Act
			Player currentPlayer = new Player(playerNumberT, playerNameT, playerPositionT, gamesPlayedT, goalsT, assistsT);
			// Assert
			Assert.AreEqual(playerNumberT, currentPlayer.PlayerNumber);
			Assert.AreEqual(playerNameT, currentPlayer.PlayerName);
			Assert.AreEqual(playerPositionT, currentPlayer.Position);
			Assert.AreEqual(gamesPlayedT, currentPlayer.GamesPlayed);
			Assert.AreEqual(goalsT, currentPlayer.Goals);
			Assert.AreEqual(assistsT, currentPlayer.Assists);
		}

		[TestMethod]
		[DataRow(97, "Connor McDavid", Position.Centre, -5, 27, 15)]
		public void GamesPlayed_InvalidValue_ThrowsArgumentException(int playerNumberT, string playerNameT, Position positionT, int gamesPlayedT, int goalsT, int assistsT)
		{
			try
			{
				Player currentplayer = new Player(playerNumberT, playerNameT, positionT, gamesPlayedT, goalsT, assistsT);
				Assert.Fail("An ArgumentException should have been thrown.");
			}
			catch (ArgumentException ex)
			{
				Assert.AreEqual(ex.Message, "Games played cannot be less than 0.");
			}
			catch (Exception ex)
			{
				Assert.Fail("Incorrect exception type thrown.");
			}
		}

		[TestMethod]
		[DataRow(97, "Connor McDavid", Position.Centre, 50, -5, 15)]
		public void Goals_InvalidValue_ThrowsArgumentException(int playerNumberT, string playerNameT, Position positionT, int gamesPlayedT, int goalsT, int assistsT)
		{
			try
			{
				Player currentplayer = new Player(playerNumberT, playerNameT, positionT, gamesPlayedT, goalsT, assistsT);
				Assert.Fail("An ArgumentException should have been thrown.");
			}
			catch (ArgumentException ex)
			{
				Assert.AreEqual(ex.Message, "Goals cannot be less than 0.");
			}
			catch (Exception ex)
			{
				Assert.Fail("Incorrect exception type thrown.");
			}
		}

		[TestMethod]
		[DataRow(97, "Connor McDavid", Position.Centre, 50, 27, -5)]
		public void Assists_InvalidValue_ThrowsArgumentException(int playerNumberT, string playerNameT, Position positionT, int gamesPlayedT, int goalsT, int assistsT)
		{
			try
			{
				Player currentplayer = new Player(playerNumberT, playerNameT, positionT, gamesPlayedT, goalsT, assistsT);
				Assert.Fail("An ArgumentException should have been thrown.");
			}
			catch (ArgumentException ex)
			{
				Assert.AreEqual(ex.Message, "Assists cannot be less than 0.");
			}
			catch (Exception ex)
			{
				Assert.Fail("Incorrect exception type thrown.");
			}
		}

		[TestMethod]
		[DataRow(97, "Connor McDavid", Position.Centre, 50, 27, 15)]
		public void Points_ValidDataCheck(int playerNumberT, string playerNameT, Position positionT, int gamesPlayedT, int goalsT, int assistsT)
		{
			Player currentplayer = new Player(playerNumberT, playerNameT, positionT, gamesPlayedT, goalsT, assistsT);
			int expectedPoints = goalsT + assistsT;
			Assert.AreEqual(currentplayer.Points, expectedPoints);
		}

		//Write a test method for validating these properties: GamesPlayed, Goals, Assists, Points
		//Write test methods for methods AddGamesPlayed(), AddGoals(), AddAssists()
	}
}
