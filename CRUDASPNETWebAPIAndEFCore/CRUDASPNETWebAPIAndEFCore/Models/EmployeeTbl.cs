﻿using System;
using System.Collections.Generic;

namespace CRUDASPNETWebAPIAndEFCore.Models
{
    public partial class EmployeeTbl
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salary { get; set; }
    }
}
