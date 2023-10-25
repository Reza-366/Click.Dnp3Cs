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

// Analog Input - Any Variation
public partial class Group30Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 0);
  }
}

// Analog Input - 32-bit With Flag
public partial class Group30Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 1);
  }


  // ------- Group30Var1 -------

  public Group30Var1()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group30Var1 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group30Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public int32_t value = new int32_t();

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group30Var1 value = new Group30Var1();
	if (Read(buff, value))
	{
	  output = AnalogFactory.From(new System.Byte(value.flags), new int32_t(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogVariation svariation = StaticAnalogVariation.Group30Var1;
}

// Analog Input - 16-bit With Flag
public partial class Group30Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 2);
  }


  // ------- Group30Var2 -------

  public Group30Var2()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 3;
  }
  public static bool Read(rseq_t buffer, Group30Var2 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group30Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public int16_t value = new int16_t();

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group30Var2 value = new Group30Var2();
	if (Read(buff, value))
	{
	  output = AnalogFactory.From(new System.Byte(value.flags), new int16_t(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogVariation svariation = StaticAnalogVariation.Group30Var2;
}

// Analog Input - 32-bit Without Flag
public partial class Group30Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 3);
  }


  // ------- Group30Var3 -------

  public Group30Var3()
  {
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 4;
  }
  public static bool Read(rseq_t buffer, Group30Var3 output)
  {
	return LittleEndian.read(buffer, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group30Var3 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public int32_t value = new int32_t();

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group30Var3 value = new Group30Var3();
	if (Read(buff, value))
	{
	  output = AnalogFactory.From(new int32_t(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogVariation svariation = StaticAnalogVariation.Group30Var3;
}

// Analog Input - 16-bit Without Flag
public partial class Group30Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 4);
  }


  // ------- Group30Var4 -------

  public Group30Var4()
  {
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 2;
  }
  public static bool Read(rseq_t buffer, Group30Var4 output)
  {
	return LittleEndian.read(buffer, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group30Var4 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public int16_t value = new int16_t();

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group30Var4 value = new Group30Var4();
	if (Read(buff, value))
	{
	  output = AnalogFactory.From(new int16_t(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogVariation svariation = StaticAnalogVariation.Group30Var4;
}

// Analog Input - Single-precision With Flag
public partial class Group30Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 5);
  }


  // ------- Group30Var5 -------

  public Group30Var5()
  {
	  this.flags = 0;
	  this.value = 0.0F;
  }

  public static size_t Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group30Var5 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group30Var5 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public float value;

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group30Var5 value = new Group30Var5();
	if (Read(buff, value))
	{
	  output = AnalogFactory.From(new System.Byte(value.flags), value.value);
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogVariation svariation = StaticAnalogVariation.Group30Var5;
}

// Analog Input - Double-precision With Flag
public partial class Group30Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 6);
  }


  // ------- Group30Var6 -------

  public Group30Var6()
  {
	  this.flags = 0;
	  this.value = 0.0;
  }

  public static size_t Size()
  {
	  return 9;
  }
  public static bool Read(rseq_t buffer, Group30Var6 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group30Var6 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public double value;

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group30Var6 value = new Group30Var6();
	if (Read(buff, value))
	{
	  output = AnalogFactory.From(new System.Byte(value.flags), value.value);
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogVariation svariation = StaticAnalogVariation.Group30Var6;
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

// Analog Input - Any Variation
public partial class Group30Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 0);
  }
}

// Analog Input - 32-bit With Flag
public partial class Group30Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group30Var1();

  public static size_t Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group30Var1 UnnamedParameter2);
  public static bool Write(in Group30Var1 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public System.Byte flags = new System.Byte();
  public int32_t value = new int32_t();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq<size_t> buff)
  {
	return Group30Var1.Write(ConvertQVRangeCheck<Group30Var1, Analog, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogVariation svariation = StaticAnalogVariation.Group30Var1;
}

// Analog Input - 16-bit With Flag
public partial class Group30Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group30Var2();

  public static size_t Size()
  {
	  return 3;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group30Var2 UnnamedParameter2);
  public static bool Write(in Group30Var2 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public System.Byte flags = new System.Byte();
  public int16_t value = new int16_t();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq<size_t> buff)
  {
	return Group30Var2.Write(ConvertQVRangeCheck<Group30Var2, Analog, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogVariation svariation = StaticAnalogVariation.Group30Var2;
}

// Analog Input - 32-bit Without Flag
public partial class Group30Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 3);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group30Var3();

  public static size_t Size()
  {
	  return 4;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group30Var3 UnnamedParameter2);
  public static bool Write(in Group30Var3 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.value);
  }

  public int32_t value = new int32_t();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq<size_t> buff)
  {
	return Group30Var3.Write(ConvertVRangeCheck<Group30Var3, Analog>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogVariation svariation = StaticAnalogVariation.Group30Var3;
}

// Analog Input - 16-bit Without Flag
public partial class Group30Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 4);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group30Var4();

  public static size_t Size()
  {
	  return 2;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group30Var4 UnnamedParameter2);
  public static bool Write(in Group30Var4 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.value);
  }

  public int16_t value = new int16_t();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq<size_t> buff)
  {
	return Group30Var4.Write(ConvertVRangeCheck<Group30Var4, Analog>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogVariation svariation = StaticAnalogVariation.Group30Var4;
}

// Analog Input - Single-precision With Flag
public partial class Group30Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 5);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group30Var5();

  public static size_t Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group30Var5 UnnamedParameter2);
  public static bool Write(in Group30Var5 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public System.Byte flags = new System.Byte();
  public float value;

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq<size_t> buff)
  {
	return Group30Var5.Write(ConvertQVRangeCheck<Group30Var5, Analog, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogVariation svariation = StaticAnalogVariation.Group30Var5;
}

// Analog Input - Double-precision With Flag
public partial class Group30Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(30, 6);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group30Var6();

  public static size_t Size()
  {
	  return 9;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group30Var6 UnnamedParameter2);
  public static bool Write(in Group30Var6 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public System.Byte flags = new System.Byte();
  public double value;

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq<size_t> buff)
  {
	return Group30Var6.Write(ConvertQV<Group30Var6, Analog>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticAnalogVariation svariation = StaticAnalogVariation.Group30Var6;
}


}

