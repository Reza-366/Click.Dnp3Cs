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

/// A null object for types that have no metadata
public class EmptyEventCell
{
}

/// Base class for different types of event metadata
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Spec>
public class EventCellBase <Spec>
{
	public PointClass clazz;
	public Spec.meas_t lastEvent = new Spec.meas_t();
	public Spec.event_variation_t evariation = new Spec.event_variation_t();

	public void SetEventValue(in Spec.meas_t value)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: lastEvent = value;
		lastEvent.CopyFrom(value);
	}

	protected EventCellBase()
	{
		this.clazz = new opendnp3.PointClass.Class1;
		this.lastEvent = new Spec.meas_t();
		this.evariation = Spec.DefaultEventVariation;
	}
}

/// Metatype w/o a deadband
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Spec>
public class SimpleEventCell <Spec> : EventCellBase<Spec>
{
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsEvent(const typename Spec::config_t& config, const typename Spec::meas_t& newValue) const
	public bool IsEvent(in Spec.config_t config, in Spec.meas_t newValue)
	{
		return Spec.IsEvent(this.lastEvent, newValue);
	}
}

/// Structure for holding metadata information on points that have support deadbanding
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Spec>
public class DeadbandEventCell <Spec> : SimpleEventCell<Spec>
{
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsEvent(const typename Spec::config_t& config, const typename Spec::meas_t& newValue) const
	public new bool IsEvent(in Spec.config_t config, in Spec.meas_t newValue)
	{
		return Spec.IsEvent(this.lastEvent, newValue, config.deadband);
	}
}

} // namespace opendnp3

