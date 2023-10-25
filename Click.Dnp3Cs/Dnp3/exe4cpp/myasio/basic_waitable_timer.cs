using System;
using System.Collections.Generic;
using System.Diagnostics;

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
	public std::chrono.steady_clock.time_point expires_at()
	{
		std::chrono.steady_clock.time_point t = new std::chrono.steady_clock.time_point();
		return new std::chrono.steady_clock.time_point(t);
	}

	public std::chrono.steady_clock.time_point expires_at(std::chrono.steady_clock.time_point time)
	{
		return new std::chrono.steady_clock.time_point(time);
	}
//	void cancel(){}
	public void cancel(std::error_code ec)
	{
	}

}

} // namespace asio

