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

// Time Delay - Coarse
public class Group52Var1
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(52, 1);
  }


  // ------- Group52Var1 -------

  public Group52Var1()
  {
	  this.time = 0;
  }

  public static size_t Size()
  {
	  return 2;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group52Var1 UnnamedParameter2);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group52Var1 UnnamedParameter, WSeq<size_t> UnnamedParameter2);

  public UInt16 time = new UInt16();
}

// Time Delay - Fine
public class Group52Var2
{
  public static GroupVariationID ID()
  {
	  return new GroupVariationID(52, 2);
  }


  // ------- Group52Var2 -------

  public Group52Var2()
  {
	  this.time = 0;
  }

  public static size_t Size()
  {
	  return 2;
  }
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Read(RSeq<size_t> UnnamedParameter, Group52Var2 UnnamedParameter2);
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//  static bool Write(in Group52Var2 UnnamedParameter, WSeq<size_t> UnnamedParameter2);

  public UInt16 time = new UInt16();
}


}

namespace opendnp3
{






}
