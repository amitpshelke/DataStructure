using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoExpert.io.Easy
{
    /*
      CLASS PHOTOS

      It's photo day at the local school, and you're the photographer assigned to take class photos. The class that you'll be photographing has an even number
      of students, and all these students are wearing red or blue shirts. In fact, exactly half of the class is wearing red shirts, and the other half is wearing
      blue shirts. You're responsible for arranging the students in two rows before taking the photo. Each row should contain the same number of the students and
      should adhere to the following guidelines:

        - All students wearing red shirts must be in the same row.</li>
        - All students wearing blue shirts must be in the same row.</li>
        - Each student in the back row must be strictly taller than the student directly in front of them in the front row.
    
      You're given two input arrays: one containing the heights of all the students with red shirts and another one containing the heights of all the students
      with blue shirts. These arrays will always have the same length, and each height will be a positive integer. Write a function that returns whether or
      not a class photo that follows the stated guidelines can be taken.

      Note: you can assume that each class has at least 2 students.

      INPUT
      redShirtHeights = [5, 8, 1, 3, 4]

      blueShirtHeights = [6, 9, 2, 4, 5]


      OUTPUT
      true // Place all students with blue shirts in the back row

    */
    class A10
    {
        public bool ClassPhotos(List<int> redShirtHeights, List<int> blueShirtHeights)
        {
            redShirtHeights.Sort((a,b)=> b.CompareTo(a));
            blueShirtHeights.Sort((a, b) => b.CompareTo(a));

            string shirtColorInFirstRow = redShirtHeights[0] < blueShirtHeights[0] ? "RED" : "BLUE";

            for (int idx = 0; idx < redShirtHeights.Count; idx++)
            {
                int redShirtHeight = redShirtHeights[idx];
                int blueSHirtHeight = blueShirtHeights[idx];

                if (shirtColorInFirstRow == "RED")
                {
                    if (redShirtHeight >= blueSHirtHeight) return false;

                    else if (blueSHirtHeight >= redShirtHeight) return true;
                }
            }
            return true;
        }
    }
}
