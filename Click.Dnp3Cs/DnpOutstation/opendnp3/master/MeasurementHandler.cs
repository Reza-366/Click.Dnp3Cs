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

//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define STRINGIFY(x) #x
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define TOSTRING(x) STRINGIFY(x)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LOCATION __FILE__ "(" TOSTRING(__LINE__) ")"
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SAFE_STRING_FORMAT(dest, length_, format, ...) _snprintf_s(dest, length_, _TRUNCATE, format, ##__VA_ARGS__)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SAFE_STRING_FORMAT(dest, size, format, ...) snprintf(dest, size, format, ##__VA_ARGS__)
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define LOG_FORMAT(logger, levels, format, ...) { char message_buffer_some_name_no_conflict[opendnp3::max_log_entry_size]; SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3::max_log_entry_size, format, ##__VA_ARGS__); logger.log(levels, LOCATION, message_buffer_some_name_no_conflict); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SIMPLE_LOG_BLOCK(logger, levels, message) if (logger.is_enabled(levels)) { logger.log(levels, LOCATION, message); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define SIMPLE_LOGGER_BLOCK(pLogger, levels, message) if (pLogger && pLogger->is_enabled(levels)) { pLogger->log(levels, LOCATION, message); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define FORMAT_LOG_BLOCK(logger, levels, format, ...) if (logger.is_enabled(levels)) { char message_buffer_some_name_no_conflict[opendnp3::max_log_entry_size]; SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3::max_log_entry_size, format, ##__VA_ARGS__); logger.log(levels, LOCATION, message_buffer_some_name_no_conflict); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define FORMAT_LOGGER_BLOCK(pLogger, levels, format, ...) if (pLogger && pLogger->is_enabled(levels)) { char message_buffer_some_name_no_conflict[opendnp3::max_log_entry_size]; SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3::max_log_entry_size, format, ##__VA_ARGS__); pLogger->log(levels, LOCATION, message_buffer_some_name_no_conflict); }
//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define FORMAT_HEX_BLOCK(logger, levels, buffer, firstSize, otherSize) if (logger.is_enabled(levels)) { opendnp3::HexLogging::log(logger, levels, buffer, ' ', firstSize, otherSize); }

namespace opendnp3
{

/**
 * Dedicated class for processing response data in the master.
 */
public sealed class MeasurementHandler : IAPDUHandler, System.IDisposable
{

	/**
	 * Static helper function for interpreting a response as a measurement response
	 */
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	static ParseResult ProcessMeasurements(ResponseInfo info, in ser4cpp::RSeq objects, Logger logger, ISOEHandler pHandler);

	// TODO
	public override bool IsAllowed(uint headerCount, GroupVariation gv, QualifierCode qc)
	{
		return true;
	}

	/**
	 * Creates a new ResponseLoader instance.
	 *
	 * @param logger	the Logger that the loader should use for message reporting
	 */
	public MeasurementHandler(ResponseInfo info, in Logger logger, ISOEHandler pSOEHandler)
	{
		this.info = new opendnp3.ResponseInfo(info);
		this.logger = new opendnp3.Logger(logger);
		this.txInitiated = false;
		this.pSOEHandler = pSOEHandler;
		this.commonTimeOccurence = new opendnp3.DNPTime(0, TimestampQuality.INVALID);
	}

	public void Dispose()
	{
		if (txInitiated && pSOEHandler != null)
		{
			this.pSOEHandler.EndFragment(this.info);
		}
	}

	private ResponseInfo info = new ResponseInfo();
	private Logger logger = new Logger();

	private static TimestampQuality ModeFromType(GroupVariation gv)
	{
		return HasAbsoluteTime(gv) ? TimestampQuality.SYNCHRONIZED : TimestampQuality.INVALID;
	}

	private override IINField ProcessHeader(in CountHeader header, in ICollection<Group50Var1> values)
	{
		this.CheckForTxStart();

//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var transform = (in Group50Var1 input) =>
		{
			return new opendnp3.DNPTime(input.time);
		};

		var collection = opendnp3.Globals.Map<Group50Var1, DNPTime>(values, transform);

		HeaderInfo info = new HeaderInfo(header.enumeration, header.GetQualifierCode(), TimestampQuality.INVALID, header.headerIndex);
		this.pSOEHandler.Process(info, collection);

		return new IINField();
	}

	// Handle the CTO objects
	private override IINField ProcessHeader(in CountHeader header, in ICollection<Group51Var1> values)
	{
		Group51Var1 cto = new Group51Var1();
		if (values.ReadOnlyValue(ref cto))
		{
			cto.time.quality = TimestampQuality.SYNCHRONIZED;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: commonTimeOccurence = cto.time;
			commonTimeOccurence.CopyFrom(cto.time);
		}
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

	private override IINField ProcessHeader(in CountHeader header, in ICollection<Group51Var2> values)
	{
		Group51Var2 cto = new Group51Var2();
		if (values.ReadOnlyValue(ref cto))
		{
			cto.time.quality = TimestampQuality.UNSYNCHRONIZED;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: commonTimeOccurence = cto.time;
			commonTimeOccurence.CopyFrom(cto.time);
		}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<Binary>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<DoubleBitBinary>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<BinaryOutputStatus>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<Counter>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<FrozenCounter>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<Analog>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<AnalogOutputStatus>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<OctetString>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<TimeAndInterval>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<Binary>> values)
	{
		if (header.enumeration == GroupVariation.Group2Var3)
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessWithCTO(header, values);
			return new opendnp3.IINField(this.ProcessWithCTO(header, values));
		}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<BinaryOutputStatus>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<DoubleBitBinary>> values)
	{
		if (header.enumeration == GroupVariation.Group4Var3)
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->ProcessWithCTO(header, values);
			return new opendnp3.IINField(this.ProcessWithCTO(header, values));
		}

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<Counter>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<FrozenCounter>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<Analog>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputStatus>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<OctetString>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<BinaryCommandEvent>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogCommandEvent>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(header, ModeFromType(header.enumeration), values);
		return new opendnp3.IINField(this.LoadValues(header, ModeFromType(header.enumeration), values));
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Target, class Source>
	private IINField LoadValuesWithTransformTo<Target, Source>(in HeaderRecord record, in ICollection<Indexed<Source>> values)
	{
		var transform = (in Indexed<Source> input) =>
		{
			return new opendnp3.Indexed<Target>(Convert<Source, Target>(input));
		});

		var collection = opendnp3.Globals.Map<Indexed<Source>, new Indexed<Target>>(values, transform);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(record, ModeFromType(record.enumeration), collection);
		return new opendnp3.IINField(this.LoadValues(record, ModeFromType(record.enumeration), collection));
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private IINField LoadValues<T>(in HeaderRecord record, TimestampQuality tsquality, in ICollection<Indexed<T>> values)
	{
		this.CheckForTxStart();
		HeaderInfo info = new HeaderInfo(record.enumeration, record.GetQualifierCode(), tsquality, record.headerIndex);
		this.pSOEHandler.Process(info, values);
		return new IINField();
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private IINField ProcessWithCTO<T>(in HeaderRecord record, in ICollection<Indexed<T>> values)
	{
		if (this.commonTimeOccurence.quality == TimestampQuality.INVALID)
		{
			if (logger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "No prior CTO objects for %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			return new IINField(IINBit.PARAM_ERROR);
		}

		var cto = this.commonTimeOccurence;

		var transform = (in Indexed<T> input) =>
		{
			Indexed<T> copy = new Indexed<T>(input);
			copy.value.time = new DNPTime(input.value.time.value + cto.value, cto.quality);
			return new opendnp3.Indexed<T>(copy);
		});

		var adjusted = opendnp3.Globals.Map<Indexed<T>, new Indexed<T>>(values, transform);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->LoadValues(record, cto.quality, adjusted);
		return new opendnp3.IINField(this.LoadValues(record, cto.quality, adjusted));
	}

	private bool txInitiated;
	private ISOEHandler pSOEHandler;

	private DNPTime commonTimeOccurence = new DNPTime();

	private void CheckForTxStart()
	{
		if (!txInitiated && pSOEHandler != null)
		{
			txInitiated = true;
			this.pSOEHandler.BeginFragment(this.info);
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T, class U>
	private static Indexed<U> Convert<T, U>(in Indexed<T> input)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return WithIndex(Convert(input.value), input.index);
		return new opendnp3.Indexed<opendnp3.Indexed<U>>(opendnp3.Globals.WithIndex(Convert(input.value), new ushort(input.index)));
	}
}

} // namespace opendnp3




namespace opendnp3
{


} // namespace opendnp3
