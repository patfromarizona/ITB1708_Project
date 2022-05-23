namespace TeamUP.Data.Party {
    public sealed class StudentData : EntityData {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IsoGender? Gender { get; set; }
        public int? Age { get; set; }
        public int? YearInUniversity { get; set; }
    }
}
