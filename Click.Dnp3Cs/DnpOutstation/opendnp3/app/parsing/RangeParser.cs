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

public class RangeParser
{
	private delegate void HandleFun(in HeaderRecord record, in Range range, in ser4cpp.RSeq buffer, IAPDUHandler handler);

	public static ParseResult ParseHeader(ser4cpp.RSeq buffer, in NumParser numparser, in ParserSettings settings, in HeaderRecord record, Logger pLogger, IAPDUHandler pHandler)
	{
		Range range = new Range();
		var res = numparser.ParseRange(buffer, range, pLogger);
		if (res != ParseResult.OK)
		{
			return res;
		}

		if (pLogger != null && pLogger.is_enabled(settings.LoggingLevel()))
		{
			string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
			SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "%03u,%03u %s, %s [%u, %u]",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
			pLogger.log(settings.LoggingLevel(), "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
		};

		if (settings.ExpectsContents())
		{
			return ParseRangeOfObjects(buffer, record, range, pLogger, pHandler);
		}

		if (pHandler != null)
		{
			pHandler.OnHeader(new RangeHeader(record, range));
		}
		return ParseResult.OK;
	}

	// Process the range against the buffer
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ParseResult Process(const HeaderRecord& record, ser4cpp::RSeq& buffer, IAPDUHandler* pHandler, Logger* pLogger) const
	private ParseResult Process(in HeaderRecord record, ser4cpp.RSeq buffer, IAPDUHandler pHandler, Logger pLogger)
	{
		if (buffer.length() < requiredSize)
		{
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Not enough data for specified objects");
			};
			return ParseResult.NOT_ENOUGH_DATA_FOR_OBJECTS;
		}

		if (pHandler != null)
		{
			handler(record, range, buffer, pHandler);
		}
		buffer.advance(requiredSize);
		return ParseResult.OK;
	}

	// Create a range parser from a fixed size descriptor
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Descriptor>
	private static RangeParser FromFixedSize<Descriptor>(in Range range)
	{
		var size = range.Count() * Descriptor.Size();
		return new RangeParser(range, size, InvokeRangeOf<Descriptor>);
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Type>
	private static RangeParser FromFixedSizeType<Type>(in Range range)
	{
		var size = range.Count() * Type.Size();
		return new RangeParser(range, size, InvokeRangeOfType<Type>);
	}

	// Create a range parser from a bitfield and a function to map the bitfield to values
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Type>
	private static RangeParser FromBitfieldType<Type>(in Range range)
	{
		var SIZE = NumBytesInBits(range.Count());
		return new RangeParser(range, SIZE, InvokeRangeBitfieldType<Type>);
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Type>
	private static RangeParser FromDoubleBitfieldType<Type>(in Range range)
	{
		var size = NumBytesInDoubleBits(range.Count());
		return new RangeParser(range, size, InvokeRangeDoubleBitfieldType<Type>);
	}

	private static ParseResult ParseRangeOfObjects(ser4cpp.RSeq buffer, in HeaderRecord record, in Range range, Logger pLogger, IAPDUHandler pHandler)
	{
		switch (record.enumeration)
		{
		case (GroupVariation.Group1Var1):
			return RangeParser.FromBitfieldType<Binary>(range).Process(record, buffer, pHandler, pLogger);

			case (GroupVariation.Group1Var2):
				return RangeParser.FromFixedSize<Group1Var2>(range).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group3Var1):
			return RangeParser.FromDoubleBitfieldType<DoubleBitBinary>(range).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group10Var1):
			return RangeParser.FromBitfieldType<BinaryOutputStatus>(range).Process(record, buffer, pHandler, pLogger);

			case (GroupVariation.Group3Var2):
				return RangeParser.FromFixedSize<Group3Var2>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group10Var2):
				return RangeParser.FromFixedSize<Group10Var2>(range).Process(record, buffer, pHandler, pLogger);

			case (GroupVariation.Group20Var1):
				return RangeParser.FromFixedSize<Group20Var1>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group20Var2):
				return RangeParser.FromFixedSize<Group20Var2>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group20Var5):
				return RangeParser.FromFixedSize<Group20Var5>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group20Var6):
				return RangeParser.FromFixedSize<Group20Var6>(range).Process(record, buffer, pHandler, pLogger);

			case (GroupVariation.Group21Var1):
				return RangeParser.FromFixedSize<Group21Var1>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group21Var2):
				return RangeParser.FromFixedSize<Group21Var2>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group21Var5):
				return RangeParser.FromFixedSize<Group21Var5>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group21Var6):
				return RangeParser.FromFixedSize<Group21Var6>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group21Var9):
				return RangeParser.FromFixedSize<Group21Var9>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group21Var10):
				return RangeParser.FromFixedSize<Group21Var10>(range).Process(record, buffer, pHandler, pLogger);

			case (GroupVariation.Group30Var1):
				return RangeParser.FromFixedSize<Group30Var1>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group30Var2):
				return RangeParser.FromFixedSize<Group30Var2>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group30Var3):
				return RangeParser.FromFixedSize<Group30Var3>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group30Var4):
				return RangeParser.FromFixedSize<Group30Var4>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group30Var5):
				return RangeParser.FromFixedSize<Group30Var5>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group30Var6):
				return RangeParser.FromFixedSize<Group30Var6>(range).Process(record, buffer, pHandler, pLogger);

			case (GroupVariation.Group40Var1):
				return RangeParser.FromFixedSize<Group40Var1>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group40Var2):
				return RangeParser.FromFixedSize<Group40Var2>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group40Var3):
				return RangeParser.FromFixedSize<Group40Var3>(range).Process(record, buffer, pHandler, pLogger);
			case (GroupVariation.Group40Var4):
				return RangeParser.FromFixedSize<Group40Var4>(range).Process(record, buffer, pHandler, pLogger);

			case (GroupVariation.Group50Var4):
				return RangeParser.FromFixedSize<Group50Var4>(range).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group80Var1):
			return RangeParser.FromBitfieldType<IINValue>(range).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group110Var0):
			return ParseRangeOfOctetData(buffer, record, range, pLogger, pHandler);

		default:
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Unsupported qualifier/object - %s - %i / %i",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
			};

			return ParseResult.INVALID_OBJECT_QUALIFIER;
		}
	}

	private static ParseResult ParseRangeOfOctetData(ser4cpp.RSeq buffer, in HeaderRecord record, in Range range, Logger pLogger, IAPDUHandler pHandler)
	{
		if (record.variation > 0)
		{
			var COUNT = range.Count();
			var size = record.variation * COUNT;
			if (buffer.length() < size)
			{
				if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
				{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
					pLogger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Not enough data for specified octet objects");
				};
				return ParseResult.NOT_ENOUGH_DATA_FOR_OBJECTS;
			}

			if (pHandler != null)
			{
				var read = (ser4cpp.RSeq buffer, uint pos) =>
				{
					var octetData = buffer.take(record.variation);
					OctetString octets = new OctetString(new Buffer(octetData, (uint)octetData.length()));
					buffer.advance(record.variation);
					return new opendnp3.Indexed<opendnp3.OctetString>(opendnp3.Globals.WithIndex(octets, range.start + pos));
				});

				var collection = opendnp3.Globals.CreateBufferedCollection<new Indexed<OctetString>>(buffer, new /*size_t*/int(COUNT), read);

				pHandler.OnHeader(new RangeHeader(record, range), collection);
			}

			buffer.advance(size);
			return ParseResult.OK;
		}
		else
		{
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, "__FILE__ ( __LINE__ )", "Octet string variation 0 may only be used in requests");
			};
			return ParseResult.INVALID_OBJECT;
		}
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Descriptor>
	private static void InvokeRangeOf<Descriptor>(in HeaderRecord record, in Range range, in ser4cpp.RSeq buffer, IAPDUHandler handler)
	{
		var COUNT = range.Count();

//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto read = [range](ser4cpp::RSeq& buffer, uint pos)
		var read = (ser4cpp.RSeq buffer, uint pos) =>
		{
			Descriptor.Target target = new Descriptor.Target();
			Descriptor.ReadTarget(buffer, target);
			return new opendnp3.Indexed<Descriptor.Target>(opendnp3.Globals.WithIndex(target, range.start + pos));
		};

		var collection = opendnp3.Globals.CreateBufferedCollection<new Indexed<typename Descriptor.Target>>(buffer, new /*size_t*/int(COUNT), read);

		handler.OnHeader(new RangeHeader(record, range), collection);
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Type>
	private static void InvokeRangeOfType<Type>(in HeaderRecord record, in Range range, in ser4cpp.RSeq buffer, IAPDUHandler handler)
	{
		var COUNT = range.Count();

		var read = (ser4cpp.RSeq buffer, uint pos) =>
		{
			Type target = default(Type);
			Type.Read(buffer, target);
			return new opendnp3.Indexed<Type>(opendnp3.Globals.WithIndex(target, range.start + pos));
		});

		var collection = opendnp3.Globals.CreateBufferedCollection<new Indexed<Type>>(buffer, new /*size_t*/int(COUNT), read);

		handler.OnHeader(new RangeHeader(record, range), collection);
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Type>
	private static void InvokeRangeBitfieldType<Type>(in HeaderRecord record, in Range range, in ser4cpp.RSeq buffer, IAPDUHandler handler)
	{
		var COUNT = range.Count();

		var read = (ser4cpp.RSeq buffer, uint pos) =>
		{
			Type value = new Type(GetBit(buffer, pos));
			return new opendnp3.Indexed<Type>(opendnp3.Globals.WithIndex(value, range.start + pos));
		});

		var collection = opendnp3.Globals.CreateBufferedCollection<new Indexed<Type>>(buffer, new /*size_t*/int(COUNT), read);

		handler.OnHeader(new RangeHeader(record, range), collection);
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Type>
	private static void InvokeRangeDoubleBitfieldType<Type>(in HeaderRecord record, in Range range, in ser4cpp.RSeq buffer, IAPDUHandler handler)
	{
		var COUNT = range.Count();

		var read = (ser4cpp.RSeq buffer, /*size_t*/int pos) =>
		{
			Type value = new Type(GetDoubleBit(buffer, pos));
			return new opendnp3.Indexed<Type>(opendnp3.Globals.WithIndex(value, (ushort)(range.start + pos)));
		});

		var collection = opendnp3.Globals.CreateBufferedCollection<new Indexed<Type>>(buffer, new /*size_t*/int(COUNT), read);

		handler.OnHeader(new RangeHeader(record, range), collection);
	}

	private RangeParser(in Range range, /*size_t*/int requiredSize, HandleFun handler)
	{
		this.range = new opendnp3.Range(range);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.requiredSize = requiredSize;
		this.requiredSize.CopyFrom(requiredSize);
		this.handler = handler;
	}

	private Range range = new Range();
	private /*size_t*/int requiredSize = new /*size_t*/int();
	private HandleFun handler;

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	RangeParser() = delete;
}

} // namespace opendnp3



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

//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
//ORIGINAL LINE: #define MACRO_PARSE_OBJECTS_WITH_RANGE(descriptor) case (GroupVariation::descriptor): return RangeParser::FromFixedSize<descriptor>(range).Process(record, buffer, pHandler, pLogger);

} // namespace opendnp3
