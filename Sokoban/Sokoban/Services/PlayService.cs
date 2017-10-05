using System;
using Sokoban.Models;
namespace Sokoban.Services
{
    public class PlayService
    {
		public void MovePlayer(int playerid, int playerendpoint, int firstbox, int secondbox, PlayModel model)
		{
			if (playerid == playerendpoint)
			{
				//Speler is op de correcte plek 
				//return
			}
			else
			{
				//Induction

			}
		}

		public void NextPush(int boxid, PlayModel model)
		{
			//Inductie
			//Controleer of met de volgende zet nog altijd een oplossing mogelijk is.
		}
    }
}
