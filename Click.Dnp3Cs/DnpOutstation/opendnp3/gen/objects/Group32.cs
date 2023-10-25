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

// Analog Input Event - Any Variation
public partial class Group32Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 0);
  }
}

// Analog Input Event - 32-bit With Flag
public partial class Group32Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 1);
  }


  // ------- Group32Var1 -------

  public Group32Var1()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group32Var1 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group32Var1 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public int value = new int();

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group32Var1 value = new Group32Var1();
	if (Read(buff, value))
	{
	  output = AnalogFactory.From(new byte(value.flags), new int(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - 16-bit With Flag
public partial class Group32Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 2);
  }


  // ------- Group32Var2 -------

  public Group32Var2()
  {
	  this.flags = 0;
	  this.value = 0;
  }

  public static /*size_t*/int Size()
  {
	  return 3;
  }
  public static bool Read(rseq_t buffer, Group32Var2 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group32Var2 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public Int16 value = new Int16();

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group32Var2 value = new Group32Var2();
	if (Read(buff, value))
	{
	  output = AnalogFactory.From(new byte(value.flags), new Int16(value.value));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - 32-bit With Flag and Time
public partial class Group32Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 3);
  }


  // ------- Group32Var3 -------

  public Group32Var3()
  {
	  this.flags = 0;
	  this.value = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 11;
  }
  public static bool Read(rseq_t buffer, Group32Var3 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group32Var3 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public int value = new int();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group32Var3 value = new Group32Var3();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = AnalogFactory::From(value.flags, value.value, value.time);
	  output = AnalogFactory.From(new byte(value.flags), new int(value.value), new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - 16-bit With Flag and Time
public partial class Group32Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 4);
  }


  // ------- Group32Var4 -------

  public Group32Var4()
  {
	  this.flags = 0;
	  this.value = 0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 9;
  }
  public static bool Read(rseq_t buffer, Group32Var4 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group32Var4 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public Int16 value = new Int16();
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group32Var4 value = new Group32Var4();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = AnalogFactory::From(value.flags, value.value, value.time);
	  output = AnalogFactory.From(new byte(value.flags), new Int16(value.value), new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - Single-precision With Flag
public partial class Group32Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 5);
  }


  // ------- Group32Var5 -------

  public Group32Var5()
  {
	  this.flags = 0;
	  this.value = 0.0F;
  }

  public static /*size_t*/int Size()
  {
	  return 5;
  }
  public static bool Read(rseq_t buffer, Group32Var5 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group32Var5 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public float value;

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group32Var5 value = new Group32Var5();
	if (Read(buff, value))
	{
	  output = AnalogFactory.From(new byte(value.flags), value.value);
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - Double-precision With Flag
public partial class Group32Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 6);
  }


  // ------- Group32Var6 -------

  public Group32Var6()
  {
	  this.flags = 0;
	  this.value = 0.0;
  }

  public static /*size_t*/int Size()
  {
	  return 9;
  }
  public static bool Read(rseq_t buffer, Group32Var6 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group32Var6 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public double value;

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group32Var6 value = new Group32Var6();
	if (Read(buff, value))
	{
	  output = AnalogFactory.From(new byte(value.flags), value.value);
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - Single-precision With Flag and Time
public partial class Group32Var7
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 7);
  }


  // ------- Group32Var7 -------

  public Group32Var7()
  {
	  this.flags = 0;
	  this.value = 0.0F;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 11;
  }
  public static bool Read(rseq_t buffer, Group32Var7 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group32Var7 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public float value;
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group32Var7 value = new Group32Var7();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = AnalogFactory::From(value.flags, value.value, value.time);
	  output = AnalogFactory.From(new byte(value.flags), value.value, new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - Double-precision With Flag and Time
public partial class Group32Var8
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 8);
  }


  // ------- Group32Var8 -------

  public Group32Var8()
  {
	  this.flags = 0;
	  this.value = 0.0;
	  this.time = new opendnp3.DNPTime(0);
  }

  public static /*size_t*/int Size()
  {
	  return 15;
  }
  public static bool Read(rseq_t buffer, Group32Var8 output)
  {
	return LittleEndian.read(buffer, output.flags, output.value, output.time);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group32Var8 UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);

  public byte flags = new byte();
  public double value;
  public DNPTime time = new DNPTime();

  public static bool ReadTarget(rseq_t buff, ref Analog output)
  {
	Group32Var8 value = new Group32Var8();
	if (Read(buff, value))
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: output = AnalogFactory::From(value.flags, value.value, value.time);
	  output = AnalogFactory.From(new byte(value.flags), value.value, new opendnp3.DNPTime(value.time));
	  return true;
	}
	else
	{
	  return false;
	}
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool WriteTarget(in Analog UnnamedParameter, ser4cpp::wseq_t UnnamedParameter2);
  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
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

// Analog Input Event - Any Variation
public partial class Group32Var0
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 0);
  }
}

// Analog Input Event - 32-bit With Flag
public partial class Group32Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 1);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group32Var1();

  public static /*size_t*/int Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group32Var1 UnnamedParameter2);
  public static bool Write(in Group32Var1 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public byte flags = new byte();
  public int value = new int();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq</*size_t*/int> buff)
  {
	return Group32Var1.Write(ConvertQVRangeCheck<Group32Var1, Analog, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - 16-bit With Flag
public partial class Group32Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 2);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group32Var2();

  public static /*size_t*/int Size()
  {
	  return 3;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group32Var2 UnnamedParameter2);
  public static bool Write(in Group32Var2 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public byte flags = new byte();
  public Int16 value = new Int16();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq</*size_t*/int> buff)
  {
	return Group32Var2.Write(ConvertQVRangeCheck<Group32Var2, Analog, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - 32-bit With Flag and Time
public partial class Group32Var3
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 3);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group32Var3();

  public static /*size_t*/int Size()
  {
	  return 11;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group32Var3 UnnamedParameter2);
  public static bool Write(in Group32Var3 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public byte flags = new byte();
  public int value = new int();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq</*size_t*/int> buff)
  {
	return Group32Var3.Write(ConvertQVTRangeCheck<Group32Var3, Analog, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - 16-bit With Flag and Time
public partial class Group32Var4
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 4);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group32Var4();

  public static /*size_t*/int Size()
  {
	  return 9;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group32Var4 UnnamedParameter2);
  public static bool Write(in Group32Var4 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public byte flags = new byte();
  public Int16 value = new Int16();
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq</*size_t*/int> buff)
  {
	return Group32Var4.Write(ConvertQVTRangeCheck<Group32Var4, Analog, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - Single-precision With Flag
public partial class Group32Var5
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 5);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group32Var5();

  public static /*size_t*/int Size()
  {
	  return 5;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group32Var5 UnnamedParameter2);
  public static bool Write(in Group32Var5 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public byte flags = new byte();
  public float value;

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq</*size_t*/int> buff)
  {
	return Group32Var5.Write(ConvertQVRangeCheck<Group32Var5, Analog, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - Double-precision With Flag
public partial class Group32Var6
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 6);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group32Var6();

  public static /*size_t*/int Size()
  {
	  return 9;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group32Var6 UnnamedParameter2);
  public static bool Write(in Group32Var6 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value);
  }

  public byte flags = new byte();
  public double value;

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq</*size_t*/int> buff)
  {
	return Group32Var6.Write(ConvertQV<Group32Var6, Analog>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - Single-precision With Flag and Time
public partial class Group32Var7
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 7);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group32Var7();

  public static /*size_t*/int Size()
  {
	  return 11;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group32Var7 UnnamedParameter2);
  public static bool Write(in Group32Var7 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public byte flags = new byte();
  public float value;
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq</*size_t*/int> buff)
  {
	return Group32Var7.Write(ConvertQVTRangeCheck<Group32Var7, Analog, 0x20>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}

// Analog Input Event - Double-precision With Flag and Time
public partial class Group32Var8
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(32, 8);
  }

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  Group32Var8();

  public static /*size_t*/int Size()
  {
	  return 15;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq</*size_t*/int> UnnamedParameter, Group32Var8 UnnamedParameter2);
  public static bool Write(in Group32Var8 arg, WSeq</*size_t*/int> buffer)
  {
	return LittleEndian.write(buffer, arg.flags, arg.value, arg.time);
  }

  public byte flags = new byte();
  public double value;
  public DNPTime time = new DNPTime();

//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool ReadTarget(RSeq</*size_t*/int> UnnamedParameter, Analog UnnamedParameter2);
  public static bool WriteTarget(in Analog value, WSeq</*size_t*/int> buff)
  {
	return Group32Var8.Write(ConvertQVT<Group32Var8, Analog>.Apply(value), buff);
  }

  public static DNP3Serializer<Analog> Inst()
  {
	  return DNP3Serializer<Analog>(ID(), Size(), ReadTarget, WriteTarget);
  }
}


}

