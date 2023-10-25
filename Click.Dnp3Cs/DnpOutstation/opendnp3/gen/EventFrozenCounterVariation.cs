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

public enum EventFrozenCounterVariation : byte
{
  Group23Var1 = 0,
  Group23Var2 = 1,
  Group23Var5 = 2,
  Group23Var6 = 3
}

public class EventFrozenCounterVariationSpec
{

  public static byte to_type(EventFrozenCounterVariation arg)
  {
	return (byte)arg;
  }

  public static EventFrozenCounterVariation from_type(byte arg)
  {
	switch (arg)
	{
	  case(0):
		return EventFrozenCounterVariation.Group23Var1;
	  case(1):
		return EventFrozenCounterVariation.Group23Var2;
	  case(2):
		return EventFrozenCounterVariation.Group23Var5;
	  case(3):
		return EventFrozenCounterVariation.Group23Var6;
	  default:
   //     throw new std::invalid_argument("Unknown value");
		  return EventFrozenCounterVariation.Group23Var6;
	}
  }

  public static string to_string(EventFrozenCounterVariation arg)
  {
	switch (arg)
	{
	  case(EventFrozenCounterVariation.Group23Var1):
		return "Group23Var1";
	  case(EventFrozenCounterVariation.Group23Var2):
		return "Group23Var2";
	  case(EventFrozenCounterVariation.Group23Var5):
		return "Group23Var5";
	  case(EventFrozenCounterVariation.Group23Var6):
		return "Group23Var6";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(EventFrozenCounterVariation arg)
  {
	switch (arg)
	{
	  case(EventFrozenCounterVariation.Group23Var1):
		return "Group23Var1";
	  case(EventFrozenCounterVariation.Group23Var2):
		return "Group23Var2";
	  case(EventFrozenCounterVariation.Group23Var5):
		return "Group23Var5";
	  case(EventFrozenCounterVariation.Group23Var6):
		return "Group23Var6";
	  default:
		return "UNDEFINED";
	}
  }

  public static EventFrozenCounterVariation from_string(in string arg)
  {
	if (arg == "Group23Var1")
	{
		return EventFrozenCounterVariation.Group23Var1;
	}
	if (arg == "Group23Var2")
	{
		return EventFrozenCounterVariation.Group23Var2;
	}
	if (arg == "Group23Var5")
	{
		return EventFrozenCounterVariation.Group23Var5;
	}
	if (arg == "Group23Var6")
	{
		return EventFrozenCounterVariation.Group23Var6;
	}
  //  else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return EventFrozenCounterVariation.Group23Var6;
  }
}

}



