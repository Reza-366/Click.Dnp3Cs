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
  Quality field bitmask for binary values
*/
public enum BinaryQuality : System.Byte
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
  /// set if the value is oscillating very quickly and some events are being suppressed
  CHATTER_FILTER = 0x20,
  /// reserved bit
  RESERVED = 0x40,
  /// state bit
  STATE = 0x80
}

public class BinaryQualitySpec
{

  public static System.Byte to_type(BinaryQuality arg)
  {
	return (System.Byte)arg;
  }

  public static BinaryQuality from_type(System.Byte arg)
  {
	switch (arg)
	{
	  case(0x1):
		return BinaryQuality.ONLINE;
	  case(0x2):
		return BinaryQuality.RESTART;
	  case(0x4):
		return BinaryQuality.COMM_LOST;
	  case(0x8):
		return BinaryQuality.REMOTE_FORCED;
	  case(0x10):
		return BinaryQuality.LOCAL_FORCED;
	  case(0x20):
		return BinaryQuality.CHATTER_FILTER;
	  case(0x40):
		return BinaryQuality.RESERVED;
	  case(0x80):
		return BinaryQuality.STATE;
	  default:
   //     throw new std::invalid_argument("Unknown value");
		  return BinaryQuality.RESERVED;
	}
  }

  public static string to_string(BinaryQuality arg)
  {
	switch (arg)
	{
	  case(BinaryQuality.ONLINE):
		return "ONLINE";
	  case(BinaryQuality.RESTART):
		return "RESTART";
	  case(BinaryQuality.COMM_LOST):
		return "COMM_LOST";
	  case(BinaryQuality.REMOTE_FORCED):
		return "REMOTE_FORCED";
	  case(BinaryQuality.LOCAL_FORCED):
		return "LOCAL_FORCED";
	  case(BinaryQuality.CHATTER_FILTER):
		return "CHATTER_FILTER";
	  case(BinaryQuality.RESERVED):
		return "RESERVED";
	  case(BinaryQuality.STATE):
		return "STATE";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(BinaryQuality arg)
  {
	switch (arg)
	{
	  case(BinaryQuality.ONLINE):
		return "ONLINE";
	  case(BinaryQuality.RESTART):
		return "RESTART";
	  case(BinaryQuality.COMM_LOST):
		return "COMM_LOST";
	  case(BinaryQuality.REMOTE_FORCED):
		return "REMOTE_FORCED";
	  case(BinaryQuality.LOCAL_FORCED):
		return "LOCAL_FORCED";
	  case(BinaryQuality.CHATTER_FILTER):
		return "CHATTER_FILTER";
	  case(BinaryQuality.RESERVED):
		return "RESERVED";
	  case(BinaryQuality.STATE):
		return "STATE";
	  default:
		return "UNDEFINED";
	}
  }

  public static BinaryQuality from_string(in string arg)
  {
	if (arg == "ONLINE")
	{
		return BinaryQuality.ONLINE;
	}
	if (arg == "RESTART")
	{
		return BinaryQuality.RESTART;
	}
	if (arg == "COMM_LOST")
	{
		return BinaryQuality.COMM_LOST;
	}
	if (arg == "REMOTE_FORCED")
	{
		return BinaryQuality.REMOTE_FORCED;
	}
	if (arg == "LOCAL_FORCED")
	{
		return BinaryQuality.LOCAL_FORCED;
	}
	if (arg == "CHATTER_FILTER")
	{
		return BinaryQuality.CHATTER_FILTER;
	}
	if (arg == "RESERVED")
	{
		return BinaryQuality.RESERVED;
	}
	if (arg == "STATE")
	{
		return BinaryQuality.STATE;
	}
   // else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return BinaryQuality.STATE; //REZA
  }
}

}




