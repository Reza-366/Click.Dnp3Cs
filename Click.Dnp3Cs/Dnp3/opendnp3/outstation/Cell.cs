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

/**
 * Type used to record whether a value is requested in a response
 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Spec>
public class SelectedValue <Spec>
{
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	SelectedValue() = default;

	public SelectedValue(bool selected, in Spec.meas_t value, Spec.static_variation_t variation)
	{
		this.selected = selected;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.value = value;
		this.value.CopyFrom(value);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.variation = variation;
		this.variation.CopyFrom(variation);
	}

	public bool selected = false;

	public Spec.meas_t value = new Spec.meas_t();
	public Spec.static_variation_t variation = Spec.DefaultStaticVariation;
}

/**
 * Holds particular measurement type in the database.
 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Spec>
public class StaticDataCell <Spec>
{
	public Spec.meas_t value = new Spec.meas_t(); // current value
	public Spec.config_t config = new Spec.config_t(); // configuration
	public Spec.event_cell_t @event = new Spec.event_cell_t(); // event cell
	public SelectedValue<Spec> selection = new SelectedValue<Spec>(); // selected value

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	StaticDataCell() = default;
	public StaticDataCell(in Spec.meas_t value, in Spec.config_t config)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.value = value;
		this.value.CopyFrom(value);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.config = config;
		this.config.CopyFrom(config);
	}
	public StaticDataCell(in Spec.config_t config)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.config = config;
		this.config.CopyFrom(config);
	}
}

} // namespace opendnp3

