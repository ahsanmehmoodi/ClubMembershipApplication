using System;
using System.Collections.Generic;
using System.Text;

namespace ClubMembershipApplication.Practice
{
    internal class Car
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string model { get; set; }

        public string getNamewithModel()
        {
            return $"Car Name:{name} & model is {model} ";
        }
        public string getNamewithModelID()
        {
            return $"Car Name:{name} & model is {model} and id is {id} ";
        }
    }
    
}
