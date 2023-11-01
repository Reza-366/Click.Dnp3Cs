using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace opendnp3
{

    public class BinaryInfo : StaticOnly
    {

        public const EventType EventTypeEnum = EventType.Binary;
        public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.BinaryInput;
        public const EventBinaryVariation DefaultEventVariation = EventBinaryVariation.Group2Var1;//REZA
        public const StaticBinaryVariation DefaultStaticVariation = StaticBinaryVariation.Group1Var1;//REZA
    }

    public class DoubleBitBinaryInfo : StaticOnly
    {

        public const EventType EventTypeEnum = EventType.DoubleBitBinary;
        public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.DoubleBinaryInput;
        public const EventDoubleBinaryVariation DefaultEventVariation = EventDoubleBinaryVariation.Group4Var1;//REZA
        public const StaticDoubleBinaryVariation DefaultStaticVariation = StaticDoubleBinaryVariation.Group3Var2;//REZA
    }

    public class BinaryOutputStatusInfo : StaticOnly
    {

        public const EventType EventTypeEnum = EventType.BinaryOutputStatus;
        public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.BinaryOutputStatus;
        public const EventBinaryOutputStatusVariation DefaultEventVariation = EventBinaryOutputStatusVariation.Group11Var1;//REZA
        public const StaticBinaryOutputStatusVariation DefaultStaticVariation = StaticBinaryOutputStatusVariation.Group10Var2; //REZA
    }

    public class AnalogInfo : StaticOnly
    {

        public const EventType EventTypeEnum = EventType.Analog;
        public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.AnalogInput;
        public const EventAnalogVariation DefaultEventVariation =  EventAnalogVariation.Group32Var1;//REZA
        public const StaticAnalogVariation DefaultStaticVariation =  StaticAnalogVariation.Group30Var1;//REZA
    }

    public class CounterInfo : StaticOnly
    {

        public const EventType EventTypeEnum = EventType.Counter;
        public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.Counter;
        public const EventCounterVariation DefaultEventVariation = EventCounterVariation.Group22Var1;//REZA
        public const StaticCounterVariation DefaultStaticVariation = StaticCounterVariation.Group20Var1;//REZA
    }

    public class FrozenCounterInfo : StaticOnly
    {

        public const EventType EventTypeEnum = EventType.FrozenCounter;
        public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.FrozenCounter;
        public const EventFrozenCounterVariation DefaultEventVariation =  EventFrozenCounterVariation.Group23Var1;//REZA
        public const StaticFrozenCounterVariation DefaultStaticVariation = StaticFrozenCounterVariation.Group21Var1;//REZA
    }

    public class AnalogOutputStatusInfo : StaticOnly
    {

        public const EventType EventTypeEnum = EventType.AnalogOutputStatus;
        public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.AnalogOutputStatus;
        public const EventAnalogOutputStatusVariation DefaultEventVariation = EventAnalogOutputStatusVariation.Group42Var8; //REZA
        public const StaticAnalogOutputStatusVariation DefaultStaticVariation = StaticAnalogOutputStatusVariation.Group40Var1;//REZA
    }

    public class OctetStringInfo : StaticOnly
    {

        public const EventType EventTypeEnum = EventType.OctetString;
        public const StaticTypeBitmask StaticTypeEnum = StaticTypeBitmask.OctetString;
        public const EventOctetStringVariation DefaultEventVariation = EventOctetStringVariation.Group111Var0;
        public const StaticOctetStringVariation DefaultStaticVariation = StaticOctetStringVariation.Group110Var0;
    }

    public class TimeAndIntervalInfo : StaticOnly
    {

        public const StaticTypeBitmask StaticTypeEnum = (opendnp3.StaticTypeBitmask)StaticTypeBitmask.TimeAndInterval;
        public const StaticTimeAndIntervalVariation DefaultStaticVariation = StaticTimeAndIntervalVariation.Group50Var4;
    }

} // namespace opendnp3



