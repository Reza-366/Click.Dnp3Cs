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
*
* Simple implementation of openpal::IExecutor that directly uses asio::io_context
*
* Should only be used when asio::io_context::run() is called from a single thread
*
*/
public sealed class BasicExecutor : exe4cpp.IExecutor
{
	public BasicExecutor(asio.io_service io_service)
	{
		this.io_service = io_service;
	}

	// Uncopyable
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	BasicExecutor(const BasicExecutor&) = delete;
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	BasicExecutor& operator =(const BasicExecutor&) = delete;

	public static BasicExecutor create(asio.io_service io_service)
	{
		return new BasicExecutor(io_service);
	}

	// ---- Implement IExecutor -----

	public override Timer start(in duration_t duration, in action_t action)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->start(this->get_time() + duration, action);
		return new exe4cpp.Timer(this.start(this.get_time() + duration, action));
	}

	public override Timer start(in steady_time_t expiration, in action_t action)
	{
		var timer = AsioTimer.create(this.io_service);

		timer.impl.expires_at(expiration);

		// neither the executor nor the timer can be deleted while the timer is still active
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto callback = [timer, action, self = this](const std::error_code & ec)
		var callback = (in std::error_code ec) =>
		{
			if (ec == null) // an error indicate timer was canceled
			{
				action();
			}
		};

		//timer->impl.async_wait(callback);

		return new Timer(timer);
	}

	public override void post(in action_t action)
	{
		//this->io_service->post(action);
		action();
	}

	public override steady_time_t get_time()
	{
		return std::chrono.steady_clock.now();
	}

	// lots of ASIO components must be initialized with a reference to the io_service
	public asio.io_service get_service()
	{
		return io_service;
	}

	// we hold a shared_ptr to the io_service so that it cannot dissapear while the executor is still around
	private readonly asio.io_service io_service;
}

}

