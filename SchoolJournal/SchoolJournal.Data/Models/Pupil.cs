namespace SchoolJournal.Models.DB
{
    public class Pupil
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid StreamId { get; set; }
        public Stream Stream { get; set; }

    }
}
