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



namespace opendnp3
{

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class EventLists;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class IEventWriteHandler;
//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class EventRecord;

public abstract class IEventType
{

	public readonly EventType value;

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool IsEqual(EventType type) const
	public bool IsEqual(EventType type)
	{
		return type == value;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool IsNotEqual(EventType type) const
	public bool IsNotEqual(EventType type)
	{
		return type != value;
	}

	protected IEventType(EventType value)
	{
		this.value = new opendnp3.EventType(value);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual void SelectDefaultVariation(EventRecord& record) const = 0;
	public abstract void SelectDefaultVariation(EventRecord record);

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual ushort WriteSome(List<EventRecord>::Iterator& iterator, EventLists& lists, IEventWriteHandler& handler) const = 0;
	public abstract ushort WriteSome(List<EventRecord>.Iterator iterator, EventLists lists, IEventWriteHandler handler);

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual void RemoveTypeFromStorage(EventRecord& record, EventLists& lists) const = 0;
	public abstract void RemoveTypeFromStorage(EventRecord record, EventLists lists);
}

} // namespace opendnp3

