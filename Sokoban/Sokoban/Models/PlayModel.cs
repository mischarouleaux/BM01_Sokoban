using System;
using System.Collections.Generic;
namespace Sokoban.Models
{
    public class PlayModel
    {
        public int ID { get; set; }
        public List<FieldModel> Fields { get; set; }
        public int Player {get;set;}
        public int FirstBoxID { get; set; }
        public int SecondBoxID { get; set; }
        public int FirstObjectiveID { get; set; }
        public int SecondObjectiveID { get; set; }
    }
}
