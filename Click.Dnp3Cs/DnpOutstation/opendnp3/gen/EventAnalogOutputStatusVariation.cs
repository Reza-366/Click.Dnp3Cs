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

public enum EventAnalogOutputStatusVariation : byte
{
  Group42Var1 = 0,
  Group42Var2 = 1,
  Group42Var3 = 2,
  Group42Var4 = 3,
  Group42Var5 = 4,
  Group42Var6 = 5,
  Group42Var7 = 6,
  Group42Var8 = 7
}

public class EventAnalogOutputStatusVariationSpec
{

  public static byte to_type(EventAnalogOutputStatusVariation arg)
  {
	return (byte)arg;
  }

  public static EventAnalogOutputStatusVariation from_type(byte arg)
  {
	switch (arg)
	{
	  case(0):
		return EventAnalogOutputStatusVariation.Group42Var1;
	  break;
	  case(1):
		return EventAnalogOutputStatusVariation.Group42Var2;
	  break;
	  case(2):
		return EventAnalogOutputStatusVariation.Group42Var3;
	  break;
	  case(3):
		return EventAnalogOutputStatusVariation.Group42Var4;
	  break;
	  case(4):
		return EventAnalogOutputStatusVariation.Group42Var5;
	  break;
	  case(5):
		return EventAnalogOutputStatusVariation.Group42Var6;
	  break;
	  case(6):
		return EventAnalogOutputStatusVariation.Group42Var7;
	  break;
	  case(7):
		return EventAnalogOutputStatusVariation.Group42Var8;
	  break;
   //   default:
   //     throw new std::invalid_argument("Unknown value");
	  default:
		  return EventAnalogOutputStatusVariation.Group42Var8;
	}
  }

  public static string to_string(EventAnalogOutputStatusVariation arg)
  {
	switch (arg)
	{
	  case(EventAnalogOutputStatusVariation.Group42Var1):
		return "Group42Var1";
	  case(EventAnalogOutputStatusVariation.Group42Var2):
		return "Group42Var2";
	  case(EventAnalogOutputStatusVariation.Group42Var3):
		return "Group42Var3";
	  case(EventAnalogOutputStatusVariation.Group42Var4):
		return "Group42Var4";
	  case(EventAnalogOutputStatusVariation.Group42Var5):
		return "Group42Var5";
	  case(EventAnalogOutputStatusVariation.Group42Var6):
		return "Group42Var6";
	  case(EventAnalogOutputStatusVariation.Group42Var7):
		return "Group42Var7";
	  case(EventAnalogOutputStatusVariation.Group42Var8):
		return "Group42Var8";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(EventAnalogOutputStatusVariation arg)
  {
	switch (arg)
	{
	  case(EventAnalogOutputStatusVariation.Group42Var1):
		return "Group42Var1";
	  case(EventAnalogOutputStatusVariation.Group42Var2):
		return "Group42Var2";
	  case(EventAnalogOutputStatusVariation.Group42Var3):
		return "Group42Var3";
	  case(EventAnalogOutputStatusVariation.Group42Var4):
		return "Group42Var4";
	  case(EventAnalogOutputStatusVariation.Group42Var5):
		return "Group42Var5";
	  case(EventAnalogOutputStatusVariation.Group42Var6):
		return "Group42Var6";
	  case(EventAnalogOutputStatusVariation.Group42Var7):
		return "Group42Var7";
	  case(EventAnalogOutputStatusVariation.Group42Var8):
		return "Group42Var8";
	  default:
		return "UNDEFINED";
	}
  }

  public static EventAnalogOutputStatusVariation from_string(in string arg)
  {
	if (arg == "Group42Var1")
	{
		return EventAnalogOutputStatusVariation.Group42Var1;
	}
	if (arg == "Group42Var2")
	{
		return EventAnalogOutputStatusVariation.Group42Var2;
	}
	if (arg == "Group42Var3")
	{
		return EventAnalogOutputStatusVariation.Group42Var3;
	}
	if (arg == "Group42Var4")
	{
		return EventAnalogOutputStatusVariation.Group42Var4;
	}
	if (arg == "Group42Var5")
	{
		return EventAnalogOutputStatusVariation.Group42Var5;
	}
	if (arg == "Group42Var6")
	{
		return EventAnalogOutputStatusVariation.Group42Var6;
	}
	if (arg == "Group42Var7")
	{
		return EventAnalogOutputStatusVariation.Group42Var7;
	}
	if (arg == "Group42Var8")
	{
		return EventAnalogOutputStatusVariation.Group42Var8;
	}
   // else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return EventAnalogOutputStatusVariation.Group42Var8;

  }
}

}




