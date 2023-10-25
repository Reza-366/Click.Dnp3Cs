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

/**
 * Describes an incoming control request from the master. It is the
 * applications responsibility to handle the request and return an
 * approiate status code. The PULSE_CLOSE and PULSE_TRIP OperationType
 * require setting the mOnTimeMS, mOffTimeMS and mCount variables, otherwise
 * just use the defaults.
 */
public class ControlRelayOutputBlock
{
	// primary constructor where the control code is split by its components
	public ControlRelayOutputBlock(OperationType opType_ = OperationType.LATCH_ON, TripCloseCode tcc_ = TripCloseCode.NUL, bool clear_ = false, System.Byte count_ = 1, System.UInt32 onTime_ = 100, System.UInt32 offTime_ = 100, CommandStatus status_ = CommandStatus.SUCCESS)
	{
		this.opType = new opendnp3.OperationType(opType_);
		this.tcc = new opendnp3.TripCloseCode(tcc_);
		this.clear = clear_;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.count = count_;
		this.count.CopyFrom(count_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.onTimeMS = onTime_;
		this.onTimeMS.CopyFrom(onTime_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.offTimeMS = offTime_;
		this.offTimeMS.CopyFrom(offTime_);
		this.status = new opendnp3.CommandStatus(status_);
		this.rawCode = ((TripCloseCodeSpec.to_type(tcc) << 6) & 0xC0) | (((System.Byte)clear << 5) & 0x20) | (OperationTypeSpec.to_type(opType) & 0x0F);
	}

	// overloaded constructor that allows the user to set a raw control code for non-standard codes
	public ControlRelayOutputBlock(System.Byte rawCode_, System.Byte count_ = 1, System.UInt32 onTime_ = 100, System.UInt32 offTime_ = 100, CommandStatus status_ = CommandStatus.SUCCESS)
	{
		this.opType = new opendnp3.OperationType(OperationTypeSpec.from_type(rawCode_ & 0x0F));
		this.tcc = new opendnp3.TripCloseCode(TripCloseCodeSpec.from_type((rawCode_ >> 6) & 0x3));
		this.clear = rawCode_ & 0x20 != null;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.count = count_;
		this.count.CopyFrom(count_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.onTimeMS = onTime_;
		this.onTimeMS.CopyFrom(onTime_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.offTimeMS = offTime_;
		this.offTimeMS.CopyFrom(offTime_);
		this.status = new opendnp3.CommandStatus(status_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.rawCode = rawCode_;
		this.rawCode.CopyFrom(rawCode_);
	}

	/// operation type
	public OperationType opType;
	// trip-close code
	public TripCloseCode tcc;
	// clear bit
	public bool clear;
	/// the number of times to repeat the operation
	public System.Byte count = new System.Byte();
	/// the 'on' time for the pulse train
	public System.UInt32 onTimeMS = new System.UInt32();
	/// the 'off' time for the pulse train
	public System.UInt32 offTimeMS = new System.UInt32();
	/// status of the resulting operation
	public CommandStatus status;
	/// The raw code in bytes
	public System.Byte rawCode = new System.Byte();

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool IsQUFlagSet() const
	public bool IsQUFlagSet()
	{
		return (rawCode & 0x10) != 0;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool ValuesEqual(const ControlRelayOutputBlock& lhs) const
	public bool ValuesEqual(in ControlRelayOutputBlock lhs)
	{
		return (opType == lhs.opType) && (tcc == lhs.tcc) && (clear == lhs.clear) && (count == lhs.count) && (onTimeMS == lhs.onTimeMS) && (offTimeMS == lhs.offTimeMS);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: bool operator ==(const ControlRelayOutputBlock& lhs) const
	public static bool operator == (ControlRelayOutputBlock ImpliedObject, in ControlRelayOutputBlock lhs)
	{
		return ImpliedObject.ValuesEqual(lhs) && (ImpliedObject.status == lhs.status);
	}
}

} // namespace opendnp3



