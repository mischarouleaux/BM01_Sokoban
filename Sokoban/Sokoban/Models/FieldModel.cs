using System;
namespace Sokoban.Models
{
    public class FieldModel
    {
        public int ID { get; set; }
        public ConnectionModel NorthConnection { get; set; }
        public ConnectionModel EastConnection { get; set; }
        public ConnectionModel SouthConnection { get; set; }
        public ConnectionModel WestConnection { get; set; }
    }
}
