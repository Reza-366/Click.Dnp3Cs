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

public class ClazzCount
{

	public void Reset()
	{
		this.num_class_1 = 0;
		this.num_class_2 = 0;
		this.num_class_3 = 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: uint Get(EventClass clazz) const
	public uint Get(EventClass clazz)
	{
		switch (clazz)
		{
		case (EventClass.EC1):
			return new uint(num_class_1);
		case (EventClass.EC2):
			return new uint(num_class_2);
			break;
		default:
			return new uint(num_class_3);
		}
	}

	public void Increment(EventClass clazz)
	{
		switch (clazz)
		{
		case (EventClass.EC1):
			++num_class_1;
			break;
		case (EventClass.EC2):
			++num_class_2;
			break;
		default:
			++num_class_3;
			break;
		}
	}

	public void Decrement(EventClass clazz)
	{
		switch (clazz)
		{
		case (EventClass.EC1):
			--num_class_1;
			break;
		case (EventClass.EC2):
			--num_class_2;
			break;
		default:
			--num_class_3;
			break;
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool Any() const
	public bool Any()
	{
		return (num_class_1 > 0) || (num_class_2 > 0) || (num_class_3 > 0);
	}

	private uint num_class_1 = 0;
	private uint num_class_2 = 0;
	private uint num_class_3 = 0;
}

public class EventClassCounters
{

	public ClazzCount total = new ClazzCount();
	public ClazzCount written = new ClazzCount();
	public uint selected = 0;

	public void OnAdd(EventClass clazz)
	{
		this.total.Increment(clazz);
	}

	public void OnSelect()
	{
		++selected;
	}

	public void OnWrite(EventClass clazz)
	{
		// only selected events are written
		--selected;
		this.written.Increment(clazz);
	}

	public void ResetOnFail()
	{
		this.selected = 0;
		this.written.Reset();
	}

	public void OnRemove(EventClass clazz, EventState state)
	{
		switch (state)
		{
		case (EventState.selected):
			--selected;
			break;
		case (EventState.written):
			this.written.Decrement(clazz);
			break;
		default:
			break;
		}

		this.total.Decrement(clazz);
	}
}
} // namespace opendnp3

