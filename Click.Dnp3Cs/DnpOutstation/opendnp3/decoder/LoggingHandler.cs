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
// stand-alone DNP3 decoder
public sealed class LoggingHandler : IAPDUHandler
{
	public LoggingHandler(in Logger logger_, IDecoderCallbacks callbacks_)
	{
		this.logger = new opendnp3.Logger(logger_);
		this.callbacks = callbacks_;
	}

	private override void OnHeaderResult(in HeaderRecord record, in IINField result)
	{
		if (result.Any())
		{
			Indent i = new Indent(callbacks);
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.APP_OBJECT_RX, "__FILE__ ( __LINE__ )", "Pretty printing not supported for this type");
			};
		}
	}

	private static string ToUTCString(in DNPTime dnptime)
	{
		var seconds = (time_t)(dnptime.value / 1000);
		var milliseconds = (ushort)(dnptime.value % 1000);

#if WIN32
		tm t = new tm();
		if (gmtime_s(t, seconds) != 0)
		{
			return "BAD TIME";
		}
#else
		tm t = new tm();
		if (!gmtime_r(seconds, t))
		{
			return "BAD TIME";
		}
#endif

		std::ostringstream oss = new std::ostringstream();
		oss << (1900 + t.tm_year);
		oss << "-" << std::setfill('0') << std::setw(2) << (1 + t.tm_mon);
		oss << "-" << std::setfill('0') << std::setw(2) << t.tm_mday;
		oss << " " << std::setfill('0') << std::setw(2) << t.tm_hour;
		oss << ":" << std::setfill('0') << std::setw(2) << t.tm_min;
		oss << ":" << std::setfill('0') << std::setw(2) << t.tm_sec;
		oss << "." << std::setfill('0') << std::setw(3) << milliseconds;
		return oss.str();
	}

	private Logger logger = new Logger();
	private IDecoderCallbacks callbacks;

	private static string GetStringValue(bool value)
	{
		return value ? "1" : "0";
	}

	private static string ToHex(byte b)
	{
		std::ostringstream oss = new std::ostringstream();
		oss << ser4cpp.HexConversions.to_hex_char((b & 0xf0) >> 4) << ser4cpp.HexConversions.to_hex_char(b & 0xf);
		return oss.str();
	}

	/// --- templated helpers ---

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private IINField PrintV<T>(in ICollection<Indexed<T>> items)
	{
		Indent i = new Indent(callbacks);
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto logItem = [this](const Indexed<T>& item)
		var logItem = (in Indexed<T> item) =>
		{
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "[%u] - value: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.APP_OBJECT_RX, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
		};

		items.ForeachItem(logItem);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private IINField PrintTime<T>(in ICollection<T> items)
	{
		Indent i = new Indent(callbacks);
		uint count = 0;
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto logItem = [this, &count](const T& item)
		var logItem = (in T item) =>
		{
			var time = ToUTCString(item.time);
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "[%u] - time: %s",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.APP_OBJECT_RX, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			++count;
		};

		items.ForeachItem(logItem);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private IINField PrintTime16<T>(in ICollection<T> items)
	{
		Indent i = new Indent(callbacks);
		uint count = 0;
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto logItem = [this, &count](const T& item)
		var logItem = (in T item) =>
		{
			std::ostringstream oss = new std::ostringstream();
			oss << "[" << count << "] - time: " << item.time;
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.APP_OBJECT_RX, "__FILE__ ( __LINE__ )", oss.str().c_str());
			};
			++count;
		};

		items.ForeachItem(logItem);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private IINField PrintAO<T>(in ICollection<Indexed<T>> items)
	{
		Indent i = new Indent(callbacks);
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto logItem = [this](const Indexed<T>& item)
		var logItem = (in Indexed<T> item) =>
		{
			std::ostringstream oss = new std::ostringstream();
			oss << "[" << item.index << "] - value: " << item.value.value;
			oss << " status: " << CommandStatusSpec.to_human_string(item.value.status);
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.APP_OBJECT_RX, "__FILE__ ( __LINE__ )", oss.str().c_str());
			};
		};

		items.ForeachItem(logItem);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

	private IINField PrintCrob(in ICollection<Indexed<ControlRelayOutputBlock>> items)
	{
		Indent i = new Indent(callbacks);
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto logItem = [this](const Indexed<ControlRelayOutputBlock>& item)
		var logItem = (in Indexed<ControlRelayOutputBlock> item) =>
		{
			std::ostringstream oss = new std::ostringstream();
			oss << "[" << item.index << "] - code: 0x" << ToHex(new byte(item.value.rawCode)) << " (" << "op type: " << OperationTypeSpec.to_human_string(item.value.opType) << ", tcc: " << TripCloseCodeSpec.to_human_string(item.value.tcc) << ", cr: " << item.value.clear << ")";
			oss << " count: " << (/*size_t*/int)item.value.count;
			oss << " on-time: " << (/*size_t*/int)item.value.onTimeMS;
			oss << " off-time: " << (/*size_t*/int)item.value.offTimeMS;
			oss << " status: " << CommandStatusSpec.to_human_string(item.value.status);
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.APP_OBJECT_RX, "__FILE__ ( __LINE__ )", oss.str().c_str());
			};
		};

		items.ForeachItem(logItem);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

	private IINField PrintOctets(in ICollection<Indexed<OctetString>> items)
	{
		Indent i = new Indent(callbacks);
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto logItem = [this](const Indexed<OctetString>& item)
		var logItem = (in Indexed<OctetString> item) =>
		{
			var buffer = item.value.ToBuffer();
			var slice = ser4cpp.rseq_t(buffer.data, buffer.length);
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "[%u] value: (length = %zu)",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.APP_OBJECT_RX, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
				opendnp3.HexLogging.log(logger, new opendnp3.LogLevel(opendnp3.flags.Globals.APP_OBJECT_RX), slice, ' ', 18, 18);
			};
		};

		items.ForeachItem(logItem);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

	private IINField PrintTimeAndInterval(in ICollection<Indexed<TimeAndInterval>> values)
	{
		Indent i = new Indent(callbacks);
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto logItem = [this](const Indexed<TimeAndInterval>& item)
		var logItem = (in Indexed<TimeAndInterval> item) =>
		{
			std::ostringstream oss = new std::ostringstream();
			oss << "[" << item.index << "] - startTime: " << ToUTCString(item.value.time);
			oss << " count: " << item.value.interval;
			oss << " units: " << IntervalUnitsSpec.to_human_string(item.value.GetUnitsEnum()) << " (" << (int)item.value.units << ")";
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.APP_OBJECT_RX, "__FILE__ ( __LINE__ )", oss.str().c_str());
			};
		};

		values.ForeachItem(logItem);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
	private IINField PrintVQT<T>(GroupVariation gv, in ICollection<Indexed<T>> items)
	{
		Indent i = new Indent(callbacks);
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto logItem = [this, gv](const Indexed<T>& item)
		var logItem = (in Indexed<T> item) =>
		{
			std::ostringstream oss = new std::ostringstream();
			oss << "[" << item.index << "] - value: " << item.value.value;
			if (HasFlags(gv))
			{
				oss << " flags: 0x" << std::hex << ToHex(item.value.flags.value) << std::dec;
			}
			if (HasAbsoluteTime(gv) || HasRelativeTime(gv))
			{
				oss << " time: " << ToUTCString(item.value.time);
			}
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.APP_OBJECT_RX, "__FILE__ ( __LINE__ )", oss.str().c_str());
			};
		};

		items.ForeachItem(logItem);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
//C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
//	IINField PrintSecStat<T>(in ICollection<Indexed<T>> values);

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T, class Stringify>
	private IINField PrintVQTStringify<T, Stringify>(GroupVariation gv, in ICollection<Indexed<T>> items, in Stringify stringify)
	{
		Indent i = new Indent(callbacks);
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto logItem = [this, gv, stringify](const Indexed<T>& item)
		var logItem = (in Indexed<T> item) =>
		{
			std::ostringstream oss = new std::ostringstream();
			oss << "[" << item.index << "] - value: " << stringify(item.value.value);
			if (HasFlags(gv))
			{
				oss << " flags: 0x" << std::hex << ToHex(item.value.flags.value) << std::dec;
			}
			if (HasAbsoluteTime(gv) || HasRelativeTime(gv))
			{
				oss << " time: " << item.value.time.value;
			}
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.APP_OBJECT_RX, "__FILE__ ( __LINE__ )", oss.str().c_str());
			};
		};

		items.ForeachItem(logItem);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

	/// --- Implement IAPDUHandler ---

	private override bool IsAllowed(uint UnnamedParameter, GroupVariation UnnamedParameter2, QualifierCode UnnamedParameter3)
	{
		return true;
	}

	private override IINField ProcessHeader(in AllObjectsHeader record)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}
	private override IINField ProcessHeader(in RangeHeader header)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}
	private override IINField ProcessHeader(in CountHeader header)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

	private override IINField ProcessHeader(in CountHeader header, in ICollection<Group50Var1> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintTime(values);
		return new opendnp3.IINField(this.PrintTime(values));
	}

	private override IINField ProcessHeader(in CountHeader header, in ICollection<Group51Var1> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintTime(values);
		return new opendnp3.IINField(this.PrintTime(values));
	}

	private override IINField ProcessHeader(in CountHeader header, in ICollection<Group51Var2> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintTime(values);
		return new opendnp3.IINField(this.PrintTime(values));
	}

	private override IINField ProcessHeader(in CountHeader header, in ICollection<Group52Var1> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintTime16(values);
		return new opendnp3.IINField(this.PrintTime16(values));
	}

	private override IINField ProcessHeader(in CountHeader header, in ICollection<Group52Var2> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintTime16(values);
		return new opendnp3.IINField(this.PrintTime16(values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<IINValue>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintV(values);
		return new opendnp3.IINField(this.PrintV(values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<Binary>> values)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var stringify = (bool value) =>
		{
			return GetStringValue(value);
		};
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQTStringify(header.enumeration, values, stringify);
		return new opendnp3.IINField(this.PrintVQTStringify(header.enumeration, values, stringify));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<DoubleBitBinary>> values)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var stringify = (DoubleBit db) =>
		{
			return DoubleBitSpec.to_human_string(db);
		};
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQTStringify(header.enumeration, values, stringify);
		return new opendnp3.IINField(this.PrintVQTStringify(header.enumeration, values, stringify));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<BinaryOutputStatus>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQT(header.enumeration, values);
		return new opendnp3.IINField(this.PrintVQT(header.enumeration, values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<Counter>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQT(header.enumeration, values);
		return new opendnp3.IINField(this.PrintVQT(header.enumeration, values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<FrozenCounter>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQT(header.enumeration, values);
		return new opendnp3.IINField(this.PrintVQT(header.enumeration, values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<Analog>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQT(header.enumeration, values);
		return new opendnp3.IINField(this.PrintVQT(header.enumeration, values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<AnalogOutputStatus>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQT(header.enumeration, values);
		return new opendnp3.IINField(this.PrintVQT(header.enumeration, values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<OctetString>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintOctets(values);
		return new opendnp3.IINField(this.PrintOctets(values));
	}

	private override IINField ProcessHeader(in RangeHeader header, in ICollection<Indexed<TimeAndInterval>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintTimeAndInterval(values);
		return new opendnp3.IINField(this.PrintTimeAndInterval(values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<Binary>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQT(header.enumeration, values);
		return new opendnp3.IINField(this.PrintVQT(header.enumeration, values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<BinaryOutputStatus>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQT(header.enumeration, values);
		return new opendnp3.IINField(this.PrintVQT(header.enumeration, values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<DoubleBitBinary>> values)
	{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
		var stringify = (DoubleBit db) =>
		{
			return DoubleBitSpec.to_human_string(db);
		};
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQTStringify(header.enumeration, values, stringify);
		return new opendnp3.IINField(this.PrintVQTStringify(header.enumeration, values, stringify));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<Counter>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQT(header.enumeration, values);
		return new opendnp3.IINField(this.PrintVQT(header.enumeration, values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<FrozenCounter>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQT(header.enumeration, values);
		return new opendnp3.IINField(this.PrintVQT(header.enumeration, values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<Analog>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQT(header.enumeration, values);
		return new opendnp3.IINField(this.PrintVQT(header.enumeration, values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputStatus>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintVQT(header.enumeration, values);
		return new opendnp3.IINField(this.PrintVQT(header.enumeration, values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<OctetString>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintOctets(values);
		return new opendnp3.IINField(this.PrintOctets(values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<TimeAndInterval>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return this->PrintTimeAndInterval(values);
		return new opendnp3.IINField(this.PrintTimeAndInterval(values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<BinaryCommandEvent>> values)
	{
		Indent i = new Indent(callbacks);
		bool HAS_TIME = HasAbsoluteTime(header.enumeration);
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto logItem = [this, HAS_TIME](const Indexed<BinaryCommandEvent>& item)
		var logItem = (in Indexed<BinaryCommandEvent> item) =>
		{
			std::ostringstream oss = new std::ostringstream();
			oss << "[" << item.index << "] - value: " << GetStringValue(item.value.value) << "  status: " << CommandStatusSpec.to_human_string(item.value.status);
			if (HAS_TIME)
			{
				oss << " time: " << ToUTCString(item.value.time);
			}
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.APP_OBJECT_RX, "__FILE__ ( __LINE__ )", oss.str().c_str());
			};
		};

		values.ForeachItem(logItem);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogCommandEvent>> values)
	{
		Indent i = new Indent(callbacks);
		bool HAS_TIME = HasAbsoluteTime(header.enumeration);
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto logItem = [this, HAS_TIME](const Indexed<AnalogCommandEvent>& item)
		var logItem = (in Indexed<AnalogCommandEvent> item) =>
		{
			std::ostringstream oss = new std::ostringstream();
			oss << "[" << item.index << "] - value: " << item.value.value << "  status: " << CommandStatusSpec.to_human_string(item.value.status);
			if (HAS_TIME)
			{
				oss << " time: " << ToUTCString(item.value.time);
			}
			if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_RX))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				logger.log(opendnp3.flags.Globals.APP_OBJECT_RX, "__FILE__ ( __LINE__ )", oss.str().c_str());
			};
		};

		values.ForeachItem(logItem);

//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return IINField::Empty();
		return new opendnp3.IINField(IINField.Empty());
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<ControlRelayOutputBlock>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return PrintCrob(values);
		return new opendnp3.IINField(PrintCrob(values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputInt16>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return PrintAO(values);
		return new opendnp3.IINField(PrintAO(values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputInt32>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return PrintAO(values);
		return new opendnp3.IINField(PrintAO(values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputFloat32>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return PrintAO(values);
		return new opendnp3.IINField(PrintAO(values));
	}

	private override IINField ProcessHeader(in PrefixHeader header, in ICollection<Indexed<AnalogOutputDouble64>> values)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return PrintAO(values);
		return new opendnp3.IINField(PrintAO(values));
	}
}
} // namespace opendnp3




//#define WIN32 //REZA


