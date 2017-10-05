using System;
using System.Collections.Generic;
using Sokoban.Models;
namespace Sokoban.Models
{
    public class RouteModel
    {
        public int beginid { get; set; }
        public int endid { get; set; }
        public List<ConnectionModel> previousconnections { get; set; }
        public bool RouteIsPossible { get; set; }
    }
}
