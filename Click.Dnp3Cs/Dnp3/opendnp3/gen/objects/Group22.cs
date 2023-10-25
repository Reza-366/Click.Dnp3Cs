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

// Counter Event - Any Variation
public partial class Group22Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(22, 0);
  }
}

// Counter Event - 32-bit With Flag
public partial class Group22Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(22, 1);
  }


  // ------- Group22Var1 -------

  public Group22Var1()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group22Var1 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group22Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public System.UInt32 value = new System.UInt32();

  public static bool ReadTarget(rseq_t buff, ref Counter output)
  {
	Group22Var1 value = new Group22Var1();
	if (Read(buff, value))
	{
	  output = CounterFactory.From(new System.Byte(value.flags), new System.UInt32(value.value));
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
}

// Counter Event - 16-bit With Flag
public partial class Group22Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(22, 2);
  }


  // ------- Group22Var2 -------

  public Group22Var2()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static size_t Size()
  {
	  return 3;
  }
  public static bool Read(rseq_t buffer, Group22Var2 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group22Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public UInt16 value = new UInt16();

  public static bool ReadTarget(rseq_t buff, ref Counter output)
  {
	Group22Var2 value = new Group22Var2();
	if (Read(buff, value))
	{
	  output = CounterFactory.From(new System.Byte(value.flags), new UInt16(value.value));
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
}

// Counter Event - 32-bit With Flag and Time
public partial class Group22Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(22, 5);
  }


  // ------- Group22Var5 -------

  public Group22Var5()
  {
	  this.flags = 0;
	  this.value = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static size_t Size()
  {
	  return 11;
  }
  public static bool Read(rseq_t buffer, Group22Var5 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group22Var5 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public System.UInt32 value = new System.UInt32();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref Counter output)
  {
	Group22Var5 value = new Group22Var5();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = CounterFactory::From(value.flags, value.value, value.time);
	  output = CounterFactory.From(new System.Byte(value.flags), new System.UInt32(value.value), new opendnp3.DNPTime(value.time));
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
}

// Counter Event - 16-bit With Flag and Time
public partial class Group22Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(22, 6);
  }


  // ------- Group22Var6 -------

  public Group22Var6()
  {
	  this.flags = 0;
	  this.value = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static size_t Size()
  {
	  return 9;
  }
  public static bool Read(rseq_t buffer, Group22Var6 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group22Var6 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public UInt16 value = new UInt16();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref Counter output)
  {
	Group22Var6 value = new Group22Var6();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = CounterFactory::From(value.flags, value.value, value.time);
	  output = CounterFactory.From(new System.Byte(value.flags), new UInt16(value.value), new opendnp3.DNPTime(value.time));
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

// Counter Event - Any Variation
public partial class Group22Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(22, 0);
  }
}

// Counter Event - 32-bit With Flag
public partial class Group22Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(22, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group22Var1();

  public static size_t Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group22Var1 UnnamedParameter2);
  public static bool Write(in Group22Var1 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public System.Byte flags = new System.Byte();
  public System.UInt32 value = new System.UInt32();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, Counter UnnamedParameter2);
  public static bool WriteTarget(in Counter value, WSeq<size_t> buff)
  {
	return Group22Var1.Write(ConvertQV<Group22Var1, Counter>.Apply(value), buff);
  }

  public static DNP3Serializer<Counter> Inst()
  {
	  return DNP3Serializer<Counter>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Counter Event - 16-bit With Flag
public partial class Group22Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(22, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group22Var2();

  public static size_t Size()
  {
	  return 3;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group22Var2 UnnamedParameter2);
  public static bool Write(in Group22Var2 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public System.Byte flags = new System.Byte();
  public UInt16 value = new UInt16();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, Counter UnnamedParameter2);
  public static bool WriteTarget(in Counter value, WSeq<size_t> buff)
  {
	return Group22Var2.Write(ConvertQVandTruncate<Group22Var2, Counter>.Apply(value), buff);
  }

  public static DNP3Serializer<Counter> Inst()
  {
	  return DNP3Serializer<Counter>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Counter Event - 32-bit With Flag and Time
public partial class Group22Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(22, 5);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group22Var5();

  public static size_t Size()
  {
	  return 11;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group22Var5 UnnamedParameter2);
  public static bool Write(in Group22Var5 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public System.Byte flags = new System.Byte();
  public System.UInt32 value = new System.UInt32();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, Counter UnnamedParameter2);
  public static bool WriteTarget(in Counter value, WSeq<size_t> buff)
  {
	return Group22Var5.Write(ConvertQVT<Group22Var5, Counter>.Apply(value), buff);
  }

  public static DNP3Serializer<Counter> Inst()
  {
	  return DNP3Serializer<Counter>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Counter Event - 16-bit With Flag and Time
public partial class Group22Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(22, 6);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group22Var6();

  public static size_t Size()
  {
	  return 9;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group22Var6 UnnamedParameter2);
  public static bool Write(in Group22Var6 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public System.Byte flags = new System.Byte();
  public UInt16 value = new UInt16();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, Counter UnnamedParameter2);
  public static bool WriteTarget(in Counter value, WSeq<size_t> buff)
  {
	return Group22Var6.Write(ConvertQVTandTruncate<Group22Var6, Counter>.Apply(value), buff);
  }

  public static DNP3Serializer<Counter> Inst()
  {
	  return DNP3Serializer<Counter>(ID(), Size(), ReadTarget, WriteTarget);
  }
}


}

