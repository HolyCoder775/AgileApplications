using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserSprintHappinessMetricCategory
    {
        [Key]
        public int UserSprintHappinessMetricCategoryId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }  
        public int HappinessMetricCategoryId { get; set; }
        public HappinessMetricCategory HappinessMetricCategory { get; set; }
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }  
        public int Score { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
