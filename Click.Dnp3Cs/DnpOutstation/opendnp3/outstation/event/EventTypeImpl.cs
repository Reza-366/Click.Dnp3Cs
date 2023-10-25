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

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public sealed class EventTypeImpl <T> : IEventType
{

	private EventTypeImpl() : base(T.EventTypeEnum)
	{
	}

	private static EventTypeImpl instance = new EventTypeImpl();

	public static IEventType Instance()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return &instance;
		return new EventTypeImpl(instance);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual void SelectDefaultVariation(EventRecord& record) const override
	public override void SelectDefaultVariation(EventRecord record)
	{
		var node = TypedStorage<T>.Retrieve(record);
		node.value.selectedVariation = node.value.defaultVariation;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual ushort WriteSome(List<EventRecord>::Iterator& iterator, EventLists& lists, IEventWriteHandler& handler) const override
	public override ushort WriteSome(List<EventRecord>.Iterator iterator, EventLists lists, IEventWriteHandler handler)
	{
		var pos = iterator.CurrentValue();
		var type = TypedStorage<T>.Retrieve(pos);

		EventCollection<T> collection = new EventCollection<T>(iterator, lists.counters, type.value.selectedVariation);

		return handler.Write(type.value.selectedVariation, type.value.value, collection);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: virtual void RemoveTypeFromStorage(EventRecord& record, EventLists& lists) const override
	public override void RemoveTypeFromStorage(EventRecord record, EventLists lists)
	{
		var node = TypedStorage<T>.Retrieve(record);
		lists.GetList<T>().Remove(node);
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>

} // namespace opendnp3

