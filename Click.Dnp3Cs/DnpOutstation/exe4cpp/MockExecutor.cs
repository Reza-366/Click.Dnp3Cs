﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

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



namespace exe4cpp
{

/**
* Mock implementation of IExecutor for testing
*/
public sealed class MockExecutor : IExecutor
{
	private sealed class MockTimer : ITimer
	{
//C++ TO C# CONVERTER TASK: C# has no concept of a 'friend' class:
//		friend class MockExecutor;

		public MockTimer(MockExecutor source, in TimeSpan time, in action_t action)
		{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.time = time;
			this.time=(time);
			this.source = source;
			this.action = action;
		}

		// implement ITimer
		public override void cancel()
		{
			source.cancel(this);
		}
			


		public  TimeSpan expires_at()
		{
			return new TimeSpan(this.time.Ticks);
		}

		private TimeSpan time = new TimeSpan();
		private MockExecutor source;
		private action_t action;
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	MockExecutor() = default;

	// ------ Implement IExecutor ------

	public override Timer start(in TimeSpan delay, in action_t action)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return start(current_time + delay, action);
		return new exe4cpp.Timer(start(current_time + delay, action));
	}

	//public override Timer start(in TimeSpan time, in action_t action)
	//{
	//	var timer = new MockTimer(this, time, action);
	//	this.timers.Add(timer);
	//		//return  new exe4cpp.Timer(){ timer};
	//		return new Timer();
	//}

	public override void post(in action_t action)
	{
		this.post_queue.AddLast(action);
	}

	public override DateTime get_time()
	{
		return new DateTime(current_time.Ticks);
	}

	/**	@return true if an action was run. */
	public bool run_one()
	{
		this.check_for_expired_timers();

		if (this.post_queue.Count > 0)
		{
			var runnable = post_queue.First.Value;
			this.post_queue.RemoveFirst();
			runnable();
			return true;
		}
		else
		{
			return false;
		}
	}

	/** Calls RunOne() up to some maximum number of times continuing while
	    there are still events to dispatch

	    @return the number of events dispatched
	*/
	public /*size_t*/int run_many(/*size_t*/int maximum = std::numeric_limits</*size_t*/int>.max())
	{
		/*size_t*/int num = 0;
		while (num < maximum && this.run_one())
		{
			++num;
		}
		return new /*size_t*/int(num);
	}

	/** @return The number of active, pending timers and post operations */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: /*size_t*/int num_active() const
	public /*size_t*/int num_active()
	{
		return this.post_queue.Count;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: /*size_t*/int num_pending_timers() const
	public /*size_t*/int num_pending_timers()
	{
		return this.timers.Count;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: /*steady_time_t*/ DateTime next_timer_expiration_abs() const
	public DateTime next_timer_expiration_abs()
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var lt = (MockTimer lhs, MockTimer rhs) =>
		{
			return lhs.expires_at() < rhs.expires_at();
		};
		var min = std::min_element(this.timers.GetEnumerator(), this.timers.end(), lt);
		if (min == this.timers.end())
		{
			return DateTime.Now;
		}
		else
		{
			return min.expires_at();
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: duration_t next_timer_expiration_rel() const
	public TimeSpan next_timer_expiration_rel()
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var lt = (MockTimer lhs, MockTimer rhs) =>
		{
			return lhs.expires_at() < rhs.expires_at();
		};
		var min = std::min_element(this.timers.GetEnumerator(), this.timers.end(), lt);
		if (min == this.timers.end())
		{
			return TimeSpan.MaxValue;
		}
		else
		{
			return min.expires_at() - this.current_time;
		}
	}

	public /*size_t*/int advance_time(TimeSpan duration)
	{
		this.add_time(new TimeSpan(duration.Ticks));
		return new /*size_t*/int(this.check_for_expired_timers());
	}

	// doesn't check timers_
	public void add_time(TimeSpan duration)
	{
		this.current_time += duration;
	}

	public bool advance_to_next_timer()
	{
		if (this.timers.Count == 0)
		{
			return false;
		}
		else
		{
			var timestamp = next_timer_expiration_abs();

			if (timestamp > this.current_time)
			{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->current_time = timestamp;
				this.current_time =(timestamp);
				return true;
			}
			else
			{
				return false;
			}
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: /*size_t*/int num_timer_cancel() const
	public /*size_t*/int num_timer_cancel()
	{
		return new /*size_t*/int(this.num_timer_cancel_);
	}

	private /*size_t*/int check_for_expired_timers()
	{
		/*size_t*/int count = 0;
		while (find_expired_timer())
		{
			++count;
		}
		return new /*size_t*/int(count);
	}

	private bool find_expired_timer()
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto expired = [this](const MockTimer*& timer)
		var expired = (MockTimer timer) =>
		{
			return timer.expires_at() <= this.current_time;
		};

		var iter = std::find_if(this.timers.GetEnumerator(), this.timers.end(), expired);

		if (iter == this.timers.end())
		{
			return false;
		}
		else
		{
			// keep the timer alive until it's callback is completed.
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto action = [timer = (*iter), action = (*iter)->action]()->void
			var action = () =>
			{
				action();
			};
			this.post_queue.AddLast(action);
//C++ TO C# CONVERTER TASK: There is no direct equivalent to the STL vector 'erase' method in C#:
			this.timers.erase(iter);
			return true;
		}
	}

	private void cancel(ITimer timer)
	{
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: const auto result = std::find_if(this->timers.begin(), this->timers.end(), [timer](const MockTimer*& item)
		var result = std::find_if(this.timers.GetEnumerator(), this.timers.end(), (MockTimer item) =>
		{
			return item.get() == timer;
		});

		if (result != this.timers.end())
		{
			++num_timer_cancel_;
//C++ TO C# CONVERTER TASK: There is no direct equivalent to the STL vector 'erase' method in C#:
			this.timers.erase(result);
		}
	}

        public override Timer start(in DateTime expiration, in action_t action)
        {
            throw new NotImplementedException();
        }

        private DateTime current_time = new DateTime();
	private /*size_t*/int num_timer_cancel_ = 0;

	private LinkedList<action_t> post_queue = new LinkedList<action_t>();
	private List<MockTimer> timers = new List<MockTimer>();
}

}

