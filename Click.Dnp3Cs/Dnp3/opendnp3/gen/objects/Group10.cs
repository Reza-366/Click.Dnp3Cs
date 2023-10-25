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

// Binary Output - Any Variation
public partial class Group10Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(10, 0);
  }
}

// Binary Output - Packed Format
public partial class Group10Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(10, 1);
  }
}

// Binary Output - Output Status With Flags
public partial class Group10Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(10, 2);
  }


  // ------- Group10Var2 -------

  public Group10Var2()
  {
	  this.flags = 0;
  }

  public static size_t Size()
  {
	  return 1;
  }
  public static bool Read(rseq_t buffer, Group10Var2 output)
  {
	return LittleEndian.read(buffer, output.flags);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group10Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();

  public static bool ReadTarget(rseq_t buff, ref BinaryOutputStatus output)
  {
	Group10Var2 value = new Group10Var2();
	if (Read(buff, value))
	{
	  output = BinaryOutputStatusFactory.From(new System.Byte(value.flags));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in BinaryOutputStatus UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<BinaryOutputStatus> Inst()
  {
	  return DNP3Serializer<BinaryOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticBinaryOutputStatusVariation svariation = StaticBinaryOutputStatusVariation.Group10Var2;
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

// Binary Output - Any Variation
public partial class Group10Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(10, 0);
  }
}

// Binary Output - Packed Format
public partial class Group10Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(10, 1);
  }
}

// Binary Output - Output Status With Flags
public partial class Group10Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(10, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group10Var2();

  public static size_t Size()
  {
	  return 1;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group10Var2 UnnamedParameter2);
  public static bool Write(in Group10Var2 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags);
  }

  public System.Byte flags = new System.Byte();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, BinaryOutputStatus UnnamedParameter2);
  public static bool WriteTarget(in BinaryOutputStatus value, WSeq<size_t> buff)
  {
	return Group10Var2.Write(ConvertQ<Group10Var2, BinaryOutputStatus>.Apply(value), buff);
  }

  public static DNP3Serializer<BinaryOutputStatus> Inst()
  {
	  return DNP3Serializer<BinaryOutputStatus>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticBinaryOutputStatusVariation svariation = StaticBinaryOutputStatusVariation.Group10Var2;
}


}

