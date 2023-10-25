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

//C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
//class HeaderWriter;

/**
 * An enumeration that defines the type of object header
 */
public enum HeaderType : System.Byte
{
	AllObjects,
	Ranged8,
	Ranged16,
	LimitedCount8,
	LimitedCount16
}

/**
 * A template for a integer range
 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public class StartStopRange <T>
{
	public T start = default(T);
	public T stop = default(T);
}

/**
 * A template for an integer count
 */
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public class Count <T>
{
	public T value = default(T);
}

/**
 * Union type that holds information for a single header type
 */
//C++ TO C# CONVERTER TASK: Unions are not supported in C#:
//union HeaderUnion
//{
//	StartStopRange<System.Byte> range8;
//	StartStopRange<UInt16> range16;
//	Count<System.Byte> count8;
//	Count<UInt16> count16;
//};

/**
 * Class used to specify a header type
 */
public class Header
{
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool WriteTo(HeaderWriter& writer) const
	public bool WriteTo(HeaderWriter writer)
	{
		switch (type)
		{
		case (HeaderType.AllObjects):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return writer.WriteHeader(id, QualifierCode::ALL_OBJECTS);
			return writer.WriteHeader(new opendnp3.GroupVariationID(id), QualifierCode.ALL_OBJECTS);
		case (HeaderType.Ranged8):
			return writer.WriteRangeHeader<ser4cpp.UInt8>(QualifierCode.UINT8_START_STOP, id, value.range8.start, value.range8.stop);
		case (HeaderType.Ranged16):
			return writer.WriteRangeHeader<new ser4cpp.Globals.Bit16<UInt16, 0, 1>>(QualifierCode.UINT16_START_STOP, id, value.range16.start, value.range16.stop);
		case (HeaderType.LimitedCount8):
			return writer.WriteCountHeader<ser4cpp.UInt8>(QualifierCode.UINT8_CNT, id, value.count8.value);
		case (HeaderType.LimitedCount16):
			return writer.WriteCountHeader<new ser4cpp.Globals.Bit16<UInt16, 0, 1>>(QualifierCode.UINT16_CNT, id, value.count16.value);
		default:
			return false;
		}
	}

	/**
	 * Create an all objects (0x06) header
	 */
	public static Header AllObjects(System.Byte group, System.Byte variation)
	{
		return new Header(group, variation);
	}

	/**
	 * Create an all objects (0x06) header
	 */
	public static Header From(PointClass pc)
	{
		switch (pc)
		{
		case (PointClass.Class0):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return Header::AllObjects(60, 1);
			return new opendnp3.Header(Header.AllObjects(60, 1));
		case (PointClass.Class1):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return Header::AllObjects(60, 2);
			return new opendnp3.Header(Header.AllObjects(60, 2));
		case (PointClass.Class2):
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return Header::AllObjects(60, 3);
			return new opendnp3.Header(Header.AllObjects(60, 3));
		default:
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return Header::AllObjects(60, 4);
			return new opendnp3.Header(Header.AllObjects(60, 4));
		}
	}

	/**
	 * Create a 8-bit start stop header (0x00)
	 */
	public static Header Range8(System.Byte group, System.Byte variation, System.Byte start, System.Byte stop)
	{
		return new Header(group, variation, start, stop);
	}

	/**
	 * Create a 16-bit start stop header (0x01)
	 */
	public static Header Range16(System.Byte group, System.Byte variation, UInt16 start, UInt16 stop)
	{
		return new Header(group, variation, start, stop);
	}

	/**
	 * Create a 8-bit count header (0x07)
	 */
	public static Header Count8(System.Byte group, System.Byte variation, System.Byte count)
	{
		return new Header(group, variation, count);
	}

	/**
	 * Create a 16-bit count header (0x08)
	 */
	public static Header Count16(System.Byte group, System.Byte variation, UInt16 count)
	{
		return new Header(group, variation, count);
	}

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	Header() = default;

	private GroupVariationID id = new GroupVariationID();
	private HeaderType type = HeaderType.AllObjects;
	private HeaderUnion value = new HeaderUnion();

	private Header(System.Byte group, System.Byte @var)
	{
		this.id = new opendnp3.GroupVariationID(group, @var);
		this.type = new opendnp3.HeaderType.AllObjects;
	}

	private Header(System.Byte group, System.Byte @var, System.Byte start, System.Byte stop)
	{
		this.id = new opendnp3.GroupVariationID(group, @var);
		this.type = new opendnp3.HeaderType.Ranged8;
		value.range8 = new StartStopRange() {start = start, stop = stop};
	}

	private Header(System.Byte group, System.Byte @var, UInt16 start, UInt16 stop)
	{
		this.id = new opendnp3.GroupVariationID(group, @var);
		this.type = new opendnp3.HeaderType.Ranged16;
		value.range16 = new StartStopRange() {start = start, stop = stop};
	}

	private Header(System.Byte group, System.Byte @var, System.Byte count)
	{
		this.id = new opendnp3.GroupVariationID(group, @var);
		this.type = new opendnp3.HeaderType.LimitedCount8;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: value.count8.value = count;
		value.count8.value.CopyFrom(count);
	}

	private Header(System.Byte group, System.Byte @var, UInt16 count)
	{
		this.id = new opendnp3.GroupVariationID(group, @var);
		this.type = new opendnp3.HeaderType.LimitedCount16;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: value.count16.value = count;
		value.count16.value.CopyFrom(count);
	}
}

} // namespace opendnp3



