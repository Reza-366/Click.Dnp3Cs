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
//ORIGINAL LINE: struct BinaryInfo : private StaticOnly
public class BinaryInfo : StaticOnly
{

	public const EventType EventTypeEnum = EventType.Binary;
	public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.BinaryInput;
	public const EventBinaryVariation DefaultEventVariation;
	public const StaticBinaryVariation DefaultStaticVariation;
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct DoubleBitBinaryInfo : private StaticOnly
public class DoubleBitBinaryInfo : StaticOnly
{

	public const EventType EventTypeEnum = EventType.DoubleBitBinary;
	public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.DoubleBinaryInput;
//C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const event_variation_t DefaultEventVariation = new event_variation_t();
//C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const static_variation_t DefaultStaticVariation = new static_variation_t();
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct BinaryOutputStatusInfo : private StaticOnly
public class BinaryOutputStatusInfo : StaticOnly
{

	public const EventType EventTypeEnum = EventType.BinaryOutputStatus;
	public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.BinaryOutputStatus;
//C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const event_variation_t DefaultEventVariation = new event_variation_t();
//C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const static_variation_t DefaultStaticVariation = new static_variation_t();
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct AnalogInfo : private StaticOnly
public class AnalogInfo : StaticOnly
{

	public const EventType EventTypeEnum = EventType.Analog;
	public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.AnalogInput;
//C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const event_variation_t DefaultEventVariation = new event_variation_t();
//C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const static_variation_t DefaultStaticVariation = new static_variation_t();
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct CounterInfo : private StaticOnly
public class CounterInfo : StaticOnly
{

	public const EventType EventTypeEnum = EventType.Counter;
	public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.Counter;
//C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const event_variation_t DefaultEventVariation = new event_variation_t();
//C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const static_variation_t DefaultStaticVariation = new static_variation_t();
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct FrozenCounterInfo : private StaticOnly
public class FrozenCounterInfo : StaticOnly
{

	public const EventType EventTypeEnum = EventType.FrozenCounter;
	public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.FrozenCounter;
//C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const event_variation_t DefaultEventVariation = new event_variation_t();
//C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const static_variation_t DefaultStaticVariation = new static_variation_t();
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct AnalogOutputStatusInfo : private StaticOnly
public class AnalogOutputStatusInfo : StaticOnly
{

	public const EventType EventTypeEnum = EventType.AnalogOutputStatus;
	public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.AnalogOutputStatus;
//C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const event_variation_t DefaultEventVariation = new event_variation_t();
//C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const static_variation_t DefaultStaticVariation = new static_variation_t();
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct OctetStringInfo : private StaticOnly
public class OctetStringInfo : StaticOnly
{

	public const EventType EventTypeEnum = EventType.OctetString;
	public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.OctetString;
//C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const event_variation_t DefaultEventVariation = new event_variation_t();
//C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
	public const static_variation_t DefaultStaticVariation = new static_variation_t();
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct TimeAndIntervalInfo : private StaticOnly
public class TimeAndIntervalInfo : StaticOnly
{

	public const StaticTypeBitmask StaticTypeEnum = (opendnp3.StaticTypeBitmask)StaticTypeBitmask.TimeAndInterval;
	public const StaticTimeAndIntervalVariation DefaultStaticVariation = StaticTimeAndIntervalVariation.Group50Var4;
}

} // namespace opendnp3



