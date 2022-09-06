using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Sprint
    {
        [Key]
        public int SprintId { get; set; }
        public int ScrumTeamId { get; set; }
        public ScrumTeam ScrumTeam { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<UserSprintHappinessMetricCategory> UserSprintHappinessMetricCategories { get; set; }
    }
}
