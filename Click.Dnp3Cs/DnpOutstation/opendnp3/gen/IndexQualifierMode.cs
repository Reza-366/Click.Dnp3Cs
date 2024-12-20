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
  Specifies whether opendnp3 optimizes for 1-byte indexes when making requests
*/
public enum IndexQualifierMode : byte
{
  /// Use a one byte qualifier if possible
  allow_one_byte = 0x0,
  /// Always use two byte qualifiers even if the index is less than or equal to 255
  always_two_bytes = 0x1
}

public class IndexQualifierModeSpec
{

  public static byte to_type(IndexQualifierMode arg)
  {
	return (byte)arg;
  }

  public static IndexQualifierMode from_type(byte arg)
  {
	switch (arg)
	{
	  case(0x0):
		return IndexQualifierMode.allow_one_byte;
	  case(0x1):
		return IndexQualifierMode.always_two_bytes;
	  default:
   //     throw new std::invalid_argument("Unknown value");
		  return IndexQualifierMode.allow_one_byte;
	}
  }

  public static string to_string(IndexQualifierMode arg)
  {
	switch (arg)
	{
	  case(IndexQualifierMode.allow_one_byte):
		return "allow_one_byte";
	  case(IndexQualifierMode.always_two_bytes):
		return "always_two_bytes";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(IndexQualifierMode arg)
  {
	switch (arg)
	{
	  case(IndexQualifierMode.allow_one_byte):
		return "allow_one_byte";
	  case(IndexQualifierMode.always_two_bytes):
		return "always_two_bytes";
	  default:
		return "UNDEFINED";
	}
  }

  public static IndexQualifierMode from_string(in string arg)
  {
	if (arg == "allow_one_byte")
	{
		return IndexQualifierMode.allow_one_byte;
	}
	if (arg == "always_two_bytes")
	{
		return IndexQualifierMode.always_two_bytes;
	}
   // else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return IndexQualifierMode.allow_one_byte;
  }
}

}




