﻿using ser4cpp;

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

// Double-bit Binary Input Event - Any Variation
public partial class Group4Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(4, 0);
  }
}

// Double-bit Binary Input Event - Without Time
public partial class Group4Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(4, 1);
  }


  // ------- Group4Var1 -------

  public Group4Var1()
  {
	  this.flags = 0;
  }

  public static size_t Size()
  {
	  return 1;
  }
  public static bool Read(rseq_t buffer, Group4Var1 output)
  {
	return LittleEndian.read(buffer, output.flags);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group4Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();

  public static bool ReadTarget(rseq_t buff, ref DoubleBitBinary output)
  {
	Group4Var1 value = new Group4Var1();
	if (Read(buff, value))
	{
	  output = DoubleBitBinaryFactory.From(new System.Byte(value.flags));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in DoubleBitBinary UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<DoubleBitBinary> Inst()
  {
	  return DNP3Serializer<DoubleBitBinary>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Double-bit Binary Input Event - With Absolute Time
public partial class Group4Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(4, 2);
  }


  // ------- Group4Var2 -------

  public Group4Var2()
  {
	  this.flags = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static size_t Size()
  {
	  return 7;
  }
  public static bool Read(rseq_t buffer, Group4Var2 output)
  {
	return LittleEndian.read(buffer, output.flags, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group4Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref DoubleBitBinary output)
  {
	Group4Var2 value = new Group4Var2();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = DoubleBitBinaryFactory::From(value.flags, value.time);
	  output = DoubleBitBinaryFactory.From(new System.Byte(value.flags), new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in DoubleBitBinary UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<DoubleBitBinary> Inst()
  {
	  return DNP3Serializer<DoubleBitBinary>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Double-bit Binary Input Event - With Relative Time
public partial class Group4Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(4, 3);
  }


  // ------- Group4Var3 -------

  public Group4Var3()
  {
	  this.flags = 0;
	  this.time = 0;
  }

  public static size_t Size()
  {
	  return 3;
  }
  public static bool Read(rseq_t buffer, Group4Var3 output)
  {
	return LittleEndian.read(buffer, output.flags, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group4Var3 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();
  public UInt16 time = new UInt16();

  public static bool ReadTarget(rseq_t buff, ref DoubleBitBinary output)
  {
	Group4Var3 value = new Group4Var3();
	if (Read(buff, value))
	{
	  output = DoubleBitBinaryFactory.From(new System.Byte(value.flags), new UInt16(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in DoubleBitBinary UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<DoubleBitBinary> Inst()
  {
	  return DNP3Serializer<DoubleBitBinary>(ID(), Size(), ReadTarget, WriteTarget);
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

// Double-bit Binary Input Event - Any Variation
public partial class Group4Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(4, 0);
  }
}

// Double-bit Binary Input Event - Without Time
public partial class Group4Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(4, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group4Var1();

  public static size_t Size()
  {
	  return 1;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group4Var1 UnnamedParameter2);
  public static bool Write(in Group4Var1 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags);
  }

  public System.Byte flags = new System.Byte();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, DoubleBitBinary UnnamedParameter2);
  public static bool WriteTarget(in DoubleBitBinary value, WSeq<size_t> buff)
  {
	return Group4Var1.Write(ConvertQ<Group4Var1, DoubleBitBinary>.Apply(value), buff);
  }

  public static DNP3Serializer<DoubleBitBinary> Inst()
  {
	  return DNP3Serializer<DoubleBitBinary>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Double-bit Binary Input Event - With Absolute Time
public partial class Group4Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(4, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group4Var2();

  public static size_t Size()
  {
	  return 7;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group4Var2 UnnamedParameter2);
  public static bool Write(in Group4Var2 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.time);
  }

  public System.Byte flags = new System.Byte();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, DoubleBitBinary UnnamedParameter2);
  public static bool WriteTarget(in DoubleBitBinary value, WSeq<size_t> buff)
  {
	return Group4Var2.Write(ConvertQT<Group4Var2, DoubleBitBinary>.Apply(value), buff);
  }

  public static DNP3Serializer<DoubleBitBinary> Inst()
  {
	  return DNP3Serializer<DoubleBitBinary>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Double-bit Binary Input Event - With Relative Time
public partial class Group4Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(4, 3);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group4Var3();

  public static size_t Size()
  {
	  return 3;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group4Var3 UnnamedParameter2);
  public static bool Write(in Group4Var3 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.time);
  }

  public System.Byte flags = new System.Byte();
  public UInt16 time = new UInt16();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, DoubleBitBinary UnnamedParameter2);
  public static bool WriteTarget(in DoubleBitBinary value, WSeq<size_t> buff)
  {
	return Group4Var3.Write(ConvertQTDowncast<Group4Var3, DoubleBitBinary, UInt16>.Apply(value), buff);
  }

  public static DNP3Serializer<DoubleBitBinary> Inst()
  {
	  return DNP3Serializer<DoubleBitBinary>(ID(), Size(), ReadTarget, WriteTarget);
  }
}


}

