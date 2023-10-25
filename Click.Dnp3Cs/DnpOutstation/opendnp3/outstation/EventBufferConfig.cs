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

    /**

      Configuration of maximum event counts per event type.

      The underlying implementation uses a *preallocated* heap buffer to store events
      until they are transmitted to the master. The size of this buffer is proportional
      to the TotalEvents() method, i.e. the sum of the maximum events for each type.

      Implementations should configure the buffers to store a reasonable number events
      given the polling frequency and memory restrictions of the target platform.

*/
    public class EventBufferConfig
    {
        /**
            Construct the class using the same maximum for all types. This is mainly used for demo purposes.
            You probably don't want to use this method unless your implementation actually reports every type.
        */
        public static EventBufferConfig AllTypes(ushort sizes)
        {
            return new EventBufferConfig(sizes, sizes, sizes, sizes, sizes, sizes, sizes, sizes);
        }

        /**
            Construct the class specifying the maximum number of events for each type individually.
        */
        public EventBufferConfig(ushort maxBinaryEvents = 0, ushort maxDoubleBinaryEvents = 0, ushort maxAnalogEvents = 0, ushort maxCounterEvents = 0, ushort maxFrozenCounterEvents = 0, ushort maxBinaryOutputStatusEvents = 0, ushort maxAnalogOutputStatusEvents = 0, ushort maxOctetStringEvents = 0)
        {
            //C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
            //ORIGINAL LINE: this.maxBinaryEvents = maxBinaryEvents;
            this.maxBinaryEvents = (maxBinaryEvents);
            //C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
            //ORIGINAL LINE: this.maxDoubleBinaryEvents = maxDoubleBinaryEvents;
            this.maxDoubleBinaryEvents = (maxDoubleBinaryEvents);
            //C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
            //ORIGINAL LINE: this.maxAnalogEvents = maxAnalogEvents;
            this.maxAnalogEvents = (maxAnalogEvents);
            //C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
            //ORIGINAL LINE: this.maxCounterEvents = maxCounterEvents;
            this.maxCounterEvents = (maxCounterEvents);
            //C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
            //ORIGINAL LINE: this.maxFrozenCounterEvents = maxFrozenCounterEvents;
            this.maxFrozenCounterEvents = (maxFrozenCounterEvents);
            //C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
            //ORIGINAL LINE: this.maxBinaryOutputStatusEvents = maxBinaryOutputStatusEvents;
            this.maxBinaryOutputStatusEvents = (maxBinaryOutputStatusEvents);
            //C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
            //ORIGINAL LINE: this.maxAnalogOutputStatusEvents = maxAnalogOutputStatusEvents;
            this.maxAnalogOutputStatusEvents = (maxAnalogOutputStatusEvents);
            //C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
            //ORIGINAL LINE: this.maxOctetStringEvents = maxOctetStringEvents;
            this.maxOctetStringEvents = (maxOctetStringEvents);
        }

        // Returns the sum of all event count maximums (number of elements in preallocated buffer)
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: uint TotalEvents() const
        public uint TotalEvents()
        {
            return Convert.ToUInt32(maxBinaryEvents + maxDoubleBinaryEvents + maxAnalogEvents + maxCounterEvents + maxFrozenCounterEvents + maxBinaryOutputStatusEvents + maxAnalogOutputStatusEvents + maxOctetStringEvents);
        }

        // The number of binary events the outstation will buffer before overflowing
        public ushort maxBinaryEvents = new ushort();

        // The number of double bit binary events the outstation will buffer before overflowing
        public ushort maxDoubleBinaryEvents = new ushort();

        // The number of analog events the outstation will buffer before overflowing
        public ushort maxAnalogEvents = new ushort();

        // The number of counter events the outstation will buffer before overflowing
        public ushort maxCounterEvents = new ushort();

        // The number of frozen counter events the outstation will buffer before overflowing
        public ushort maxFrozenCounterEvents = new ushort();

        // The number of binary output status events the outstation will buffer before overflowing
        public ushort maxBinaryOutputStatusEvents = new ushort();

        // The number of analog output status events the outstation will buffer before overflowing
        public ushort maxAnalogOutputStatusEvents = new ushort();

        // The number of analog output status events the outstation will buffer before overflowing
        public ushort maxOctetStringEvents = new ushort();
    }

} // namespace opendnp3



