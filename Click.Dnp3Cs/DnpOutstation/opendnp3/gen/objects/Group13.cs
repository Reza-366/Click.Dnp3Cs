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

// Binary Command Event - Without Time
public partial class Group13Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(13, 1);
  }


  // ------- Group13Var1 -------

  public Group13Var1()
  {
	  this.flags = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 1;
  }
  public static bool Read(rseq_t buffer, Group13Var1 output)
  {
	return LittleEndian.read(buffer, output.flags);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group13Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();

  public static bool ReadTarget(rseq_t buff, ref BinaryCommandEvent output)
  {
	Group13Var1 value = new Group13Var1();
	if (Read(buff, value))
	{
	  output = BinaryCommandEventFactory.From(new byte(value.flags));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in BinaryCommandEvent UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<BinaryCommandEvent> Inst()
  {
	  return DNP3Serializer<BinaryCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Binary Command Event - With Time
public partial class Group13Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(13, 2);
  }


  // ------- Group13Var2 -------

  public Group13Var2()
  {
	  this.flags = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 7;
  }
  public static bool Read(rseq_t buffer, Group13Var2 output)
  {
	return LittleEndian.read(buffer, output.flags, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group13Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref BinaryCommandEvent output)
  {
	Group13Var2 value = new Group13Var2();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = BinaryCommandEventFactory::From(value.flags, value.time);
	  output = BinaryCommandEventFactory.From(new byte(value.flags), new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in BinaryCommandEvent UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<BinaryCommandEvent> Inst()
  {
	  return DNP3Serializer<BinaryCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
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

// Binary Command Event - Without Time
public partial class Group13Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(13, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group13Var1();

  public static /*size_t*/int Size()
  {
	  return 1;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group13Var1 UnnamedParameter2);
  public static bool Write(in Group13Var1 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags);
  }

  public byte flags = new byte();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, BinaryCommandEvent UnnamedParameter2);
  public static bool WriteTarget(in BinaryCommandEvent value, WSeq</*size_t*/int> buff)
  {
	return Group13Var1.Write(ConvertGroup13Var1.Apply(value), buff);
  }

  public static DNP3Serializer<BinaryCommandEvent> Inst()
  {
	  return DNP3Serializer<BinaryCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Binary Command Event - With Time
public partial class Group13Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(13, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group13Var2();

  public static /*size_t*/int Size()
  {
	  return 7;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group13Var2 UnnamedParameter2);
  public static bool Write(in Group13Var2 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.time);
  }

  public byte flags = new byte();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, BinaryCommandEvent UnnamedParameter2);
  public static bool WriteTarget(in BinaryCommandEvent value, WSeq</*size_t*/int> buff)
  {
	return Group13Var2.Write(ConvertGroup13Var2.Apply(value), buff);
  }

  public static DNP3Serializer<BinaryCommandEvent> Inst()
  {
	  return DNP3Serializer<BinaryCommandEvent>(ID(), Size(), ReadTarget, WriteTarget);
  }
}


}

