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

public enum StaticAnalogVariation : byte
{
  Group30Var1 = 0,
  Group30Var2 = 1,
  Group30Var3 = 2,
  Group30Var4 = 3,
  Group30Var5 = 4,
  Group30Var6 = 5
}

public class StaticAnalogVariationSpec
{

  public static byte to_type(StaticAnalogVariation arg)
  {
	return (byte)arg;
  }

  public static StaticAnalogVariation from_type(byte arg)
  {
	switch (arg)
	{
	  case(0):
		return StaticAnalogVariation.Group30Var1;
	  case(1):
		return StaticAnalogVariation.Group30Var2;
	  case(2):
		return StaticAnalogVariation.Group30Var3;
	  case(3):
		return StaticAnalogVariation.Group30Var4;
	  case(4):
		return StaticAnalogVariation.Group30Var5;
	  case(5):
		return StaticAnalogVariation.Group30Var6;
	  default:
	//    throw new std::invalid_argument("Unknown value");
		  return StaticAnalogVariation.Group30Var6;
	}
  }

  public static string to_string(StaticAnalogVariation arg)
  {
	switch (arg)
	{
	  case(StaticAnalogVariation.Group30Var1):
		return "Group30Var1";
	  case(StaticAnalogVariation.Group30Var2):
		return "Group30Var2";
	  case(StaticAnalogVariation.Group30Var3):
		return "Group30Var3";
	  case(StaticAnalogVariation.Group30Var4):
		return "Group30Var4";
	  case(StaticAnalogVariation.Group30Var5):
		return "Group30Var5";
	  case(StaticAnalogVariation.Group30Var6):
		return "Group30Var6";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(StaticAnalogVariation arg)
  {
	switch (arg)
	{
	  case(StaticAnalogVariation.Group30Var1):
		return "Group30Var1";
	  case(StaticAnalogVariation.Group30Var2):
		return "Group30Var2";
	  case(StaticAnalogVariation.Group30Var3):
		return "Group30Var3";
	  case(StaticAnalogVariation.Group30Var4):
		return "Group30Var4";
	  case(StaticAnalogVariation.Group30Var5):
		return "Group30Var5";
	  case(StaticAnalogVariation.Group30Var6):
		return "Group30Var6";
	  default:
		return "UNDEFINED";
	}
  }

  public static StaticAnalogVariation from_string(in string arg)
  {
	if (arg == "Group30Var1")
	{
		return StaticAnalogVariation.Group30Var1;
	}
	if (arg == "Group30Var2")
	{
		return StaticAnalogVariation.Group30Var2;
	}
	if (arg == "Group30Var3")
	{
		return StaticAnalogVariation.Group30Var3;
	}
	if (arg == "Group30Var4")
	{
		return StaticAnalogVariation.Group30Var4;
	}
	if (arg == "Group30Var5")
	{
		return StaticAnalogVariation.Group30Var5;
	}
	if (arg == "Group30Var6")
	{
		return StaticAnalogVariation.Group30Var6;
	}
  //  else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return StaticAnalogVariation.Group30Var6;
  }
}

}




