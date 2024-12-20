﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

/**
  Bitmask values for all the static types
*/
public enum StaticTypeBitmask : ushort
{
  BinaryInput = 0x1,
  DoubleBinaryInput = 0x2,
  Counter = 0x4,
  FrozenCounter = 0x8,
  AnalogInput = 0x10,
  BinaryOutputStatus = 0x20,
  AnalogOutputStatus = 0x40,
  TimeAndInterval = 0x80,
  OctetString = 0x100
}

public class StaticTypeBitmaskSpec
{

  public static ushort to_type(StaticTypeBitmask arg)
  {
	return (ushort)arg;
  }

  public static StaticTypeBitmask from_type(ushort arg)
  {
	switch (arg)
	{
	  case(0x1):
		return StaticTypeBitmask.BinaryInput;
	  case(0x2):
		return StaticTypeBitmask.DoubleBinaryInput;
	  case(0x4):
		return StaticTypeBitmask.Counter;
	  case(0x8):
		return StaticTypeBitmask.FrozenCounter;
	  case(0x10):
		return StaticTypeBitmask.AnalogInput;
	  case(0x20):
		return StaticTypeBitmask.BinaryOutputStatus;
	  case(0x40):
		return StaticTypeBitmask.AnalogOutputStatus;
	  case(0x80):
		return StaticTypeBitmask.TimeAndInterval;
	  case(0x100):
		return StaticTypeBitmask.OctetString;
	  default: //REZA
		  return StaticTypeBitmask.OctetString;
   //     throw new std::invalid_argument("Unknown value");
	}
  }

  public static string to_string(StaticTypeBitmask arg)
  {
	switch (arg)
	{
	  case(StaticTypeBitmask.BinaryInput):
		return "BinaryInput";
	  case(StaticTypeBitmask.DoubleBinaryInput):
		return "DoubleBinaryInput";
	  case(StaticTypeBitmask.Counter):
		return "Counter";
	  case(StaticTypeBitmask.FrozenCounter):
		return "FrozenCounter";
	  case(StaticTypeBitmask.AnalogInput):
		return "AnalogInput";
	  case(StaticTypeBitmask.BinaryOutputStatus):
		return "BinaryOutputStatus";
	  case(StaticTypeBitmask.AnalogOutputStatus):
		return "AnalogOutputStatus";
	  case(StaticTypeBitmask.TimeAndInterval):
		return "TimeAndInterval";
	  case(StaticTypeBitmask.OctetString):
		return "OctetString";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(StaticTypeBitmask arg)
  {
	switch (arg)
	{
	  case(StaticTypeBitmask.BinaryInput):
		return "BinaryInput";
	  case(StaticTypeBitmask.DoubleBinaryInput):
		return "DoubleBinaryInput";
	  case(StaticTypeBitmask.Counter):
		return "Counter";
	  case(StaticTypeBitmask.FrozenCounter):
		return "FrozenCounter";
	  case(StaticTypeBitmask.AnalogInput):
		return "AnalogInput";
	  case(StaticTypeBitmask.BinaryOutputStatus):
		return "BinaryOutputStatus";
	  case(StaticTypeBitmask.AnalogOutputStatus):
		return "AnalogOutputStatus";
	  case(StaticTypeBitmask.TimeAndInterval):
		return "TimeAndInterval";
	  case(StaticTypeBitmask.OctetString):
		return "OctetString";
	  default:
		return "UNDEFINED";
	}
  }

  public static StaticTypeBitmask from_string(in string arg)
  {
	if (arg == "BinaryInput")
	{
		return StaticTypeBitmask.BinaryInput;
	}
	if (arg == "DoubleBinaryInput")
	{
		return StaticTypeBitmask.DoubleBinaryInput;
	}
	if (arg == "Counter")
	{
		return StaticTypeBitmask.Counter;
	}
	if (arg == "FrozenCounter")
	{
		return StaticTypeBitmask.FrozenCounter;
	}
	if (arg == "AnalogInput")
	{
		return StaticTypeBitmask.AnalogInput;
	}
	if (arg == "BinaryOutputStatus")
	{
		return StaticTypeBitmask.BinaryOutputStatus;
	}
	if (arg == "AnalogOutputStatus")
	{
		return StaticTypeBitmask.AnalogOutputStatus;
	}
	if (arg == "TimeAndInterval")
	{
		return StaticTypeBitmask.TimeAndInterval;
	}
	if (arg == "OctetString")
	{
		return StaticTypeBitmask.OctetString;
	}
	//REZA
	 return StaticTypeBitmask.OctetString;
	 //  else throw std::invalid_argument(std::string("Unknown value: ") + arg);
  }
}

}




