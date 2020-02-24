using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Common
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public bool Status { get; private set; }

        public void SetStatus(bool value)
        {
            Status = value;
        }
    }
}
