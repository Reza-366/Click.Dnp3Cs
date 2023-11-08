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
 *  Strong typing for millisecond-based monotonic timestamps
 */
public class Timestamp
{

	public static Timestamp Max()
	{
		return new Timestamp(DateTime.max());
	}

	public static Timestamp Min()
	{
		return new Timestamp(DateTime.min());
	}

	public Timestamp()
	{
		this.value = DateTime.min();
	}

	public Timestamp(DateTime value)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.value = value;
		this.value.CopyFrom(value);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsMax() const
	public bool IsMax()
	{
		return value == DateTime.max();
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsMin() const
	public bool IsMin()
	{
		return value == DateTime.min();
	}

	// overflow capped to maximum value
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Timestamp operator +(const TimeDuration& duration) const
	public static Timestamp operator + (Timestamp ImpliedObject, in TimeDuration duration)
	{
		var maximum = DateTime.max() - ImpliedObject.value;

		return duration.value >= maximum ? Timestamp.Max() : new Timestamp(ImpliedObject.value + duration.value);
	}

//C++ TO C# CONVERTER TASK: The += operator cannot be overloaded in C#:
	public static Timestamp operator += (in TimeDuration duration)
	{
		var result = this + duration;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->value = result.value;
		this.value.CopyFrom(result.value);
		return this;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Timestamp operator -(const TimeDuration& duration) const
	public static Timestamp operator - (Timestamp ImpliedObject, in TimeDuration duration)
	{
		var maximum = ImpliedObject.value - DateTime.min();

		return duration.value >= maximum ? Timestamp.Min() : new Timestamp(ImpliedObject.value - duration.value);
	}

//C++ TO C# CONVERTER TASK: The -= operator cannot be overloaded in C#:
	public static Timestamp operator -= (in TimeDuration duration)
	{
		var result = this - duration;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->value = result.value;
		this.value.CopyFrom(result.value);
		return this;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: TimeDuration operator -(const Timestamp& timestamp) const
	public static TimeDuration operator - (Timestamp ImpliedObject, in Timestamp timestamp)
	{
		return new TimeDuration(ImpliedObject.value - timestamp.value);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const Timestamp& other) const
	public static bool operator == (Timestamp ImpliedObject, in Timestamp other)
	{
		return ImpliedObject.value == other.value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator !=(const Timestamp& other) const
	public static bool operator != (Timestamp ImpliedObject, in Timestamp other)
	{
		return ImpliedObject.value != other.value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator <(const Timestamp& other) const
	public static bool operator < (Timestamp ImpliedObject, in Timestamp other)
	{
		return ImpliedObject.value < other.value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator <=(const Timestamp& other) const
	public static bool operator <= (Timestamp ImpliedObject, in Timestamp other)
	{
		return ImpliedObject.value <= other.value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator >(const Timestamp& other) const
	public static bool operator > (Timestamp ImpliedObject, in Timestamp other)
	{
		return ImpliedObject.value > other.value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator >=(const Timestamp& other) const
	public static bool operator >= (Timestamp ImpliedObject, in Timestamp other)
	{
		return ImpliedObject.value >= other.value;
	}

	public DateTime value = new DateTime();
}

} // namespace opendnp3




//#include <exe4cpp/Typedefs.h>

