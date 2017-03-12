using System;

namespace DPXamarin.Core.Models
{
    public class ComicDate
    {
        public string type { get; set; }        //type(string, optional): A description of the date(e.g.onsale date, FOC date).,
        public DateTime date { get; set; }      //date(Date, optional): The date.
    }
}
