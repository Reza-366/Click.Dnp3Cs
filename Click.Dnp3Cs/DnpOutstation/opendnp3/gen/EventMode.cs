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
  Describes how a transaction behaves with respect to event generation
*/
public enum EventMode : byte
{
  /// Detect events using the specific mechanism for that type
  Detect = 0x0,
  /// Force the creation of an event bypassing detection mechanism
  Force = 0x1,
  /// Never produce an event regardless of changes
  Suppress = 0x2,
  /// Force the creation of an event bypassing detection mechanism, but does not update the static value
  EventOnly = 0x3
}

public class EventModeSpec
{

  public static byte to_type(EventMode arg)
  {
	return (byte)arg;
  }

  public static EventMode from_type(byte arg)
  {
	switch (arg)
	{
	  case(0x0):
		return EventMode.Detect;
	  case(0x1):
		return EventMode.Force;
	  case(0x2):
		return EventMode.Suppress;
	  case(0x3):
		return EventMode.EventOnly;
	  default:
   //     throw new std::invalid_argument("Unknown value");
		  return EventMode.EventOnly;
	}
  }

  public static string to_string(EventMode arg)
  {
	switch (arg)
	{
	  case(EventMode.Detect):
		return "Detect";
	  case(EventMode.Force):
		return "Force";
	  case(EventMode.Suppress):
		return "Suppress";
	  case(EventMode.EventOnly):
		return "EventOnly";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(EventMode arg)
  {
	switch (arg)
	{
	  case(EventMode.Detect):
		return "Detect";
	  case(EventMode.Force):
		return "Force";
	  case(EventMode.Suppress):
		return "Suppress";
	  case(EventMode.EventOnly):
		return "EventOnly";
	  default:
		return "UNDEFINED";
	}
  }

  public static EventMode from_string(in string arg)
  {
	if (arg == "Detect")
	{
		return EventMode.Detect;
	}
	if (arg == "Force")
	{
		return EventMode.Force;
	}
	if (arg == "Suppress")
	{
		return EventMode.Suppress;
	}
	if (arg == "EventOnly")
	{
		return EventMode.EventOnly;
	}
  //  else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return EventMode.Force;
  }
}

}




