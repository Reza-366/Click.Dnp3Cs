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

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct EventUpdate : private StaticOnly
public class EventUpdate : StaticOnly
{
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	public static bool Update<T>(EventLists lists, in Event<T> @event)
	{
		auto list = lists.GetList<T>();

		// lists with no capacity don't cause "buffer overflow"
		if (list.Capacity() == 0)
		{
			return false;
		}

		bool overflow = false;

		if (list.IsFullAndCapacityNotZero())
		{
			// we must make space

			overflow = true;
			var first = list.Head();
			var record_node = first.value.record;

			// remove the generic record
			lists.counters.OnRemove(record_node.value.clazz, record_node.value.state);
			lists.events.Remove(first.value.record);

			// remove the type specific record
			list.Remove(first);
		}

		// now that we know that space exists, create the generic record
		var record_node = lists.events.Add(new EventRecord(@event.index, @event.clazz));

		// followed by the typed record
		var typed_node = list.Add(TypedEventRecord<T>(@event.value, @event.variation, record_node));

		// configure the typed storage
		record_node.value.type = opendnp3.Globals.EventTypeImpl<T>.Instance();
		record_node.value.storage_node = typed_node;

		lists.counters.OnAdd(@event.clazz);

		return overflow;
	}
}

} // namespace opendnp3

