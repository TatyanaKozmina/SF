﻿using System.ComponentModel.DataAnnotations;

namespace SchoolJournal.Models.DB
{
    public class Stream
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [DataType(DataType.Date)]
        public DateTime Started { get; set; }
        public int CurrentClass { get; set; }
        public bool IsCompleted { get; set; }
        List<Pupil> Pupils { get; set; } = new List<Pupil>();
    }
}
