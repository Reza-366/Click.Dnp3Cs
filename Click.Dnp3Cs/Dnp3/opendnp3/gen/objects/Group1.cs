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

// Binary Input - Any Variation
public partial class Group1Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(1, 0);
  }
}

// Binary Input - Packed Format
public partial class Group1Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(1, 1);
  }
  public const StaticBinaryVariation svariation = StaticBinaryVariation.Group1Var1;
}

// Binary Input - With Flags
public partial class Group1Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(1, 2);
  }


  // ------- Group1Var2 -------

  public Group1Var2()
  {
	  this.flags = 0;
  }

  public static size_t Size()
  {
	  return 1;
  }
  public static bool Read(rseq_t buffer, Group1Var2 output)
  {
	return LittleEndian.read(buffer, output.flags);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group1Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public System.Byte flags = new System.Byte();

  public static bool ReadTarget(rseq_t buff, ref Binary output)
  {
	Group1Var2 value = new Group1Var2();
	if (Read(buff, value))
	{
	  output = BinaryFactory.From(new System.Byte(value.flags));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Binary UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Binary> Inst()
  {
	  return DNP3Serializer<Binary>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticBinaryVariation svariation = StaticBinaryVariation.Group1Var2;
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

// Binary Input - Any Variation
public partial class Group1Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(1, 0);
  }
}

// Binary Input - Packed Format
public partial class Group1Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(1, 1);
  }
  public const StaticBinaryVariation svariation = StaticBinaryVariation.Group1Var1;
}

// Binary Input - With Flags
public partial class Group1Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(1, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group1Var2();

  public static size_t Size()
  {
	  return 1;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group1Var2 UnnamedParameter2);
  public static bool Write(in Group1Var2 arg, WSeq<size_t> buffer)
  {
	return LittleEndian.write(buffer, arg.flags);
  }

  public System.Byte flags = new System.Byte();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq<size_t> UnnamedParameter, Binary UnnamedParameter2);
  public static bool WriteTarget(in Binary value, WSeq<size_t> buff)
  {
	return Group1Var2.Write(ConvertQ<Group1Var2, Binary>.Apply(value), buff);
  }

  public static DNP3Serializer<Binary> Inst()
  {
	  return DNP3Serializer<Binary>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticBinaryVariation svariation = StaticBinaryVariation.Group1Var2;
}


}

