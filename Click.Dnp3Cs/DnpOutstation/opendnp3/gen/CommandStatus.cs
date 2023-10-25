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
  An enumeration of result codes received from an outstation in response to command request.
  These correspond to those defined in the DNP3 standard
*/
public enum CommandStatus : byte
{
  /// command was accepted, initiated, or queued
  SUCCESS = 0,
  /// command timed out before completing
  TIMEOUT = 1,
  /// command requires being selected before operate, configuration issue
  NO_SELECT = 2,
  /// bad control code or timing values
  FORMAT_ERROR = 3,
  /// command is not implemented
  NOT_SUPPORTED = 4,
  /// command is all ready in progress or its all ready in that mode
  ALREADY_ACTIVE = 5,
  /// something is stopping the command, often a local/remote interlock
  HARDWARE_ERROR = 6,
  /// the function governed by the control is in local only control
  LOCAL = 7,
  /// the command has been done too often and has been throttled
  TOO_MANY_OPS = 8,
  /// the command was rejected because the device denied it or an RTU intercepted it
  NOT_AUTHORIZED = 9,
  /// command not accepted because it was prevented or inhibited by a local automation process, such as interlocking logic or synchrocheck
  AUTOMATION_INHIBIT = 10,
  /// command not accepted because the device cannot process any more activities than are presently in progress
  PROCESSING_LIMITED = 11,
  /// command not accepted because the value is outside the acceptable range permitted for this point
  OUT_OF_RANGE = 12,
  /// command not accepted because the outstation is forwarding the request to another downstream device which reported LOCAL
  DOWNSTREAM_LOCAL = 13,
  /// command not accepted because the outstation has already completed the requested operation
  ALREADY_COMPLETE = 14,
  /// command not accepted because the requested function is specifically blocked at the outstation
  BLOCKED = 15,
  /// command not accepted because the operation was cancelled
  CANCELLED = 16,
  /// command not accepted because another master is communicating with the outstation and has exclusive rights to operate this control point
  BLOCKED_OTHER_MASTER = 17,
  /// command not accepted because the outstation is forwarding the request to another downstream device which cannot be reached or is otherwise incapable of performing the request
  DOWNSTREAM_FAIL = 18,
  /// (deprecated) indicates the outstation shall not issue or perform the control operation
  NON_PARTICIPATING = 126,
  /// 10 to 126 are currently reserved
  UNDEFINED = 127
}

public class CommandStatusSpec
{

  public static byte to_type(CommandStatus arg)
  {
	return (byte)arg;
  }

  public static CommandStatus from_type(byte arg)
  {
	switch (arg)
	{
	  case(0):
		return CommandStatus.SUCCESS;
	  case(1):
		return CommandStatus.TIMEOUT;
	  case(2):
		return CommandStatus.NO_SELECT;
	  case(3):
		return CommandStatus.FORMAT_ERROR;
	  case(4):
		return CommandStatus.NOT_SUPPORTED;
	  case(5):
		return CommandStatus.ALREADY_ACTIVE;
	  case(6):
		return CommandStatus.HARDWARE_ERROR;
	  case(7):
		return CommandStatus.LOCAL;
	  case(8):
		return CommandStatus.TOO_MANY_OPS;
	  case(9):
		return CommandStatus.NOT_AUTHORIZED;
	  case(10):
		return CommandStatus.AUTOMATION_INHIBIT;
	  case(11):
		return CommandStatus.PROCESSING_LIMITED;
	  case(12):
		return CommandStatus.OUT_OF_RANGE;
	  case(13):
		return CommandStatus.DOWNSTREAM_LOCAL;
	  case(14):
		return CommandStatus.ALREADY_COMPLETE;
	  case(15):
		return CommandStatus.BLOCKED;
	  case(16):
		return CommandStatus.CANCELLED;
	  case(17):
		return CommandStatus.BLOCKED_OTHER_MASTER;
	  case(18):
		return CommandStatus.DOWNSTREAM_FAIL;
	  case(126):
		return CommandStatus.NON_PARTICIPATING;
	  default:
		return CommandStatus.UNDEFINED;
	}
  }

  public static string to_string(CommandStatus arg)
  {
	switch (arg)
	{
	  case(CommandStatus.SUCCESS):
		return "SUCCESS";
	  case(CommandStatus.TIMEOUT):
		return "TIMEOUT";
	  case(CommandStatus.NO_SELECT):
		return "NO_SELECT";
	  case(CommandStatus.FORMAT_ERROR):
		return "FORMAT_ERROR";
	  case(CommandStatus.NOT_SUPPORTED):
		return "NOT_SUPPORTED";
	  case(CommandStatus.ALREADY_ACTIVE):
		return "ALREADY_ACTIVE";
	  case(CommandStatus.HARDWARE_ERROR):
		return "HARDWARE_ERROR";
	  case(CommandStatus.LOCAL):
		return "LOCAL";
	  case(CommandStatus.TOO_MANY_OPS):
		return "TOO_MANY_OPS";
	  case(CommandStatus.NOT_AUTHORIZED):
		return "NOT_AUTHORIZED";
	  case(CommandStatus.AUTOMATION_INHIBIT):
		return "AUTOMATION_INHIBIT";
	  case(CommandStatus.PROCESSING_LIMITED):
		return "PROCESSING_LIMITED";
	  case(CommandStatus.OUT_OF_RANGE):
		return "OUT_OF_RANGE";
	  case(CommandStatus.DOWNSTREAM_LOCAL):
		return "DOWNSTREAM_LOCAL";
	  case(CommandStatus.ALREADY_COMPLETE):
		return "ALREADY_COMPLETE";
	  case(CommandStatus.BLOCKED):
		return "BLOCKED";
	  case(CommandStatus.CANCELLED):
		return "CANCELLED";
	  case(CommandStatus.BLOCKED_OTHER_MASTER):
		return "BLOCKED_OTHER_MASTER";
	  case(CommandStatus.DOWNSTREAM_FAIL):
		return "DOWNSTREAM_FAIL";
	  case(CommandStatus.NON_PARTICIPATING):
		return "NON_PARTICIPATING";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(CommandStatus arg)
  {
	switch (arg)
	{
	  case(CommandStatus.SUCCESS):
		return "SUCCESS";
	  case(CommandStatus.TIMEOUT):
		return "TIMEOUT";
	  case(CommandStatus.NO_SELECT):
		return "NO_SELECT";
	  case(CommandStatus.FORMAT_ERROR):
		return "FORMAT_ERROR";
	  case(CommandStatus.NOT_SUPPORTED):
		return "NOT_SUPPORTED";
	  case(CommandStatus.ALREADY_ACTIVE):
		return "ALREADY_ACTIVE";
	  case(CommandStatus.HARDWARE_ERROR):
		return "HARDWARE_ERROR";
	  case(CommandStatus.LOCAL):
		return "LOCAL";
	  case(CommandStatus.TOO_MANY_OPS):
		return "TOO_MANY_OPS";
	  case(CommandStatus.NOT_AUTHORIZED):
		return "NOT_AUTHORIZED";
	  case(CommandStatus.AUTOMATION_INHIBIT):
		return "AUTOMATION_INHIBIT";
	  case(CommandStatus.PROCESSING_LIMITED):
		return "PROCESSING_LIMITED";
	  case(CommandStatus.OUT_OF_RANGE):
		return "OUT_OF_RANGE";
	  case(CommandStatus.DOWNSTREAM_LOCAL):
		return "DOWNSTREAM_LOCAL";
	  case(CommandStatus.ALREADY_COMPLETE):
		return "ALREADY_COMPLETE";
	  case(CommandStatus.BLOCKED):
		return "BLOCKED";
	  case(CommandStatus.CANCELLED):
		return "CANCELLED";
	  case(CommandStatus.BLOCKED_OTHER_MASTER):
		return "BLOCKED_OTHER_MASTER";
	  case(CommandStatus.DOWNSTREAM_FAIL):
		return "DOWNSTREAM_FAIL";
	  case(CommandStatus.NON_PARTICIPATING):
		return "NON_PARTICIPATING";
	  default:
		return "UNDEFINED";
	}
  }

  public static CommandStatus from_string(in string arg)
  {
	if (arg == "SUCCESS")
	{
		return CommandStatus.SUCCESS;
	}
	if (arg == "TIMEOUT")
	{
		return CommandStatus.TIMEOUT;
	}
	if (arg == "NO_SELECT")
	{
		return CommandStatus.NO_SELECT;
	}
	if (arg == "FORMAT_ERROR")
	{
		return CommandStatus.FORMAT_ERROR;
	}
	if (arg == "NOT_SUPPORTED")
	{
		return CommandStatus.NOT_SUPPORTED;
	}
	if (arg == "ALREADY_ACTIVE")
	{
		return CommandStatus.ALREADY_ACTIVE;
	}
	if (arg == "HARDWARE_ERROR")
	{
		return CommandStatus.HARDWARE_ERROR;
	}
	if (arg == "LOCAL")
	{
		return CommandStatus.LOCAL;
	}
	if (arg == "TOO_MANY_OPS")
	{
		return CommandStatus.TOO_MANY_OPS;
	}
	if (arg == "NOT_AUTHORIZED")
	{
		return CommandStatus.NOT_AUTHORIZED;
	}
	if (arg == "AUTOMATION_INHIBIT")
	{
		return CommandStatus.AUTOMATION_INHIBIT;
	}
	if (arg == "PROCESSING_LIMITED")
	{
		return CommandStatus.PROCESSING_LIMITED;
	}
	if (arg == "OUT_OF_RANGE")
	{
		return CommandStatus.OUT_OF_RANGE;
	}
	if (arg == "DOWNSTREAM_LOCAL")
	{
		return CommandStatus.DOWNSTREAM_LOCAL;
	}
	if (arg == "ALREADY_COMPLETE")
	{
		return CommandStatus.ALREADY_COMPLETE;
	}
	if (arg == "BLOCKED")
	{
		return CommandStatus.BLOCKED;
	}
	if (arg == "CANCELLED")
	{
		return CommandStatus.CANCELLED;
	}
	if (arg == "BLOCKED_OTHER_MASTER")
	{
		return CommandStatus.BLOCKED_OTHER_MASTER;
	}
	if (arg == "DOWNSTREAM_FAIL")
	{
		return CommandStatus.DOWNSTREAM_FAIL;
	}
	if (arg == "NON_PARTICIPATING")
	{
		return CommandStatus.NON_PARTICIPATING;
	}
	else
	{
		return CommandStatus.UNDEFINED;
	}
  }
}

}




