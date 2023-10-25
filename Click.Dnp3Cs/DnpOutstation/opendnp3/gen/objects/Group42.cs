using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ser4cpp;

//
//  _   _         ______    _ _ _   _             _ _ _
// | \ | |       |  ____|  | (_) | (_)           | | | |
// |  \| | ___   | |__   __| |_| |_ _ _ __   __ _| | | |
// | . ` |/ _ \  |  __| / _` | | __| | '_ \ / _` | | | |
// | |\  | (_) | | |___| (_| | | |_| | | | | (_| |_|_|_|
// |_| \_|\___/  |______\__,_|_|\__|_|_| |_|\__, (_|_|_)
//                                           __/ |
//                                          |___/
// 
// This file is auto-generated. Do not edit manually
// 
// Copyright 2013-2022 Step Function I/O, LLC
// 
// Licensed to Green Energy Corp (www.greenenergycorp.com) and Step Function I/O
// LLC (https://stepfunc.io) under one or more contributor license agreements.
// See the NOTICE file distributed with this work for additional information
// regarding copyright ownership. Green Energy Corp and Step Function I/O LLC license
// this file to you under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License. You may obtain
// a copy of the License at:
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

//
//  _   _         ______    _ _ _   _             _ _ _
// | \ | |       |  ____|  | (_) | (_)           | | | |
// |  \| | ___   | |__   __| |_| |_ _ _ __   __ _| | | |
// | . ` |/ _ \  |  __| / _` | | __| | '_ \ / _` | | | |
// | |\  | (_) | | |___| (_| | | |_| | | | | (_| |_|_|_|
// |_| \_|\___/  |______\__,_|_|\__|_|_| |_|\__, (_|_|_)
//                                           __/ |
//                                          |___/
// 
// This file is auto-generated. Do not edit manually
// 
// Copyright 2013-2022 Step Function I/O, LLC
// 
// Licensed to Green Energy Corp (www.greenenergycorp.com) and Step Function I/O
// LLC (https://stepfunc.io) under one or more contributor license agreements.
// See the NOTICE file distributed with this work for additional information
// regarding copyright ownership. Green Energy Corp and Step Function I/O LLC license
// this file to you under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License. You may obtain
// a copy of the License at:
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//




namespace opendnp3
{

// Analog Output Event - Any Variation
public partial class Group42Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 0);
  }
}

// Analog Output Event - 32-bit With Flag
public partial class Group42Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 1);
  }


  // ------- Group42Var1 -------

  public Group42Var1()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group42Var1 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group42Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public int value = new int();

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputStatus output)
  {
	Group42Var1 value = new Group42Var1();
	if (Read(buff, value))
	{
	  output = AnalogOutputStatusFactory.From(new byte(value.flags), new int(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogOutputStatus UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - 16-bit With Flag
public partial class Group42Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 2);
  }


  // ------- Group42Var2 -------

  public Group42Var2()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 3;
  }
  public static bool Read(rseq_t buffer, Group42Var2 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group42Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public Int16 value = new Int16();

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputStatus output)
  {
	Group42Var2 value = new Group42Var2();
	if (Read(buff, value))
	{
	  output = AnalogOutputStatusFactory.From(new byte(value.flags), new Int16(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogOutputStatus UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - 32-bit With Flag and Time
public partial class Group42Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 3);
  }


  // ------- Group42Var3 -------

  public Group42Var3()
  {
	  this.flags = 0;
	  this.value = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 11;
  }
  public static bool Read(rseq_t buffer, Group42Var3 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group42Var3 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public int value = new int();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputStatus output)
  {
	Group42Var3 value = new Group42Var3();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = AnalogOutputStatusFactory::From(value.flags, value.value, value.time);
	  output = AnalogOutputStatusFactory.From(new byte(value.flags), new int(value.value), new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogOutputStatus UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - 16-bit With Flag and Time
public partial class Group42Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 4);
  }


  // ------- Group42Var4 -------

  public Group42Var4()
  {
	  this.flags = 0;
	  this.value = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 9;
  }
  public static bool Read(rseq_t buffer, Group42Var4 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group42Var4 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public Int16 value = new Int16();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputStatus output)
  {
	Group42Var4 value = new Group42Var4();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = AnalogOutputStatusFactory::From(value.flags, value.value, value.time);
	  output = AnalogOutputStatusFactory.From(new byte(value.flags), new Int16(value.value), new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogOutputStatus UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - Single-precision With Flag
public partial class Group42Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 5);
  }


  // ------- Group42Var5 -------

  public Group42Var5()
  {
	  this.flags = 0;
	  this.value = 0.0F;
  }

  public static /*size_t*/int Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group42Var5 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group42Var5 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public float value;

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputStatus output)
  {
	Group42Var5 value = new Group42Var5();
	if (Read(buff, value))
	{
	  output = AnalogOutputStatusFactory.From(new byte(value.flags), value.value);
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogOutputStatus UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - Double-precision With Flag
public partial class Group42Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 6);
  }


  // ------- Group42Var6 -------

  public Group42Var6()
  {
	  this.flags = 0;
	  this.value = 0.0;
  }

  public static /*size_t*/int Size()
  {
	  return 9;
  }
  public static bool Read(rseq_t buffer, Group42Var6 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group42Var6 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public double value;

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputStatus output)
  {
	Group42Var6 value = new Group42Var6();
	if (Read(buff, value))
	{
	  output = AnalogOutputStatusFactory.From(new byte(value.flags), value.value);
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogOutputStatus UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - Single-precision With Flag and Time
public partial class Group42Var7
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 7);
  }


  // ------- Group42Var7 -------

  public Group42Var7()
  {
	  this.flags = 0;
	  this.value = 0.0F;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 11;
  }
  public static bool Read(rseq_t buffer, Group42Var7 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group42Var7 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public float value;
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputStatus output)
  {
	Group42Var7 value = new Group42Var7();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = AnalogOutputStatusFactory::From(value.flags, value.value, value.time);
	  output = AnalogOutputStatusFactory.From(new byte(value.flags), value.value, new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogOutputStatus UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - Double-precision With Flag and Time
public partial class Group42Var8
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 8);
  }


  // ------- Group42Var8 -------

  public Group42Var8()
  {
	  this.flags = 0;
	  this.value = 0.0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 15;
  }
  public static bool Read(rseq_t buffer, Group42Var8 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group42Var8 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public double value;
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputStatus output)
  {
	Group42Var8 value = new Group42Var8();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = AnalogOutputStatusFactory::From(value.flags, value.value, value.time);
	  output = AnalogOutputStatusFactory.From(new byte(value.flags), value.value, new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogOutputStatus UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}


}




//
//  _   _         ______    _ _ _   _             _ _ _
// | \ | |       |  ____|  | (_) | (_)           | | | |
// |  \| | ___   | |__   __| |_| |_ _ _ __   __ _| | | |
// | . ` |/ _ \  |  __| / _` | | __| | '_ \ / _` | | | |
// | |\  | (_) | | |___| (_| | | |_| | | | | (_| |_|_|_|
// |_| \_|\___/  |______\__,_|_|\__|_|_| |_|\__, (_|_|_)
//                                           __/ |
//                                          |___/
// 
// This file is auto-generated. Do not edit manually
// 
// Copyright 2013-2022 Step Function I/O, LLC
// 
// Licensed to Green Energy Corp (www.greenenergycorp.com) and Step Function I/O
// LLC (https://stepfunc.io) under one or more contributor license agreements.
// See the NOTICE file distributed with this work for additional information
// regarding copyright ownership. Green Energy Corp and Step Function I/O LLC license
// this file to you under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License. You may obtain
// a copy of the License at:
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//




namespace opendnp3
{

// Analog Output Event - Any Variation
public partial class Group42Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 0);
  }
}

// Analog Output Event - 32-bit With Flag
public partial class Group42Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group42Var1();

  public static /*size_t*/int Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group42Var1 UnnamedParameter2);
  public static bool Write(in Group42Var1 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public byte flags = new byte();
  public int value = new int();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, AnalogOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputStatus value, WSeq</*size_t*/int> buff)
  {
	return Group42Var1.Write(ConvertQVRangeCheck<Group42Var1, AnalogOutputStatus, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - 16-bit With Flag
public partial class Group42Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group42Var2();

  public static /*size_t*/int Size()
  {
	  return 3;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group42Var2 UnnamedParameter2);
  public static bool Write(in Group42Var2 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public byte flags = new byte();
  public Int16 value = new Int16();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, AnalogOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputStatus value, WSeq</*size_t*/int> buff)
  {
	return Group42Var2.Write(ConvertQVRangeCheck<Group42Var2, AnalogOutputStatus, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - 32-bit With Flag and Time
public partial class Group42Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 3);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group42Var3();

  public static /*size_t*/int Size()
  {
	  return 11;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group42Var3 UnnamedParameter2);
  public static bool Write(in Group42Var3 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public byte flags = new byte();
  public int value = new int();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, AnalogOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputStatus value, WSeq</*size_t*/int> buff)
  {
	return Group42Var3.Write(ConvertQVTRangeCheck<Group42Var3, AnalogOutputStatus, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - 16-bit With Flag and Time
public partial class Group42Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 4);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group42Var4();

  public static /*size_t*/int Size()
  {
	  return 9;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group42Var4 UnnamedParameter2);
  public static bool Write(in Group42Var4 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public byte flags = new byte();
  public Int16 value = new Int16();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, AnalogOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputStatus value, WSeq</*size_t*/int> buff)
  {
	return Group42Var4.Write(ConvertQVTRangeCheck<Group42Var4, AnalogOutputStatus, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - Single-precision With Flag
public partial class Group42Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 5);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group42Var5();

  public static /*size_t*/int Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group42Var5 UnnamedParameter2);
  public static bool Write(in Group42Var5 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public byte flags = new byte();
  public float value;

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, AnalogOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputStatus value, WSeq</*size_t*/int> buff)
  {
	return Group42Var5.Write(ConvertQVRangeCheck<Group42Var5, AnalogOutputStatus, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - Double-precision With Flag
public partial class Group42Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 6);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group42Var6();

  public static /*size_t*/int Size()
  {
	  return 9;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group42Var6 UnnamedParameter2);
  public static bool Write(in Group42Var6 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public byte flags = new byte();
  public double value;

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, AnalogOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputStatus value, WSeq</*size_t*/int> buff)
  {
	return Group42Var6.Write(ConvertQV<Group42Var6, AnalogOutputStatus>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - Single-precision With Flag and Time
public partial class Group42Var7
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 7);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group42Var7();

  public static /*size_t*/int Size()
  {
	  return 11;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group42Var7 UnnamedParameter2);
  public static bool Write(in Group42Var7 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public byte flags = new byte();
  public float value;
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, AnalogOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputStatus value, WSeq</*size_t*/int> buff)
  {
	return Group42Var7.Write(ConvertQVTRangeCheck<Group42Var7, AnalogOutputStatus, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output Event - Double-precision With Flag and Time
public partial class Group42Var8
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(42, 8);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group42Var8();

  public static /*size_t*/int Size()
  {
	  return 15;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group42Var8 UnnamedParameter2);
  public static bool Write(in Group42Var8 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public byte flags = new byte();
  public double value;
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, AnalogOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputStatus value, WSeq</*size_t*/int> buff)
  {
	return Group42Var8.Write(ConvertQVT<Group42Var8, AnalogOutputStatus>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
}


}

