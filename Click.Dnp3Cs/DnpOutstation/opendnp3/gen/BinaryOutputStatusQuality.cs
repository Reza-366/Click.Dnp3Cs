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
  Quality field bitmask for binary output status values
*/
public enum BinaryOutputStatusQuality : byte
{
  /// set when the data is "good", meaning that rest of the system can trust the value
  ONLINE = 0x1,
  /// the quality all points get before we have established communication (or populated) the point
  RESTART = 0x2,
  /// set if communication has been lost with the source of the data (after establishing contact)
  COMM_LOST = 0x4,
  /// set if the value is being forced to a "fake" value somewhere in the system
  REMOTE_FORCED = 0x8,
  /// set if the value is being forced to a "fake" value on the original device
  LOCAL_FORCED = 0x10,
  /// reserved bit 1
  RESERVED1 = 0x20,
  /// reserved bit 2
  RESERVED2 = 0x40,
  /// state bit
  STATE = 0x80
}

public class BinaryOutputStatusQualitySpec
{

  public static byte to_type(BinaryOutputStatusQuality arg)
  {
	return (byte)arg;
  }

  public static BinaryOutputStatusQuality from_type(byte arg)
  {
	switch (arg)
	{
	  case(0x1):
		return BinaryOutputStatusQuality.ONLINE;
	  case(0x2):
		return BinaryOutputStatusQuality.RESTART;
	  case(0x4):
		return BinaryOutputStatusQuality.COMM_LOST;
	  case(0x8):
		return BinaryOutputStatusQuality.REMOTE_FORCED;
	  case(0x10):
		return BinaryOutputStatusQuality.LOCAL_FORCED;
	  case(0x20):
		return BinaryOutputStatusQuality.RESERVED1;
	  case(0x40):
		return BinaryOutputStatusQuality.RESERVED2;
	  case(0x80):
		return BinaryOutputStatusQuality.STATE;
	  default:
   //     throw new std::invalid_argument("Unknown value");
		  return BinaryOutputStatusQuality.RESERVED2;
	}
  }

  public static string to_string(BinaryOutputStatusQuality arg)
  {
	switch (arg)
	{
	  case(BinaryOutputStatusQuality.ONLINE):
		return "ONLINE";
	  case(BinaryOutputStatusQuality.RESTART):
		return "RESTART";
	  case(BinaryOutputStatusQuality.COMM_LOST):
		return "COMM_LOST";
	  case(BinaryOutputStatusQuality.REMOTE_FORCED):
		return "REMOTE_FORCED";
	  case(BinaryOutputStatusQuality.LOCAL_FORCED):
		return "LOCAL_FORCED";
	  case(BinaryOutputStatusQuality.RESERVED1):
		return "RESERVED1";
	  case(BinaryOutputStatusQuality.RESERVED2):
		return "RESERVED2";
	  case(BinaryOutputStatusQuality.STATE):
		return "STATE";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(BinaryOutputStatusQuality arg)
  {
	switch (arg)
	{
	  case(BinaryOutputStatusQuality.ONLINE):
		return "ONLINE";
	  case(BinaryOutputStatusQuality.RESTART):
		return "RESTART";
	  case(BinaryOutputStatusQuality.COMM_LOST):
		return "COMM_LOST";
	  case(BinaryOutputStatusQuality.REMOTE_FORCED):
		return "REMOTE_FORCED";
	  case(BinaryOutputStatusQuality.LOCAL_FORCED):
		return "LOCAL_FORCED";
	  case(BinaryOutputStatusQuality.RESERVED1):
		return "RESERVED1";
	  case(BinaryOutputStatusQuality.RESERVED2):
		return "RESERVED2";
	  case(BinaryOutputStatusQuality.STATE):
		return "STATE";
	  default:
		return "UNDEFINED";
	}
  }

  public static BinaryOutputStatusQuality from_string(in string arg)
  {
	if (arg == "ONLINE")
	{
		return BinaryOutputStatusQuality.ONLINE;
	}
	if (arg == "RESTART")
	{
		return BinaryOutputStatusQuality.RESTART;
	}
	if (arg == "COMM_LOST")
	{
		return BinaryOutputStatusQuality.COMM_LOST;
	}
	if (arg == "REMOTE_FORCED")
	{
		return BinaryOutputStatusQuality.REMOTE_FORCED;
	}
	if (arg == "LOCAL_FORCED")
	{
		return BinaryOutputStatusQuality.LOCAL_FORCED;
	}
	if (arg == "RESERVED1")
	{
		return BinaryOutputStatusQuality.RESERVED1;
	}
	if (arg == "RESERVED2")
	{
		return BinaryOutputStatusQuality.RESERVED2;
	}
	if (arg == "STATE")
	{
		return BinaryOutputStatusQuality.STATE;
	}
  //  else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return BinaryOutputStatusQuality.RESERVED1;
  }
}

}




