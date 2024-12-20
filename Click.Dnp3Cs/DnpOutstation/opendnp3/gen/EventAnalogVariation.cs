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

public enum EventAnalogVariation : byte
{
  Group32Var1 = 0,
  Group32Var2 = 1,
  Group32Var3 = 2,
  Group32Var4 = 3,
  Group32Var5 = 4,
  Group32Var6 = 5,
  Group32Var7 = 6,
  Group32Var8 = 7
}

public class EventAnalogVariationSpec
{

  public static byte to_type(EventAnalogVariation arg)
  {
	return (byte)arg;
  }

  public static EventAnalogVariation from_type(byte arg)
  {
	switch (arg)
	{
	  case(0):
		return EventAnalogVariation.Group32Var1;
	  case(1):
		return EventAnalogVariation.Group32Var2;
	  case(2):
		return EventAnalogVariation.Group32Var3;
	  case(3):
		return EventAnalogVariation.Group32Var4;
	  case(4):
		return EventAnalogVariation.Group32Var5;
	  case(5):
		return EventAnalogVariation.Group32Var6;
	  case(6):
		return EventAnalogVariation.Group32Var7;
	  case(7):
		return EventAnalogVariation.Group32Var8;
	  default:
	//    throw new std::invalid_argument("Unknown value");
		  return EventAnalogVariation.Group32Var8;
	}
  }

  public static string to_string(EventAnalogVariation arg)
  {
	switch (arg)
	{
	  case(EventAnalogVariation.Group32Var1):
		return "Group32Var1";
	  case(EventAnalogVariation.Group32Var2):
		return "Group32Var2";
	  case(EventAnalogVariation.Group32Var3):
		return "Group32Var3";
	  case(EventAnalogVariation.Group32Var4):
		return "Group32Var4";
	  case(EventAnalogVariation.Group32Var5):
		return "Group32Var5";
	  case(EventAnalogVariation.Group32Var6):
		return "Group32Var6";
	  case(EventAnalogVariation.Group32Var7):
		return "Group32Var7";
	  case(EventAnalogVariation.Group32Var8):
		return "Group32Var8";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(EventAnalogVariation arg)
  {
	switch (arg)
	{
	  case(EventAnalogVariation.Group32Var1):
		return "Group32Var1";
	  case(EventAnalogVariation.Group32Var2):
		return "Group32Var2";
	  case(EventAnalogVariation.Group32Var3):
		return "Group32Var3";
	  case(EventAnalogVariation.Group32Var4):
		return "Group32Var4";
	  case(EventAnalogVariation.Group32Var5):
		return "Group32Var5";
	  case(EventAnalogVariation.Group32Var6):
		return "Group32Var6";
	  case(EventAnalogVariation.Group32Var7):
		return "Group32Var7";
	  case(EventAnalogVariation.Group32Var8):
		return "Group32Var8";
	  default:
		return "UNDEFINED";
	}
  }

  public static EventAnalogVariation from_string(in string arg)
  {
	if (arg == "Group32Var1")
	{
		return EventAnalogVariation.Group32Var1;
	}
	if (arg == "Group32Var2")
	{
		return EventAnalogVariation.Group32Var2;
	}
	if (arg == "Group32Var3")
	{
		return EventAnalogVariation.Group32Var3;
	}
	if (arg == "Group32Var4")
	{
		return EventAnalogVariation.Group32Var4;
	}
	if (arg == "Group32Var5")
	{
		return EventAnalogVariation.Group32Var5;
	}
	if (arg == "Group32Var6")
	{
		return EventAnalogVariation.Group32Var6;
	}
	if (arg == "Group32Var7")
	{
		return EventAnalogVariation.Group32Var7;
	}
	if (arg == "Group32Var8")
	{
		return EventAnalogVariation.Group32Var8;
	}
  //  else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return EventAnalogVariation.Group32Var8;
  }
}

}




