using System;
using System.Collections.Generic;
using System.Linq;
using ClubMembershipApplication.Data;
using ClubMembershipApplication.Models;
using System.Net.Mail;
using ClubMembershipApplication.Practice;
using ClubMembershipApplication.Views;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

using System.Data;

namespace ClubMembershipApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //IView mainView = Factory.GetMainViewObject();
            //mainView.RunView();
           Car car = new Car()
           {
               id = 1,
               model="2001",
               name="Honda Civic"
           };
            
            Console.WriteLine(car.getNamewithModel());

            List<Car> list = new List<Car>();
            list.Add(new Car { id = 2, name = "Corola", model = "2002" });
            list.Add(new Car { id = 3, name = "Corola", model = "2003" });
            list.Add(new Car { id = 4, name = "Corola", model = "2004" });
            foreach (var  item in list)
            {
                Console.WriteLine(item.getNamewithModelID());
            }

            List<Car> list2 = new List<Car>();
            for(int i = 0; i < 10; i++)
            {
                list2.Add(new Car { id = i, name = "new car" + i, model = "200,00" + i });
            }
            //for(int i = 0;i < 10; i++)
            //{
            //    Console.WriteLine(list2[i].getNamewithModelID());

            //}
            List<Person> person = new List<Person>
           {
               new Person {id=1,name="ahsan",age=15},
               new Person {id=2,name="ahsan awan",age=15},
               new Person {id=3,name="ahsan malik",age=15},
               new Person {id=4,name="ahsan khan",age=15},
           };
            List<Pet> pets = new List<Pet>
            {
                new Pet{id=1,name="Dog",ownerId=1},
                new Pet{id=1,name="Dog",ownerId=1},
                new Pet{id=1,name="Lion",ownerId=2}
            };

            var query = person.GroupJoin(pets, person => person.id, pets => pets.ownerId, (person, pet) => new
            {
                persons = person,
                pets = pet.DefaultIfEmpty(),
            }).SelectMany(result => result.pets.Select(pet => new
            {
                person = result.persons.name,
                petName = pet != null ? pet.name : "no Pet",
            }));
           
            foreach(var p in query)
            {
                Console.WriteLine($"Person from query1:{p.person} ,Pet:{p.petName}");
            }
            var query2 = person.Join(pets, person => person.id, pets => pets.ownerId, (person, pet) => new
            { persons = person,pet=pet }).Select(x=> new
            {
                person=x.persons.name,
                pet=x.pet.name
            });
            foreach(var p in query2)
            {
                Console.WriteLine($"Person from query2:{p.person} ,Pet:{p.pet}");
            }

            Console.WriteLine("------------------------------");

            Dictionary<string,List<student>> studentDatasets= new Dictionary<string,List<student>>();

            List<student> students = new List<student>
            {
                new student {id=1,name="Ahsan"},
                 new student {id=2,name="Ahsan Awan"},
                  new student {id=3,name="Ahsan Malik"},
            };
            List<student> students2 = new List<student>
            {
                new student {id=4,name="Ahsan khan"},
                 new student {id=5,name="Ahsan bangash"},
                  new student {id=6,name="Ahsan pathan"},
            };

            studentDatasets.Add("mydata", students);
            studentDatasets.Add("mydata1", students2);

           

            foreach(var student in studentDatasets)
            {
                Console.WriteLine(student.Key);
                foreach(var test in student.Value)
                {
                    Console.WriteLine(test.name);
                }
            }


            Console.WriteLine("----------------------");
            List<clas> clastest = new List<clas> {
                new clas
                {
                    id=1,
                    name="BS",
                    stdId=2,
                    students=new student
                    {
                        id=2,
                        name="ahsan"
                    }
                }
            };

            foreach(var test in clastest)
            {
                Console.WriteLine(test.name +" "+test.students.name);
                Console.WriteLine("===========================" );
            }
            
            Console.ReadKey();

            
           
        }


    }
}
