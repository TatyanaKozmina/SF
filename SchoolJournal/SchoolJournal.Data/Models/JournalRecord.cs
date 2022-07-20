using System.ComponentModel.DataAnnotations;

namespace SchoolJournal.Models.DB
{
    public class JournalRecord
    {   
        [DataType(DataType.Date)]
        public DateTime Created { get; set; } = DateTime.Today;
        public Subject Subject { get; set; }

        [Range(2, 5,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Mark { get; set; }
        public string? Comment { get; set; }

        public Guid PupilId { get; set; }
        public Pupil Pupil { get; set; }
    }
}
