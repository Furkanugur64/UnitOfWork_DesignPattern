﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CustomerProcess
    {
        public int CustomerProcessId { get; set; }
        public int SenderId { get; set; }
        public int ReveiverId { get; set; }
        public decimal Amount { get; set; }
    }
}
