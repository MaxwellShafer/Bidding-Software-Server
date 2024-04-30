using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    /// <summary>
    /// ServerState enum
    /// </summary>
    public enum ServerState
    {
        INIT,
        LOGIN,
        WAIT,
        UPDATING,
        SENDING
    }
}
