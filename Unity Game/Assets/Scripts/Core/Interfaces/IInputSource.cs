using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Input
{
    public interface IInputSource
    {
        public Intent BuildIntent();
    }
}
