using GradeBook.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count() < 5) throw new InvalidOperationException("There should be at least 5 students.");

            int aboveStudentsCount = 0;
            foreach (var student in Students) if (student.AverageGrade > averageGrade) aboveStudentsCount++;
            double studentPercent = ((aboveStudentsCount + 1) * 100) /Students.Count();

            if (0 <= studentPercent && studentPercent <= 20)
                return 'A';
            else if (20 < studentPercent && studentPercent <= 40)
                return 'B';
            else if (40 < studentPercent && studentPercent <= 60)
                return 'C';
            else if (60 < studentPercent && studentPercent <= 80)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count() < 5)
            {
                Console.Write("Ranked grading requires at least 5 students.");
                return;
            }
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count() < 5) 
            { 
                Console.Write("Ranked grading requires at least 5 students.");
                return; 
            }
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
