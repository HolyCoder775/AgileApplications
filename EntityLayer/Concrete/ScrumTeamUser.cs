using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ScrumTeamUser
    {
        public int ScrumTeamUserId { get; set; }
        public int ScrumTeamId { get; set; }
        public ScrumTeam ScrumTeam { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
