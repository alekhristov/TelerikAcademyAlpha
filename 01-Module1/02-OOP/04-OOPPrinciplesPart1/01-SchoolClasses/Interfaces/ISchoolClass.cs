using System.Collections.Generic;

namespace _01_SchoolClasses
{
    interface ISchoolClass
    {
        char Identifier { get; }

        List<Student> Students { get; }

        List<Teacher> Teachers { get; }
    }
}
