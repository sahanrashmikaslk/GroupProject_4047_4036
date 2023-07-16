﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_4047_4036.Model
{
    public class StudentModule
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Module")]
        public int ModuleId { get; set; }

        public string Grade { get; set; }

        public int Credit { get; set; }

        public Student Student { get; set; }

        public Module Module { get; set; }
    }
}
