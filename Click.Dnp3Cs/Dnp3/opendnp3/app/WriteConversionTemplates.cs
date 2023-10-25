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
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertQ : private StaticOnly
public class ConvertQ <Target, Source> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		t.flags = src.flags.value;
		return t;
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertQV : private StaticOnly
public class ConvertQV <Target, Source> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		t.value = src.value;
		t.flags = src.flags.value;
		return t;
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertV : private StaticOnly
public class ConvertV <Target, Source> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		t.value = src.value;
		return t;
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertVandTruncate : private StaticOnly
public class ConvertVandTruncate <Target, Source> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		t.value = (typename Target.ValueType)src.value;
		return t;
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertVRangeCheck : private StaticOnly
public class ConvertVRangeCheck <Target, Source> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		DownSampling<typename Source.Type, typename Target.ValueType>.Apply(src.value, ref t.value);
		return t;
	}
}

//C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
//ORIGINAL LINE: template<class Target, class Source, System.Byte Overrange> struct ConvertQVRangeCheck : private StaticOnly
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source, typename Overrange> requires System.Byte<Overrange>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertQVRangeCheck : private StaticOnly
public class ConvertQVRangeCheck <Target, Source, Overrange> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		var overrange = DownSampling<typename Source.Type, typename Target.ValueType>.Apply(src.value, ref t.value);
		t.flags = overrange ? Overrange : 0;
		t.flags |= src.flags.value;
		return t;
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertQVandTruncate : private StaticOnly
public class ConvertQVandTruncate <Target, Source> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		t.flags = src.flags.value;
		t.value = (typename Target.ValueType)src.value;
		return t;
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertQVT : private StaticOnly
public class ConvertQVT <Target, Source> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		t.flags = src.flags.value;
		t.value = src.value;
		t.time = src.time;
		return t;
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertQVTandTruncate : private StaticOnly
public class ConvertQVTandTruncate <Target, Source> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		t.flags = src.flags.value;
		t.value = (typename Target.ValueType)src.value;
		t.time = src.time;
		return t;
	}
}

//C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
//ORIGINAL LINE: template<class Target, class Source, System.Byte Overrange> struct ConvertQVTRangeCheck : private StaticOnly
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source, typename Overrange> requires System.Byte<Overrange>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertQVTRangeCheck : private StaticOnly
public class ConvertQVTRangeCheck <Target, Source, Overrange> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		var overrange = DownSampling<typename Source.Type, typename Target.ValueType>.Apply(src.value, ref t.value);
		t.flags = overrange ? Overrange : 0;
		t.flags |= src.flags.value;
		t.time = src.time;
		return t;
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertQT : private StaticOnly
public class ConvertQT <Target, Source> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		t.flags = src.flags.value;
		t.time = src.time;
		return t;
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source, class Downcast>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertQTDowncast : private StaticOnly
public class ConvertQTDowncast <Target, Source, Downcast> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		t.flags = src.flags.value;
		t.time = (Downcast)src.time.value;
		return t;
	}
}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source>
//C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
//ORIGINAL LINE: struct ConvertQS : private StaticOnly
public class ConvertQS <Target, Source> : StaticOnly
{
	public static Target Apply(in Source src)
	{
		Target t = default(Target);
		t.value = src.value;
		t.status = CommandStatusSpec.to_type(src.status);
		return t;
	}
}

} // namespace opendnp3

