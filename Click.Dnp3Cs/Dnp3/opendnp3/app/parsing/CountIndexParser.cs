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

public class CountIndexParser
{
	private delegate void HandleFun(in HeaderRecord record, UInt16 count, in NumParser numparser, in ser4cpp.rseq_t buffer, IAPDUHandler handler);

	public static ParseResult ParseHeader(ser4cpp.rseq_t buffer, in NumParser numparser, in ParserSettings settings, in HeaderRecord record, Logger pLogger, IAPDUHandler pHandler)
	{
		UInt16 count = new UInt16();
		var res = numparser.ParseCount(buffer, count, pLogger);
		if (res == ParseResult.OK)
		{
			if (pLogger != null && pLogger.is_enabled(settings.LoggingLevel()))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "%03u,%03u %s, %s [%u]",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(settings.LoggingLevel(), __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
			};

			if (settings.ExpectsContents())
			{
				return ParseCountOfObjects(buffer, record, numparser, new UInt16(count), pLogger, pHandler);
			}
			else
			{
				return ParseCountOfIndices(buffer, record, numparser, new UInt16(count), pLogger, pHandler);
			}
		}

		return res;
	}

	// Process the count handler against the buffer
//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: ParseResult Process(const HeaderRecord& record, ser4cpp::rseq_t& buffer, IAPDUHandler* pHandler, Logger* pLogger) const
	private ParseResult Process(in HeaderRecord record, ser4cpp.rseq_t buffer, IAPDUHandler pHandler, Logger pLogger)
	{
		if (buffer.length() < requiredSize)
		{
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Not enough data for specified objects");
			};
			return ParseResult.NOT_ENOUGH_DATA_FOR_OBJECTS;
		}

		if (pHandler != null)
		{
			handler(record, count, numparser, buffer, pHandler);
		}
		buffer.advance(requiredSize);
		return ParseResult.OK;
	}

	// Create a count handler from a fixed size descriptor
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Descriptor>
	private static CountIndexParser From<Descriptor>(UInt16 count, in NumParser numparser)
	{
		size_t SIZE = (size_t)count * (Descriptor.Size() + numparser.NumBytes());
		return new CountIndexParser(count, SIZE, numparser, InvokeCountOf<Descriptor>);
	}

	// Create a count handler from a fixed size descriptor
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Type>
	private static CountIndexParser FromType<Type>(UInt16 count, in NumParser numparser)
	{
		size_t SIZE = (size_t)count * (Type.Size() + numparser.NumBytes());
		return new CountIndexParser(count, SIZE, numparser, InvokeCountOfType<Type>);
	}

	private static ParseResult ParseCountOfObjects(ser4cpp.rseq_t buffer, in HeaderRecord record, in NumParser numparser, UInt16 count, Logger pLogger, IAPDUHandler pHandler)
	{
		switch (record.enumeration)
		{
		case (GroupVariation.Group2Var1):
			return CountIndexParser.From<Group2Var1>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group2Var2):
			return CountIndexParser.From<Group2Var2>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group2Var3):
			return CountIndexParser.From<Group2Var3>(count, numparser).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group4Var1):
			return CountIndexParser.From<Group4Var1>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group4Var2):
			return CountIndexParser.From<Group4Var2>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group4Var3):
			return CountIndexParser.From<Group4Var3>(count, numparser).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group11Var1):
			return CountIndexParser.From<Group11Var1>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group11Var2):
			return CountIndexParser.From<Group11Var2>(count, numparser).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group12Var1):
			return CountIndexParser.From<Group12Var1>(count, numparser).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group13Var1):
			return CountIndexParser.From<Group13Var1>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group13Var2):
			return CountIndexParser.From<Group13Var2>(count, numparser).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group22Var1):
			return CountIndexParser.From<Group22Var1>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group22Var2):
			return CountIndexParser.From<Group22Var2>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group22Var5):
			return CountIndexParser.From<Group22Var5>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group22Var6):
			return CountIndexParser.From<Group22Var6>(count, numparser).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group23Var1):
			return CountIndexParser.From<Group23Var1>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group23Var2):
			return CountIndexParser.From<Group23Var2>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group23Var5):
			return CountIndexParser.From<Group23Var5>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group23Var6):
			return CountIndexParser.From<Group23Var6>(count, numparser).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group32Var1):
			return CountIndexParser.From<Group32Var1>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group32Var2):
			return CountIndexParser.From<Group32Var2>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group32Var3):
			return CountIndexParser.From<Group32Var3>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group32Var4):
			return CountIndexParser.From<Group32Var4>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group32Var5):
			return CountIndexParser.From<Group32Var5>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group32Var6):
			return CountIndexParser.From<Group32Var6>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group32Var7):
			return CountIndexParser.From<Group32Var7>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group32Var8):
			return CountIndexParser.From<Group32Var8>(count, numparser).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group41Var1):
			return CountIndexParser.From<Group41Var1>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group41Var2):
			return CountIndexParser.From<Group41Var2>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group41Var3):
			return CountIndexParser.From<Group41Var3>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group41Var4):
			return CountIndexParser.From<Group41Var4>(count, numparser).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group42Var1):
			return CountIndexParser.From<Group42Var1>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group42Var2):
			return CountIndexParser.From<Group42Var2>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group42Var3):
			return CountIndexParser.From<Group42Var3>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group42Var4):
			return CountIndexParser.From<Group42Var4>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group42Var5):
			return CountIndexParser.From<Group42Var5>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group42Var6):
			return CountIndexParser.From<Group42Var6>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group42Var7):
			return CountIndexParser.From<Group42Var7>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group42Var8):
			return CountIndexParser.From<Group42Var8>(count, numparser).Process(record, buffer, pHandler, pLogger);

		case (GroupVariation.Group43Var1):
			return CountIndexParser.From<Group43Var1>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group43Var2):
			return CountIndexParser.From<Group43Var2>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group43Var3):
			return CountIndexParser.From<Group43Var3>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group43Var4):
			return CountIndexParser.From<Group43Var4>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group43Var5):
			return CountIndexParser.From<Group43Var5>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group43Var6):
			return CountIndexParser.From<Group43Var6>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group43Var7):
			return CountIndexParser.From<Group43Var7>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group43Var8):
			return CountIndexParser.From<Group43Var8>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group50Var4):
			return CountIndexParser.From<Group50Var4>(count, numparser).Process(record, buffer, pHandler, pLogger);
		case (GroupVariation.Group111Var0):
			return ParseIndexPrefixedOctetData(buffer, record, numparser, new UInt16(count), pLogger, pHandler);

		default:

			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
				string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
				SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "Unsupported qualifier/object - %s - %i / %i",__VA_ARGS__);
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", message_buffer_some_name_no_conflict);
			};

			return ParseResult.INVALID_OBJECT_QUALIFIER;
		}
	}

	private static ParseResult ParseCountOfIndices(ser4cpp.rseq_t buffer, in HeaderRecord record, in NumParser numparser, UInt16 count, Logger pLogger, IAPDUHandler pHandler)
	{
		var SIZE = (size_t)count * (size_t)numparser.NumBytes();

		if (buffer.length() < SIZE)
		{
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Not enough data for specified sequence of indices");
			};
			return ParseResult.NOT_ENOUGH_DATA_FOR_OBJECTS;
		}

		if (pHandler != null)
		{
//C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
//C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
//ORIGINAL LINE: auto read = [&numparser, record](ser4cpp::rseq_t& buffer, System.UInt32 pos)->UInt16
			var read = (ser4cpp.rseq_t buffer, System.UInt32 pos) =>
			{
				return new UInt16(numparser.ReadNum(buffer));
			};

			var collection = opendnp3.Globals.CreateBufferedCollection<UInt16>(buffer, new UInt16(count), read);
			pHandler.OnHeader(new PrefixHeader(record, count), collection);
		}

		buffer.advance(SIZE);
		return ParseResult.OK;
	}

	private static ParseResult ParseIndexPrefixedOctetData(ser4cpp.rseq_t buffer, in HeaderRecord record, in NumParser numparser, System.UInt32 count, Logger pLogger, IAPDUHandler pHandler)
	{
		if (record.variation == 0)
		{
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Octet string variation 0 may only be used in requests");
			};
			return ParseResult.INVALID_OBJECT;
		}

		System.UInt32 TOTAL_SIZE = count * (numparser.NumBytes() + record.variation);

		if (buffer.length() < TOTAL_SIZE)
		{
			if (pLogger != null && pLogger.is_enabled(opendnp3.flags.Globals.WARN))
			{
	//C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
				pLogger.log(opendnp3.flags.Globals.WARN, __FILE__ "(" "__LINE__" ")", "Not enough data for specified bitfield objects");
			};
			return ParseResult.NOT_ENOUGH_DATA_FOR_OBJECTS;
		}

		if (pHandler != null)
		{
			var read = (ser4cpp.rseq_t buffer, System.UInt32 pos) =>
			{
				var index = numparser.ReadNum(buffer);
				var octetStringSlice = buffer.take(record.variation);
				OctetString octets = new OctetString(new Buffer(octetStringSlice, (uint)octetStringSlice.length()));
				buffer.advance(record.variation);
				return new opendnp3.Indexed<opendnp3.OctetString>(opendnp3.Globals.WithIndex(octets, new UInt16(index)));
			});

			var collection = opendnp3.Globals.CreateBufferedCollection<new Indexed<OctetString>>(buffer, new System.UInt32(count), read);
			pHandler.OnHeader(new PrefixHeader(record, count), collection);
		}

		buffer.advance(TOTAL_SIZE);
		return ParseResult.OK;
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Descriptor>
	private static void InvokeCountOf<Descriptor>(in HeaderRecord record, UInt16 count, in NumParser numparser, in ser4cpp.rseq_t buffer, IAPDUHandler handler)
	{
		var read = (ser4cpp.rseq_t buffer, System.UInt32 UnnamedParameter) =>
		{
			Indexed<typename Descriptor.Target> pair = new Indexed<typename Descriptor.Target>();
			pair.index.CopyFrom(numparser.ReadNum(buffer));
			Descriptor.ReadTarget(buffer, pair.value);
			return new opendnp3.Indexed<typename Descriptor.Target>(pair);
		});

		var collection = opendnp3.Globals.CreateBufferedCollection<new Indexed<typename Descriptor.Target>>(buffer, new UInt16(count), read);
		handler.OnHeader(new PrefixHeader(record, count), collection);
	}

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class Type>
	private static void InvokeCountOfType<Type>(in HeaderRecord record, UInt16 count, in NumParser numparser, in ser4cpp.rseq_t buffer, IAPDUHandler handler)
	{
		var read = (ser4cpp.rseq_t buffer, System.UInt32 UnnamedParameter) =>
		{
			Indexed<Type> pair = new Indexed<Type>();
			pair.index.CopyFrom(numparser.ReadNum(buffer));
			Type.Read(buffer, pair.value);
			return new opendnp3.Indexed<Type>(pair);
		});

		var collection = opendnp3.Globals.CreateBufferedCollection<new Indexed<Type>>(buffer, new UInt16(count), read);
		handler.OnHeader(new PrefixHeader(record, count), collection);
	}

	private CountIndexParser(UInt16 count, size_t requiredSize, in NumParser numparser, HandleFun handler)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.count = count;
		this.count.CopyFrom(count);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.requiredSize = requiredSize;
		this.requiredSize.CopyFrom(requiredSize);
		this.numparser = new opendnp3.NumParser(numparser);
		this.handler = handler;
	}

	private UInt16 count = new UInt16();
	private size_t requiredSize = new size_t();
	private NumParser numparser = new NumParser();
	private HandleFun handler;

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = delete':
//	CountIndexParser() = delete;
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

