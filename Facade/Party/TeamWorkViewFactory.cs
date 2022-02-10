using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Facade.Party{
    public class TeamWorkViewFactory{
        public TeamWork Create(TeamWorkView v) => new TeamWork(new TeamWorkData{           
            TeamWorkId = v.TeamWorkId,
            Name = v.Name,
            Description = v.Description,
            TeamSize = v.TeamSize,
            Deadline = v.Deadline,
            Done = v.Done            
        });
        public TeamWorkView Create(TeamWork o) => new(){
            TeamWorkId = o.TeamWorkId,
            Name = o.Name,
            Description = o.Description,
            TeamSize = o.TeamSize,
            Deadline = o.Deadline,
            Done = o.Done,
            Overview = o.ToString()
        };
    }
}
