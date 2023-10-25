﻿//
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
  groups that can be used inconjunction with the ASSIGN_CLASS function code
*/
public enum AssignClassType : System.Byte
{
  BinaryInput = 0x0,
  DoubleBinaryInput = 0x1,
  Counter = 0x2,
  FrozenCounter = 0x3,
  AnalogInput = 0x4,
  BinaryOutputStatus = 0x5,
  AnalogOutputStatus = 0x6
}

public class AssignClassTypeSpec
{

  public static System.Byte to_type(AssignClassType arg)
  {
	return (System.Byte)arg;
  }

  public static AssignClassType from_type(System.Byte arg)
  {
	switch (arg)
	{
	  case(0x0):
		return AssignClassType.BinaryInput;
	  case(0x1):
		return AssignClassType.DoubleBinaryInput;
	  case(0x2):
		return AssignClassType.Counter;
	  case(0x3):
		return AssignClassType.FrozenCounter;
	  case(0x4):
		return AssignClassType.AnalogInput;
	  case(0x5):
		return AssignClassType.BinaryOutputStatus;
	  case(0x6):
		return AssignClassType.AnalogOutputStatus;
	  default:
  //      throw new std::invalid_argument("Unknown value");
		  return AssignClassType.AnalogInput;
	}
  }

  public static string to_string(AssignClassType arg)
  {
	switch (arg)
	{
	  case(AssignClassType.BinaryInput):
		return "BinaryInput";
	  case(AssignClassType.DoubleBinaryInput):
		return "DoubleBinaryInput";
	  case(AssignClassType.Counter):
		return "Counter";
	  case(AssignClassType.FrozenCounter):
		return "FrozenCounter";
	  case(AssignClassType.AnalogInput):
		return "AnalogInput";
	  case(AssignClassType.BinaryOutputStatus):
		return "BinaryOutputStatus";
	  case(AssignClassType.AnalogOutputStatus):
		return "AnalogOutputStatus";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(AssignClassType arg)
  {
	switch (arg)
	{
	  case(AssignClassType.BinaryInput):
		return "BinaryInput";
	  case(AssignClassType.DoubleBinaryInput):
		return "DoubleBinaryInput";
	  case(AssignClassType.Counter):
		return "Counter";
	  case(AssignClassType.FrozenCounter):
		return "FrozenCounter";
	  case(AssignClassType.AnalogInput):
		return "AnalogInput";
	  case(AssignClassType.BinaryOutputStatus):
		return "BinaryOutputStatus";
	  case(AssignClassType.AnalogOutputStatus):
		return "AnalogOutputStatus";
	  default:
		return "UNDEFINED";
	}
  }

  public static AssignClassType from_string(in string arg)
  {
	if (arg == "BinaryInput")
	{
		return AssignClassType.BinaryInput;
	}
	if (arg == "DoubleBinaryInput")
	{
		return AssignClassType.DoubleBinaryInput;
	}
	if (arg == "Counter")
	{
		return AssignClassType.Counter;
	}
	if (arg == "FrozenCounter")
	{
		return AssignClassType.FrozenCounter;
	}
	if (arg == "AnalogInput")
	{
		return AssignClassType.AnalogInput;
	}
	if (arg == "BinaryOutputStatus")
	{
		return AssignClassType.BinaryOutputStatus;
	}
	if (arg == "AnalogOutputStatus")
	{
		return AssignClassType.AnalogOutputStatus;
	}
  //  else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return AssignClassType.AnalogOutputStatus;
  }
}

}




