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

/**
  Link layer function code enumeration
*/
public enum LinkFunction : byte
{
  PRI_RESET_LINK_STATES = 0x40,
  PRI_TEST_LINK_STATES = 0x42,
  PRI_CONFIRMED_USER_DATA = 0x43,
  PRI_UNCONFIRMED_USER_DATA = 0x44,
  PRI_REQUEST_LINK_STATUS = 0x49,
  SEC_ACK = 0x0,
  SEC_NACK = 0x1,
  SEC_LINK_STATUS = 0xB,
  SEC_NOT_SUPPORTED = 0xF,
  INVALID = 0xFF
}

public class LinkFunctionSpec
{

  public static byte to_type(LinkFunction arg)
  {
	return (byte)arg;
  }

  public static LinkFunction from_type(byte arg)
  {
	switch (arg)
	{
	  case(0x40):
		return LinkFunction.PRI_RESET_LINK_STATES;
	  case(0x42):
		return LinkFunction.PRI_TEST_LINK_STATES;
	  case(0x43):
		return LinkFunction.PRI_CONFIRMED_USER_DATA;
	  case(0x44):
		return LinkFunction.PRI_UNCONFIRMED_USER_DATA;
	  case(0x49):
		return LinkFunction.PRI_REQUEST_LINK_STATUS;
	  case(0x0):
		return LinkFunction.SEC_ACK;
	  case(0x1):
		return LinkFunction.SEC_NACK;
	  case(0xB):
		return LinkFunction.SEC_LINK_STATUS;
	  case(0xF):
		return LinkFunction.SEC_NOT_SUPPORTED;
	  default:
		return LinkFunction.INVALID;
	}
  }

  public static string to_string(LinkFunction arg)
  {
	switch (arg)
	{
	  case(LinkFunction.PRI_RESET_LINK_STATES):
		return "PRI_RESET_LINK_STATES";
	  case(LinkFunction.PRI_TEST_LINK_STATES):
		return "PRI_TEST_LINK_STATES";
	  case(LinkFunction.PRI_CONFIRMED_USER_DATA):
		return "PRI_CONFIRMED_USER_DATA";
	  case(LinkFunction.PRI_UNCONFIRMED_USER_DATA):
		return "PRI_UNCONFIRMED_USER_DATA";
	  case(LinkFunction.PRI_REQUEST_LINK_STATUS):
		return "PRI_REQUEST_LINK_STATUS";
	  case(LinkFunction.SEC_ACK):
		return "SEC_ACK";
	  case(LinkFunction.SEC_NACK):
		return "SEC_NACK";
	  case(LinkFunction.SEC_LINK_STATUS):
		return "SEC_LINK_STATUS";
	  case(LinkFunction.SEC_NOT_SUPPORTED):
		return "SEC_NOT_SUPPORTED";
	  default:
		return "INVALID";
	}
  }

  public static string to_human_string(LinkFunction arg)
  {
	switch (arg)
	{
	  case(LinkFunction.PRI_RESET_LINK_STATES):
		return "PRI_RESET_LINK_STATES";
	  case(LinkFunction.PRI_TEST_LINK_STATES):
		return "PRI_TEST_LINK_STATES";
	  case(LinkFunction.PRI_CONFIRMED_USER_DATA):
		return "PRI_CONFIRMED_USER_DATA";
	  case(LinkFunction.PRI_UNCONFIRMED_USER_DATA):
		return "PRI_UNCONFIRMED_USER_DATA";
	  case(LinkFunction.PRI_REQUEST_LINK_STATUS):
		return "PRI_REQUEST_LINK_STATUS";
	  case(LinkFunction.SEC_ACK):
		return "SEC_ACK";
	  case(LinkFunction.SEC_NACK):
		return "SEC_NACK";
	  case(LinkFunction.SEC_LINK_STATUS):
		return "SEC_LINK_STATUS";
	  case(LinkFunction.SEC_NOT_SUPPORTED):
		return "SEC_NOT_SUPPORTED";
	  default:
		return "INVALID";
	}
  }

  public static LinkFunction from_string(in string arg)
  {
	if (arg == "PRI_RESET_LINK_STATES")
	{
		return LinkFunction.PRI_RESET_LINK_STATES;
	}
	if (arg == "PRI_TEST_LINK_STATES")
	{
		return LinkFunction.PRI_TEST_LINK_STATES;
	}
	if (arg == "PRI_CONFIRMED_USER_DATA")
	{
		return LinkFunction.PRI_CONFIRMED_USER_DATA;
	}
	if (arg == "PRI_UNCONFIRMED_USER_DATA")
	{
		return LinkFunction.PRI_UNCONFIRMED_USER_DATA;
	}
	if (arg == "PRI_REQUEST_LINK_STATUS")
	{
		return LinkFunction.PRI_REQUEST_LINK_STATUS;
	}
	if (arg == "SEC_ACK")
	{
		return LinkFunction.SEC_ACK;
	}
	if (arg == "SEC_NACK")
	{
		return LinkFunction.SEC_NACK;
	}
	if (arg == "SEC_LINK_STATUS")
	{
		return LinkFunction.SEC_LINK_STATUS;
	}
	if (arg == "SEC_NOT_SUPPORTED")
	{
		return LinkFunction.SEC_NOT_SUPPORTED;
	}
	else
	{
		return LinkFunction.INVALID;
	}
  }
}

}




