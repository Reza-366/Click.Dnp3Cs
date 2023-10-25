using System;
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
  Used in conjunction with Trip Close Code in a CROB to describe what action to perform
  Refer to section A.8.1 of IEEE 1815-2012 for a full description
*/
public enum OperationType : byte
{
  /// Do nothing.
  NUL = 0x0,
  /// Set output to active for the duration of the On-time.
  PULSE_ON = 0x1,
  /// Non-interoperable code. Do not use for new applications.
  PULSE_OFF = 0x2,
  /// Set output to active.
  LATCH_ON = 0x3,
  /// Set the output to inactive.
  LATCH_OFF = 0x4,
  /// Undefined.
  Undefined = 0xFF
}

public class OperationTypeSpec
{

  public static byte to_type(OperationType arg)
  {
	return (byte)arg;
  }

  public static OperationType from_type(byte arg)
  {
	switch (arg)
	{
	  case(0x0):
		return OperationType.NUL;
	  case(0x1):
		return OperationType.PULSE_ON;
	  case(0x2):
		return OperationType.PULSE_OFF;
	  case(0x3):
		return OperationType.LATCH_ON;
	  case(0x4):
		return OperationType.LATCH_OFF;
	  default:
		return OperationType.Undefined;
	}
  }

  public static string to_string(OperationType arg)
  {
	switch (arg)
	{
	  case(OperationType.NUL):
		return "NUL";
	  case(OperationType.PULSE_ON):
		return "PULSE_ON";
	  case(OperationType.PULSE_OFF):
		return "PULSE_OFF";
	  case(OperationType.LATCH_ON):
		return "LATCH_ON";
	  case(OperationType.LATCH_OFF):
		return "LATCH_OFF";
	  default:
		return "Undefined";
	}
  }

  public static string to_human_string(OperationType arg)
  {
	switch (arg)
	{
	  case(OperationType.NUL):
		return "NUL";
	  case(OperationType.PULSE_ON):
		return "PULSE_ON";
	  case(OperationType.PULSE_OFF):
		return "PULSE_OFF";
	  case(OperationType.LATCH_ON):
		return "LATCH_ON";
	  case(OperationType.LATCH_OFF):
		return "LATCH_OFF";
	  default:
		return "Undefined";
	}
  }

  public static OperationType from_string(in string arg)
  {
	if (arg == "NUL")
	{
		return OperationType.NUL;
	}
	if (arg == "PULSE_ON")
	{
		return OperationType.PULSE_ON;
	}
	if (arg == "PULSE_OFF")
	{
		return OperationType.PULSE_OFF;
	}
	if (arg == "LATCH_ON")
	{
		return OperationType.LATCH_ON;
	}
	if (arg == "LATCH_OFF")
	{
		return OperationType.LATCH_OFF;
	}
	else
	{
		return OperationType.Undefined;
	}
  }
}

}




