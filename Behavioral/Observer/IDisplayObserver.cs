using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.Observer
{
    public interface IDisplayObserver
    {
        int Id { get;}

        void Update();
    }
}
