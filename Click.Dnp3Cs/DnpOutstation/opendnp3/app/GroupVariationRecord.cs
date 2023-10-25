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

public enum GroupVariationType : int
{
	STATIC,
	EVENT,
	OTHER
}

public class EnumAndType
{
	public EnumAndType(GroupVariation enumeration_, GroupVariationType type_)
	{
		this.enumeration = new opendnp3.GroupVariation(enumeration_);
		this.type = new opendnp3.GroupVariationType(type_);
	}

	public GroupVariation enumeration;
	public GroupVariationType type;
}

public class GroupVariationRecord
{

	public static EnumAndType GetEnumAndType(byte group, byte variation)
	{
		var type = GetType(new byte(group), new byte(variation));
		var enumeration = GroupVariationSpec.from_type(GetGroupVar(new byte(group), new byte(variation)));

		if (enumeration == GroupVariation.UNKNOWN)
		{
			switch (group)
			{
			case (110):
				enumeration = GroupVariation.Group110Var0;
				break;
			case (111):
				enumeration = GroupVariation.Group111Var0;
				break;
			case (112):
				enumeration = GroupVariation.Group112Var0;
				break;
			case (113):
				enumeration = GroupVariation.Group113Var0;
				break;
			default:
				break;
			}
		}

		return new EnumAndType(enumeration, type);
	}

	public static ushort GetGroupVar(byte group, byte variation)
	{
		return (group << 8) | variation;
	}

	public static GroupVariationRecord GetRecord(byte group, byte variation)
	{
		var pair = GetEnumAndType(new byte(group), new byte(variation));
		return new GroupVariationRecord(group, variation, pair.enumeration, pair.type);
	}

	public static GroupVariationType GetType(byte group, byte variation)
	{
		switch (group)
		{
		case (1):
			return GroupVariationType.STATIC;

		case (2):
			return GroupVariationType.EVENT;

		case (3):
			return GroupVariationType.STATIC;

		case (4):
			return GroupVariationType.EVENT;

		case (10):
			return GroupVariationType.STATIC;

		case (11):
			return GroupVariationType.EVENT;

		case (13):
			return GroupVariationType.EVENT;

		case (20):
			return GroupVariationType.STATIC;

		case (21):
			return GroupVariationType.STATIC;

		case (22):
			return GroupVariationType.EVENT;

		case (23):
			return GroupVariationType.EVENT;

		case (30):
			return GroupVariationType.STATIC;

		case (32):
			return GroupVariationType.EVENT;

		case (40):
			return GroupVariationType.STATIC;

		case (41):
			return GroupVariationType.EVENT;

		case (42):
			return GroupVariationType.EVENT;

		case (43):
			return GroupVariationType.EVENT;

		case (50):
			switch (variation)
			{
			case (4):
				return GroupVariationType.STATIC;
			default:
				return GroupVariationType.OTHER;
			}

		case (60):
			switch (variation)
			{
			case (1):
				return GroupVariationType.STATIC;
			default:
				return GroupVariationType.EVENT;
			}

		case (110):
			return GroupVariationType.STATIC;

		case (111):
			return GroupVariationType.EVENT;

		case (121):
			return GroupVariationType.STATIC;
		case (122):
			return GroupVariationType.EVENT;

		default:
			return GroupVariationType.OTHER;
		}
	}

	public GroupVariationRecord(byte group_, byte variation_, GroupVariation enumeration_, GroupVariationType type_)
	{
		this.enumeration = new opendnp3.GroupVariation(enumeration_);
		this.type = new opendnp3.GroupVariationType(type_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.group = group_;
		this.group.CopyFrom(group_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.variation = variation_;
		this.variation.CopyFrom(variation_);
	}

	public GroupVariationRecord()
	{
		this.enumeration = new opendnp3.GroupVariation.UNKNOWN;
		this.type = new opendnp3.GroupVariationType.OTHER;
		this.group = 0;
		this.variation = 0;
	}

	public GroupVariation enumeration;
	public GroupVariationType type;
	public byte group = new byte();
	public byte variation = new byte();
}

public class HeaderRecord : GroupVariationRecord
{
	public HeaderRecord()
	{
		this.qualifier = 0;
		this.headerIndex = 0;
	}

	public HeaderRecord(in GroupVariationRecord gv, byte qualifier_, uint headerIndex_) : base(gv)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.qualifier = qualifier_;
		this.qualifier.CopyFrom(qualifier_);
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.headerIndex = headerIndex_;
		this.headerIndex.CopyFrom(headerIndex_);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: QualifierCode GetQualifierCode() const
	public QualifierCode GetQualifierCode()
	{
		return QualifierCodeSpec.from_type(new byte(qualifier));
	}

	public byte qualifier = new byte();
	public uint headerIndex = new uint();
}

// ---- Specific header types  ---

public class AllObjectsHeader : HeaderRecord
{
	public AllObjectsHeader(in HeaderRecord record) : base(record)
	{
	}
}

public class CountHeader : HeaderRecord
{
	public CountHeader(in HeaderRecord record, ushort count_) : base(record)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.count = count_;
		this.count.CopyFrom(count_);
	}

	public ushort count = new ushort();
}

public class FreeFormatHeader : HeaderRecord
{
	public FreeFormatHeader(in HeaderRecord record, ushort count_) : base(record)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.count = count_;
		this.count.CopyFrom(count_);
	}

	public ushort count = new ushort();
}

public class RangeHeader : HeaderRecord
{
	public RangeHeader(in HeaderRecord record, in Range range_) : base(record)
	{
		this.range = new opendnp3.Range(range_);
	}

	public Range range = new Range();
}

public class PrefixHeader : HeaderRecord
{
	public PrefixHeader(in HeaderRecord record, ushort count_) : base(record)
	{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this.count = count_;
		this.count.CopyFrom(count_);
	}

	public ushort count = new ushort();
}

} // namespace opendnp3



