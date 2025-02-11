﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Core.Entities
{
    public abstract class BaseEntity
    {
        public virtual string id { get; protected set; } = Guid.NewGuid().ToString();
    }
}
