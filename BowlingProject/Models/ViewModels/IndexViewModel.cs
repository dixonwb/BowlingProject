using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//this contains important info that will be passed between the view and the controller
//list of bowlers, pagenumberinginfo object, and teamname

namespace BowlingProject.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowlers> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string TeamName { get; set; }
    }
}
