using System;
using System.Collections.Generic;

namespace Api005.Todo
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
