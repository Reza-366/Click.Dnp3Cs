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
  Enumeration for possible states of a double bit value
*/
public enum DoubleBit : byte
{
  /// Transitioning between end conditions
  INTERMEDIATE = 0x0,
  /// End condition, determined to be OFF
  DETERMINED_OFF = 0x1,
  /// End condition, determined to be ON
  DETERMINED_ON = 0x2,
  /// Abnormal or custom condition
  INDETERMINATE = 0x3
}

public class DoubleBitSpec
{

  public static byte to_type(DoubleBit arg)
  {
	return (byte)arg;
  }

  public static DoubleBit from_type(byte arg)
  {
	switch (arg)
	{
	  case(0x0):
		return DoubleBit.INTERMEDIATE;
	  case(0x1):
		return DoubleBit.DETERMINED_OFF;
	  case(0x2):
		return DoubleBit.DETERMINED_ON;
	  default:
		return DoubleBit.INDETERMINATE;
	}
  }

  public static string to_string(DoubleBit arg)
  {
	switch (arg)
	{
	  case(DoubleBit.INTERMEDIATE):
		return "INTERMEDIATE";
	  case(DoubleBit.DETERMINED_OFF):
		return "DETERMINED_OFF";
	  case(DoubleBit.DETERMINED_ON):
		return "DETERMINED_ON";
	  default:
		return "INDETERMINATE";
	}
  }

  public static string to_human_string(DoubleBit arg)
  {
	switch (arg)
	{
	  case(DoubleBit.INTERMEDIATE):
		return "INTERMEDIATE";
	  case(DoubleBit.DETERMINED_OFF):
		return "DETERMINED_OFF";
	  case(DoubleBit.DETERMINED_ON):
		return "DETERMINED_ON";
	  default:
		return "INDETERMINATE";
	}
  }

  public static DoubleBit from_string(in string arg)
  {
	if (arg == "INTERMEDIATE")
	{
		return DoubleBit.INTERMEDIATE;
	}
	if (arg == "DETERMINED_OFF")
	{
		return DoubleBit.DETERMINED_OFF;
	}
	if (arg == "DETERMINED_ON")
	{
		return DoubleBit.DETERMINED_ON;
	}
	else
	{
		return DoubleBit.INDETERMINATE;
	}
  }
}

}




