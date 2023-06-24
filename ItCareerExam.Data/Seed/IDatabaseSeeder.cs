namespace ItCareerExam.Data.Seed;

public interface IDatabaseSeeder
{
    void SeedRoles(params string[] roleNames);
}
