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

// Frozen Counter - Any Variation
public partial class Group21Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 0);
  }
}

// Frozen Counter - 32-bit With Flag
public partial class Group21Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 1);
  }


  // ------- Group21Var1 -------

  public Group21Var1()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group21Var1 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group21Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public System.UInt32 value = new System.UInt32();

  public static bool ReadTarget(rseq_t buff, ref FrozenCounter output)
  {
	Group21Var1 value = new Group21Var1();
	if (Read(buff, value))
	{
	  output = FrozenCounterFactory.From(new System.Byte(value.flags), new System.UInt32(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in FrozenCounter UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticFrozenCounterVariation svariation = StaticFrozenCounterVariation.Group21Var1;
}

// Frozen Counter - 16-bit With Flag
public partial class Group21Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 2);
  }


  // ------- Group21Var2 -------

  public Group21Var2()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 3;
  }
  public static bool Read(rseq_t buffer, Group21Var2 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group21Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public UInt16 value = new UInt16();

  public static bool ReadTarget(rseq_t buff, ref FrozenCounter output)
  {
	Group21Var2 value = new Group21Var2();
	if (Read(buff, value))
	{
	  output = FrozenCounterFactory.From(new System.Byte(value.flags), new UInt16(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in FrozenCounter UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticFrozenCounterVariation svariation = StaticFrozenCounterVariation.Group21Var2;
}

// Frozen Counter - 32-bit With Flag and Time
public partial class Group21Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 5);
  }


  // ------- Group21Var5 -------

  public Group21Var5()
  {
	  this.flags = 0;
	  this.value = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static size_t Size()
  {
	  return 11;
  }
  public static bool Read(rseq_t buffer, Group21Var5 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group21Var5 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public System.UInt32 value = new System.UInt32();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref FrozenCounter output)
  {
	Group21Var5 value = new Group21Var5();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = FrozenCounterFactory::From(value.flags, value.value, value.time);
	  output = FrozenCounterFactory.From(new System.Byte(value.flags), new System.UInt32(value.value), new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in FrozenCounter UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticFrozenCounterVariation svariation = StaticFrozenCounterVariation.Group21Var5;
}

// Frozen Counter - 16-bit With Flag and Time
public partial class Group21Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 6);
  }


  // ------- Group21Var6 -------

  public Group21Var6()
  {
	  this.flags = 0;
	  this.value = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static size_t Size()
  {
	  return 9;
  }
  public static bool Read(rseq_t buffer, Group21Var6 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group21Var6 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public UInt16 value = new UInt16();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref FrozenCounter output)
  {
	Group21Var6 value = new Group21Var6();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = FrozenCounterFactory::From(value.flags, value.value, value.time);
	  output = FrozenCounterFactory.From(new System.Byte(value.flags), new UInt16(value.value), new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in FrozenCounter UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticFrozenCounterVariation svariation = StaticFrozenCounterVariation.Group21Var6;
}

// Frozen Counter - 32-bit Without Flag
public partial class Group21Var9
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 9);
  }


  // ------- Group21Var9 -------

  public Group21Var9()
  {
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 4;
  }
  public static bool Read(rseq_t buffer, Group21Var9 output)
  {
	return LittleEndian.read(buffer, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group21Var9 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.UInt32 value = new System.UInt32();

  public static bool ReadTarget(rseq_t buff, ref FrozenCounter output)
  {
	Group21Var9 value = new Group21Var9();
	if (Read(buff, value))
	{
	  output = FrozenCounterFactory.From(new System.UInt32(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in FrozenCounter UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticFrozenCounterVariation svariation = StaticFrozenCounterVariation.Group21Var9;
}

// Frozen Counter - 16-bit Without Flag
public partial class Group21Var10
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 10);
  }


  // ------- Group21Var10 -------

  public Group21Var10()
  {
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 2;
  }
  public static bool Read(rseq_t buffer, Group21Var10 output)
  {
	return LittleEndian.read(buffer, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group21Var10 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public UInt16 value = new UInt16();

  public static bool ReadTarget(rseq_t buff, ref FrozenCounter output)
  {
	Group21Var10 value = new Group21Var10();
	if (Read(buff, value))
	{
	  output = FrozenCounterFactory.From(new UInt16(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in FrozenCounter UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticFrozenCounterVariation svariation = StaticFrozenCounterVariation.Group21Var10;
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

// Frozen Counter - Any Variation
public partial class Group21Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 0);
  }
}

// Frozen Counter - 32-bit With Flag
public partial class Group21Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group21Var1();

  public static size_t Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group21Var1 UnnamedParameter2);
  public static bool Write(in Group21Var1 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public System.Byte flags = new System.Byte();
  public System.UInt32 value = new System.UInt32();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, FrozenCounter UnnamedParameter2);
  public static bool WriteTarget(in FrozenCounter value, WSeq<size_t> buff)
  {
	return Group21Var1.Write(ConvertQV<Group21Var1, FrozenCounter>.Apply(value), buff);
  }

  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticFrozenCounterVariation svariation = StaticFrozenCounterVariation.Group21Var1;
}

// Frozen Counter - 16-bit With Flag
public partial class Group21Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group21Var2();

  public static size_t Size()
  {
	  return 3;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group21Var2 UnnamedParameter2);
  public static bool Write(in Group21Var2 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public System.Byte flags = new System.Byte();
  public UInt16 value = new UInt16();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, FrozenCounter UnnamedParameter2);
  public static bool WriteTarget(in FrozenCounter value, WSeq<size_t> buff)
  {
	return Group21Var2.Write(ConvertQVandTruncate<Group21Var2, FrozenCounter>.Apply(value), buff);
  }

  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticFrozenCounterVariation svariation = StaticFrozenCounterVariation.Group21Var2;
}

// Frozen Counter - 32-bit With Flag and Time
public partial class Group21Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 5);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group21Var5();

  public static size_t Size()
  {
	  return 11;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group21Var5 UnnamedParameter2);
  public static bool Write(in Group21Var5 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public System.Byte flags = new System.Byte();
  public System.UInt32 value = new System.UInt32();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, FrozenCounter UnnamedParameter2);
  public static bool WriteTarget(in FrozenCounter value, WSeq<size_t> buff)
  {
	return Group21Var5.Write(ConvertQVT<Group21Var5, FrozenCounter>.Apply(value), buff);
  }

  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticFrozenCounterVariation svariation = StaticFrozenCounterVariation.Group21Var5;
}

// Frozen Counter - 16-bit With Flag and Time
public partial class Group21Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 6);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group21Var6();

  public static size_t Size()
  {
	  return 9;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group21Var6 UnnamedParameter2);
  public static bool Write(in Group21Var6 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public System.Byte flags = new System.Byte();
  public UInt16 value = new UInt16();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, FrozenCounter UnnamedParameter2);
  public static bool WriteTarget(in FrozenCounter value, WSeq<size_t> buff)
  {
	return Group21Var6.Write(ConvertQVTandTruncate<Group21Var6, FrozenCounter>.Apply(value), buff);
  }

  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticFrozenCounterVariation svariation = StaticFrozenCounterVariation.Group21Var6;
}

// Frozen Counter - 32-bit Without Flag
public partial class Group21Var9
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 9);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group21Var9();

  public static size_t Size()
  {
	  return 4;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group21Var9 UnnamedParameter2);
  public static bool Write(in Group21Var9 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.value);
  }

  public System.UInt32 value = new System.UInt32();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, FrozenCounter UnnamedParameter2);
  public static bool WriteTarget(in FrozenCounter value, WSeq<size_t> buff)
  {
	return Group21Var9.Write(ConvertV<Group21Var9, FrozenCounter>.Apply(value), buff);
  }

  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticFrozenCounterVariation svariation = StaticFrozenCounterVariation.Group21Var9;
}

// Frozen Counter - 16-bit Without Flag
public partial class Group21Var10
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(21, 10);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group21Var10();

  public static size_t Size()
  {
	  return 2;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group21Var10 UnnamedParameter2);
  public static bool Write(in Group21Var10 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.value);
  }

  public UInt16 value = new UInt16();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, FrozenCounter UnnamedParameter2);
  public static bool WriteTarget(in FrozenCounter value, WSeq<size_t> buff)
  {
	return Group21Var10.Write(ConvertVandTruncate<Group21Var10, FrozenCounter>.Apply(value), buff);
  }

  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticFrozenCounterVariation svariation = StaticFrozenCounterVariation.Group21Var10;
}


}

