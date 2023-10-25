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
 * An interface used to update measurement values.
 */
public abstract class IUpdateHandler : System.IDisposable
{
	public virtual void Dispose()
	{
	}

	/**
	 * Update a Binary measurement
	 * @param meas measurement to be processed
	 * @param index index of the measurement
	 * @param mode Describes how event generation is handled for this method
	 * @return true if the value exists and it was updated
	 */
	public abstract bool Update(in Binary meas, ushort index, EventMode mode = EventMode.Detect);

	/**
	 * Update a DoubleBitBinary measurement
	 * @param meas measurement to be processed
	 * @param index index of the measurement
	 * @param mode Describes how event generation is handled for this method
	 * @return true if the value exists and it was updated
	 */
	public abstract bool Update(in DoubleBitBinary meas, ushort index, EventMode mode = EventMode.Detect);

	/**
	 * Update an Analog measurement
	 * @param meas measurement to be processed
	 * @param index index of the measurement
	 * @param mode Describes how event generation is handled for this method
	 * @return true if the value exists and it was updated
	 */
	public abstract bool Update(in Analog meas, ushort index, EventMode mode = EventMode.Detect);

	/**
	 * Update a Counter measurement
	 * @param meas measurement to be processed
	 * @param index index of the measurement
	 * @param mode Describes how event generation is handled for this method
	 * @return true if the value exists and it was updated
	 */
	public abstract bool Update(in Counter meas, ushort index, EventMode mode = EventMode.Detect);

	/**
	 * Freeze a Counter measurement
	 * @param index index of the measurement
	 * @param clear clear the original counter
	 * @param mode Describes how event generation is handled for this method
	 * @return true if the value exists and it was updated
	 */
	public abstract bool FreezeCounter(ushort index, bool clear = false, EventMode mode = EventMode.Detect);

	/**
	 * Update a BinaryOutputStatus measurement
	 * @param meas measurement to be processed
	 * @param index index of the measurement
	 * @param mode Describes how event generation is handled for this method
	 * @return true if the value exists and it was updated
	 */
	public abstract bool Update(in BinaryOutputStatus meas, ushort index, EventMode mode = EventMode.Detect);

	/**
	 * Update a AnalogOutputStatus measurement
	 * @param meas measurement to be processed
	 * @param index index of the measurement
	 * @param mode Describes how event generation is handled for this method
	 * @return true if the value exists and it was updated
	 */
	public abstract bool Update(in AnalogOutputStatus meas, ushort index, EventMode mode = EventMode.Detect);

	/**
	 * Update an octet string value
	 * @param meas measurement to be processed
	 * @param index index of the measurement
	 * @param mode Describes how event generation is handled for this method
	 * @return true if the value exists and it was updated
	 */
	public abstract bool Update(in OctetString meas, ushort index, EventMode mode = EventMode.Detect);

	/**
	 * Update a TimeAndInterval valueindex
	 * @param meas measurement to be processed
	 * @param index index of the measurement
	 * @return true if the value exists and it was updated
	 */
	public abstract bool Update(in TimeAndInterval meas, ushort index);

	/**
	 * Update the flags of a measurement without changing it's value
	 * @param type enumeration specifiy the type to change
	 * @param start the start index at which to begin changing flags
	 * @param stop the stop index at which to end changing flags
	 * @param flags the new value of the flags
	 */
	public abstract bool Modify(FlagsType type, ushort start, ushort stop, byte flags);
}

} // namespace opendnp3

