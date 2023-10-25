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
  Class assignment for a measurement point
*/
public enum PointClass : System.Byte
{
  /// No event class assignment
  Class0 = 0x1,
  /// Assigned to event class 1
  Class1 = 0x2,
  /// Assigned to event class 2
  Class2 = 0x4,
  /// Assigned to event class 3
  Class3 = 0x8
}

public class PointClassSpec
{

  public static System.Byte to_type(PointClass arg)
  {
	return (System.Byte)arg;
  }

  public static PointClass from_type(System.Byte arg)
  {
	switch (arg)
	{
	  case(0x1):
		return PointClass.Class0;
	  case(0x2):
		return PointClass.Class1;
	  case(0x4):
		return PointClass.Class2;
	  case(0x8):
		return PointClass.Class3;
	  default:
  //      throw new std::invalid_argument("Unknown value");
		  return PointClass.Class0;
	}
  }

  public static string to_string(PointClass arg)
  {
	switch (arg)
	{
	  case(PointClass.Class0):
		return "Class0";
	  case(PointClass.Class1):
		return "Class1";
	  case(PointClass.Class2):
		return "Class2";
	  case(PointClass.Class3):
		return "Class3";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(PointClass arg)
  {
	switch (arg)
	{
	  case(PointClass.Class0):
		return "Class0";
	  case(PointClass.Class1):
		return "Class1";
	  case(PointClass.Class2):
		return "Class2";
	  case(PointClass.Class3):
		return "Class3";
	  default:
		return "UNDEFINED";
	}
  }

  public static PointClass from_string(in string arg)
  {
	if (arg == "Class0")
	{
		return PointClass.Class0;
	}
	if (arg == "Class1")
	{
		return PointClass.Class1;
	}
	if (arg == "Class2")
	{
		return PointClass.Class2;
	}
	if (arg == "Class3")
	{
		return PointClass.Class3;
	}
  //  else throw std::invalid_argument(std::string("Unknown value: ") + arg);
	return PointClass.Class0;
  }
}

}




