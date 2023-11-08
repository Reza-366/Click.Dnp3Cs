using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * basicwaitabletimer.h
 *
 *  Created on: Jun 1, 2023
 *      Author: Reza
 */



namespace asio
{


//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<typename _Tp>
public class basic_waitable_timer <_Tp> : System.IDisposable
{
  //    template<typename... _Args>

	public basic_waitable_timer()
	{
	}
	public virtual void Dispose()
	{
	}
	public DateTime expires_at()
	{
		DateTime t = new DateTime();
		return new DateTime();
	}

	public DateTime expires_at(DateTime time)
	{
		return new DateTime();
	}
//	void cancel(){}
	public void cancel(/*std::error_code*/ int ec)
	{
	}

}

} // namespace asio

