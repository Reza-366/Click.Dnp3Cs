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

// Group 1

// Group 2

// Group 3

// Group 3

// Group 10

// Group 11

// Group 12
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertGroup12Var1 : private StaticOnly
public class ConvertGroup12Var1 : StaticOnly
{
	public static Group12Var1 Apply(in ControlRelayOutputBlock crob)
	{
		Group12Var1 ret = new Group12Var1();
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: ret.code = crob.rawCode;
		ret.code=(crob.rawCode);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: ret.count = crob.count;
		ret.count=(crob.count);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: ret.onTime = crob.onTimeMS;
		ret.onTime=(crob.onTimeMS);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: ret.offTime = crob.offTimeMS;
		ret.offTime=(crob.offTimeMS);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: ret.status = CommandStatusSpec::to_type(crob.status);
		ret.status=(CommandStatusSpec.to_type(crob.status));
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ret;
		return new opendnp3.Group12Var1(ret);
	}
}

// Group 13
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertGroup13Var1 : private StaticOnly
public class ConvertGroup13Var1 : StaticOnly
{
	public static Group13Var1 Apply(in BinaryCommandEvent ev)
	{
		Group13Var1 ret = new Group13Var1();
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: ret.flags = ev.GetFlags().value;
		ret.flags.CopyFrom(ev.GetFlags().value);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ret;
		return new opendnp3.Group13Var1(ret);
	}
}

//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertGroup13Var2 : private StaticOnly
public class ConvertGroup13Var2 : StaticOnly
{
	public static Group13Var2 Apply(in BinaryCommandEvent ev)
	{
		Group13Var2 ret = new Group13Var2();
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: ret.flags = ev.GetFlags().value;
		ret.flags.CopyFrom(ev.GetFlags().value);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: ret.time = ev.time;
		ret.time.CopyFrom(ev.time);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ret;
		return new opendnp3.Group13Var2(ret);
	}
}

// Group 20


// Group 21



// Group 22


// Group 23

// Group 30

// Group 32


// Group 41

// Group 42

// Group 43
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertGroup43RangeCheck : private StaticOnly
public class ConvertGroup43RangeCheck <Target> : StaticOnly
{
	public static Target Apply(in AnalogCommandEvent src)
	{
		Target t = default(Target);
		DownSampling<double, typename Target.ValueType>.Apply(src.value, ref t.value);
		t.status = CommandStatusSpec.to_type(src.status);
		return t;
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertGroup43WithTimeRangeCheck : private StaticOnly
public class ConvertGroup43WithTimeRangeCheck <Target> : StaticOnly
{
	public static Target Apply(in AnalogCommandEvent src)
	{
		Target t = default(Target);
		DownSampling<double, typename Target.ValueType>.Apply(src.value, ref t.value);
		t.status = CommandStatusSpec.to_type(src.status);
		t.time = src.time;
		return t;
	}
}


//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertGroup43Var6 : private StaticOnly
public class ConvertGroup43Var6 : StaticOnly
{
	public static Group43Var6 Apply(in AnalogCommandEvent src)
	{
		Group43Var6 t = new Group43Var6();
		t.value = src.value;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: t.status = CommandStatusSpec::to_type(src.status);
		t.status.CopyFrom(CommandStatusSpec.to_type(src.status));
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return t;
		return new opendnp3.Group43Var6(t);
	}
}


//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertGroup43Var8 : private StaticOnly
public class ConvertGroup43Var8 : StaticOnly
{
	public static Group43Var8 Apply(in AnalogCommandEvent src)
	{
		Group43Var8 t = new Group43Var8();
		t.value = src.value;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: t.status = CommandStatusSpec::to_type(src.status);
		t.status.CopyFrom(CommandStatusSpec.to_type(src.status));
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: t.time = src.time;
		t.time.CopyFrom(src.time);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return t;
		return new opendnp3.Group43Var8(t);
	}
}

// Group 50
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertGroup50Var4 : private StaticOnly
public class ConvertGroup50Var4 : StaticOnly
{
	public static Group50Var4 Apply(in TimeAndInterval value)
	{
		Group50Var4 ret = new Group50Var4();
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: ret.time = value.time;
		ret.time.CopyFrom(value.time);
		ret.interval = value.interval;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: ret.units = value.units;
		ret.units.CopyFrom(value.units);
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ret;
		return new opendnp3.Group50Var4(ret);
	}
}

} // namespace opendnp3

