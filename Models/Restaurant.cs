using System;

namespace restauranter.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string ReviewerName { get; set; }
        public string RestaurantName { get; set; }
        public string Review { get; set; }
        public int Stars { get; set; }
        public string VisitDate { get; set; }
    }
}