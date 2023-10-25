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

public enum StaticCounterVariation : byte
{
  Group20Var1 = 0,
  Group20Var2 = 1,
  Group20Var5 = 2,
  Group20Var6 = 3
}

public class StaticCounterVariationSpec
{

  public static byte to_type(StaticCounterVariation arg)
  {
	return (byte)arg;
  }

  public static StaticCounterVariation from_type(byte arg)
  {
	switch (arg)
	{
	  case(0):
		return StaticCounterVariation.Group20Var1;
	  case(1):
		return StaticCounterVariation.Group20Var2;
	  case(2):
		return StaticCounterVariation.Group20Var5;
	  case(3):
		return StaticCounterVariation.Group20Var6;
	  default:
	//    throw new std::invalid_argument("Unknown value");
		return StaticCounterVariation.Group20Var6;
	}
  }

  public static string to_string(StaticCounterVariation arg)
  {
	switch (arg)
	{
	  case(StaticCounterVariation.Group20Var1):
		return "Group20Var1";
	  case(StaticCounterVariation.Group20Var2):
		return "Group20Var2";
	  case(StaticCounterVariation.Group20Var5):
		return "Group20Var5";
	  case(StaticCounterVariation.Group20Var6):
		return "Group20Var6";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(StaticCounterVariation arg)
  {
	switch (arg)
	{
	  case(StaticCounterVariation.Group20Var1):
		return "Group20Var1";
	  case(StaticCounterVariation.Group20Var2):
		return "Group20Var2";
	  case(StaticCounterVariation.Group20Var5):
		return "Group20Var5";
	  case(StaticCounterVariation.Group20Var6):
		return "Group20Var6";
	  default:
		return "UNDEFINED";
	}
  }

  public static StaticCounterVariation from_string(in string arg)
  {
	if (arg == "Group20Var1")
	{
		return StaticCounterVariation.Group20Var1;
	}
	if (arg == "Group20Var2")
	{
		return StaticCounterVariation.Group20Var2;
	}
	if (arg == "Group20Var5")
	{
		return StaticCounterVariation.Group20Var5;
	}
	if (arg == "Group20Var6")
	{
		return StaticCounterVariation.Group20Var6;
	}
  //  else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return StaticCounterVariation.Group20Var6;
  }
}

}




