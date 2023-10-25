using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal static class DefineConstants
{
#if ! (! OPENDNP3_SUPPRESS_LOG_LOCATION)
	public const string LOCATION = "";
#endif
}
