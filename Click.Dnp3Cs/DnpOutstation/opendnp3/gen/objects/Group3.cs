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

// Double-bit Binary Input - Any Variation
public partial class Group3Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(3, 0);
  }
}

// Double-bit Binary Input - Packed Format
public partial class Group3Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(3, 1);
  }
}

// Double-bit Binary Input - With Flags
public partial class Group3Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(3, 2);
  }


  // ------- Group3Var2 -------

  public Group3Var2()
  {
	  this.flags = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 1;
  }
  public static bool Read(RSeq buffer, Group3Var2 output)
  {
	return LittleEndian.read(buffer, output.flags);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group3Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();

  public static bool ReadTarget(RSeq buff, ref DoubleBitBinary output)
  {
	Group3Var2 value = new Group3Var2();
	if (Read(buff, value))
	{
	  output = DoubleBitBinaryFactory.From(new byte(value.flags));
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
  public const StaticDoubleBinaryVariation svariation = StaticDoubleBinaryVariation.Group3Var2;
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

// Double-bit Binary Input - Any Variation
public partial class Group3Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(3, 0);
  }
}

// Double-bit Binary Input - Packed Format
public partial class Group3Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(3, 1);
  }
}

// Double-bit Binary Input - With Flags
public partial class Group3Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(3, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group3Var2();

  public static /*size_t*/int Size()
  {
	  return 1;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq/*<size_t>*/ UnnamedParameter, Group3Var2 UnnamedParameter2);
  public static bool Write(in Group3Var2 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags);
  }

  public byte flags = new byte();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq/*<size_t>*/ UnnamedParameter, DoubleBitBinary UnnamedParameter2);
  public static bool WriteTarget(in DoubleBitBinary value, WSeq</*size_t*/int> buff)
  {
	return Group3Var2.Write(ConvertQ<Group3Var2, DoubleBitBinary>.Apply(value), buff);
  }

  public static DNP3Serializer<DoubleBitBinary> Inst()
  {
	  return DNP3Serializer<DoubleBitBinary>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticDoubleBinaryVariation svariation = StaticDoubleBinaryVariation.Group3Var2;
}


}

