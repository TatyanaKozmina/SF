using System.ComponentModel.DataAnnotations;

namespace SchoolJournal.Models.DB
{
    public class Pupil
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Поток")]
        public Guid StreamId { get; set; }
        public Stream Stream { get; set; }

    }
}
