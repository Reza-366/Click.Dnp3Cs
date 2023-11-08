using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Copyright (c) 2018, Automatak LLC
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided that the
 * following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following
 * disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following
 * disclaimer in the documentation and/or other materials provided with the distribution.
 *
 * 3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote
 * products derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE
 * USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */


//#include "asio.hpp"

namespace exe4cpp
{

	/**
    *	A thread pool that calls asio::io_service::run
*/
	public class ThreadPool : System.IDisposable
	{

		/*  ///REZA
	public delegate void thread_init_t(uint UnnamedParameter);

	{
//	ThreadPool(asio::io_service io_service, uint concurrency) : ThreadPool(io_service, concurrency, (uint UnnamedParameter) =>
	}, (uint UnnamedParameter) =>
	{
	}){}ThreadPool(const asio.io_service * & io_service, uint concurrency, const thread_init_t & on_thread_start, const thread_init_t & on_thread_exit) : io_service({io_service}), on_thread_start({on_thread_start}), on_thread_exit({on_thread_exit}), infinite_timer({*io_service}){if (concurrency == 0){concurrency = 1;Tangible Method Implementation Not Foundexe4cpp.ThreadPool - ThreadPool
}

//C++ TO C# CONVERTER TASK: The following statement was not recognized, possibly due to an unrecognized macro:
		infinite_timer.expires_at(DateTime.max());
//C++ TO C# CONVERTER TASK: The following statement was not recognized, possibly due to an unrecognized macro:
		infinite_timer.async_wait((in /*std::error_code*/ int UnnamedParameter) =>
		{
		});

//C++ TO C# CONVERTER TASK: The following method format was not recognized, possibly due to an unrecognized macro:
		for (uint i = 0; i < concurrency; ++i)
		{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto run = [this, i]()
			var run = () =>
			{
				this.run(i);
			};
			threads.push_back(std::make_unique<std::thread>(run));
		}
		*/
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
