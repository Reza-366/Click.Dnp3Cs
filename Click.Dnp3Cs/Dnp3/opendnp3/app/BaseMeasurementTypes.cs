﻿/*
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
  Base class shared by all of the DataPoint types.
*/
public class Measurement
{
	public Flags flags = new Flags(); //    bitfield that stores type specific quality information
	public DNPTime time = new DNPTime(); //    timestamp associated with the measurement

	protected Measurement()
	{
	}

	protected Measurement(Flags flags)
	{
		this.flags = new opendnp3.Flags(flags);
	}

	protected Measurement(Flags flags, DNPTime time)
	{
		this.flags = new opendnp3.Flags(flags);
		this.time = new opendnp3.DNPTime(time);
	}
}

/// Common subclass to analogs and counters
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public class TypedMeasurement <T> : Measurement
{
	public T value = default(T);


	protected TypedMeasurement() : base()
	{
		this.value = 0;
	}
	protected TypedMeasurement(Flags flags) : base(flags)
	{
		this.value = 0;
	}
	protected TypedMeasurement(T value, Flags flags) : base(flags)
	{
		this.value = value;
	}
	protected TypedMeasurement(T value, Flags flags, DNPTime time) : base(flags, time)
	{
		this.value = value;
	}
}

} // namespace opendnp3
