using System;
using System.Collections.Generic;
using Sokoban.Models;
namespace Sokoban.Services
{
    public class SolveService
    {
        public void CheckRoute(int boxid, int objectiveid, int playerid, PlayModel model)
        {
            
        }





        public List<ConnectionModel> GetPlayerPushDirections(int playerid, FieldModel box, PlayModel model)
        {
            var currentField = model.Fields.Find(x => x.ID == playerid);

            bool PlayerDirectionIsPossible = true;

            List<ConnectionModel> connections = new List<ConnectionModel>();
            connections.Add(currentField.NorthConnection);
            connections.Add(currentField.EastConnection);
            connections.Add(currentField.SouthConnection);
            connections.Add(currentField.WestConnection);


            for (int i = 0; i < connections.Count; i++)
            {
                if (!PlayerPushIsPossible(connections[i], currentField, box)) { PlayerDirectionIsPossible = false; }

                else if (connections[i].NextID == 0) { PlayerDirectionIsPossible = false; }

                if (!PlayerDirectionIsPossible) {connections.Remove(connections[i]);} 

            }

            return connections;
        }

        public List<ConnectionModel> GetBoxDirections(int boxid, PlayModel model, int playerid)
        {
            var currentField = model.Fields.Find(x => x.ID == boxid);

            List<ConnectionModel> connections = new List<ConnectionModel>();
			connections.Add(currentField.NorthConnection);
			connections.Add(currentField.EastConnection);
			connections.Add(currentField.SouthConnection);
			connections.Add(currentField.WestConnection);

            for (int i = 0; i < connections.Count; i++)
            {
                bool pushIsPossible = true;
                if (connections[i].NextID == currentField.NorthConnection.NextID)
                {
                    if (!DirectionIsPossible(currentField.SouthConnection)) { pushIsPossible = false;}
                }
                else if (connections[i].NextID == currentField.EastConnection.NextID)
                {
                    if (!DirectionIsPossible(currentField.WestConnection)) { pushIsPossible = false; }
                }
                else if (connections[i].NextID == currentField.SouthConnection.NextID)
                {
                    if (!DirectionIsPossible(currentField.NorthConnection)) { pushIsPossible = false; }
                }
                else if (connections[i].NextID == currentField.WestConnection.NextID)
                {
                    if (!DirectionIsPossible(currentField.EastConnection)) { pushIsPossible = false; }
                }

				else if (connections[i].NextID == 0)
				{
                    pushIsPossible = false;
				}
                else if (connections[i].NextID == playerid)
                {
                    pushIsPossible = false;
                }

                if (pushIsPossible == false)
                {
                    connections.Remove(connections[i]);
                }
			}
            return connections;
        }

		public bool PlayerPushIsPossible(ConnectionModel currentconnection, FieldModel currentfield, FieldModel currentboxfield)
		{
            //First part check direction, Second part check if next step contains the box, third part checks if the box direction == 0
            //Return false
            if (currentconnection.NextID == currentfield.NorthConnection.NextID && currentconnection.NextID == currentboxfield.ID && currentboxfield.NorthConnection.NextID == 0)
			{
                return false;
			}
			else if (currentconnection.NextID == currentfield.EastConnection.NextID && currentboxfield.EastConnection.NextID == 0)
			{
				return false;
			}
			else if (currentconnection.NextID == currentfield.SouthConnection.NextID && currentboxfield.SouthConnection.NextID == 0)
			{
				return false;
			}
			else if (currentconnection.NextID == currentfield.WestConnection.NextID && currentboxfield.WestConnection.NextID == 0)
			{
				return false;
			}

			return true;
		}



        public bool DirectionIsPossible(ConnectionModel oppositesite)
        {
            if (oppositesite.NextID == 0)
            {
                return false;
            }

            return true;
        }
    }
}
