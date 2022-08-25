using LINQ_Standard_Query_Operators.Class;
using LINQ_Standard_Query_Operators.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Standard_Query_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "humpty", "dumpty", "set", "on", "a", "wall" };

            int[] numbers_array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] empty_array = { };

            IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentFirstName = "John", StudentLastName = "Smith" , Age = 18 } ,
            new Student() { StudentID = 2, StudentFirstName = "Bill", StudentLastName = "Clinton" , Age = 15 } ,
            new Student() { StudentID = 3, StudentFirstName = "Josh", StudentLastName = "DeSanta" ,Age = 25 } ,
            new Student() { StudentID = 4, StudentFirstName = "Amy", StudentLastName = "Santiago" ,Age = 20 } ,
            new Student() { StudentID = 5, StudentFirstName = "Jack", StudentLastName = "Dow" ,Age = 19 },
            new Student() { StudentID = 6, StudentFirstName = "Jesse", StudentLastName = "Pink" ,Age = 18 },
            new Student() { StudentID = 7, StudentFirstName = "Josh", StudentLastName = "Keneth" , Age = 17 } 
            };

            IList<Standard> standardList = new List<Standard>() {
            new Standard() { StandardID = 1, Class = 1, Floor = 1, Capacity = 28 },
            new Standard() { StandardID = 2, Class = 2, Floor = 2, Capacity = 35 },
            new Standard() { StandardID = 3, Class = 3, Floor = 3, Capacity = 45 },
            new Standard() { StandardID = 4, Class = 4, Floor = 4, Capacity = 50 },
            new Standard() { StandardID = 5, Class = 5, Floor = 5, Capacity = 59 },
            new Standard() { StandardID = 6, Class = 6, Floor = 6, Capacity = 68 }
            };

            //----------------------------------------

            //Filter Queries

            //Where
            var Where_query = from word in words where word.Length == 4 select word;

            //OfType
            var OfType_query = from word in words.OfType<String>() select word;

            foreach (string str in Where_query)
                Console.WriteLine(str);

            foreach (string str in OfType_query)
                Console.Write(str);

            //----------------------------------------

            //Sorting Queries

            Console.WriteLine("\n------------------Sorting Queries----------------------");

            //OrderBy

            var OrderBy_query = from word in words orderby word.Length select word;

            Console.WriteLine("Elements in OrderBy \n");
            foreach (string element in OrderBy_query)
                Console.WriteLine(element);

            Console.WriteLine("----------------------------------------");

            //OrderByDecending

            var OrderByDescending_query = from word in words orderby word.Length descending select word;

            Console.WriteLine("Elements in OrderBy Descending \n");
            foreach (string element in OrderByDescending_query)
                Console.WriteLine(element);

            Console.WriteLine("----------------------------------------");

            //ThenBy

            var ThenBy_query = studentList.OrderBy(s => s.StudentFirstName).ThenBy(s => s.Age);

            foreach (var element in ThenBy_query)
                Console.WriteLine("Student Name: {0}, Student Age: {1}", element.StudentFirstName, element.Age);

            var ThenByDescending_query = studentList.OrderBy(s => s.StudentFirstName).ThenByDescending(s => s.Age);

            Console.WriteLine("----------------------------------------");

            //ThenByDescending

            foreach (var element in ThenByDescending_query)
                Console.WriteLine("Student Name: {0}, Student Age: {1}", element.StudentFirstName, element.Age);

            Console.WriteLine("----------------------------------------");

            //Reverse
            var Reverse_Query = (from numbers in numbers_array select numbers).Reverse();

            Console.WriteLine("Reversed Numbers are:");
            foreach (var element in Reverse_Query)
                Console.WriteLine(element);

            //----------------------------------------

            //Grouping

            Console.WriteLine("\n------------------Grouping Queries----------------------");

            //GroupBy

            var GroupBy_query = from s in studentList
                                group s by s.Age;

            Console.WriteLine("\n GroupBy");
            foreach (var element in GroupBy_query)
            {
                Console.WriteLine("Age Group: {0}", element.Key);
                foreach (Student s in element)
                    Console.WriteLine("Student Name: {0}", s.StudentFirstName);
            }

            //ToLookUp
            //Only difference is GroupBy execution is deferred, whereas ToLookup execution is immediate.
            //ToLookup is not supported in the query syntax.

            var ToLookUp = studentList.ToLookup(s => s.Age);

            Console.WriteLine("\n ToLookUp");
            foreach (var element in ToLookUp)
            {
                Console.WriteLine("Age Group: {0}", element.Key);
                foreach (Student s in element)
                    Console.WriteLine("Student Name: {0}", s.StudentFirstName);
            }

            Console.WriteLine("\n------------------Join Queries----------------------");

            //GroupJoin
            Console.WriteLine("GroupJoin\n");
            var GroupJoin_query = standardList.GroupJoin(studentList,
                std => std.Class,
                s => s.Age,
                (std, studentsGroup) => new
                {
                    Student = studentsGroup,
                    Capacity = std.Capacity
                });

            foreach (var element in GroupJoin_query)
            {
                Console.WriteLine(element.Capacity);
            }

            Console.WriteLine("----------------");

            //Join
            Console.WriteLine("Join\n");
            var innerJoinResult = studentList.Join(// outer sequence 
                      standardList,  // inner sequence 
                      student => student.StudentID,    // outerKeySelector
                      standard => standard.StandardID,  // innerKeySelector
                      (student, standard) => new  // result selector
                      {
                          StudentName = student.StudentFirstName,
                          StandardName = standard.Class
                      });

            foreach (var obj in innerJoinResult)
            {

                Console.WriteLine("{0} - {1}", obj.StudentName, obj.StandardName);
            }

            Console.WriteLine("\n------------------Projection Queries----------------------");

            //Select
            var select_query = from s in studentList
                               select s.StudentFirstName;

            Console.WriteLine("Select Query\n");

            foreach (var element in select_query)
            {
                Console.WriteLine("{0}", element);
            }

            //SelectMany
            var selectMany_query = from s in studentList
                                   from p in s.StudentFirstName.Split('a')
                               select p;

            Console.WriteLine("SelectMany Query\n");

            foreach (var element in selectMany_query)
            {
                Console.WriteLine("{0}", element);
            }

            Console.WriteLine("\n------------------Aggregate Queries----------------------");

            //Aggregate
            Console.WriteLine("Aggregate Query");

            string Aggregate_query = studentList.Aggregate<Student, string>(
                "Student Names:",
                (str, s) => str += s.StudentFirstName + ",");
            Console.WriteLine(Aggregate_query);

            //Average
            Console.WriteLine("\nAverage Query\n");

            var Average_query = numbers_array.Average();
            Console.WriteLine("Average : {0}", Average_query);

            //Sum
            Console.WriteLine("\nSum Query\n");

            var Sum_query = numbers_array.Sum();
            Console.WriteLine("Sum : {0}", Sum_query);

            //Count
            Console.WriteLine("\nCount Query\n");

            var Count_query = numbers_array.Count();
            Console.WriteLine("Count : {0}", Count_query);

            //LongCount
            Console.WriteLine("\nLongCount Query\n");

            var LongCount_query = numbers_array.LongCount();
            Console.WriteLine("LongCount : {0}", LongCount_query);

            //Max
            Console.WriteLine("\nMax Query\n");

            var Max_query = numbers_array.Max();
            Console.WriteLine("Max : {0}", Max_query);

            //Max
            Console.WriteLine("\nMax Query\n");

            var Min_query = numbers_array.Min();
            Console.WriteLine("Min : {0}", Min_query);

            Console.WriteLine("\n------------------Quantifiers Queries----------------------");

            //All
            //The All operator evalutes each elements in the given collection on a specified condition and
            //returns True if all the elements satisfy a condition.
            
            bool All_query = studentList.All(s => s.Age > 30);
            Console.WriteLine("All_query: {0}", All_query);

            //Any
            //Any checks whether any element satisfy given condition or not? In the following example,
            //Any operation is used to check whether any student is teen ager or not.

            bool Any_query = studentList.Any(s => s.Age > 10);
            Console.WriteLine("Any Query: {0}", Any_query);

            //Contains
            //Checks if certain element is present in the collection.

            bool Contains_query = numbers_array.Contains(20);
            Console.WriteLine("Contains Query: {0}", Contains_query);

            Console.WriteLine("\n------------------Elements Queries----------------------");

            //ElementAt
            Console.WriteLine("ElementAt Query");

            Console.WriteLine("1st Element is: {0}", numbers_array.ElementAt(0));

            //ElementAtOrDefault
            Console.WriteLine("ElementAtOrDefault Query");

            Console.WriteLine("Specific Element at index or default element is: {0}", numbers_array.ElementAtOrDefault(99));

            //First
            //The First() method returns the first element of a collection, or the first element that satisfies the specified
            //condition using lambda expression or Func delegate.
            Console.WriteLine("\nFirst Query");

            Console.WriteLine("First Element is: {0}", numbers_array.First());
            Console.WriteLine("First Element which fulfills the conidition is: {0}", numbers_array.First(i => i + 1 == 3));

            //FirstOrDefault
            Console.WriteLine("\nFirstOrDefault Query");

            Console.WriteLine("FirstOrDefault Element is: {0}", empty_array.FirstOrDefault()); //Here FirstOrDefault will return the value if present and default data type if not present.
            Console.WriteLine("FirstOrDefault Element which fulfills the conidition is: {0}", numbers_array.FirstOrDefault(i => i + 1 == 99));

            //Last
            Console.WriteLine("\nLast Query");

            Console.WriteLine("Last Element is: {0}", numbers_array.Last());
            Console.WriteLine("Last Element which fulfills the condition is: {0}", numbers_array.Last(i => i - 2 == 1));

            //LastOrDefault
            Console.WriteLine("\nLastOrDefault Query");

            Console.WriteLine("LastOrDefault Element is: {0}", numbers_array.LastOrDefault());
            Console.WriteLine("LastOrDefault Element which fulfills the condition is: {0}", numbers_array.LastOrDefault(i => i -2 == 1));

            //Single
            //Single() returns the only element from a collection, or the only element that satisfies the specified condition. If a given collection includes no elements or
            //more than one elements then Single() throws InvalidOperationException.
            
            Console.WriteLine("\nSingle Query");

            int[] single_element_array = { 1 };
            Console.WriteLine("Single element from collection is: {0}", single_element_array.Single());

            //SingleOrDefault
            Console.WriteLine("SingleOrDefault element from collection is: {0}", empty_array.SingleOrDefault());

            Console.WriteLine("\n------------------Set Queries----------------------");

            //Distinct
            //The Distinct extension method returns a new collection of unique elements from the given collection.
            //Distinct is not supported in C# query syntax

            Console.WriteLine("Distinct Query");

            int[] duplicate_elements = { 2, 2, 2, 2, 3, 1, 1, 13, 3, 2323, 5, 6 };

            var Distinct_query = duplicate_elements.Distinct();
            
            foreach(var element in Distinct_query)
            {
                Console.WriteLine("Distinct Element from the collection is: {0}", element);
            }

            //Except

            Console.ReadLine();
        }
    }
}
