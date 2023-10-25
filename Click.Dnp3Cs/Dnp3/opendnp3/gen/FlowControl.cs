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
  Enumeration for setting serial port flow control
*/
public enum FlowControl : System.Byte
{
  Hardware = 1,
  XONXOFF = 2,
  None = 0
}

public class FlowControlSpec
{

  public static System.Byte to_type(FlowControl arg)
  {
	return (System.Byte)arg;
  }

  public static FlowControl from_type(System.Byte arg)
  {
	switch (arg)
	{
	  case(1):
		return FlowControl.Hardware;
	  case(2):
		return FlowControl.XONXOFF;
	  default:
		return FlowControl.None;
	}
  }

  public static string to_string(FlowControl arg)
  {
	switch (arg)
	{
	  case(FlowControl.Hardware):
		return "Hardware";
	  case(FlowControl.XONXOFF):
		return "XONXOFF";
	  default:
		return "None";
	}
  }

  public static string to_human_string(FlowControl arg)
  {
	switch (arg)
	{
	  case(FlowControl.Hardware):
		return "Hardware";
	  case(FlowControl.XONXOFF):
		return "XONXOFF";
	  default:
		return "None";
	}
  }

  public static FlowControl from_string(in string arg)
  {
	if (arg == "Hardware")
	{
		return FlowControl.Hardware;
	}
	if (arg == "XONXOFF")
	{
		return FlowControl.XONXOFF;
	}
	else
	{
		return FlowControl.None;
	}
  }
}

}




