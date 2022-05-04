using System;
using System.Collections.Generic;

namespace Api005.Model
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Salary { get; set; }
    }
}
