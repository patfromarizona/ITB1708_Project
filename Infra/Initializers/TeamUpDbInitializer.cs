namespace TeamUP.Infra.Initializers {
    public static class TeamUpDbInitializer {
        public static void Init(TeamUPDb? db) {
            new StudentsInitializer(db).Init();
            new TeamWorksInitializer(db).Init();
            new UniversitiesInitializer(db).Init();
            new LocationsInitializer(db).Init();
        }
    }
}
