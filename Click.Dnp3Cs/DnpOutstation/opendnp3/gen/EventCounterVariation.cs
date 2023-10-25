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

public enum EventCounterVariation : byte
{
  Group22Var1 = 0,
  Group22Var2 = 1,
  Group22Var5 = 2,
  Group22Var6 = 3
}

public class EventCounterVariationSpec
{

  public static byte to_type(EventCounterVariation arg)
  {
	return (byte)arg;
  }

  public static EventCounterVariation from_type(byte arg)
  {
	switch (arg)
	{
	  case(0):
		return EventCounterVariation.Group22Var1;
	  case(1):
		return EventCounterVariation.Group22Var2;
	  case(2):
		return EventCounterVariation.Group22Var5;
	  case(3):
		return EventCounterVariation.Group22Var6;
	  default:
  //      throw new std::invalid_argument("Unknown value");
		  return EventCounterVariation.Group22Var6;
	}
  }

  public static string to_string(EventCounterVariation arg)
  {
	switch (arg)
	{
	  case(EventCounterVariation.Group22Var1):
		return "Group22Var1";
	  case(EventCounterVariation.Group22Var2):
		return "Group22Var2";
	  case(EventCounterVariation.Group22Var5):
		return "Group22Var5";
	  case(EventCounterVariation.Group22Var6):
		return "Group22Var6";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(EventCounterVariation arg)
  {
	switch (arg)
	{
	  case(EventCounterVariation.Group22Var1):
		return "Group22Var1";
	  case(EventCounterVariation.Group22Var2):
		return "Group22Var2";
	  case(EventCounterVariation.Group22Var5):
		return "Group22Var5";
	  case(EventCounterVariation.Group22Var6):
		return "Group22Var6";
	  default:
		return "UNDEFINED";
	}
  }

  public static EventCounterVariation from_string(in string arg)
  {
	if (arg == "Group22Var1")
	{
		return EventCounterVariation.Group22Var1;
	}
	if (arg == "Group22Var2")
	{
		return EventCounterVariation.Group22Var2;
	}
	if (arg == "Group22Var5")
	{
		return EventCounterVariation.Group22Var5;
	}
	if (arg == "Group22Var6")
	{
		return EventCounterVariation.Group22Var6;
	}
   // else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return EventCounterVariation.Group22Var6;
  }
}

}




