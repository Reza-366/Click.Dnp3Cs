﻿//
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

public enum StaticBinaryOutputStatusVariation : System.Byte
{
  Group10Var2 = 0
}

public class StaticBinaryOutputStatusVariationSpec
{

  public static System.Byte to_type(StaticBinaryOutputStatusVariation arg)
  {
	return (System.Byte)arg;
  }

  public static StaticBinaryOutputStatusVariation from_type(System.Byte arg)
  {
	switch (arg)
	{
	  case(0):
		return StaticBinaryOutputStatusVariation.Group10Var2;
	  default:
   //     throw new std::invalid_argument("Unknown value");
		  return StaticBinaryOutputStatusVariation.Group10Var2;
	}
  }

  public static string to_string(StaticBinaryOutputStatusVariation arg)
  {
	switch (arg)
	{
	  case(StaticBinaryOutputStatusVariation.Group10Var2):
		return "Group10Var2";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(StaticBinaryOutputStatusVariation arg)
  {
	switch (arg)
	{
	  case(StaticBinaryOutputStatusVariation.Group10Var2):
		return "Group10Var2";
	  default:
		return "UNDEFINED";
	}
  }

  public static StaticBinaryOutputStatusVariation from_string(in string arg)
  {
	if (arg == "Group10Var2")
	{
		return StaticBinaryOutputStatusVariation.Group10Var2;
	}
   // else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return StaticBinaryOutputStatusVariation.Group10Var2;
  }
}

}




