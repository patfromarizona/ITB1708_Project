namespace TeamUP.Data.Party {
    public sealed class UniversityData : EntityData {
        public string Name { get; set; } = string.Empty;
        public string? Location { get; set; }
        public int? StudentsAmount { get; set; }
        public int? CostOfStudying { get; set; }
        public string? Currency { get; set; }
    }
}
