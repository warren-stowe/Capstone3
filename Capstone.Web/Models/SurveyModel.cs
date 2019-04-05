using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public string ParkCode { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Invalid email address.")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "State")]
        [Required]
        public string State { get; set; }

        [Display(Name = "Activity Level")]
        [Required]
        public string ActivityLevel { get; set; }

        public Dictionary<string, SelectListItem> AllParks { get; } = new Dictionary<string, SelectListItem>();

        public static List<SelectListItem> States = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Alabama" },
            new SelectListItem() { Text = "Alaska" },
            new SelectListItem() { Text = "Arizona" },
            new SelectListItem() { Text = "Arkansas" },
            new SelectListItem() { Text = "California" },
            new SelectListItem() { Text = "Colorado" },
            new SelectListItem() { Text = "Connecticut" },
            new SelectListItem() { Text = "Delaware" },
            new SelectListItem() { Text = "Florida" },
            new SelectListItem() { Text = "Georgia" },
            new SelectListItem() { Text = "Hawaii" },
            new SelectListItem() { Text = "Idaho" },
            new SelectListItem() { Text = "Illinois" },
            new SelectListItem() { Text = "Indiana" },
            new SelectListItem() { Text = "Iowa" },
            new SelectListItem() { Text = "Kansas" },
            new SelectListItem() { Text = "Kentucky" },
            new SelectListItem() { Text = "Louisiana" },
            new SelectListItem() { Text = "Maine" },
            new SelectListItem() { Text = "Maryland" },
            new SelectListItem() { Text = "Massachusetts" },
            new SelectListItem() { Text = "Michigan" },
            new SelectListItem() { Text = "Minnesota" },
            new SelectListItem() { Text = "Mississippi" },
            new SelectListItem() { Text = "Missouri" },
            new SelectListItem() { Text = "Montana" },
            new SelectListItem() { Text = "Nebraska" },
            new SelectListItem() { Text = "Nevada" },
            new SelectListItem() { Text = "New Hampshire" },
            new SelectListItem() { Text = "New Jersey" },
            new SelectListItem() { Text = "New Mexico" },
            new SelectListItem() { Text = "New York" },
            new SelectListItem() { Text = "North Carolina" },
            new SelectListItem() { Text = "North Dakota" },
            new SelectListItem() { Text = "Ohio" },
            new SelectListItem() { Text = "Oklahoma" },
            new SelectListItem() { Text = "Oregon" },
            new SelectListItem() { Text = "Pennsylvania" },
            new SelectListItem() { Text = "Rhode Island" },
            new SelectListItem() { Text = "South Carolina" },
            new SelectListItem() { Text = "South Dakota" },
            new SelectListItem() { Text = "Tennessee" },
            new SelectListItem() { Text = "Texas" },
            new SelectListItem() { Text = "Utah" },
            new SelectListItem() { Text = "Vermont" },
            new SelectListItem() { Text = "Virginia" },
            new SelectListItem() { Text = "Washington" },
            new SelectListItem() { Text = "West Virginia" },
            new SelectListItem() { Text = "Wisconsin" },
            new SelectListItem() { Text = "Wyoming" }
        };

        public void ParksByName(Dictionary<string, string> names)
        {

            foreach (KeyValuePair<string, string> park in names)
            {
                AllParks.Add(park.Key, new SelectListItem() { Text = park.Value, Value = park.Key });
            }
        }

        public static List<SelectListItem> ActivityLevels = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Inactive" },
            new SelectListItem() { Text = "Sedentary" },
            new SelectListItem() { Text = "Active" },
            new SelectListItem() { Text = "Extremely Active" }
        };

    }
}
