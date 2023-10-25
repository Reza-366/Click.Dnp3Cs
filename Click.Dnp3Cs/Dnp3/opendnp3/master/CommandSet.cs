using System.Collections.Generic;

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

// don't want this to be part of the public API
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class ICommandHeader;

/**
 * Provides a mechanism for building a set of one or more command headers
 */
public sealed class CommandSet : System.IDisposable
{
	// friend class used to hide some implementation details while keeping the headers private
//C++ TO C# CONVERTER TASK: C# has no concept of a 'friend' class:
//	friend class CommandSetOps;


	/// Contrsuct an empty command set
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	CommandSet() = default;

	// Put this in impl so we can hide details of ICommandHeader
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	public void Dispose();

	/// Construct a new command set and take ownership of the headers in argument
//C++ TO C# CONVERTER TASK: 'rvalue references' have no equivalent in C#:
	public CommandSet(CommandSet && other)
	{
		this.m_headers = std::move(other.m_headers);
	}

	/// Construct a command set from a list of CROB
	public CommandSet(List<Indexed<ControlRelayOutputBlock>> items)
	{
		this.Add(new List<Indexed<ControlRelayOutputBlock>>(items));
	}

	/// Construct a command set from a list of AOInt16
	public CommandSet(List<Indexed<AnalogOutputInt16>> items)
	{
		this.Add(new List<Indexed<AnalogOutputInt16>>(items));
	}

	/// Construct a command set from a list of AOInt32
	public CommandSet(List<Indexed<AnalogOutputInt32>> items)
	{
		this.Add(new List<Indexed<AnalogOutputInt32>>(items));
	}

	/// Construct a command set from a list of AOFloat32
	public CommandSet(List<Indexed<AnalogOutputFloat32>> items)
	{
		this.Add(new List<Indexed<AnalogOutputFloat32>>(items));
	}

	/// Construct a command set from a list of AODouble64
	public CommandSet(List<Indexed<AnalogOutputDouble64>> items)
	{
		this.Add(new List<Indexed<AnalogOutputDouble64>>(items));
	}

	/// Convenience functions that can build an entire header in one call
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	public void Add<T>(List<Indexed<T>> items)
	{
		if (items.Count != 0)
		{
			auto header = this.StartHeader<T>();
			foreach (var command in items)
			{
				header.Add(command.value, command.index);
			}
		}
	}

	/// Convenience functions that can build an entire header in one call
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	public void Add<T>(List<Indexed<T>> items)
	{
		if (items.Count > 0)
		{
			auto header = this.StartHeader<T>();
			foreach (var command in items)
			{
				header.Add(command.value, command.index);
			}
		}
	}

	/// Begin a header of the parameterized type
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	public ICommandCollection<ControlRelayOutputBlock> StartHeader<T>()
	{
		return this.StartHeaderCROB();
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	void AddAny<T>(System.Collections.Generic.List<Indexed<T>> items);

	private ICommandCollection<ControlRelayOutputBlock> StartHeaderCROB<T>()
	{
		var header = new TypedCommandHeader<ControlRelayOutputBlock>(Group12Var1.Inst());
		this.m_headers.Add(header);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return *header;
		return new opendnp3.TypedCommandHeader<ControlRelayOutputBlock>(header);
	}

	private ICommandCollection<AnalogOutputInt32> StartHeaderAOInt32()
	{
		var header = new TypedCommandHeader<AnalogOutputInt32>(Group41Var1.Inst());
		this.m_headers.Add(header);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return *header;
		return new opendnp3.TypedCommandHeader<AnalogOutputInt32>(header);
	}

	private ICommandCollection<AnalogOutputInt16> StartHeaderAOInt16()
	{
		var header = new TypedCommandHeader<AnalogOutputInt16>(Group41Var2.Inst());
		this.m_headers.Add(header);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return *header;
		return new opendnp3.TypedCommandHeader<AnalogOutputInt16>(header);
	}

	private ICommandCollection<AnalogOutputFloat32> StartHeaderAOFloat32()
	{
		var header = new TypedCommandHeader<AnalogOutputFloat32>(Group41Var3.Inst());
		this.m_headers.Add(header);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return *header;
		return new opendnp3.TypedCommandHeader<AnalogOutputFloat32>(header);
	}

	private ICommandCollection<AnalogOutputDouble64> StartHeaderAODouble64()
	{
		var header = new TypedCommandHeader<AnalogOutputDouble64>(Group41Var4.Inst());
		this.m_headers.Add(header);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return *header;
		return new opendnp3.TypedCommandHeader<AnalogOutputDouble64>(header);
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	CommandSet(const CommandSet&) = delete;
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	CommandSet& operator =(const CommandSet& other) = delete;

	private List<ICommandHeader> m_headers = new List<ICommandHeader>();
}





} // namespace opendnp3




namespace opendnp3
{

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//CommandSet::~CommandSet() = default;

} // namespace opendnp3
