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
  Used in conjunction with Operation Type in a CROB to describe which output to operate for complementary two-output model
  Refer to section A.8.1 of IEEE 1815-2012 for a full description
*/
public enum TripCloseCode : System.Byte
{
  /// Use the default output.
  NUL = 0x0,
  /// For complementary two-output model, operate the close output.
  CLOSE = 0x1,
  /// For complementary two-output model, operate the trip output.
  TRIP = 0x2,
  /// Reserved for future use.
  RESERVED = 0x3
}

public class TripCloseCodeSpec
{

  public static System.Byte to_type(TripCloseCode arg)
  {
	return (System.Byte)arg;
  }

  public static TripCloseCode from_type(System.Byte arg)
  {
	switch (arg)
	{
	  case(0x0):
		return TripCloseCode.NUL;
	  case(0x1):
		return TripCloseCode.CLOSE;
	  case(0x2):
		return TripCloseCode.TRIP;
	  case(0x3):
		return TripCloseCode.RESERVED;
	  default:
		  return TripCloseCode.RESERVED;
   //     throw new std::invalid_argument("Unknown value");
	}
  }

  public static string to_string(TripCloseCode arg)
  {
	switch (arg)
	{
	  case(TripCloseCode.NUL):
		return "NUL";
	  case(TripCloseCode.CLOSE):
		return "CLOSE";
	  case(TripCloseCode.TRIP):
		return "TRIP";
	  case(TripCloseCode.RESERVED):
		return "RESERVED";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(TripCloseCode arg)
  {
	switch (arg)
	{
	  case(TripCloseCode.NUL):
		return "NUL";
	  case(TripCloseCode.CLOSE):
		return "CLOSE";
	  case(TripCloseCode.TRIP):
		return "TRIP";
	  case(TripCloseCode.RESERVED):
		return "RESERVED";
	  default:
		return "UNDEFINED";
	}
  }

  public static TripCloseCode from_string(in string arg)
  {
	if (arg == "NUL")
	{
		return TripCloseCode.NUL;
	}
	if (arg == "CLOSE")
	{
		return TripCloseCode.CLOSE;
	}
	if (arg == "TRIP")
	{
		return TripCloseCode.TRIP;
	}
	if (arg == "RESERVED")
	{
		return TripCloseCode.RESERVED;
	}
	else
	{
		return TripCloseCode.RESERVED;
	}
  //  else throw std::invalid_argument(std::string("Unknown value: ") + arg);
  }
}

}




