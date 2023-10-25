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
 * A strategy interface for controlling how connection are retried
 */
public abstract class IOpenDelayStrategy : System.IDisposable
{

	public virtual void Dispose()
	{
	}

	/**
	 * The the next delay based on the current and the maximum.
	 */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual TimeDuration GetNextDelay(const TimeDuration& current, const TimeDuration& max) const = 0;
	public abstract TimeDuration GetNextDelay(in TimeDuration current, in TimeDuration max);
}

/**
 * Implements IOpenDelayStrategy using exponential-backoff.
 */
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class ExponentialBackoffStrategy final : public IOpenDelayStrategy, private Uncopyable
//C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
public sealed class ExponentialBackoffStrategy : IOpenDelayStrategy, Uncopyable
{
	private static ExponentialBackoffStrategy instance = new ExponentialBackoffStrategy();

	public static IOpenDelayStrategy Instance()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return instance;
		return new opendnp3.ExponentialBackoffStrategy(instance);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: TimeDuration GetNextDelay(const TimeDuration& current, const TimeDuration& max) const
	public override TimeDuration GetNextDelay(in TimeDuration current, in TimeDuration max)
	{
		var doubled = current.Double();
		return (doubled > max) ? max : doubled;
	}
}

} // namespace opendnp3



