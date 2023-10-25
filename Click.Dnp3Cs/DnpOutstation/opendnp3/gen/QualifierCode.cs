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
  Object header range/prefix as a single enumeration
*/
public enum QualifierCode : byte
{
  UINT8_START_STOP = 0x0,
  UINT16_START_STOP = 0x1,
  ALL_OBJECTS = 0x6,
  UINT8_CNT = 0x7,
  UINT16_CNT = 0x8,
  UINT8_CNT_UINT8_INDEX = 0x17,
  UINT16_CNT_UINT16_INDEX = 0x28,
  UNDEFINED = 0xFF
}

public class QualifierCodeSpec
{

  public static byte to_type(QualifierCode arg)
  {
	return (byte)arg;
  }

  public static QualifierCode from_type(byte arg)
  {
	switch (arg)
	{
	  case(0x0):
		return QualifierCode.UINT8_START_STOP;
	  case(0x1):
		return QualifierCode.UINT16_START_STOP;
	  case(0x6):
		return QualifierCode.ALL_OBJECTS;
	  case(0x7):
		return QualifierCode.UINT8_CNT;
	  case(0x8):
		return QualifierCode.UINT16_CNT;
	  case(0x17):
		return QualifierCode.UINT8_CNT_UINT8_INDEX;
	  case(0x28):
		return QualifierCode.UINT16_CNT_UINT16_INDEX;
	  default:
		return QualifierCode.UNDEFINED;
	}
  }

  public static string to_string(QualifierCode arg)
  {
	switch (arg)
	{
	  case(QualifierCode.UINT8_START_STOP):
		return "UINT8_START_STOP";
	  case(QualifierCode.UINT16_START_STOP):
		return "UINT16_START_STOP";
	  case(QualifierCode.ALL_OBJECTS):
		return "ALL_OBJECTS";
	  case(QualifierCode.UINT8_CNT):
		return "UINT8_CNT";
	  case(QualifierCode.UINT16_CNT):
		return "UINT16_CNT";
	  case(QualifierCode.UINT8_CNT_UINT8_INDEX):
		return "UINT8_CNT_UINT8_INDEX";
	  case(QualifierCode.UINT16_CNT_UINT16_INDEX):
		return "UINT16_CNT_UINT16_INDEX";
	  default:
		return "UNDEFINED";
	}
  }

  public static string to_human_string(QualifierCode arg)
  {
	switch (arg)
	{
	  case(QualifierCode.UINT8_START_STOP):
		return "8-bit start stop";
	  case(QualifierCode.UINT16_START_STOP):
		return "16-bit start stop";
	  case(QualifierCode.ALL_OBJECTS):
		return "all objects";
	  case(QualifierCode.UINT8_CNT):
		return "8-bit count";
	  case(QualifierCode.UINT16_CNT):
		return "16-bit count";
	  case(QualifierCode.UINT8_CNT_UINT8_INDEX):
		return "8-bit count and prefix";
	  case(QualifierCode.UINT16_CNT_UINT16_INDEX):
		return "16-bit count and prefix";
	  default:
		return "unknown";
	}
  }

  public static QualifierCode from_string(in string arg)
  {
	if (arg == "UINT8_START_STOP")
	{
		return QualifierCode.UINT8_START_STOP;
	}
	if (arg == "UINT16_START_STOP")
	{
		return QualifierCode.UINT16_START_STOP;
	}
	if (arg == "ALL_OBJECTS")
	{
		return QualifierCode.ALL_OBJECTS;
	}
	if (arg == "UINT8_CNT")
	{
		return QualifierCode.UINT8_CNT;
	}
	if (arg == "UINT16_CNT")
	{
		return QualifierCode.UINT16_CNT;
	}
	if (arg == "UINT8_CNT_UINT8_INDEX")
	{
		return QualifierCode.UINT8_CNT_UINT8_INDEX;
	}
	if (arg == "UINT16_CNT_UINT16_INDEX")
	{
		return QualifierCode.UINT16_CNT_UINT16_INDEX;
	}
	else
	{
		return QualifierCode.UNDEFINED;
	}
  }
}

}




