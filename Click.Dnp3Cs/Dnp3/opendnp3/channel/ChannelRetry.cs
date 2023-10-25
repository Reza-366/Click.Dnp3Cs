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

/// Class used to configure how channel failures are retried
public class ChannelRetry
{

	/*
	 * Construct a channel retry config class
	 *
	 * @param minOpenRetry minimum connection retry interval on failure
	 * @param maxOpenRetry maximum connection retry interval on failure
	 */
	public ChannelRetry(TimeDuration minOpenRetry_, TimeDuration maxOpenRetry_, TimeDuration reconnectDelay_ = TimeDuration.Zero(), IOpenDelayStrategy strategy_ = ExponentialBackoffStrategy.Instance())
	{
		this.minOpenRetry = new opendnp3.TimeDuration(minOpenRetry_);
		this.maxOpenRetry = new opendnp3.TimeDuration(maxOpenRetry_);
		this.reconnectDelay = new opendnp3.TimeDuration(reconnectDelay_);
		this.strategy = new opendnp3.IOpenDelayStrategy(strategy_);
	}

	/// Return the default configuration of exponential backoff from 1 sec to 1 minute
	public static ChannelRetry Default()
	{
		return new ChannelRetry(TimeDuration.Seconds(1), TimeDuration.Minutes(1));
	}

	/// minimum connection retry interval on failure
	public TimeDuration minOpenRetry = new TimeDuration();
	/// maximum connection retry interval on failure
	public TimeDuration maxOpenRetry = new TimeDuration();
	/// reconnect delay (defaults to zero)
	public TimeDuration reconnectDelay = new TimeDuration();

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: TimeDuration NextDelay(const TimeDuration& current) const
	public TimeDuration NextDelay(in TimeDuration current)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return strategy.GetNextDelay(current, maxOpenRetry);
		return new opendnp3.TimeDuration(strategy.GetNextDelay(current, maxOpenRetry));
	}

	//// Strategy to use (default to exponential backoff)
	private IOpenDelayStrategy strategy;
}

} // namespace opendnp3



