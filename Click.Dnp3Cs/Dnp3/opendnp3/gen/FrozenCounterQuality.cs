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
  Quality field bitmask for frozen counter values
*/
public enum FrozenCounterQuality : System.Byte
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
  /// Deprecated flag that indicates value has rolled over
  ROLLOVER = 0x20,
  /// indicates an unusual change in value
  DISCONTINUITY = 0x40,
  /// reserved bit
  RESERVED = 0x80
}

public class FrozenCounterQualitySpec
{

  public static System.Byte to_type(FrozenCounterQuality arg)
  {
	return (System.Byte)arg;
  }

  public static FrozenCounterQuality from_type(System.Byte arg)
  {
	switch (arg)
	{
	  case(0x1):
		return FrozenCounterQuality.ONLINE;
	  case(0x2):
		return FrozenCounterQuality.RESTART;
	  case(0x4):
		return FrozenCounterQuality.COMM_LOST;
	  case(0x8):
		return FrozenCounterQuality.REMOTE_FORCED;
	  case(0x10):
		return FrozenCounterQuality.LOCAL_FORCED;
	  case(0x20):
		return FrozenCounterQuality.ROLLOVER;
	  case(0x40):
		return FrozenCounterQuality.DISCONTINUITY;
	  case(0x80):
		return FrozenCounterQuality.RESERVED;
	  default:
   //     throw new std::invalid_argument("Unknown value");
		  return FrozenCounterQuality.RESERVED;
	}
  }

  public static string to_string(FrozenCounterQuality arg)
  {
	switch (arg)
	{
	  case(FrozenCounterQuality.ONLINE):
		return "ONLINE";
	  case(FrozenCounterQuality.RESTART):
		return "RESTART";
	  case(FrozenCounterQuality.COMM_LOST):
		return "COMM_LOST";
	  case(FrozenCounterQuality.REMOTE_FORCED):
		return "REMOTE_FORCED";
	  case(FrozenCounterQuality.LOCAL_FORCED):
		return "LOCAL_FORCED";
	  case(FrozenCounterQuality.ROLLOVER):
		return "ROLLOVER";
	  case(FrozenCounterQuality.DISCONTINUITY):
		return "DISCONTINUITY";
	  case(FrozenCounterQuality.RESERVED):
		return "RESERVED";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(FrozenCounterQuality arg)
  {
	switch (arg)
	{
	  case(FrozenCounterQuality.ONLINE):
		return "ONLINE";
	  case(FrozenCounterQuality.RESTART):
		return "RESTART";
	  case(FrozenCounterQuality.COMM_LOST):
		return "COMM_LOST";
	  case(FrozenCounterQuality.REMOTE_FORCED):
		return "REMOTE_FORCED";
	  case(FrozenCounterQuality.LOCAL_FORCED):
		return "LOCAL_FORCED";
	  case(FrozenCounterQuality.ROLLOVER):
		return "ROLLOVER";
	  case(FrozenCounterQuality.DISCONTINUITY):
		return "DISCONTINUITY";
	  case(FrozenCounterQuality.RESERVED):
		return "RESERVED";
	  default:
		return "UNDEFINED";
	}
  }

  public static FrozenCounterQuality from_string(in string arg)
  {
	if (arg == "ONLINE")
	{
		return FrozenCounterQuality.ONLINE;
	}
	if (arg == "RESTART")
	{
		return FrozenCounterQuality.RESTART;
	}
	if (arg == "COMM_LOST")
	{
		return FrozenCounterQuality.COMM_LOST;
	}
	if (arg == "REMOTE_FORCED")
	{
		return FrozenCounterQuality.REMOTE_FORCED;
	}
	if (arg == "LOCAL_FORCED")
	{
		return FrozenCounterQuality.LOCAL_FORCED;
	}
	if (arg == "ROLLOVER")
	{
		return FrozenCounterQuality.ROLLOVER;
	}
	if (arg == "DISCONTINUITY")
	{
		return FrozenCounterQuality.DISCONTINUITY;
	}
	if (arg == "RESERVED")
	{
		return FrozenCounterQuality.RESERVED;
	}
   // else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return FrozenCounterQuality.RESERVED;
  }
}

}




