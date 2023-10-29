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

// Binary Command - Any Variation
public partial class Group12Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(12, 0);
  }
}

// Binary Command - CROB
public partial class Group12Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(12, 1);
  }


  // ------- Group12Var1 -------

  public Group12Var1()
  {
	  this.code = 0;
	  this.count = 0;
	  this.onTime = 0;
	  this.offTime = 0;
	  this.status = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 11;
  }
  public static bool Read(RSeq buffer, Group12Var1 output)
  {
	return LittleEndian.read(buffer, output.code, output.count, output.onTime, output.offTime, output.status);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group12Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte code = new byte();
  public byte count = new byte();
  public uint onTime = new uint();
  public uint offTime = new uint();
  public byte status = new byte();

  public static bool ReadTarget(RSeq buff, ref ControlRelayOutputBlock output)
  {
	Group12Var1 value = new Group12Var1();
	if (Read(buff, value))
	{
	  output = ControlRelayOutputBlockFactory.From(new byte(value.code), new byte(value.count), new uint(value.onTime), new uint(value.offTime), new byte(value.status));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in ControlRelayOutputBlock UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<ControlRelayOutputBlock> Inst()
  {
	  return DNP3Serializer<ControlRelayOutputBlock>(ID(), Size(), ReadTarget, WriteTarget);
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

// Binary Command - Any Variation
public partial class Group12Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(12, 0);
  }
}

// Binary Command - CROB
public partial class Group12Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(12, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group12Var1();

  public static /*size_t*/int Size()
  {
	  return 11;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq/*<size_t>*/ UnnamedParameter, Group12Var1 UnnamedParameter2);
  public static bool Write(in Group12Var1 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.code, arg.count, arg.onTime, arg.offTime, arg.status);
  }

  public byte code = new byte();
  public byte count = new byte();
  public uint onTime = new uint();
  public uint offTime = new uint();
  public byte status = new byte();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq/*<size_t>*/ UnnamedParameter, ControlRelayOutputBlock UnnamedParameter2);
  public static bool WriteTarget(in ControlRelayOutputBlock value, WSeq</*size_t*/int> buff)
  {
	return Group12Var1.Write(ConvertGroup12Var1.Apply(value), buff);
  }

  public static DNP3Serializer<ControlRelayOutputBlock> Inst()
  {
	  return DNP3Serializer<ControlRelayOutputBlock>(ID(), Size(), ReadTarget, WriteTarget);
  }
}


}

