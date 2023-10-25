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

public class Evented
{
	public Evented(UInt16 index, EventClass clazz)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.index = index;
		this.index.CopyFrom(index);
		this.clazz = new opendnp3.EventClass(clazz);
	}

	public Evented()
	{
		this.clazz = new opendnp3.EventClass.EC1;
	}

	public UInt16 index = 0;
	public EventClass clazz; // class of the event (CLASS<1-3>)
}

/**
 * Record of an event that includes value, index, and class
 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<typename Spec>
public class Event <Spec> : Evented
{

	public Event(in Spec.meas_t value, UInt16 index, EventClass clazz, Spec.event_variation_t variation) : base(index, clazz)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.value = value;
		this.value.CopyFrom(value);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.variation = variation;
		this.variation.CopyFrom(variation);
	}

	public Event() : base()
	{
		this.value = new Spec.meas_t();
		this.variation = new Spec.event_variation_t();
	}

	public Spec.meas_t value = new Spec.meas_t();
	public Spec.event_variation_t variation = new Spec.event_variation_t();
}

} // namespace opendnp3

