using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ser4cpp;

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

// Time and Date - Absolute Time
public partial class Group50Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(50, 1);
  }


  // ------- Group50Var1 -------

  public Group50Var1()
  {
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 6;
  }
  public static bool Read(rseq_t buffer, Group50Var1 output)
  {
	return LittleEndian.read(buffer, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group50Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public DNPTime time = new DNPTime();
}

// Time and Date - Absolute Time at last recorded time
public partial class Group50Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(50, 3);
  }


  // ------- Group50Var3 -------

  public Group50Var3()
  {
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 6;
  }
  public static bool Read(rseq_t buffer, Group50Var3 output)
  {
	return LittleEndian.read(buffer, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group50Var3 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public DNPTime time = new DNPTime();
}

// Time and Date - Indexed absolute time and long interval
public partial class Group50Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(50, 4);
  }


  // ------- Group50Var4 -------

  public Group50Var4()
  {
	  this.time = new opendnp3.DNPTime(0);
	  this.interval = 0;
	  this.units = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 11;
  }
  public static bool Read(rseq_t buffer, Group50Var4 output)
  {
	return LittleEndian.read(buffer, output.time, output.interval, output.units);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group50Var4 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public DNPTime time = new DNPTime();
  public uint interval = new uint();
  public byte units = new byte();

  public static bool ReadTarget(rseq_t buff, ref TimeAndInterval output)
  {
	Group50Var4 value = new Group50Var4();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = TimeAndIntervalFactory::From(value.time, value.interval, value.units);
	  output = TimeAndIntervalFactory.From(new opendnp3.DNPTime(value.time), new uint(value.interval), new byte(value.units));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in TimeAndInterval UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<TimeAndInterval> Inst()
  {
	  return DNP3Serializer<TimeAndInterval>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticTimeAndIntervalVariation svariation = StaticTimeAndIntervalVariation.Group50Var4;
}


}




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

// Time and Date - Absolute Time
public partial class Group50Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(50, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group50Var1();

  public static /*size_t*/int Size()
  {
	  return 6;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group50Var1 UnnamedParameter2);
  public static bool Write(in Group50Var1 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.time);
  }

  public DNPTime time = new DNPTime();
}

// Time and Date - Absolute Time at last recorded time
public partial class Group50Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(50, 3);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group50Var3();

  public static /*size_t*/int Size()
  {
	  return 6;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group50Var3 UnnamedParameter2);
  public static bool Write(in Group50Var3 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.time);
  }

  public DNPTime time = new DNPTime();
}

// Time and Date - Indexed absolute time and long interval
public partial class Group50Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(50, 4);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group50Var4();

  public static /*size_t*/int Size()
  {
	  return 11;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group50Var4 UnnamedParameter2);
  public static bool Write(in Group50Var4 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.time, arg.interval, arg.units);
  }

  public DNPTime time = new DNPTime();
  public uint interval = new uint();
  public byte units = new byte();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, TimeAndInterval UnnamedParameter2);
  public static bool WriteTarget(in TimeAndInterval value, WSeq</*size_t*/int> buff)
  {
	return Group50Var4.Write(ConvertGroup50Var4.Apply(value), buff);
  }

  public static DNP3Serializer<TimeAndInterval> Inst()
  {
	  return DNP3Serializer<TimeAndInterval>(ID(), Size(), ReadTarget, WriteTarget);
  }
  public const StaticTimeAndIntervalVariation svariation = StaticTimeAndIntervalVariation.Group50Var4;
}


}

