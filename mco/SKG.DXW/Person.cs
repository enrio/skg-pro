using System;

namespace SKG.DXW
{
    class Person
    {
        public Person(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
            Comments = String.Empty;
        }

        public Person(string firstName, string secondName, string comments) : this(firstName, secondName) { Comments = comments; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Comments { get; set; }
    }
}