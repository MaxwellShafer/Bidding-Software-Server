﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    /// <summary>
    /// LoginState enum definition
    /// </summary>
    public enum LoginState
    {
        START,
        GOTUSERNAME,
        GOTPASSWORD,
        DECLINED,
        EXIT
    }
}
