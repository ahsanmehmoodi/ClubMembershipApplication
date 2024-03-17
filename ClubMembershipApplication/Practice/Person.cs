using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace ClubMembershipApplication.Practice
{
    internal class Person
    {
        public int id { get; set; }
        public string name { get; set; }    
        public int age { get; set; }
    }
    public class Pet
    {
        public int id { get; set; }
        public string name { get; set; }
        public int ownerId { get; set; }
    }
    public class student 
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class clas
    {
        public int id { get; set; } 
        public string name { get; set; }
        public student students { get; set; }
        public int  stdId { get; set; }
    }
}
