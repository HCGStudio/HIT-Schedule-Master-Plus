using System.Collections.Generic;
using HCGStudio.HITScheduleMasterCore;

namespace HITScheduleMasterPlus.Models
{
    public class EditableSchedule
    {
        public int Semester { get; set; }
        public int Year { get; set; }
        public List<ScheduleEntry> Entries { get; set; }
    }
}