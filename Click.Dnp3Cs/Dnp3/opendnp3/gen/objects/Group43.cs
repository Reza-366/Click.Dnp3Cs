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

// Analog Command Event - 32-bit
public partial class Group43Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 1);
  }


  // ------- Group43Var1 -------

  public Group43Var1()
  {
	  this.status = 0;
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group43Var1 output)
  {
	return LittleEndian.read(buffer, output.status, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group43Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte status = new System.Byte();
  public int32_t value = new int32_t();

  public static bool ReadTarget(rseq_t buff, ref AnalogCommandEvent output)
  {
	Group43Var1 value = new Group43Var1();
	if (Read(buff, value))
	{
	  output = AnalogCommandEventFactory.From(new System.Byte(value.status), new int32_t(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogCommandEvent UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - 16-bit
public partial class Group43Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 2);
  }


  // ------- Group43Var2 -------

  public Group43Var2()
  {
	  this.status = 0;
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 3;
  }
  public static bool Read(rseq_t buffer, Group43Var2 output)
  {
	return LittleEndian.read(buffer, output.status, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group43Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte status = new System.Byte();
  public int16_t value = new int16_t();

  public static bool ReadTarget(rseq_t buff, ref AnalogCommandEvent output)
  {
	Group43Var2 value = new Group43Var2();
	if (Read(buff, value))
	{
	  output = AnalogCommandEventFactory.From(new System.Byte(value.status), new int16_t(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogCommandEvent UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - 32-bit With Time
public partial class Group43Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 3);
  }


  // ------- Group43Var3 -------

  public Group43Var3()
  {
	  this.status = 0;
	  this.value = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static size_t Size()
  {
	  return 11;
  }
  public static bool Read(rseq_t buffer, Group43Var3 output)
  {
	return LittleEndian.read(buffer, output.status, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group43Var3 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte status = new System.Byte();
  public int32_t value = new int32_t();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref AnalogCommandEvent output)
  {
	Group43Var3 value = new Group43Var3();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = AnalogCommandEventFactory::From(value.status, value.value, value.time);
	  output = AnalogCommandEventFactory.From(new System.Byte(value.status), new int32_t(value.value), new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogCommandEvent UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - 16-bit With Time
public partial class Group43Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 4);
  }


  // ------- Group43Var4 -------

  public Group43Var4()
  {
	  this.status = 0;
	  this.value = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static size_t Size()
  {
	  return 9;
  }
  public static bool Read(rseq_t buffer, Group43Var4 output)
  {
	return LittleEndian.read(buffer, output.status, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group43Var4 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte status = new System.Byte();
  public int16_t value = new int16_t();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref AnalogCommandEvent output)
  {
	Group43Var4 value = new Group43Var4();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = AnalogCommandEventFactory::From(value.status, value.value, value.time);
	  output = AnalogCommandEventFactory.From(new System.Byte(value.status), new int16_t(value.value), new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogCommandEvent UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - Single-precision
public partial class Group43Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 5);
  }


  // ------- Group43Var5 -------

  public Group43Var5()
  {
	  this.status = 0;
	  this.value = 0.0F;
  }

  public static size_t Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group43Var5 output)
  {
	return LittleEndian.read(buffer, output.status, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group43Var5 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte status = new System.Byte();
  public float value;

  public static bool ReadTarget(rseq_t buff, ref AnalogCommandEvent output)
  {
	Group43Var5 value = new Group43Var5();
	if (Read(buff, value))
	{
	  output = AnalogCommandEventFactory.From(new System.Byte(value.status), value.value);
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogCommandEvent UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - Double-precision
public partial class Group43Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 6);
  }


  // ------- Group43Var6 -------

  public Group43Var6()
  {
	  this.status = 0;
	  this.value = 0.0;
  }

  public static size_t Size()
  {
	  return 9;
  }
  public static bool Read(rseq_t buffer, Group43Var6 output)
  {
	return LittleEndian.read(buffer, output.status, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group43Var6 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte status = new System.Byte();
  public double value;

  public static bool ReadTarget(rseq_t buff, ref AnalogCommandEvent output)
  {
	Group43Var6 value = new Group43Var6();
	if (Read(buff, value))
	{
	  output = AnalogCommandEventFactory.From(new System.Byte(value.status), value.value);
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogCommandEvent UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - Single-precision With Time
public partial class Group43Var7
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 7);
  }


  // ------- Group43Var7 -------

  public Group43Var7()
  {
	  this.status = 0;
	  this.value = 0.0F;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static size_t Size()
  {
	  return 11;
  }
  public static bool Read(rseq_t buffer, Group43Var7 output)
  {
	return LittleEndian.read(buffer, output.status, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group43Var7 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte status = new System.Byte();
  public float value;
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref AnalogCommandEvent output)
  {
	Group43Var7 value = new Group43Var7();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = AnalogCommandEventFactory::From(value.status, value.value, value.time);
	  output = AnalogCommandEventFactory.From(new System.Byte(value.status), value.value, new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogCommandEvent UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - Double-precision With Time
public partial class Group43Var8
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 8);
  }


  // ------- Group43Var8 -------

  public Group43Var8()
  {
	  this.status = 0;
	  this.value = 0.0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static size_t Size()
  {
	  return 15;
  }
  public static bool Read(rseq_t buffer, Group43Var8 output)
  {
	return LittleEndian.read(buffer, output.status, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group43Var8 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte status = new System.Byte();
  public double value;
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref AnalogCommandEvent output)
  {
	Group43Var8 value = new Group43Var8();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = AnalogCommandEventFactory::From(value.status, value.value, value.time);
	  output = AnalogCommandEventFactory.From(new System.Byte(value.status), value.value, new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in AnalogCommandEvent UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
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

// Analog Command Event - 32-bit
public partial class Group43Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group43Var1();

  public static size_t Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group43Var1 UnnamedParameter2);
  public static bool Write(in Group43Var1 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.status, arg.value);
  }

  public System.Byte status = new System.Byte();
  public int32_t value = new int32_t();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, AnalogCommandEvent UnnamedParameter2);
  public static bool WriteTarget(in AnalogCommandEvent value, WSeq<size_t> buff)
  {
	return Group43Var1.Write(ConvertGroup43RangeCheck<Group43Var1>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - 16-bit
public partial class Group43Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group43Var2();

  public static size_t Size()
  {
	  return 3;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group43Var2 UnnamedParameter2);
  public static bool Write(in Group43Var2 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.status, arg.value);
  }

  public System.Byte status = new System.Byte();
  public int16_t value = new int16_t();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, AnalogCommandEvent UnnamedParameter2);
  public static bool WriteTarget(in AnalogCommandEvent value, WSeq<size_t> buff)
  {
	return Group43Var2.Write(ConvertGroup43RangeCheck<Group43Var2>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - 32-bit With Time
public partial class Group43Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 3);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group43Var3();

  public static size_t Size()
  {
	  return 11;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group43Var3 UnnamedParameter2);
  public static bool Write(in Group43Var3 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.status, arg.value, arg.time);
  }

  public System.Byte status = new System.Byte();
  public int32_t value = new int32_t();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, AnalogCommandEvent UnnamedParameter2);
  public static bool WriteTarget(in AnalogCommandEvent value, WSeq<size_t> buff)
  {
	return Group43Var3.Write(ConvertGroup43WithTimeRangeCheck<Group43Var3>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - 16-bit With Time
public partial class Group43Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 4);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group43Var4();

  public static size_t Size()
  {
	  return 9;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group43Var4 UnnamedParameter2);
  public static bool Write(in Group43Var4 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.status, arg.value, arg.time);
  }

  public System.Byte status = new System.Byte();
  public int16_t value = new int16_t();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, AnalogCommandEvent UnnamedParameter2);
  public static bool WriteTarget(in AnalogCommandEvent value, WSeq<size_t> buff)
  {
	return Group43Var4.Write(ConvertGroup43WithTimeRangeCheck<Group43Var4>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - Single-precision
public partial class Group43Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 5);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group43Var5();

  public static size_t Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group43Var5 UnnamedParameter2);
  public static bool Write(in Group43Var5 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.status, arg.value);
  }

  public System.Byte status = new System.Byte();
  public float value;

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, AnalogCommandEvent UnnamedParameter2);
  public static bool WriteTarget(in AnalogCommandEvent value, WSeq<size_t> buff)
  {
	return Group43Var5.Write(ConvertGroup43RangeCheck<Group43Var5>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - Double-precision
public partial class Group43Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 6);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group43Var6();

  public static size_t Size()
  {
	  return 9;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group43Var6 UnnamedParameter2);
  public static bool Write(in Group43Var6 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.status, arg.value);
  }

  public System.Byte status = new System.Byte();
  public double value;

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, AnalogCommandEvent UnnamedParameter2);
  public static bool WriteTarget(in AnalogCommandEvent value, WSeq<size_t> buff)
  {
	return Group43Var6.Write(ConvertGroup43Var6.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - Single-precision With Time
public partial class Group43Var7
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 7);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group43Var7();

  public static size_t Size()
  {
	  return 11;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group43Var7 UnnamedParameter2);
  public static bool Write(in Group43Var7 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.status, arg.value, arg.time);
  }

  public System.Byte status = new System.Byte();
  public float value;
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, AnalogCommandEvent UnnamedParameter2);
  public static bool WriteTarget(in AnalogCommandEvent value, WSeq<size_t> buff)
  {
	return Group43Var7.Write(ConvertGroup43WithTimeRangeCheck<Group43Var7>.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Command Event - Double-precision With Time
public partial class Group43Var8
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(43, 8);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group43Var8();

  public static size_t Size()
  {
	  return 15;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group43Var8 UnnamedParameter2);
  public static bool Write(in Group43Var8 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.status, arg.value, arg.time);
  }

  public System.Byte status = new System.Byte();
  public double value;
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, AnalogCommandEvent UnnamedParameter2);
  public static bool WriteTarget(in AnalogCommandEvent value, WSeq<size_t> buff)
  {
	return Group43Var8.Write(ConvertGroup43Var8.Apply(value), buff);
  }

  public static DNP3Serializer<AnalogCommandEvent> Inst()
  {
	  return DNP3Serializer<AnalogCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}


}

