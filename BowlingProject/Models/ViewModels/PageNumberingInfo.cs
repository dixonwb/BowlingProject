using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//this class will be important for our pagination tag helper

namespace BowlingProject.Models.ViewModels
{
    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        //calculate number of pages
        public int NumPages => (int) (Math.Ceiling((decimal) TotalNumItems / NumItemsPerPage));

    }
}
