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

public class ModuleId
{
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	ModuleId() = default;

	public ModuleId(int32_t level)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.value = level;
		this.value.CopyFrom(level);
	}

	public int32_t value = 0;
}

public class LogLevel
{
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	LogLevel() = default;

	public LogLevel(int32_t level)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.value = level;
		this.value.CopyFrom(level);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: LogLevel next() const
	public LogLevel next()
	{
		return new LogLevel(value << 1);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const LogLevel& other) const
	public static bool operator == (LogLevel ImpliedObject, in LogLevel other)
	{
		return ImpliedObject.value == other.value;
	}

	public int32_t value = 0;
}

/**
 * Strongly typed wrapper for flags bitfield
 */
public class LogLevels
{
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	LogLevels() = default;

	public LogLevels(int32_t levels)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.levels = levels;
		this.levels.CopyFrom(levels);
	}

	public LogLevels(LogLevel level)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.levels = level.value;
		this.levels.CopyFrom(level.value);
	}

	public static LogLevels none()
	{
		return new LogLevels(0);
	}

	public static LogLevels everything()
	{
		return new LogLevels(~0);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool is_set(const LogLevel& level) const
	public bool is_set(in LogLevel level)
	{
		return (level.value & levels) != 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: LogLevels operator ~() const
	public static LogLevels operator ~(LogLevels ImpliedObject)
	{
		return new LogLevels(~ImpliedObject.levels);
	}

//C++ TO C# CONVERTER TASK: The |= operator cannot be overloaded in C#:
	public static LogLevels operator |= (in LogLevel other)
	{
		this.levels |= other.value;
		return this;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: LogLevels operator |(const LogLevel& other) const
	public static LogLevels operator | (LogLevels ImpliedObject, in LogLevel other)
	{
		return new LogLevels(ImpliedObject.levels | other.value);
	}

//C++ TO C# CONVERTER TASK: The |= operator cannot be overloaded in C#:
	public static LogLevels operator |= (in LogLevels other)
	{
		this.levels |= other.levels;
		return this;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: LogLevels operator |(const LogLevels& other) const
	public static LogLevels operator | (LogLevels ImpliedObject, in LogLevels other)
	{
		return new LogLevels(ImpliedObject.levels | other.levels);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline int32_t get_value() const
	public int32_t get_value()
	{
		return new int32_t(levels);
	}

	private int32_t levels = 0;
}

namespace flags
{

} // namespace flags

namespace levels
{
} // namespace levels

} // namespace opendnp3



