using System;

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
 *  Strong typing for millisecond based time durations
 */
public class TimeDuration
{
//C++ TO C# CONVERTER TASK: C# has no concept of a 'friend' class:
//	friend class Timestamp;

	public static TimeDuration Min()
	{
		return new TimeDuration(std::chrono.steady_clock.duration.min());
	}

	public static TimeDuration Max()
	{
		return new TimeDuration(std::chrono.steady_clock.duration.max());
	}

	public static TimeDuration Zero()
	{
		return new TimeDuration(std::chrono.milliseconds(0));
	}

	public static TimeDuration Milliseconds(int64_t milliseconds)
	{
		return FromValue<std::chrono.milliseconds>(milliseconds);
	}

	public static TimeDuration Seconds(int64_t seconds)
	{
		return FromValue<std::chrono.seconds>(seconds);
	}

	public static TimeDuration Minutes(int64_t minutes)
	{
		return FromValue<std::chrono.minutes>(minutes);
	}

	public TimeDuration()
	{
		this.value = std::chrono.milliseconds(0);
	}

	public TimeDuration(int seconds)
	{
		this.value = std::chrono.milliseconds(seconds);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: TimeDuration Double() const
	public TimeDuration Double()
	{
		bool doubling_would_cause_mult_overflow = this.value >= std::chrono.steady_clock.duration.max() / 2;

		return doubling_would_cause_mult_overflow ? TimeDuration.Max() : new TimeDuration(this.value + this.value);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsNegative() const
	public bool IsNegative()
	{
		return this < TimeDuration.Zero();
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: string ToString() const
	public string ToString()
	{
		var millis = std::chrono.duration_cast<std::chrono.milliseconds>(value).count();

		return Convert.ToString(millis);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const TimeDuration& other) const
	public static bool operator == (TimeDuration ImpliedObject, in TimeDuration other)
	{
		return ImpliedObject.value == other.value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator <(const TimeDuration& other) const
	public static bool operator < (TimeDuration ImpliedObject, in TimeDuration other)
	{
		return ImpliedObject.value < other.value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator <=(const TimeDuration& other) const
	public static bool operator <= (TimeDuration ImpliedObject, in TimeDuration other)
	{
		return ImpliedObject.value <= other.value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator >(const TimeDuration& other) const
	public static bool operator > (TimeDuration ImpliedObject, in TimeDuration other)
	{
		return ImpliedObject.value > other.value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator >=(const TimeDuration& other) const
	public static bool operator >= (TimeDuration ImpliedObject, in TimeDuration other)
	{
		return ImpliedObject.value >= other.value;
	}

	public std::chrono.steady_clock.duration value = new std::chrono.steady_clock.duration();

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private static TimeDuration FromValue<T>(int64_t value)
	{
		// > this will overflow when converting to nanos
		var MAX = std::chrono.duration_cast<T>(std::chrono.steady_clock.duration.max()).count();
		var MIN = std::chrono.duration_cast<T>(std::chrono.steady_clock.duration.min()).count();

		if (value > MAX)
		{
			return new TimeDuration(std::chrono.steady_clock.duration.max());
		}

		if (value < MIN)
		{
			return new TimeDuration(std::chrono.steady_clock.duration.min());
		}

		return new TimeDuration(T(value));
	}

	private TimeDuration(std::chrono.steady_clock.duration value)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.value = value;
		this.value.CopyFrom(value);
	}
}

} // namespace opendnp3



