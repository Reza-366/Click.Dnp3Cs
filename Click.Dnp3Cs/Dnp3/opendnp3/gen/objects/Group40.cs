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

// Analog Output Status - Any Variation
public partial class Group40Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(40, 0);
  }
}

// Analog Output Status - 32-bit With Flag
public partial class Group40Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(40, 1);
  }


  // ------- Group40Var1 -------

  public Group40Var1()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group40Var1 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group40Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public int32_t value = new int32_t();

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputStatus output)
  {
	Group40Var1 value = new Group40Var1();
	if (Read(buff, value))
	{
	  output = AnalogOutputStatusFactory.From(new System.Byte(value.flags), new int32_t(value.value));
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
  public const StaticAnalogOutputStatusVariation svariation = StaticAnalogOutputStatusVariation.Group40Var1;
}

// Analog Output Status - 16-bit With Flag
public partial class Group40Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(40, 2);
  }


  // ------- Group40Var2 -------

  public Group40Var2()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 3;
  }
  public static bool Read(rseq_t buffer, Group40Var2 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group40Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public int16_t value = new int16_t();

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputStatus output)
  {
	Group40Var2 value = new Group40Var2();
	if (Read(buff, value))
	{
	  output = AnalogOutputStatusFactory.From(new System.Byte(value.flags), new int16_t(value.value));
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
  public const StaticAnalogOutputStatusVariation svariation = StaticAnalogOutputStatusVariation.Group40Var2;
}

// Analog Output Status - Single-precision With Flag
public partial class Group40Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(40, 3);
  }


  // ------- Group40Var3 -------

  public Group40Var3()
  {
	  this.flags = 0;
	  this.value = 0.0F;
  }

  public static size_t Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group40Var3 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group40Var3 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public float value;

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputStatus output)
  {
	Group40Var3 value = new Group40Var3();
	if (Read(buff, value))
	{
	  output = AnalogOutputStatusFactory.From(new System.Byte(value.flags), value.value);
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
  public const StaticAnalogOutputStatusVariation svariation = StaticAnalogOutputStatusVariation.Group40Var3;
}

// Analog Output Status - Double-precision With Flag
public partial class Group40Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(40, 4);
  }


  // ------- Group40Var4 -------

  public Group40Var4()
  {
	  this.flags = 0;
	  this.value = 0.0;
  }

  public static size_t Size()
  {
	  return 9;
  }
  public static bool Read(rseq_t buffer, Group40Var4 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group40Var4 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public double value;

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputStatus output)
  {
	Group40Var4 value = new Group40Var4();
	if (Read(buff, value))
	{
	  output = AnalogOutputStatusFactory.From(new System.Byte(value.flags), value.value);
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
  public const StaticAnalogOutputStatusVariation svariation = StaticAnalogOutputStatusVariation.Group40Var4;
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

// Analog Output Status - Any Variation
public partial class Group40Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(40, 0);
  }
}

// Analog Output Status - 32-bit With Flag
public partial class Group40Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(40, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group40Var1();

  public static size_t Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group40Var1 UnnamedParameter2);
  public static bool Write(in Group40Var1 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public System.Byte flags = new System.Byte();
  public int32_t value = new int32_t();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, AnalogOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputStatus value, WSeq<size_t> buff)
  {
	return Group40Var1.Write(ConvertQVRangeCheck<Group40Var1, AnalogOutputStatus, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogOutputStatusVariation svariation = StaticAnalogOutputStatusVariation.Group40Var1;
}

// Analog Output Status - 16-bit With Flag
public partial class Group40Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(40, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group40Var2();

  public static size_t Size()
  {
	  return 3;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group40Var2 UnnamedParameter2);
  public static bool Write(in Group40Var2 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public System.Byte flags = new System.Byte();
  public int16_t value = new int16_t();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, AnalogOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputStatus value, WSeq<size_t> buff)
  {
	return Group40Var2.Write(ConvertQVRangeCheck<Group40Var2, AnalogOutputStatus, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogOutputStatusVariation svariation = StaticAnalogOutputStatusVariation.Group40Var2;
}

// Analog Output Status - Single-precision With Flag
public partial class Group40Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(40, 3);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group40Var3();

  public static size_t Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group40Var3 UnnamedParameter2);
  public static bool Write(in Group40Var3 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public System.Byte flags = new System.Byte();
  public float value;

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, AnalogOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputStatus value, WSeq<size_t> buff)
  {
	return Group40Var3.Write(ConvertQVRangeCheck<Group40Var3, AnalogOutputStatus, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogOutputStatusVariation svariation = StaticAnalogOutputStatusVariation.Group40Var3;
}

// Analog Output Status - Double-precision With Flag
public partial class Group40Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(40, 4);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group40Var4();

  public static size_t Size()
  {
	  return 9;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group40Var4 UnnamedParameter2);
  public static bool Write(in Group40Var4 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public System.Byte flags = new System.Byte();
  public double value;

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, AnalogOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputStatus value, WSeq<size_t> buff)
  {
	return Group40Var4.Write(ConvertQV<Group40Var4, AnalogOutputStatus>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputStatus> Inst()
  {
	  return DNP3Serializer<AnalogOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogOutputStatusVariation svariation = StaticAnalogOutputStatusVariation.Group40Var4;
}


}

