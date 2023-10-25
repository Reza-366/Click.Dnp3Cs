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
  Enumeration for possible states of a channel
*/
public enum ChannelState : byte
{
  /// offline and idle
  CLOSED = 0,
  /// trying to open
  OPENING = 1,
  /// open
  OPEN = 2,
  /// stopped and will never do anything again
  SHUTDOWN = 3
}

public class ChannelStateSpec
{

  public static byte to_type(ChannelState arg)
  {
	return (byte)arg;
  }

  public static ChannelState from_type(byte arg)
  {
	switch (arg)
	{
	  case(0):
		return ChannelState.CLOSED;
	  case(1):
		return ChannelState.OPENING;
	  case(2):
		return ChannelState.OPEN;
	  default:
		return ChannelState.SHUTDOWN;
	}
  }

  public static string to_string(ChannelState arg)
  {
	switch (arg)
	{
	  case(ChannelState.CLOSED):
		return "CLOSED";
	  case(ChannelState.OPENING):
		return "OPENING";
	  case(ChannelState.OPEN):
		return "OPEN";
	  default:
		return "SHUTDOWN";
	}
  }

  public static string to_human_string(ChannelState arg)
  {
	switch (arg)
	{
	  case(ChannelState.CLOSED):
		return "CLOSED";
	  case(ChannelState.OPENING):
		return "OPENING";
	  case(ChannelState.OPEN):
		return "OPEN";
	  default:
		return "SHUTDOWN";
	}
  }

  public static ChannelState from_string(in string arg)
  {
	if (arg == "CLOSED")
	{
		return ChannelState.CLOSED;
	}
	if (arg == "OPENING")
	{
		return ChannelState.OPENING;
	}
	if (arg == "OPEN")
	{
		return ChannelState.OPEN;
	}
	else
	{
		return ChannelState.SHUTDOWN;
	}
  }
}

}




