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

// Analog Output - Any Variation
public partial class Group41Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(41, 0);
  }
}

// Analog Output - 32-bit With Flag
public partial class Group41Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(41, 1);
  }


  // ------- Group41Var1 -------

  public Group41Var1()
  {
	  this.value = 0;
	  this.status = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group41Var1 output)
  {
	return LittleEndian.read(buffer, output.value, output.status);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group41Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public int value = new int();
  public byte status = new byte();

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputInt32 output)
  {
	Group41Var1 value = new Group41Var1();
	if (Read(buff, value))
	{
	  output = AnalogOutputFactory<AnalogOutputInt32, int>.From(new int(value.value), new byte(value.status));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogOutputInt32 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogOutputInt32> Inst()
  {
	  return DNP3Serializer<AnalogOutputInt32>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output - 16-bit With Flag
public partial class Group41Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(41, 2);
  }


  // ------- Group41Var2 -------

  public Group41Var2()
  {
	  this.value = 0;
	  this.status = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 3;
  }
  public static bool Read(rseq_t buffer, Group41Var2 output)
  {
	return LittleEndian.read(buffer, output.value, output.status);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group41Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public Int16 value = new Int16();
  public byte status = new byte();

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputInt16 output)
  {
	Group41Var2 value = new Group41Var2();
	if (Read(buff, value))
	{
	  output = AnalogOutputFactory<AnalogOutputInt16, Int16>.From(new Int16(value.value), new byte(value.status));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogOutputInt16 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogOutputInt16> Inst()
  {
	  return DNP3Serializer<AnalogOutputInt16>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output - Single-precision
public partial class Group41Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(41, 3);
  }


  // ------- Group41Var3 -------

  public Group41Var3()
  {
	  this.value = 0.0F;
	  this.status = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group41Var3 output)
  {
	return LittleEndian.read(buffer, output.value, output.status);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group41Var3 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public float value;
  public byte status = new byte();

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputFloat32 output)
  {
	Group41Var3 value = new Group41Var3();
	if (Read(buff, value))
	{
	  output = AnalogOutputFactory<AnalogOutputFloat32, float>.From(value.value, new byte(value.status));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogOutputFloat32 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogOutputFloat32> Inst()
  {
	  return DNP3Serializer<AnalogOutputFloat32>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output - Double-precision
public partial class Group41Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(41, 4);
  }


  // ------- Group41Var4 -------

  public Group41Var4()
  {
	  this.value = 0.0;
	  this.status = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 9;
  }
  public static bool Read(rseq_t buffer, Group41Var4 output)
  {
	return LittleEndian.read(buffer, output.value, output.status);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group41Var4 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public double value;
  public byte status = new byte();

  public static bool ReadTarget(rseq_t buff, ref AnalogOutputDouble64 output)
  {
	Group41Var4 value = new Group41Var4();
	if (Read(buff, value))
	{
	  output = AnalogOutputFactory<AnalogOutputDouble64, double>.From(value.value, new byte(value.status));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogOutputDouble64 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogOutputDouble64> Inst()
  {
	  return DNP3Serializer<AnalogOutputDouble64>(ID(), Size(), ReadTarget, WriteTarget);
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

// Analog Output - Any Variation
public partial class Group41Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(41, 0);
  }
}

// Analog Output - 32-bit With Flag
public partial class Group41Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(41, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group41Var1();

  public static /*size_t*/int Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group41Var1 UnnamedParameter2);
  public static bool Write(in Group41Var1 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.value, arg.status);
  }

  public int value = new int();
  public byte status = new byte();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, AnalogOutputInt32 UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputInt32 value, WSeq</*size_t*/int> buff)
  {
	return Group41Var1.Write(ConvertQS<Group41Var1, AnalogOutputInt32>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputInt32> Inst()
  {
	  return DNP3Serializer<AnalogOutputInt32>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output - 16-bit With Flag
public partial class Group41Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(41, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group41Var2();

  public static /*size_t*/int Size()
  {
	  return 3;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group41Var2 UnnamedParameter2);
  public static bool Write(in Group41Var2 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.value, arg.status);
  }

  public Int16 value = new Int16();
  public byte status = new byte();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, AnalogOutputInt16 UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputInt16 value, WSeq</*size_t*/int> buff)
  {
	return Group41Var2.Write(ConvertQS<Group41Var2, AnalogOutputInt16>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputInt16> Inst()
  {
	  return DNP3Serializer<AnalogOutputInt16>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output - Single-precision
public partial class Group41Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(41, 3);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group41Var3();

  public static /*size_t*/int Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group41Var3 UnnamedParameter2);
  public static bool Write(in Group41Var3 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.value, arg.status);
  }

  public float value;
  public byte status = new byte();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, AnalogOutputFloat32 UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputFloat32 value, WSeq</*size_t*/int> buff)
  {
	return Group41Var3.Write(ConvertQS<Group41Var3, AnalogOutputFloat32>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputFloat32> Inst()
  {
	  return DNP3Serializer<AnalogOutputFloat32>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Output - Double-precision
public partial class Group41Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(41, 4);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group41Var4();

  public static /*size_t*/int Size()
  {
	  return 9;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group41Var4 UnnamedParameter2);
  public static bool Write(in Group41Var4 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.value, arg.status);
  }

  public double value;
  public byte status = new byte();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, AnalogOutputDouble64 UnnamedParameter2);
  public static bool WriteTarget(in AnalogOutputDouble64 value, WSeq</*size_t*/int> buff)
  {
	return Group41Var4.Write(ConvertQS<Group41Var4, AnalogOutputDouble64>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogOutputDouble64> Inst()
  {
	  return DNP3Serializer<AnalogOutputDouble64>(ID(), Size(), ReadTarget, WriteTarget);
  }
}


}

