﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson06.Models.Finance
{
    internal class Expense : Transaction
    {
        public int TotalLimit { get; set; }
    }
}
