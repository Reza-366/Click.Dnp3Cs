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

// Counter - Any Variation
public partial class Group20Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(20, 0);
  }
}

// Counter - 32-bit With Flag
public partial class Group20Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(20, 1);
  }


  // ------- Group20Var1 -------

  public Group20Var1()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 5;
  }
  public static bool Read(RSeq buffer, Group20Var1 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group20Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public uint value = new uint();

  public static bool ReadTarget(RSeq buff, ref Counter output)
  {
	Group20Var1 value = new Group20Var1();
	if (Read(buff, value))
	{
	  output = CounterFactory.From(new byte(value.flags), new uint(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Counter UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Counter> Inst()
  {
	  return DNP3Serializer<Counter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticCounterVariation svariation = StaticCounterVariation.Group20Var1;
}

// Counter - 16-bit With Flag
public partial class Group20Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(20, 2);
  }


  // ------- Group20Var2 -------

  public Group20Var2()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 3;
  }
  public static bool Read(RSeq buffer, Group20Var2 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group20Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public ushort value = new ushort();

  public static bool ReadTarget(RSeq buff, ref Counter output)
  {
	Group20Var2 value = new Group20Var2();
	if (Read(buff, value))
	{
	  output = CounterFactory.From(new byte(value.flags), new ushort(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Counter UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Counter> Inst()
  {
	  return DNP3Serializer<Counter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticCounterVariation svariation = StaticCounterVariation.Group20Var2;
}

// Counter - 32-bit Without Flag
public partial class Group20Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(20, 5);
  }


  // ------- Group20Var5 -------

  public Group20Var5()
  {
	  this.value = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 4;
  }
  public static bool Read(RSeq buffer, Group20Var5 output)
  {
	return LittleEndian.read(buffer, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group20Var5 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public uint value = new uint();

  public static bool ReadTarget(RSeq buff, ref Counter output)
  {
	Group20Var5 value = new Group20Var5();
	if (Read(buff, value))
	{
	  output = CounterFactory.From(new uint(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Counter UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Counter> Inst()
  {
	  return DNP3Serializer<Counter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticCounterVariation svariation = StaticCounterVariation.Group20Var5;
}

// Counter - 16-bit Without Flag
public partial class Group20Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(20, 6);
  }


  // ------- Group20Var6 -------

  public Group20Var6()
  {
	  this.value = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 2;
  }
  public static bool Read(RSeq buffer, Group20Var6 output)
  {
	return LittleEndian.read(buffer, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group20Var6 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public ushort value = new ushort();

  public static bool ReadTarget(RSeq buff, ref Counter output)
  {
	Group20Var6 value = new Group20Var6();
	if (Read(buff, value))
	{
	  output = CounterFactory.From(new ushort(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Counter UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Counter> Inst()
  {
	  return DNP3Serializer<Counter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticCounterVariation svariation = StaticCounterVariation.Group20Var6;
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

// Counter - Any Variation
public partial class Group20Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(20, 0);
  }
}

// Counter - 32-bit With Flag
public partial class Group20Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(20, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group20Var1();

  public static /*size_t*/int Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq/*<size_t>*/ UnnamedParameter, Group20Var1 UnnamedParameter2);
  public static bool Write(in Group20Var1 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public byte flags = new byte();
  public uint value = new uint();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq/*<size_t>*/ UnnamedParameter, Counter UnnamedParameter2);
  public static bool WriteTarget(in Counter value, WSeq</*size_t*/int> buff)
  {
	return Group20Var1.Write(ConvertQV<Group20Var1, Counter>.Apply(value), buff);
  }

  public static DNP3Serializer<Counter> Inst()
  {
	  return DNP3Serializer<Counter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticCounterVariation svariation = StaticCounterVariation.Group20Var1;
}

// Counter - 16-bit With Flag
public partial class Group20Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(20, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group20Var2();

  public static /*size_t*/int Size()
  {
	  return 3;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq/*<size_t>*/ UnnamedParameter, Group20Var2 UnnamedParameter2);
  public static bool Write(in Group20Var2 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public byte flags = new byte();
  public ushort value = new ushort();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq/*<size_t>*/ UnnamedParameter, Counter UnnamedParameter2);
  public static bool WriteTarget(in Counter value, WSeq</*size_t*/int> buff)
  {
	return Group20Var2.Write(ConvertQVandTruncate<Group20Var2, Counter>.Apply(value), buff);
  }

  public static DNP3Serializer<Counter> Inst()
  {
	  return DNP3Serializer<Counter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticCounterVariation svariation = StaticCounterVariation.Group20Var2;
}

// Counter - 32-bit Without Flag
public partial class Group20Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(20, 5);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group20Var5();

  public static /*size_t*/int Size()
  {
	  return 4;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq/*<size_t>*/ UnnamedParameter, Group20Var5 UnnamedParameter2);
  public static bool Write(in Group20Var5 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.value);
  }

  public uint value = new uint();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq/*<size_t>*/ UnnamedParameter, Counter UnnamedParameter2);
  public static bool WriteTarget(in Counter value, WSeq</*size_t*/int> buff)
  {
	return Group20Var5.Write(ConvertV<Group20Var5, Counter>.Apply(value), buff);
  }

  public static DNP3Serializer<Counter> Inst()
  {
	  return DNP3Serializer<Counter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticCounterVariation svariation = StaticCounterVariation.Group20Var5;
}

// Counter - 16-bit Without Flag
public partial class Group20Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(20, 6);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group20Var6();

  public static /*size_t*/int Size()
  {
	  return 2;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq/*<size_t>*/ UnnamedParameter, Group20Var6 UnnamedParameter2);
  public static bool Write(in Group20Var6 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.value);
  }

  public ushort value = new ushort();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq/*<size_t>*/ UnnamedParameter, Counter UnnamedParameter2);
  public static bool WriteTarget(in Counter value, WSeq</*size_t*/int> buff)
  {
	return Group20Var6.Write(ConvertVandTruncate<Group20Var6, Counter>.Apply(value), buff);
  }

  public static DNP3Serializer<Counter> Inst()
  {
	  return DNP3Serializer<Counter>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticCounterVariation svariation = StaticCounterVariation.Group20Var6;
}


}

