using Domain.Primitives;

namespace Domain.Aggregates.BookAggregate
{
    public class Narrator : AggregateRootEntityBase<int>
    {

        public int? Number { get; set; }
        public string? Name { get; set; }

        public string? Gender { get; set; }
        public string? Kunya { get; set; }
        public string? Nickname { get; set; }
        public string? Nasab { get; set; }

        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Activity { get; set; }
        public string? Madhhab { get; set; }

        public string? Rank { get; set; }
        public string? Layer { get; set; }

        public string? DeathYear { get; set; }
        public string? BirthYear { get; set; }
        public string? Age { get; set; }

        public string? Residence { get; set; }
        public string? DeathPlace { get; set; }

        public string? Relatives { get; set; }
        public string? Mawali { get; set; }
        public string? NarratedFor { get; set; }

        public string? Kamal { get; set; }


        public string? SirAlamAlNubala { get; set; }
        public string? SifatAlSafwa { get; set; }

        List<NarratorTeacher> _narratorTeachers = new List<NarratorTeacher>();
        public IReadOnlyCollection<NarratorTeacher> NarratorTeachers => _narratorTeachers;

        List<NarratorStudent> _narratorStudents = new List<NarratorStudent>();
        public IReadOnlyCollection<NarratorStudent> NarratorStudents => _narratorStudents;

        List<NarratorsCriticism> _narratorsCriticisms = new List<NarratorsCriticism>();
        public IReadOnlyCollection<NarratorsCriticism> NarratorsCriticisms => _narratorsCriticisms;

        public Narrator()
        {
        }
        public Narrator(
    int Id,
    int? number,
    string? name,
    string? gender,
    string? kunya,
    string? nickname,
    string? nasab,
    string? description,
    string? title,
    string? activity,
    string? madhhab,
    string? rank,
    string? layer,
    string? birthYear,
    string? deathYear,
    string? age,
    string? residence,
    string? deathPlace,
    string? relatives,
    string? mawali,
    string? narratedFor,
    string? kamal,
    string? sirAlamAlNubala,
    string? sifatAlSafwa,
    bool isActive
)
        {
            Id = Id;
            Number = number;
            Name = name;
            Gender = gender;
            Kunya = kunya;
            Nickname = nickname;
            Nasab = nasab;
            Description = description;
            Title = title;
            Activity = activity;
            Madhhab = madhhab;
            Rank = rank;
            Layer = layer;
            BirthYear = birthYear;
            DeathYear = deathYear;
            Age = age;
            Residence = residence;
            DeathPlace = deathPlace;
            Relatives = relatives;
            Mawali = mawali;
            NarratedFor = narratedFor;
            Kamal = kamal;


            SirAlamAlNubala = sirAlamAlNubala;
            SifatAlSafwa = sifatAlSafwa;

            IsActive = isActive;
        }


        public static Narrator Create(
      int Id,
      int? number,
      string name,
      string? gender,
      string? kunya,
      string? nickname,
      string? nasab,
      string description,
      string? title,
      string? activity,
      string? madhhab,
      string? rank,
      string? layer,
      string? birthYear,
      string? deathYear,
      string? age,
      string? residence,
      string? deathPlace,
      string? relatives,
      string? mawali,
      string? narratedFor,
      string? kamal,
      string? sirAlamAlNubala,
      string? sifatAlSafwa,
      bool isActive
  )
        {
            Validator.NotNullOrWhiteSpace(name);
            Validator.NotNullOrWhiteSpace(description);

            return new Narrator(
                Id,
                number,
                name,
                gender,
                kunya,
                nickname,
                nasab,
                description,
                title,
                activity,
                madhhab,
                rank,
                layer,
                birthYear,
                deathYear,
                age,
                residence,
                deathPlace,
                relatives,
                mawali,
                narratedFor,
                kamal,

                sirAlamAlNubala,
                sifatAlSafwa,
                isActive
            );
        }


        public void Update(
    string name,
    string description,
    bool isActive,
    string? gender,
    string? kunya,
    string? nickname,
    string? nasab,
    string? title,
    string? activity,
    string? madhhab,
    string? rank,
    string? layer,
    string? birthYear,
    string? deathYear,
    string? age,
    string? residence,
    string? deathPlace,
    string? relatives,
    string? mawali,
    string? narratedFor,
    string? kamal,

    string? sirAlamAlNubala,
    string? sifatAlSafwa
)
        {
            Validator.NotNullOrWhiteSpace(name);
            Validator.NotNullOrWhiteSpace(description);

            Name = name;
            Description = description;
            IsActive = isActive;

            Gender = gender;
            Kunya = kunya;
            Nickname = nickname;
            Nasab = nasab;
            Title = title;
            Activity = activity;
            Madhhab = madhhab;
            Rank = rank;
            Layer = layer;

            BirthYear = birthYear;
            DeathYear = deathYear;
            Age = age;

            Residence = residence;
            DeathPlace = deathPlace;
            Relatives = relatives;
            Mawali = mawali;
            NarratedFor = narratedFor;
            Kamal = kamal;

            SirAlamAlNubala = sirAlamAlNubala;
            SifatAlSafwa = sifatAlSafwa;
        }

    }
}
