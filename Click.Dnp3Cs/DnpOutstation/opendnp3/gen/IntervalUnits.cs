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
  Time internal units
*/
public enum IntervalUnits : byte
{
  /// The outstation does not repeat the action regardless of the value in the interval count
  NoRepeat = 0x0,
  /// the interval is always counted relative to the start time and is constant regardless of the clock time set at the outstation
  Milliseconds = 0x1,
  /// At the same millisecond within the second that is specified in the start time
  Seconds = 0x2,
  /// At the same second and millisecond within the minute that is specified in the start time
  Minutes = 0x3,
  /// At the same minute, second and millisecond within the hour that is specified in the start time
  Hours = 0x4,
  /// At the same time of day that is specified in the start time
  Days = 0x5,
  /// On the same day of the week at the same time of day that is specified in the start time
  Weeks = 0x6,
  /// On the same day of each month at the same time of day that is specified in the start time
  Months7 = 0x7,
  /// At the same time of day on the same day of the week after the beginning of the month as the day specified in the start time
  Months8 = 0x8,
  /// Months on Same Day of Week from End of Month - The outstation shall interpret this setting as in Months8, but the day of the week shall be measured from the end of the month,
  Months9 = 0x9,
  /// The definition of a season is specific to the outstation
  Seasons = 0xA,
  /// 11-127 are reserved for future use
  Undefined = 0x7F
}

public class IntervalUnitsSpec
{

  public static byte to_type(IntervalUnits arg)
  {
	return (byte)arg;
  }

  public static IntervalUnits from_type(byte arg)
  {
	switch (arg)
	{
	  case(0x0):
		return IntervalUnits.NoRepeat;
	  case(0x1):
		return IntervalUnits.Milliseconds;
	  case(0x2):
		return IntervalUnits.Seconds;
	  case(0x3):
		return IntervalUnits.Minutes;
	  case(0x4):
		return IntervalUnits.Hours;
	  case(0x5):
		return IntervalUnits.Days;
	  case(0x6):
		return IntervalUnits.Weeks;
	  case(0x7):
		return IntervalUnits.Months7;
	  case(0x8):
		return IntervalUnits.Months8;
	  case(0x9):
		return IntervalUnits.Months9;
	  case(0xA):
		return IntervalUnits.Seasons;
	  default:
		return IntervalUnits.Undefined;
	}
  }

  public static string to_string(IntervalUnits arg)
  {
	switch (arg)
	{
	  case(IntervalUnits.NoRepeat):
		return "NoRepeat";
	  case(IntervalUnits.Milliseconds):
		return "Milliseconds";
	  case(IntervalUnits.Seconds):
		return "Seconds";
	  case(IntervalUnits.Minutes):
		return "Minutes";
	  case(IntervalUnits.Hours):
		return "Hours";
	  case(IntervalUnits.Days):
		return "Days";
	  case(IntervalUnits.Weeks):
		return "Weeks";
	  case(IntervalUnits.Months7):
		return "Months7";
	  case(IntervalUnits.Months8):
		return "Months8";
	  case(IntervalUnits.Months9):
		return "Months9";
	  case(IntervalUnits.Seasons):
		return "Seasons";
	  default:
		return "Undefined";
	}
  }

  public static string to_human_string(IntervalUnits arg)
  {
	switch (arg)
	{
	  case(IntervalUnits.NoRepeat):
		return "NoRepeat";
	  case(IntervalUnits.Milliseconds):
		return "Milliseconds";
	  case(IntervalUnits.Seconds):
		return "Seconds";
	  case(IntervalUnits.Minutes):
		return "Minutes";
	  case(IntervalUnits.Hours):
		return "Hours";
	  case(IntervalUnits.Days):
		return "Days";
	  case(IntervalUnits.Weeks):
		return "Weeks";
	  case(IntervalUnits.Months7):
		return "Months7";
	  case(IntervalUnits.Months8):
		return "Months8";
	  case(IntervalUnits.Months9):
		return "Months9";
	  case(IntervalUnits.Seasons):
		return "Seasons";
	  default:
		return "Undefined";
	}
  }

  public static IntervalUnits from_string(in string arg)
  {
	if (arg == "NoRepeat")
	{
		return IntervalUnits.NoRepeat;
	}
	if (arg == "Milliseconds")
	{
		return IntervalUnits.Milliseconds;
	}
	if (arg == "Seconds")
	{
		return IntervalUnits.Seconds;
	}
	if (arg == "Minutes")
	{
		return IntervalUnits.Minutes;
	}
	if (arg == "Hours")
	{
		return IntervalUnits.Hours;
	}
	if (arg == "Days")
	{
		return IntervalUnits.Days;
	}
	if (arg == "Weeks")
	{
		return IntervalUnits.Weeks;
	}
	if (arg == "Months7")
	{
		return IntervalUnits.Months7;
	}
	if (arg == "Months8")
	{
		return IntervalUnits.Months8;
	}
	if (arg == "Months9")
	{
		return IntervalUnits.Months9;
	}
	if (arg == "Seasons")
	{
		return IntervalUnits.Seasons;
	}
	else
	{
		return IntervalUnits.Undefined;
	}
  }
}

}




