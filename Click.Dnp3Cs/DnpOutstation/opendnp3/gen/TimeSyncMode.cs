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
  Determines what the master station does when it sees the NEED_TIME iin bit
*/
public enum TimeSyncMode : byte
{
  /// synchronize the outstation's time using the non-LAN time sync procedure
  NonLAN = 1,
  /// synchronize the outstation's time using the LAN time sync procedure
  LAN = 2,
  /// don't perform a time-sync
  None = 0
}

public class TimeSyncModeSpec
{

  public static byte to_type(TimeSyncMode arg)
  {
	return (byte)arg;
  }

  public static TimeSyncMode from_type(byte arg)
  {
	switch (arg)
	{
	  case(1):
		return TimeSyncMode.NonLAN;
	  case(2):
		return TimeSyncMode.LAN;
	  default:
		return TimeSyncMode.None;
	}
  }

  public static string to_string(TimeSyncMode arg)
  {
	switch (arg)
	{
	  case(TimeSyncMode.NonLAN):
		return "NonLAN";
	  case(TimeSyncMode.LAN):
		return "LAN";
	  default:
		return "None";
	}
  }

  public static string to_human_string(TimeSyncMode arg)
  {
	switch (arg)
	{
	  case(TimeSyncMode.NonLAN):
		return "NonLAN";
	  case(TimeSyncMode.LAN):
		return "LAN";
	  default:
		return "None";
	}
  }

  public static TimeSyncMode from_string(in string arg)
  {
	if (arg == "NonLAN")
	{
		return TimeSyncMode.NonLAN;
	}
	if (arg == "LAN")
	{
		return TimeSyncMode.LAN;
	}
	else
	{
		return TimeSyncMode.None;
	}
  }
}

}




