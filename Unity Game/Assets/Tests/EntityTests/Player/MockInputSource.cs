using Core.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTests.Player
{
    internal class MockInputSource : IInputSource
    {
        public Intent BuildIntent()
        {
            throw new NotImplementedException();
        }
    }
}
