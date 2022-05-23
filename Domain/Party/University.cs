
using TeamUP.Data.Party;

namespace TeamUP.Domain.Party {
    public interface IUniversitiesRepo : IRepo<University> { }
    public sealed class University : Entity<UniversityData> {
        public University() : this(new()) { }
        public University(UniversityData d) : base(d) { }
        public string Name => getValue(Data?.Name);
        public string Location => getValue(Data?.Location);
        public int StudentsAmount => getValue(Data?.StudentsAmount);
        public int CostOfStudying => getValue(Data?.CostOfStudying);
        public string Currency => getValue(Data?.Currency);
        public override string ToString() => $"{Name}, {Location}, {StudentsAmount} students (average price: {CostOfStudying} {Currency} / year)";
        public List<UniversityStudent> UniversityStudents => GetRepo.Instance<IUniversityStudentRepo>()?
           .GetAll(x => x.UniversityId)?
           .Where(x => x.UniversityId == Id)?
           .ToList() ?? new List<UniversityStudent>();
        public List<Student?> Students => UniversityStudents
            .Select(x => x.Student)
            .ToList() ?? new List<Student?>();
    }
}
