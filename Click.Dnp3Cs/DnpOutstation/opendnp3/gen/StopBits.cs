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

public enum StopBits : byte
{
  One = 1,
  OnePointFive = 2,
  Two = 3,
  None = 0
}

public class StopBitsSpec
{

  public static byte to_type(StopBits arg)
  {
	return (byte)arg;
  }

  public static StopBits from_type(byte arg)
  {
	switch (arg)
	{
	  case(1):
		return StopBits.One;
	  case(2):
		return StopBits.OnePointFive;
	  case(3):
		return StopBits.Two;
	  default:
		return StopBits.None;
	}
  }

  public static string to_string(StopBits arg)
  {
	switch (arg)
	{
	  case(StopBits.One):
		return "One";
	  case(StopBits.OnePointFive):
		return "OnePointFive";
	  case(StopBits.Two):
		return "Two";
	  default:
		return "None";
	}
  }

  public static string to_human_string(StopBits arg)
  {
	switch (arg)
	{
	  case(StopBits.One):
		return "One";
	  case(StopBits.OnePointFive):
		return "OnePointFive";
	  case(StopBits.Two):
		return "Two";
	  default:
		return "None";
	}
  }

  public static StopBits from_string(in string arg)
  {
	if (arg == "One")
	{
		return StopBits.One;
	}
	if (arg == "OnePointFive")
	{
		return StopBits.OnePointFive;
	}
	if (arg == "Two")
	{
		return StopBits.Two;
	}
	else
	{
		return StopBits.None;
	}
  }
}

}



