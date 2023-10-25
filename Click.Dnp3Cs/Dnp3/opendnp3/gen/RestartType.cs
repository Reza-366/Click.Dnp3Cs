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

/**
  Enumeration describing restart operation to perform on an outstation
*/
public enum RestartType : System.Byte
{
  /// Full reboot
  COLD = 0,
  /// Warm reboot of process only
  WARM = 1
}

public class RestartTypeSpec
{

  public static System.Byte to_type(RestartType arg)
  {
	return (System.Byte)arg;
  }

  public static RestartType from_type(System.Byte arg)
  {
	switch (arg)
	{
	  case(0):
		return RestartType.COLD;
	  case(1):
		return RestartType.WARM;
	  default:
   //     throw new std::invalid_argument("Unknown value");
		  return RestartType.WARM;
	}
  }

  public static string to_string(RestartType arg)
  {
	switch (arg)
	{
	  case(RestartType.COLD):
		return "COLD";
	  case(RestartType.WARM):
		return "WARM";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(RestartType arg)
  {
	switch (arg)
	{
	  case(RestartType.COLD):
		return "COLD";
	  case(RestartType.WARM):
		return "WARM";
	  default:
		return "UNDEFINED";
	}
  }

  public static RestartType from_string(in string arg)
  {
	if (arg == "COLD")
	{
		return RestartType.COLD;
	}
	if (arg == "WARM")
	{
		return RestartType.WARM;
	}
   // else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return RestartType.WARM;
  }
}

}




