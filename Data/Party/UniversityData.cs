using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamUP.Data.Party
{
    public sealed class UniversityData : EntityData
    {
        public string UniversityName { get; set; } = string.Empty;
        public string? UniversityLocation { get; set; }
        public int? StudentsAmount { get; set; }
        public int? CostOfStudying { get; set; }
        public string? Currency { get; set; }
    }
}
