using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Copyright 2013-2022 Step Function I/O, LLC
 *
 * Licensed to Green Energy Corp (www.greenenergycorp.com) and Step Function I/O
 * LLC (https://stepfunc.io) under one or more contributor license agreements.
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Green Energy Corp and Step Function I/O LLC license
 * this file to you under the Apache License, Version 2.0 (the "License"); you
 * may not use this file except in compliance with the License. You may obtain
 * a copy of the License at:
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


namespace opendnp3
{

// Broadcast addresses
public enum LinkBroadcastAddress : ushort
{
	DontConfirm = 0xFFFD,
	ShallConfirm = 0xFFFE,
	OptionalConfirm = 0xFFFF
}

/// Indices for use with buffers containing link headers
public enum LinkHeaderIndex : byte
{
	LI_START_05 = 0,
	LI_START_64 = 1,
	LI_LENGTH = 2,
	LI_CONTROL = 3,
	LI_DESTINATION = 4,
	LI_SOURCE = 6,
	LI_CRC = 8
}

/// Masks for use with the CONTROL byte
public enum ControlMask : byte
{
	MASK_DIR = 0x80,
	MASK_PRM = 0x40,
	MASK_FCB = 0x20,
	MASK_FCV = 0x10,
	MASK_FUNC = 0x0F,
	MASK_FUNC_OR_PRM = MASK_PRM | MASK_FUNC
}

} // namespace opendnp3

