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
  Quality field bitmask for analog output status values
*/
public enum AnalogOutputStatusQuality : byte
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
  /// set if a hardware input etc. is out of range and we are using a place holder value
  OVERRANGE = 0x20,
  /// set if calibration or reference voltage has been lost meaning readings are questionable
  REFERENCE_ERR = 0x40,
  /// reserved bit
  RESERVED = 0x80
}

public class AnalogOutputStatusQualitySpec
{

  public static byte to_type(AnalogOutputStatusQuality arg)
  {
	return (byte)arg;
  }

  public static AnalogOutputStatusQuality from_type(byte arg)
  {
	switch (arg)
	{
	  case(0x1):
		return AnalogOutputStatusQuality.ONLINE;
	  case(0x2):
		return AnalogOutputStatusQuality.RESTART;
	  case(0x4):
		return AnalogOutputStatusQuality.COMM_LOST;
	  case(0x8):
		return AnalogOutputStatusQuality.REMOTE_FORCED;
	  case(0x10):
		return AnalogOutputStatusQuality.LOCAL_FORCED;
	  case(0x20):
		return AnalogOutputStatusQuality.OVERRANGE;
	  case(0x40):
		return AnalogOutputStatusQuality.REFERENCE_ERR;
	  case(0x80):
		return AnalogOutputStatusQuality.RESERVED;
	  default:
  //      throw new std::invalid_argument("Unknown value"); //REZA
		  return AnalogOutputStatusQuality.RESERVED;
	}
  }

  public static string to_string(AnalogOutputStatusQuality arg)
  {
	switch (arg)
	{
	  case(AnalogOutputStatusQuality.ONLINE):
		return "ONLINE";
	  case(AnalogOutputStatusQuality.RESTART):
		return "RESTART";
	  case(AnalogOutputStatusQuality.COMM_LOST):
		return "COMM_LOST";
	  case(AnalogOutputStatusQuality.REMOTE_FORCED):
		return "REMOTE_FORCED";
	  case(AnalogOutputStatusQuality.LOCAL_FORCED):
		return "LOCAL_FORCED";
	  case(AnalogOutputStatusQuality.OVERRANGE):
		return "OVERRANGE";
	  case(AnalogOutputStatusQuality.REFERENCE_ERR):
		return "REFERENCE_ERR";
	  case(AnalogOutputStatusQuality.RESERVED):
		return "RESERVED";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(AnalogOutputStatusQuality arg)
  {
	switch (arg)
	{
	  case(AnalogOutputStatusQuality.ONLINE):
		return "ONLINE";
	  case(AnalogOutputStatusQuality.RESTART):
		return "RESTART";
	  case(AnalogOutputStatusQuality.COMM_LOST):
		return "COMM_LOST";
	  case(AnalogOutputStatusQuality.REMOTE_FORCED):
		return "REMOTE_FORCED";
	  case(AnalogOutputStatusQuality.LOCAL_FORCED):
		return "LOCAL_FORCED";
	  case(AnalogOutputStatusQuality.OVERRANGE):
		return "OVERRANGE";
	  case(AnalogOutputStatusQuality.REFERENCE_ERR):
		return "REFERENCE_ERR";
	  case(AnalogOutputStatusQuality.RESERVED):
		return "RESERVED";
	  default:
		return "UNDEFINED";
	}
  }

  public static AnalogOutputStatusQuality from_string(in string arg)
  {
	if (arg == "ONLINE")
	{
		return AnalogOutputStatusQuality.ONLINE;
	}
	if (arg == "RESTART")
	{
		return AnalogOutputStatusQuality.RESTART;
	}
	if (arg == "COMM_LOST")
	{
		return AnalogOutputStatusQuality.COMM_LOST;
	}
	if (arg == "REMOTE_FORCED")
	{
		return AnalogOutputStatusQuality.REMOTE_FORCED;
	}
	if (arg == "LOCAL_FORCED")
	{
		return AnalogOutputStatusQuality.LOCAL_FORCED;
	}
	if (arg == "OVERRANGE")
	{
		return AnalogOutputStatusQuality.OVERRANGE;
	}
	if (arg == "REFERENCE_ERR")
	{
		return AnalogOutputStatusQuality.REFERENCE_ERR;
	}
	if (arg == "RESERVED")
	{
		return AnalogOutputStatusQuality.RESERVED;
	}
  //  else throw std::invalid_argument(std::string("Unknown value: ") + arg); //REZA
	return AnalogOutputStatusQuality.RESERVED;
  }
}

}




