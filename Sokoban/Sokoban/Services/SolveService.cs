using System;
using System.Collections.Generic;
using Sokoban.Models;
namespace Sokoban.Services
{
    public class SolveService
    {
        //Finds if there is a solution possible with the current model;
        public void GetBoxSolve(int firstboxid, int secondboxid, int firstobjectiveid, int secondobjectiveid, int playerid, PlayModel model)
        {
            bool solutionIsPossible = false;

            var firstidtofirstobjective = CheckRoute(firstboxid, firstobjectiveid, playerid, model);
            var secondidtosecondobjective = CheckRoute(secondboxid, secondobjectiveid, playerid, model);
            var firstidtosecondobjective = CheckRoute(firstboxid, secondobjectiveid, playerid, model);
            var secondidtofirstobjective = CheckRoute(secondboxid, firstobjectiveid, playerid, model);

            if (firstidtofirstobjective.RouteIsPossible == true && secondidtosecondobjective.RouteIsPossible == true)
            {
                solutionIsPossible = true;
            }
            else if (firstidtosecondobjective.RouteIsPossible == true && secondidtofirstobjective.RouteIsPossible == true)
            {
                solutionIsPossible = true;
            }
            else
            {
                //Gefaald, met het huidige spel is er geen oplossing
                //Probeer een blok op te lossen.

                if (firstidtofirstobjective.RouteIsPossible)
                {
                    //Volgende zet maken
                }
                if (secondidtosecondobjective.RouteIsPossible)
                {
					//Volgende zet maken
				}
                if (firstidtosecondobjective.RouteIsPossible)
                {
					//Volgende zet maken
				}
                if (secondidtofirstobjective.RouteIsPossible)
                {
					//Volgende zet maken
				}
            }

        }




        public RouteModel CheckRoute(FieldModel firstbox, FieldModel firstobjective, FieldModel secondbox, FieldModel secondobjective, FieldModel player, PlayModel model)
        {
            if ((firstbox.ID == firstobjective.ID || secondbox.ID == firstobjective.ID) && (firstbox.ID == secondobjective.id || secondbox.ID == secondobjective.ID))
            {
                //Box staat op de correcte plek
                //return true;
            }
            else
            {
                //Induction
                //return true;

            }
        }


        public List<ConnectionModel> GetPlayerPushDirections(int playerid, FieldModel box, FieldModel secondbox, PlayModel model)
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
                if (!PlayerPushIsPossible(connections[i], currentField, box, secondbox)) { PlayerDirectionIsPossible = false; }

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

        public bool PlayerPushIsPossible(ConnectionModel currentconnection, FieldModel currentfield, FieldModel firstcurrentboxfield, FieldModel secondcurrentboxfield)
		{
            //First part check direction, Second part check if next step contains the box, third part checks if the box direction == 0
            //Return false
            if (currentconnection.NextID == currentfield.NorthConnection.NextID)
			{
                if (currentfield.NorthConnection.NextID == 0)
                {
                    return false;
                }
                else if (currentconnection.NextID == firstcurrentboxfield.ID)
                {
                    if (firstcurrentboxfield.NorthConnection.NextID == 0 || firstcurrentboxfield.NorthConnection.NextID == secondcurrentboxfield.ID)
                    {
                        return false;
                    }
                    return true;
                }
                return true;
			}

            else if (currentconnection.NextID == currentfield.EastConnection.NextID)
			{
                if (currentfield.EastConnection.NextID == 0)
                {
                    return false;
                }
                else if (currentconnection.NextID == firstcurrentboxfield.ID)
                {
                    if (firstcurrentboxfield.EastConnection.NextID == 0 || firstcurrentboxfield.EastConnection.NextID == secondcurrentboxfield.ID)
                    {
                        return false;
                    }
                    return true;
                }
				return true;
			}

            else if (currentconnection.NextID == currentfield.SouthConnection.NextID)
			{
                if (firstcurrentboxfield.SouthConnection.NextID == 0)
                {
                    return false;
                }
                else if (currentconnection.NextID == firstcurrentboxfield.ID)
                {
                    if (firstcurrentboxfield.SouthConnection.NextID == 0 || firstcurrentboxfield.SouthConnection.NextID == secondcurrentboxfield.ID)
                    {
                        return false;
                    }
                    return true;
                }
				return true;
			}

            else if (currentconnection.NextID == currentfield.WestConnection.NextID)
			{
                if (firstcurrentboxfield.WestConnection.NextID == 0)
                {
                    return false;
                }
                else if (currentconnection.NextID == firstcurrentboxfield.ID)
                {
                    if (firstcurrentboxfield.WestConnection.NextID == 0 || firstcurrentboxfield.WestConnection.NextID == secondcurrentboxfield.ID)
                    {
                        return false;
                    }
                    return true;
                }
                return true;
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
