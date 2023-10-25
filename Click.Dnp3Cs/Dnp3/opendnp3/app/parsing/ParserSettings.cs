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

public class ParserSettings
{
	public static ParserSettings NoContents(LogLevel logLevel = flags.APP_OBJECT_RX)
	{
		return new ParserSettings(false, logLevel);
	}

	public static ParserSettings Default(LogLevel logLevel = flags.APP_OBJECT_RX)
	{
		return new ParserSettings(true, logLevel);
	}

	public static ParserSettings Create(bool expectContents = true, LogLevel logLevel = flags.APP_OBJECT_RX)
	{
		return new ParserSettings(expectContents, logLevel);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline bool ExpectsContents() const
	public bool ExpectsContents()
	{
		return expectContents;
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: inline LogLevel LoggingLevel() const
	public LogLevel LoggingLevel()
	{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return logLevel;
		return new opendnp3.LogLevel(logLevel);
	}

	private ParserSettings(bool expectContents_ = true, LogLevel logLevel_ = flags.APP_OBJECT_RX)
	{
		this.expectContents = expectContents_;
		this.logLevel = new opendnp3.LogLevel(logLevel_);
	}

	private readonly bool expectContents;
	private readonly LogLevel logLevel = new LogLevel();
}
} // namespace opendnp3

