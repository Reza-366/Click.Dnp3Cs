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

// Class for dealing with all aspects of FT3 Frame headers
public class LinkHeader
{
	public LinkHeader()
	{
		this.length = 5;
		this.src = 0;
		this.dest = 0;
		this.ctrl = 0;
	}

	public LinkHeader(byte aLen, ushort aSrc, ushort aDest, bool aFromMaster, bool aFcvDfc, bool aFcb, LinkFunction aCode)
	{
		this.Set(new byte(aLen), new ushort(aSrc), new ushort(aDest), aFromMaster, aFcvDfc, aFcb, aCode);
	}

	// Setter

	public void Set(byte aLen, ushort aSrc, ushort aDest, bool aFromMaster, bool aFcvDfc, bool aFcb, LinkFunction aCode)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: length = aLen;
		length.CopyFrom(aLen);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: src = aSrc;
		src.CopyFrom(aSrc);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: dest = aDest;
		dest.CopyFrom(aDest);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: ctrl = ControlByte(aFromMaster, aFcb, aFcvDfc, aCode);
		ctrl.CopyFrom(ControlByte(aFromMaster, aFcb, aFcvDfc, aCode));
	}

	public void ChangeFCB(bool aFCB)
	{
		if (aFCB)
		{
			ctrl |= ControlMask.MASK_FCB;
		}
		else
		{
			ctrl &= ~ControlMask.MASK_FCB;
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: byte GetControl() const
	public byte GetControl()
	{
		return new byte(ctrl);
	}

	// Getters
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: byte GetLength() const
	public byte GetLength()
	{
		return new byte(length);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ushort GetDest() const
	public ushort GetDest()
	{
		return new ushort(dest);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ushort GetSrc() const
	public ushort GetSrc()
	{
		return new ushort(src);
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsFromMaster() const
	public bool IsFromMaster()
	{
		return (ctrl & ControlMask.MASK_DIR) != 0;
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsPriToSec() const
	public bool IsPriToSec()
	{
		return (ctrl & ControlMask.MASK_PRM) != 0;
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsFcbSet() const
	public bool IsFcbSet()
	{
		return (ctrl & ControlMask.MASK_FCB) != 0;
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsFcvDfcSet() const
	public bool IsFcvDfcSet()
	{
		return (ctrl & ControlMask.MASK_FCV) != 0;
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: byte GetFuncByte() const
	public byte GetFuncByte()
	{
		return ctrl & ControlMask.MASK_FUNC;
	}
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: LinkFunction GetFuncEnum() const
	public LinkFunction GetFuncEnum()
	{
		return LinkFunctionSpec.from_type(ctrl & ControlMask.MASK_FUNC_OR_PRM);
	}

	public bool ValidLength()
	{
		return length > 4;
	}

	/** Reads the header, setting all the fields. Does NOT validate 0x0564 or CRC
	@param apBuff Buffer of at least 10 bytes */
	public void Read(byte[] apBuff)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: length = apBuff[LI_LENGTH];
		length.CopyFrom(apBuff[(int)LinkHeaderIndex.LI_LENGTH]);
		ser4cpp.rseq_t buffer = new ser4cpp.rseq_t(apBuff + LinkHeaderIndex.LI_DESTINATION, 4);
		ser4cpp.Globals.Bit16<ushort, 0, 1>.read_from(buffer, dest);
		ser4cpp.Globals.Bit16<ushort, 0, 1>.read_from(buffer, src);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: ctrl = apBuff[LI_CONTROL];
		ctrl.CopyFrom(apBuff[(int)LinkHeaderIndex.LI_CONTROL]);
	}

	/** Writes header to buffer including, 0x0564 and CRC
	@param apBuff Buffer of at least 10 bytes */
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: void Write(byte* apBuff) const
	public void Write(byte[] apBuff)
	{
		apBuff[(int)LinkHeaderIndex.LI_START_05] = 0x05;
		apBuff[(int)LinkHeaderIndex.LI_START_64] = 0x64;

//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: apBuff[LI_LENGTH] = length;
		apBuff[(int)LinkHeaderIndex.LI_LENGTH].CopyFrom(length);
		ser4cpp.wseq_t buffer = new ser4cpp.wseq_t(apBuff + LinkHeaderIndex.LI_DESTINATION, 4);
		ser4cpp.Globals.Bit16<ushort, 0, 1>.write_to(buffer, dest);
		ser4cpp.Globals.Bit16<ushort, 0, 1>.write_to(buffer, src);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: apBuff[LI_CONTROL] = ctrl;
		apBuff[(int)LinkHeaderIndex.LI_CONTROL].CopyFrom(ctrl);

		CRC.AddCrc(apBuff, LinkHeaderIndex.LI_CRC);
	}

	public static byte ControlByte(bool aIsMaster, bool aFcb, bool aFcvDfc, LinkFunction aFunc)
	{
		byte ret = LinkFunctionSpec.to_type(aFunc);

		if (aIsMaster)
		{
			ret |= ControlMask.MASK_DIR;
		}
		if (aFcb)
		{
			ret |= ControlMask.MASK_FCB;
		}
		if (aFcvDfc)
		{
			ret |= ControlMask.MASK_FCV;
		}

		return new byte(ret);
	}

	// Fields read directly from the header
	private byte length = new byte(); // Length of field, range [5,255] valid
	private ushort src = new ushort(); // Where the frame originated
	private ushort dest = new ushort(); // Where the frame is going
	private byte ctrl = new byte(); // Control octet, individual fields accessed using accessors below
}

} // namespace opendnp3



