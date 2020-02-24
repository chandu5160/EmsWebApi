using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Domain.Common
{
    public abstract class Model
    {
        public int Id { get; set; }

        public bool Status { get; private set; }

        public void SetStatus(bool value)
        {
            Status = value;
        }
    }
}
