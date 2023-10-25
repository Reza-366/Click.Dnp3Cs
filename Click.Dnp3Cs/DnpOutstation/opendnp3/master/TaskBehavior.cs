using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Copyright 2013-2022 Step Function I/O, LLC
 *
 * Licensed to Green Energy Corp (www.greenenergycorp.com) and Step Function I/O
 * LLC (https://stepfunc.io) under one or more contributor license agreements.
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Green Energy Corp and Step Function I/O LLC license
 * this file to you under the Apache License, Version 2.0 (the "License"); you
 * may not use this file except in compliance with the License. You may obtain
 * a copy of the License at:
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

/*
 * Copyright 2013-2022 Step Function I/O, LLC
 *
 * Licensed to Green Energy Corp (www.greenenergycorp.com) and Step Function I/O
 * LLC (https://stepfunc.io) under one or more contributor license agreements.
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Green Energy Corp and Step Function I/O LLC license
 * this file to you under the Apache License, Version 2.0 (the "License"); you
 * may not use this file except in compliance with the License. You may obtain
 * a copy of the License at:
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */



namespace opendnp3
{

/**
 *   All of the configuration parameters that control how the task wil behave
 */
public class TaskBehavior
{

	public static TaskBehavior SingleExecutionNoRetry()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return SingleExecutionNoRetry(Timestamp::Max());
		return new opendnp3.TaskBehavior(SingleExecutionNoRetry(Timestamp.Max())); // no start expiration
	}

	public static TaskBehavior SingleExecutionNoRetry(in Timestamp startExpiration)
	{
		return new TaskBehavior(TimeDuration.Min(), Timestamp.Min(), TimeDuration.Max(), TimeDuration.Max(), startExpiration);
	}

	public static TaskBehavior ImmediatePeriodic(in TimeDuration period, in TimeDuration minRetryDelay, in TimeDuration maxRetryDelay)
	{
		return new TaskBehavior(period, Timestamp.Min(), minRetryDelay, maxRetryDelay, Timestamp.Max());
	}

	public static TaskBehavior SingleImmediateExecutionWithRetry(in TimeDuration minRetryDelay, in TimeDuration maxRetryDelay)
	{
		return new TaskBehavior(TimeDuration.Min(), Timestamp.Min(), minRetryDelay, maxRetryDelay, Timestamp.Max());
	}

	public static TaskBehavior ReactsToIINOnly()
	{
		return new TaskBehavior(TimeDuration.Min(), Timestamp.Max(), TimeDuration.Max(), TimeDuration.Max(), Timestamp.Max());
	}

	/**
	 * Called when the task succeeds. Resets the retry timeout to the minimum, and returns the new expiration time
	 */
	public void OnSuccess(in Timestamp now)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->currentRetryDelay = this->minRetryDelay;
		this.currentRetryDelay.CopyFrom(this.minRetryDelay);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->expiration = this->period.IsNegative() ? Timestamp::Max() : now + this->period;
		this.expiration.CopyFrom(this.period.IsNegative() ? Timestamp.Max() : now + this.period);
	}

	/**
	 * Called when the task fails due to a response timeout
	 */
	public void OnResponseTimeout(in Timestamp now)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->expiration = now + this->currentRetryDelay;
		this.expiration.CopyFrom(now + this.currentRetryDelay);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->currentRetryDelay = this->CalcNextRetryTimeout();
		this.currentRetryDelay.CopyFrom(this.CalcNextRetryTimeout());
	}

	/**
	 * return the current expiration time
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Timestamp GetExpiration() const
	public Timestamp GetExpiration()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return expiration;
		return new opendnp3.Timestamp(expiration);
	}

	/**
	 * return the time after which the task should fail if it hasn't start running
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Timestamp GetStartExpiration() const
	public Timestamp GetStartExpiration()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return startExpiration;
		return new opendnp3.Timestamp(startExpiration);
	}

	/**
	 * reset to the initial state
	 */
	public void Reset()
	{
		this.disabled = false;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->expiration = Timestamp::Min();
		this.expiration.CopyFrom(Timestamp.Min());
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->currentRetryDelay = this->minRetryDelay;
		this.currentRetryDelay.CopyFrom(this.minRetryDelay);
	}

	/**
	 * Disable the task
	 */
	public void Disable()
	{
		this.disabled = true;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->expiration = Timestamp::Max();
		this.expiration.CopyFrom(Timestamp.Max());
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: TimeDuration CalcNextRetryTimeout() const
	private TimeDuration CalcNextRetryTimeout()
	{
		var doubled = this.currentRetryDelay.Double();
		return (doubled > this.maxRetryDelay) ? this.maxRetryDelay : doubled;
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	TaskBehavior() = delete;

	private TaskBehavior(in TimeDuration period, in Timestamp expiration, in TimeDuration minRetryDelay, in TimeDuration maxRetryDelay, in Timestamp startExpiration)
	{
		this.period = new opendnp3.TimeDuration(period);
		this.minRetryDelay = new opendnp3.TimeDuration(minRetryDelay);
		this.maxRetryDelay = new opendnp3.TimeDuration(maxRetryDelay);
		this.startExpiration = new opendnp3.Timestamp(startExpiration);
		this.expiration = new opendnp3.Timestamp(expiration);
		this.currentRetryDelay = new opendnp3.TimeDuration(minRetryDelay);
	}

	private readonly TimeDuration period = new TimeDuration();
	private readonly TimeDuration minRetryDelay = new TimeDuration();
	private readonly TimeDuration maxRetryDelay = new TimeDuration();
	private readonly Timestamp startExpiration = new Timestamp();

	// permanently disable the task
	private bool disabled = false;

	// The tasks current expiration time
	private Timestamp expiration = new Timestamp();

	// The current retry delay
	private TimeDuration currentRetryDelay = new TimeDuration();
}

} // namespace opendnp3




