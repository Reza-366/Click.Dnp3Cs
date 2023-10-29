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

// Frozen Counter Event - Any Variation
public partial class Group23Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(23, 0);
  }
}

// Frozen Counter Event - 32-bit With Flag
public partial class Group23Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(23, 1);
  }


  // ------- Group23Var1 -------

  public Group23Var1()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 5;
  }
  public static bool Read(RSeq buffer, Group23Var1 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group23Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public uint value = new uint();

  public static bool ReadTarget(RSeq buff, ref FrozenCounter output)
  {
	Group23Var1 value = new Group23Var1();
	if (Read(buff, value))
	{
	  output = FrozenCounterFactory.From(new byte(value.flags), new uint(value.value));
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
}

// Frozen Counter Event - 16-bit With Flag
public partial class Group23Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(23, 2);
  }


  // ------- Group23Var2 -------

  public Group23Var2()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 3;
  }
  public static bool Read(RSeq buffer, Group23Var2 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group23Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public ushort value = new ushort();

  public static bool ReadTarget(RSeq buff, ref FrozenCounter output)
  {
	Group23Var2 value = new Group23Var2();
	if (Read(buff, value))
	{
	  output = FrozenCounterFactory.From(new byte(value.flags), new ushort(value.value));
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
}

// Frozen Counter Event - 32-bit With Flag and Time
public partial class Group23Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(23, 5);
  }


  // ------- Group23Var5 -------

  public Group23Var5()
  {
	  this.flags = 0;
	  this.value = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 11;
  }
  public static bool Read(RSeq buffer, Group23Var5 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group23Var5 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public uint value = new uint();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(RSeq buff, ref FrozenCounter output)
  {
	Group23Var5 value = new Group23Var5();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = FrozenCounterFactory::From(value.flags, value.value, value.time);
	  output = FrozenCounterFactory.From(new byte(value.flags), new uint(value.value), new opendnp3.DNPTime(value.time));
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
}

// Frozen Counter Event - 16-bit With Flag and Time
public partial class Group23Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(23, 6);
  }


  // ------- Group23Var6 -------

  public Group23Var6()
  {
	  this.flags = 0;
	  this.value = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 9;
  }
  public static bool Read(RSeq buffer, Group23Var6 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group23Var6 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public ushort value = new ushort();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(RSeq buff, ref FrozenCounter output)
  {
	Group23Var6 value = new Group23Var6();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = FrozenCounterFactory::From(value.flags, value.value, value.time);
	  output = FrozenCounterFactory.From(new byte(value.flags), new ushort(value.value), new opendnp3.DNPTime(value.time));
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

// Frozen Counter Event - Any Variation
public partial class Group23Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(23, 0);
  }
}

// Frozen Counter Event - 32-bit With Flag
public partial class Group23Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(23, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group23Var1();

  public static /*size_t*/int Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq/*<size_t>*/ UnnamedParameter, Group23Var1 UnnamedParameter2);
  public static bool Write(in Group23Var1 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public byte flags = new byte();
  public uint value = new uint();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq/*<size_t>*/ UnnamedParameter, FrozenCounter UnnamedParameter2);
  public static bool WriteTarget(in FrozenCounter value, WSeq</*size_t*/int> buff)
  {
	return Group23Var1.Write(ConvertQV<Group23Var1, FrozenCounter>.Apply(value), buff);
  }

  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Frozen Counter Event - 16-bit With Flag
public partial class Group23Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(23, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group23Var2();

  public static /*size_t*/int Size()
  {
	  return 3;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq/*<size_t>*/ UnnamedParameter, Group23Var2 UnnamedParameter2);
  public static bool Write(in Group23Var2 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public byte flags = new byte();
  public ushort value = new ushort();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq/*<size_t>*/ UnnamedParameter, FrozenCounter UnnamedParameter2);
  public static bool WriteTarget(in FrozenCounter value, WSeq</*size_t*/int> buff)
  {
	return Group23Var2.Write(ConvertQVandTruncate<Group23Var2, FrozenCounter>.Apply(value), buff);
  }

  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Frozen Counter Event - 32-bit With Flag and Time
public partial class Group23Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(23, 5);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group23Var5();

  public static /*size_t*/int Size()
  {
	  return 11;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq/*<size_t>*/ UnnamedParameter, Group23Var5 UnnamedParameter2);
  public static bool Write(in Group23Var5 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public byte flags = new byte();
  public uint value = new uint();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq/*<size_t>*/ UnnamedParameter, FrozenCounter UnnamedParameter2);
  public static bool WriteTarget(in FrozenCounter value, WSeq</*size_t*/int> buff)
  {
	return Group23Var5.Write(ConvertQVT<Group23Var5, FrozenCounter>.Apply(value), buff);
  }

  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Frozen Counter Event - 16-bit With Flag and Time
public partial class Group23Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(23, 6);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group23Var6();

  public static /*size_t*/int Size()
  {
	  return 9;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq/*<size_t>*/ UnnamedParameter, Group23Var6 UnnamedParameter2);
  public static bool Write(in Group23Var6 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public byte flags = new byte();
  public ushort value = new ushort();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq/*<size_t>*/ UnnamedParameter, FrozenCounter UnnamedParameter2);
  public static bool WriteTarget(in FrozenCounter value, WSeq</*size_t*/int> buff)
  {
	return Group23Var6.Write(ConvertQVTandTruncate<Group23Var6, FrozenCounter>.Apply(value), buff);
  }

  public static DNP3Serializer<FrozenCounter> Inst()
  {
	  return DNP3Serializer<FrozenCounter>(ID(), Size(), ReadTarget, WriteTarget);
  }
}


}

