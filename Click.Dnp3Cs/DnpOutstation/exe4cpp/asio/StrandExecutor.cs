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
	* Implementation of openpal::IExecutor backed by asio::strand
	*
	* Shutdown life-cycle guarantees are provided by using std::shared_ptr
	*
	*/
	public sealed class StrandExecutor : exe4cpp.IExecutor
	{



		/**
		*
		* Implementation of openpal::IExecutor backed by asio::strand
		*
		* Shutdown life-cycle guarantees are provided by using std::shared_ptr
		*
		*/

		public StrandExecutor(asio.io_service io_service)
		{
			//strand{*io_service}
			this.io_service =  io_service ;
		}

		public StrandExecutor(asio.io_context io_context)
			// io_service{io_context}//,
			// strand{*io_service}
		{
		}

		public static StrandExecutor create(asio.io_context io_context)
		{
			return new StrandExecutor(io_context);
		}

		public static StrandExecutor create(asio.io_service io_service)
		{
			return new StrandExecutor(io_service);
		}

		public StrandExecutor fork()
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return create(this->io_service);
			return new exe4cpp.StrandExecutor(create(this.io_service));
		}

		// ---- Implement IExecutor -----


		// ---- Implement IExecutor -----

		public override Timer start(in duration_t duration, in action_t action)
		{
			//return this->start(get_time() + duration, action);
			Timer rrr = new Timer();
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return rrr;
			return new exe4cpp.Timer(rrr);
		}

		public override Timer start(in /*steady_time_t*/ DateTime expiration, in action_t action)
		{
			//        const auto timer = AsioTimer::create(this->io_service);
			//
			//        timer->impl.expires_at(expiration);

					// neither this executor nor the timer can be deleted while the timer is still active
					//        auto callback = [timer, action, self = shared_from_this()](const /*std::error_code*/ int & ec)
					//        {
					//            if (!ec)   // an error indicate timer was canceled
					//            {
					//                action();
					//            }
					//        };
					//
					//        timer->impl.async_wait(strand.wrap(callback));
					//
					//        return Timer(timer);
			Timer rrr = new Timer();
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return rrr;
			return new exe4cpp.Timer(rrr);
		}

		public override void post(in action_t action)
		{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto callback = [action, self = this]()
			var callback = () =>
			{
				action();
			};
			//strand.post(callback);
		}

		public override /*steady_time_t*/ DateTime get_time()
		{
			return std::chrono.steady_clock.now();
		}

		public asio.io_service get_service()
		{
			return io_service;
		}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
		private delegate void funcDelegate(T t);

		public void block_until_and_flush<T>(funcDelegate func)
		{
		}

		//    template <typename handler_t>
		//    asio::detail::wrapped_handler<asio::strand, handler_t, asio::detail::is_continuation_if_running> wrap(const handler_t& handler)
		//    {
		//        return strand.wrap(handler);
		//    }

		// we hold a shared_ptr to the io_service so that it cannot dissapear while the strand is still executing
		// std::vector<void*> processes;

		private readonly asio.io_service io_service;
		private asio.strand strand = new asio.strand();
	}

}



namespace exe4cpp
{

	//    template <typename handler_t>
	//    asio::detail::wrapped_handler<asio::strand, handler_t, asio::detail::is_continuation_if_running> wrap(const handler_t& handler)
	//    {
	//        return strand.wrap(handler);
	//    }


}
