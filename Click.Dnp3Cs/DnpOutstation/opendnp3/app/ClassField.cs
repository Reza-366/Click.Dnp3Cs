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

/**
 * Specifies a set of event classes e.g. some subset of {0, 1, 2, 3}
 */
public class ClassField
{
	public ClassField()
	{
		this.bitfield = 0;
	}

	public ClassField(PointClass pc)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.bitfield = static_cast<byte>(pc);
		this.bitfield.CopyFrom((byte)pc);
	}

	public ClassField(EventClass ec) : this(false, ec == EventClass.EC1, ec == EventClass.EC2, ec == EventClass.EC3)
	{
	}

	public ClassField(byte mask_)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.bitfield = mask_ & ALL_CLASSES;
		this.bitfield.CopyFrom(mask_ & ALL_CLASSES);
	}

	public ClassField(bool class0, bool class1, bool class2, bool class3)
	{
		this.bitfield = 0;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: bitfield = class0 ? ClassField::CLASS_0 : 0;
		bitfield.CopyFrom(class0 ? ClassField.CLASS_0 : 0);
		bitfield |= class1 ? ClassField.CLASS_1 : 0;
		bitfield |= class2 ? ClassField.CLASS_2 : 0;
		bitfield |= class3 ? ClassField.CLASS_3 : 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsEmpty() const
	public bool IsEmpty()
	{
		return (bitfield == 0);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool Intersects(const ClassField& other) const
	public bool Intersects(in ClassField other)
	{
		return (bitfield & other.bitfield) != 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: byte GetBitfield() const
	public byte GetBitfield()
	{
		return new byte(bitfield);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ClassField OnlyEventClasses() const
	public ClassField OnlyEventClasses()
	{
		return new ClassField(bitfield & EVENT_CLASSES);
	}

	public void Clear(in ClassField field)
	{
		bitfield &= ~(field.bitfield);
	}

	public void Set(in ClassField field)
	{
		bitfield |= field.bitfield;
	}

	public void Set(PointClass pc)
	{
		bitfield |= (byte)pc;
	}

	public static byte CLASS_0 = static_cast<byte>(PointClass.Class0);
	public static byte CLASS_1 = static_cast<byte>(PointClass.Class1);
	public static byte CLASS_2 = static_cast<byte>(PointClass.Class2);
	public static byte CLASS_3 = static_cast<byte>(PointClass.Class3);
	public static byte EVENT_CLASSES = CLASS_1 | CLASS_2 | CLASS_3;
	public static byte ALL_CLASSES = EVENT_CLASSES | CLASS_0;

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool HasEventType(EventClass ec) const
	public bool HasEventType(EventClass ec)
	{
		switch (ec)
		{
		case (EventClass.EC1):
			return HasClass1();
		case (EventClass.EC2):
			return HasClass2();
		case (EventClass.EC3):
			return HasClass3();
		default:
			return false;
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool HasClass0() const
	public bool HasClass0()
	{
		return (bitfield & CLASS_0) != 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool HasClass1() const
	public bool HasClass1()
	{
		return (bitfield & CLASS_1) != 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool HasClass2() const
	public bool HasClass2()
	{
		return (bitfield & CLASS_2) != 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool HasClass3() const
	public bool HasClass3()
	{
		return (bitfield & CLASS_3) != 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool HasEventClass() const
	public bool HasEventClass()
	{
		return (bitfield & EVENT_CLASSES) != 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool HasAnyClass() const
	public bool HasAnyClass()
	{
		return bitfield != 0;
	}

	public static ClassField None()
	{
		return new ClassField();
	}

	public static ClassField AllClasses()
	{
		return new ClassField(ALL_CLASSES);
	}

	public static ClassField AllEventClasses()
	{
		return new ClassField(EVENT_CLASSES);
	}

	private byte bitfield = new byte();
}

} // namespace opendnp3



