using System;
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
//C++ TO C# CONVERTER TASK: C++ template specialization was removed by C++ to C# Converter:
//ORIGINAL LINE: StaticBinaryVariation check_for_promotion<BinarySpec>(const Binary& value, StaticBinaryVariation variation);
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: class StaticDataMap : private Uncopyable
public class StaticDataMap <Spec> : Uncopyable
{

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	StaticDataMap() = default;
	public StaticDataMap(in SortedDictionary<UInt16, typename Spec.config_t> config)
	{
		foreach (var item in config)
		{
			this.map[item.first] = StaticDataCell<Spec>({item.second});
		}
	}

	public class iterator
	{
		private map_iter_t iter = new map_iter_t();
		private map_iter_t end = new map_iter_t();
		private Range range;

		public iterator(map_iter_t begin, map_iter_t end, Range range)
		{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.iter = begin;
			this.iter.CopyFrom(begin);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.end = end;
			this.end.CopyFrom(end);
			this.range = new opendnp3.Range(range);
		}


		public static bool operator == (iterator ImpliedObject, in iterator rhs)
		{
			return ImpliedObject.iter == rhs.iter;
		}
		public static bool operator != (iterator ImpliedObject, in iterator rhs)
		{
			return ImpliedObject.iter != rhs.iter;
		}

		public static void operator ++(iterator ImpliedObject)
		{
			// unselect the point
			ImpliedObject.iter.second.selection.selected = false;

			while (true)
			{
				ImpliedObject.iter++;

				if (ImpliedObject.iter == ImpliedObject.end)
				{
					ImpliedObject.range = Range.Invalid();
					return;
				}

				// shorten the range
				ImpliedObject.range.start = ImpliedObject.iter.first;

				if (ImpliedObject.iter.second.selection.selected)
				{
					return;
				}
			}
		}

		public Tuple<UInt16, SelectedValue<Spec>&> Indirection()
		{
			return new Tuple<UInt16, SelectedValue<Spec>&>(iter.first, iter.second.selection);
		}
	}

	public bool add(in Spec.meas_t value, UInt16 index, Spec.config_t config)
	{
		if (this.map.ContainsKey(index))
		{
			return false;
		}

		this.map[index] = StaticDataCell<Spec>({value, config});

		return true;
	}

	public bool update(in Spec.meas_t value, UInt16 index, EventMode mode, IEventReceiver receiver)
	{
		return update(this.map.find(index), value, mode, receiver);
	}

	public bool modify(UInt16 start, UInt16 stop, System.Byte flags, IEventReceiver receiver)
	{
		if (stop < start)
		{
			return false;
		}

		for (var iter = this.map.lower_bound(start); iter != this.map.end(); ++iter)
		{
			if (iter.first > stop)
			{
				return false;
			}

			var new_value = iter.second.value;
			new_value.flags = new Flags(flags);
			this.update(iter, new_value, EventMode.Detect, receiver);
		}

		return true;
	}

	public void clear_selection()
	{
		// the act of iterating clears the selection
		for (var iter = this.begin(); iter != this.end(); ++iter)
		{
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool has_any_selection() const
	public bool has_any_selection()
	{
		return this.selected.IsValid();
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Range get_selected_range() const
	public Range get_selected_range()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->selected;
		return new opendnp3.Range(this.selected);
	}

	public size_t select_all()
	{
		return this.select_all((@var) =>
		{
			return new auto(@var);
		});
	}

	public size_t select_all(Spec.static_variation_t variation)
	{
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: return this->select_all([variation](auto var)
		return this.select_all((@var) =>
		{
			return new Spec.static_variation_t(variation);
		});
	}

	public size_t select(Range range)
	{
		return this.select(range, (@var) =>
		{
			return new auto(@var);
		});
	}

	public bool select(UInt16 index, Spec.static_variation_t variation)
	{
		return new size_t(this.select(Range.From(new UInt16(index), new UInt16(index)), new Spec.static_variation_t(variation)));
	}

	public bool select(UInt16 index)
	{
		return this.select(Range.From(new UInt16(index), new UInt16(index))) == 1;
	}

	public size_t select(Range range, Spec.static_variation_t variation)
	{
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: return this->select(range, [variation](auto var)
		return this.select(range, (@var) =>
		{
			return new Spec.static_variation_t(variation);
		});
	}

	public Range assign_class(PointClass clazz)
	{
		foreach (var elem in this.map)
		{
			elem.second.config.clazz = clazz;
		}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->get_full_range();
		return new opendnp3.Range(this.get_full_range());
	}

	public Range assign_class(PointClass clazz, in Range range)
	{
		for (var iter = this.map.lower_bound(range.start); iter != this.map.end() && range.Contains(iter.first); iter++)
		{
			iter.second.config.clazz = clazz;
		}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return range.Intersection(this->get_full_range());
		return new opendnp3.Range(range.Intersection(this.get_full_range()));
	}

	public StaticDataMap<Spec>.iterator begin()
	{
		if (!this.selected.IsValid())
		{
			return new iterator(this.map.end(), this.map.end(), this.selected);
		}

		var begin = this.map.lower_bound(this.selected.start);

		return new iterator(begin, this.map.end(), this.selected);
	}

	public StaticDataMap<Spec>.iterator end()
	{
		return new iterator(this.map.end(), this.map.end(), this.selected);
	}

	private SortedDictionary<UInt16, StaticDataCell<Spec>> map = new SortedDictionary<UInt16, StaticDataCell<Spec>>();
	private Range selected = new Range();

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: Range get_full_range() const
	private Range get_full_range()
	{
		return this.map.Count == 0 ? Range.Invalid() : Range.From(this.map.GetEnumerator().first, this.map.rbegin().first);
	}

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	bool update(in System.Collections.Generic.SortedDictionaryIterator<UInt16, StaticDataCell<Spec>> iter, in Spec::meas_t new_value, EventMode mode, IEventReceiver receiver);

	// generic implementation of select_all that accepts a function
	// that can use or override the default variation
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class F>
	private size_t select_all<F>(F get_variation)
	{
		if (map.Count == 0)
		{
			return 0;
		}
		else
		{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->selected = Range::From(map.begin()->first, map.rbegin()->first);
			this.selected.CopyFrom(Range.From(map.GetEnumerator().first, map.rbegin().first));

			foreach (var iter in this.map)
			{
				iter.second.selection = SelectedValue<Spec>({true, iter.second.value, opendnp3.Globals.check_for_promotion<Spec>(iter.second.value, get_variation(iter.second.config.svariation))});
			}

			return this.map.Count;
		}
	}

	// generic implementation of select that accepts a function
	// that can use or override the default variation
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class F>
	private size_t select<F>(Range range, F get_variation)
	{
		if (!range.IsValid())
		{
			return 0;
		}

		var start = this.map.lower_bound(range.start);

		if (start == this.map.end())
		{
			return 0;
		}

		if (!range.Contains(start.first))
		{
			return 0;
		}

		UInt16 stop = 0;
		size_t count = 0;

		for (var iter = start; iter != this.map.end(); ++iter)
		{
			if (!range.Contains(iter.first))
			{
				break;
			}

			stop = iter.first;
			iter.second.selection = SelectedValue<Spec>({true, iter.second.value, opendnp3.Globals.check_for_promotion<Spec>(iter.second.value, get_variation(iter.second.config.svariation))});
			++count;
		}

//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->selected = this->selected.Union(Range::From(start->first, stop));
		this.selected.CopyFrom(this.selected.Union(Range.From(start.first, new UInt16(stop))));

		return new size_t(count);
	}
}

public bool StaticDataMap<TimeAndIntervalSpec>.update(in TimeAndInterval value, UInt16 index, EventMode mode, IEventReceiver receiver)
{
	var iter = this.map.find(index);
	if (iter == this.map.end())
	{
		return false;
	}

	iter.second.value = value;

	return true;
}


//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Spec>
public bool StaticDataMap<Spec>.update<Spec>(in map_iter_t iter, in Spec.meas_t new_value, EventMode mode, IEventReceiver receiver)
{
	if (iter == this.map.end())
	{
		return false;
	}

	if (mode != EventMode.EventOnly)
	{
		iter.second.value = new_value;
	}

	if (mode == EventMode.Force || mode == EventMode.EventOnly || Spec.IsEvent(iter.second.@event.lastEvent, new_value, iter.second.config))
	{
		iter.second.@event.lastEvent = new_value;
		if (mode != EventMode.Suppress)
		{
			EventClass ec;
			if (convert_to_event_class(iter.second.config.clazz, ref ec))
			{
				receiver.Update(Event<Spec>(new_value, iter.first, ec, iter.second.config.evariation));
			}
		}
	}

	return true;
}

} // namespace opendnp3



