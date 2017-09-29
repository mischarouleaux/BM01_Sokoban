using System;
namespace Sokoban.Models
{
    public class ConnectionModel
    {
        public int CurrentID {get;set;}
        public int NextID { get; set; }
        public int Direction { get; set; }
        // 0 - North
        // 1 - East
        // 2 - South
        // 3 - West
    }
}
