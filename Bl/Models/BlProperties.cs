using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class BlProperties
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        //public  List<PointsTestTbl> PointsTestTbls { get; set; } = new List<PointsTestTbl>();

        //public  List<RequestsTbl> RequestsTbls { get; set; } = new List<RequestsTbl>();
    }
}
