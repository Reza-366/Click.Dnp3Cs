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

    public class ModuleId
    {
        public ModuleId()
        { }

        public ModuleId(int level)
        {
            this.value = level;
        }

        public int value = 0;
    }

    public class LogLevel
    {
        public LogLevel()
        { }

        public LogLevel(int level)
        {
            this.value = level;
        }

        public LogLevel(LogLevels level)
        {
            this.value = (int)level;
        }


        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: LogLevel next() const
        public LogLevel next()
        {
            return new LogLevel(value << 1);
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: bool operator ==(const LogLevel& other) const
        public static bool operator ==(LogLevel ImpliedObject, in LogLevel other)
        {
            return ImpliedObject.value == other.value;
        }

        public static bool operator !=(LogLevel ImpliedObject, in LogLevel other)
        {
            return ImpliedObject.value != other.value;
        }

        public int value = 0;
    }
    /**
     * Strongly typed wrapper for flags bitfield
     */
    /*
    public class LogLevels
    {
        public LogLevels()
        { }

        public LogLevels(int levels)
        {
            this.levels = levels;
        }

        public LogLevels(LogLevel level)
        {
            this.levels = level.value;
        }

        public static LogLevels none()
        {
            return new LogLevels(0);
        }

        public static LogLevels everything()
        {
            return new LogLevels(~0);
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline bool is_set(const LogLevel& level) const
        public bool is_set(in LogLevel level)
        {
            return (level.value & levels) != 0;
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: LogLevels operator ~() const
        public static LogLevels operator ~(LogLevels ImpliedObject)
        {
            return new LogLevels(~ImpliedObject.levels);
        }

        //C++ TO C# CONVERTER TASK: The |= operator cannot be overloaded in C#:
        //public static LogLevels BitwiseOR (LogLevel l, in LogLevel other)
        //{

        //    this.levels | other.value;
        //    return this;
        //}

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: LogLevels operator |(const LogLevel& other) const
        public static LogLevels operator |(LogLevels ImpliedObject, in LogLevel other)
        {
            return new LogLevels(ImpliedObject.levels | other.value);
        }

        //C++ TO C# CONVERTER TASK: The |= operator cannot be overloaded in C#:
        //public static LogLevels operator |= (in LogLevels other)
        //{
        //    this.levels |= other.levels;
        //    return this;
        //}

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: LogLevels operator |(const LogLevels& other) const
        public static LogLevels operator |(LogLevels ImpliedObject, in LogLevels other)
        {
            return new LogLevels(ImpliedObject.levels | other.levels);
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline int get_value() const
        public int get_value()
        {
            return levels;
        }

        private int levels = 0;
    }
    */
    //Converted To ENUMS
    public enum LogLevels
    {


     NOTHING  =0,
     ALL = 1,
     NORMAL = NOTHING | flags.EVENT | flags.ERR | flags.WARN | flags.INFO;
     ALL_APP_COMMS = NOTHING | flags.APP_HEADER_RX | flags.APP_HEADER_TX | flags.APP_OBJECT_RX | flags.APP_OBJECT_TX | flags.APP_HEX_RX | flags.APP_HEX_TX;
     ALL_COMMS = ALL_APP_COMMS | flags.LINK_RX | flags.LINK_TX | flags.TRANSPORT_RX | flags.TRANSPORT_TX;

}

    namespace flags
    {

    } // namespace flags

    namespace levels
    {
    } // namespace levels

} // namespace opendnp3



