using System;
using System.Collections.Generic;
using Sokoban.Models;
namespace Sokoban.Services
{
    public class CreateFirstPlayField
    {
        public CreateFirstPlayField()
        {
            var model = new PlayModel();

            model.ID = 1;
            model.Player = 7;
            model.FirstBoxID = 4;
            model.SecondBoxID = 10;
            model.FirstObjectiveID = 5;
            model.SecondObjectiveID = 15;

            var fields = new List<FieldModel>();
            fields.Add(new FieldModel
            {
                ID = 1,
                NorthConnection = new ConnectionModel { CurrentID = 1, NextID = 0, Direction = 0 },
                EastConnection = new ConnectionModel { CurrentID = 1, NextID = 2, Direction = 1 },
                SouthConnection = new ConnectionModel { CurrentID = 1, NextID = 3, Direction = 2 },
                WestConnection = new ConnectionModel { CurrentID = 1, NextID = 0, Direction = 3 }
            });

            fields.Add(new FieldModel
            {
                ID = 2,
                NorthConnection = new ConnectionModel { CurrentID = 2, NextID = 0, Direction = 0 },
                EastConnection = new ConnectionModel { CurrentID = 2, NextID = 0, Direction = 1 },
                SouthConnection = new ConnectionModel { CurrentID = 2, NextID = 4, Direction = 2 },
                WestConnection = new ConnectionModel { CurrentID = 2, NextID = 3, Direction = 3 }
            });

            fields.Add(new FieldModel
            {
                ID = 3,
                NorthConnection = new ConnectionModel { CurrentID = 3, NextID = 1, Direction = 0 },
                EastConnection = new ConnectionModel { CurrentID = 3, NextID = 4, Direction = 1 },
                SouthConnection = new ConnectionModel { CurrentID = 3, NextID = 5, Direction = 2 },
                WestConnection = new ConnectionModel { CurrentID = 3, NextID = 0, Direction = 3 }
            });

            fields.Add(new FieldModel
            {
                ID = 4,
                NorthConnection = new ConnectionModel { CurrentID = 4, NextID = 2, Direction = 0 },
                EastConnection = new ConnectionModel { CurrentID = 4, NextID = 7, Direction = 1 },
                SouthConnection = new ConnectionModel { CurrentID = 4, NextID = 6, Direction = 2 },
                WestConnection = new ConnectionModel { CurrentID = 4, NextID = 3, Direction = 3 }
            });

            fields.Add(new FieldModel
            {
                ID = 5,
                NorthConnection = new ConnectionModel { CurrentID = 5, NextID = 3, Direction = 0 },
                EastConnection = new ConnectionModel { CurrentID = 5, NextID = 6, Direction = 1 },
                SouthConnection = new ConnectionModel { CurrentID = 5, NextID = 0, Direction = 2 },
                WestConnection = new ConnectionModel { CurrentID = 5, NextID = 0, Direction = 3 }
            });

            fields.Add(new FieldModel
            {
                ID = 6,
                NorthConnection = new ConnectionModel { CurrentID = 6, NextID = 4, Direction = 0 },
                EastConnection = new ConnectionModel { CurrentID = 6, NextID = 0, Direction = 1 },
                SouthConnection = new ConnectionModel { CurrentID = 6, NextID = 0, Direction = 2 },
                WestConnection = new ConnectionModel { CurrentID = 6, NextID = 5, Direction = 3 }
            });

            fields.Add(new FieldModel
            {
                ID = 7,
                NorthConnection = new ConnectionModel { CurrentID = 7, NextID = 0, Direction = 0 },
                EastConnection = new ConnectionModel { CurrentID = 7, NextID = 10, Direction = 1 },
                SouthConnection = new ConnectionModel { CurrentID = 7, NextID = 0, Direction = 2 },
                WestConnection = new ConnectionModel { CurrentID = 7, NextID = 4, Direction = 3 }
            });



            model.Fields = fields;
        }
    }
}
