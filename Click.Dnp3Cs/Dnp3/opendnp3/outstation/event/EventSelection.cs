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

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct EventSelection : private StaticOnly
public class EventSelection : StaticOnly
{
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	public static System.UInt32 SelectByType<T>(EventLists lists, System.UInt32 max)
	{
		return SelectByTypeGeneric<T>(lists, true, (typename T.event_variation_t)0, ser4cpp.Globals.max);
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	public static System.UInt32 SelectByType<T>(EventLists lists, T.event_variation_t variation, System.UInt32 max)
	{
		return SelectByTypeGeneric<T>(lists, false, variation, ser4cpp.Globals.max);
	}

	public static System.UInt32 SelectByClass(EventLists lists, in ClassField clazz, System.UInt32 max)
	{
		System.UInt32 num_selected = 0;
		var iter = lists.events.Iterate();

		while (iter.HasNext() && num_selected < ser4cpp.Globals.max)
		{
			var node = iter.Next();
			if (node.value.state == EventState.unselected && clazz.HasEventType(node.value.clazz))
			{
				// if not previously selected
				node.value.state = EventState.selected;
				// TODO - set the storage to use the default variation
				// node->value.selectedVariation = useDefaultVariation ? node->value.defaultVariation : variation;
				++num_selected;
				lists.counters.OnSelect();
			}
		}

		return new System.UInt32(num_selected);
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private static System.UInt32 SelectByTypeGeneric<T>(EventLists lists, bool useDefaultVariation, T.event_variation_t variation, System.UInt32 max)
	{
		auto list = lists.GetList<T>();

		System.UInt32 num_selected = 0;

//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var select = (TypedEventRecord<T> node) =>
		{
			if (num_selected == ser4cpp.Globals.max)
			{
				return false;
			}

			if (node.record.value.state == EventState.unselected)
			{
				node.record.value.state = EventState.selected;
				node.selectedVariation.CopyFrom(useDefaultVariation ? node.defaultVariation : variation);
				lists.counters.OnSelect();
				++num_selected;
			}

			return true;
		};

		list.ForeachWhile(select);

		return new System.UInt32(num_selected);
	}
}

} // namespace opendnp3



