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

///
/// Represent all of the mutable state for SBO controls
///
public class ControlState
{

//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	ControlState() = default;

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: CommandStatus ValidateSelection(const AppSeqNum& seq, const Timestamp& now, const TimeDuration& timeout, const RSeq<size_t>& objects) const
	public CommandStatus ValidateSelection(in AppSeqNum seq, in Timestamp now, in TimeDuration timeout, in RSeq<size_t> objects)
	{
		if (selected && expectedSeq.Equals(seq))
		{
			if (selectTime <= now)
			{
				var elapsed = now - selectTime;
				if (elapsed < timeout)
				{
					if (length == objects.length() && digest == CRC.CalcCrc(objects))
					{
						return CommandStatus.SUCCESS;
					}
					else
					{
						return CommandStatus.NO_SELECT;
					}
				}
				else
				{
					return CommandStatus.TIMEOUT;
				}
			}
			else
			{
				return CommandStatus.TIMEOUT;
			}
		}
		else
		{
			return CommandStatus.NO_SELECT;
		}
	}

	public void Select(in AppSeqNum currentSeqN, in Timestamp now, in RSeq<size_t> objects)
	{
		selected = true;
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: selectTime = now;
		selectTime.CopyFrom(now);
		expectedSeq = currentSeqN.Next();
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: digest = CRC::CalcCrc(objects);
		digest.CopyFrom(CRC.CalcCrc(objects));
		length = objects.length();
	}

	public void Unselect()
	{
		selected = false;
	}

	private bool selected = false;
	private AppSeqNum expectedSeq = new AppSeqNum();
	private Timestamp selectTime = new Timestamp();
	private UInt16 digest = 0;
	private size_t length = 0;
}

} // namespace opendnp3

