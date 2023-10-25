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

/**
 * Simple structure used in the ISOEHandler callbacks to return information
 * about the associated header.
 */
public class HeaderInfo
{
	public HeaderInfo()
	{
		this.gv = new opendnp3.GroupVariation.UNKNOWN;
		this.qualifier = new opendnp3.QualifierCode.UNDEFINED;
		this.tsquality = new opendnp3.TimestampQuality.INVALID;
		this.isEventVariation = false;
		this.flagsValid = false;
		this.headerIndex = 0;
	}

	public HeaderInfo(GroupVariation gv_, QualifierCode qualifier_, TimestampQuality tsquality_, uint headerIndex_)
	{
		this.gv = new opendnp3.GroupVariation(gv_);
		this.qualifier = new opendnp3.QualifierCode(qualifier_);
		this.tsquality = new opendnp3.TimestampQuality(tsquality_);
		this.isEventVariation = IsEvent(gv_);
		this.flagsValid = HasFlags(gv_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.headerIndex = headerIndex_;
		this.headerIndex.CopyFrom(headerIndex_);
	}

	/// The group/variation enumeration for the header
	public GroupVariation gv;
	/// The qualifier code enumeration for the header
	public QualifierCode qualifier;
	/// Enumeration that provides information about the validity of timestamps on the associated objects
	public TimestampQuality tsquality;
	/// True if the specfied variation is an event variation
	public bool isEventVariation;
	/// True if the flags on the value were present on underlying type, false if online is just assumed
	public bool flagsValid;
	/// The 0-based index of the header within the ASDU
	public uint headerIndex = new uint();
}

} // namespace opendnp3

