﻿
using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public interface IUniversitiesRepo : IRepo<University> { }
    public sealed class University : Entity<UniversityData>
    {
        public University() : this (new UniversityData()) { }
        public University(UniversityData d) : base(d) { }
        public string Name => getValue(Data?.Name);
        public string Location => getValue(Data?.Location);
        public int StudentsAmount => getValue(Data?.StudentsAmount);
        public int CostOfStudying => getValue(Data?.CostOfStudying);
        public string Currency => getValue(Data?.Currency);

        public override string ToString() => $"{Name}, {Location}, {StudentsAmount} students (average price: {CostOfStudying} {Currency} / year)";
    }
}
