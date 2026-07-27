namespace Application.CQRS.Narrators
{
    public record NarratorDetailsResponse
  (
    int Id,
    int? Number,
    string? Name,
    string? Gender,
    string? Kunya,
    string? Nickname,
    string? Nasab,
    string? Description,
    string? Title,
    string? Activity,
    string? Madhhab,
    string? Rank,
    string? Layer,
    string? DeathYear,
    string? BirthYear,
    string? Age,
    string? Residence,
    string? DeathPlace,
    string? Relatives,
    string? Mawali,
    string? NarratedFor,
    string? Kamal,
    string? SirAlamAlNubala,
    string? SifatAlSafwa,
        List<NarratorStudentListResponse> NarratorStudents,
        List<NarratorTeacherListResponse> NarratorTeachers,
        List<NarratorsCriticismListResponse> NarratorsCriticisms

    );

    public record NarratorStudentListResponse
        (
            int Id,
         string Name,
         string? Kunya,
         string? Honorific,
         string? Lineage
    );
    public record NarratorTeacherListResponse
      (
      int Id,
     string Name,
   string? Kunya,
   string? Honorific,
   string? Lineage
  );
    public record NarratorsCriticismListResponse
      (int Id,
          string? CriticName,
     string? CriticStatement
  );
}
