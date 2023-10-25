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

// All entries have this information
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<typename Info>
public class StaticConfig <Info>
{
	public Info.static_variation_t svariation = Info.DefaultStaticVariation;
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<typename Info>
public class EventConfig <Info> : StaticConfig<Info>
{
	public PointClass clazz = PointClass.Class1;
	public Info.event_variation_t evariation = Info.DefaultEventVariation;
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Info>
public class DeadbandConfig <Info> : EventConfig<Info>
{
	public Info.value_t deadband = 0;
}

public class BinaryConfig : EventConfig<BinaryInfo>
{
}

public class DoubleBitBinaryConfig : EventConfig<DoubleBitBinaryInfo>
{
}

public class AnalogConfig : DeadbandConfig<AnalogInfo>
{
}

public class CounterConfig : DeadbandConfig<CounterInfo>
{
}

public class FrozenCounterConfig : DeadbandConfig<FrozenCounterInfo>
{
}

public class BOStatusConfig : EventConfig<BinaryOutputStatusInfo>
{
}

public class AOStatusConfig : DeadbandConfig<AnalogOutputStatusInfo>
{
}

public class OctetStringConfig : EventConfig<OctetStringInfo>
{
}

public class TimeAndIntervalConfig : StaticConfig<TimeAndIntervalInfo>
{
}

public class SecurityStatConfig
{
}

} // namespace opendnp3

