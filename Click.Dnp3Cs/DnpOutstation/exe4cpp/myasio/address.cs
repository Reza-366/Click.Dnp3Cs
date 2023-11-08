using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace asio
{
	namespace ip
	{

		public class address : System.IDisposable
		{
			public address()
			{
			}
			public static address from_string(string str, int ec)
			{
				return new address();
			}
			public void Dispose()
			{
			}

			//private:
		}
	}
}

