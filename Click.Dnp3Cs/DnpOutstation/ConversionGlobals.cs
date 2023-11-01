using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ser4cpp;

namespace opendnp3
{
    public static class Globals
    {
        public static /*size_t*/int NumBytesInBits(/*size_t*/int numBits)
        {
            /*size_t*/
            int numBytes = numBits / 8;
            return ((numBits % 8) == 0) ? numBytes : numBytes + 1;
        }

        public static bool GetBit(in RSeq/*<size_t>*/ buffer, /*size_t*/int position)
        {
            /*size_t*/
            int @byte = position / 8;
            /*size_t*/
            int bit = position % 8;
            Debug.Assert(@byte < buffer.length());
            return (buffer[@byte] & (1 << bit)) != 0;
        }

        public static /*size_t*/int NumBytesInDoubleBits(/*size_t*/int numBits)
        {
            /*size_t*/
            int numBytes = numBits / 4;
            return ((numBits % 4) == 0) ? numBytes : numBytes + 1;
        }

        public static DoubleBit GetDoubleBit(in RSeq/*<size_t>*/ buffer, /*size_t*/int index)
        {
            /*size_t*/
            int byteNumber = index / 4;
            Debug.Assert(byteNumber < buffer.length());
            byte @byte = buffer[byteNumber];
            /*size_t*/
            int bitshift = 2 * (index % 4);
            return DoubleBitSpec.from_type(Convert.ToByte((@byte >> bitshift) & 0x03));
        }

        ////C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly EventBinaryVariation DefaultEventVariation = EventBinaryVariation.Group2Var1;
        ////C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly StaticBinaryVariation DefaultStaticVariation = StaticBinaryVariation.Group1Var2;

        ////C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly EventDoubleBinaryVariation DefaultEventVariation = EventDoubleBinaryVariation.Group4Var1;
        ////C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly StaticDoubleBinaryVariation DefaultStaticVariation = StaticDoubleBinaryVariation.Group3Var2;

        ////C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly EventBinaryOutputStatusVariation DefaultEventVariation = EventBinaryOutputStatusVariation.Group11Var1;
        ////C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly StaticBinaryOutputStatusVariation DefaultStaticVariation = StaticBinaryOutputStatusVariation.Group10Var2;

        ////C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly AnalogInfo.event_variation_t DefaultEventVariation = EventAnalogVariation.Group32Var1;
        ////C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly AnalogInfo.static_variation_t DefaultStaticVariation = StaticAnalogVariation.Group30Var1;

        ////C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly CounterInfo.event_variation_t DefaultEventVariation = EventCounterVariation.Group22Var1;
        ////C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly CounterInfo.static_variation_t DefaultStaticVariation = StaticCounterVariation.Group20Var1;

        ////C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly FrozenCounterInfo.event_variation_t DefaultEventVariation = EventFrozenCounterVariation.Group23Var1;
        ////C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly FrozenCounterInfo.static_variation_t DefaultStaticVariation = StaticFrozenCounterVariation.Group21Var1;

        ////C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly AnalogOutputStatusInfo.event_variation_t DefaultEventVariation = EventAnalogOutputStatusVariation.Group42Var1;
        ////C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly AnalogOutputStatusInfo.static_variation_t DefaultStaticVariation = StaticAnalogOutputStatusVariation.Group40Var1;

        ////C++ TO C# CONVERTER TASK: The typedef 'event_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly OctetStringInfo.event_variation_t DefaultEventVariation = EventOctetStringVariation.Group111Var0;
        ////C++ TO C# CONVERTER TASK: The typedef 'static_variation_t' was defined in multiple preprocessor conditionals and cannot be replaced in-line:
        //public static readonly OctetStringInfo.static_variation_t DefaultStaticVariation = StaticOctetStringVariation.Group110Var0;

        // Serial port configuration functions "free" to keep the classes simple.
        public static bool Configure(in SerialSettings settings, asio.serial_port port, int ec)
        {

            //     Set all the various options
            port.set_option(ConvertBaud(settings.baud), ec);
            if (ec != null)
            {
                return false;
            }

            port.set_option(ConvertDataBits(settings.dataBits), ec);
            if (ec != null)
            {
                return false;
            }

            port.set_option(ConvertParity(settings.parity), ec);
            if (ec != null)
            {
                return false;
            }

            port.set_option(ConvertFlow(settings.flowType), ec);
            if (ec != null)
            {
                return false;
            }

            port.set_option(ConvertStopBits(settings.stopBits), ec);
            return ec == null;

        }

        public static asio.serial_port_base.stop_bits ConvertStopBits(StopBits stopBits)
        {
            asio.serial_port_base.stop_bits t = asio.serial_port_base.stop_bits.one;

            switch (stopBits)
            {
                case (StopBits.One):
                    t = asio.serial_port_base.stop_bits.one;
                    break;
                case (StopBits.OnePointFive):
                    t = asio.serial_port_base.stop_bits.onepointfive;
                    break;
                case (StopBits.Two):
                    t = asio.serial_port_base.stop_bits.two;
                    break;
                default:
                    break;
            }

            return (asio.serial_port_base.stop_bits)(t);
        }

        public static asio.serial_port_base.flow_control ConvertFlow(FlowControl flowType)
        {
            asio.serial_port_base.flow_control t = asio.serial_port_base.flow_control.none;

            switch (flowType)
            {
                case (FlowControl.None):
                    t = asio.serial_port_base.flow_control.none;
                    break;
                case (FlowControl.XONXOFF):
                    t = asio.serial_port_base.flow_control.software;
                    break;
                case (FlowControl.Hardware):
                    t = asio.serial_port_base.flow_control.hardware;
                    break;
                default:
                    break;
            }

            return (asio.serial_port_base.flow_control)(t);
        }

        public static asio.serial_port_base.character_size ConvertDataBits(int aDataBits)
        {
            return (asio.serial_port_base.character_size)((uint)aDataBits);
        }

        public static asio.serial_port_base.baud_rate ConvertBaud(int aBaud)
        {
            return (asio.serial_port_base.baud_rate)((uint)aBaud);
        }

        public static asio.serial_port_base.parity ConvertParity(Parity parity)
        {
            asio.serial_port_base.parity t = asio.serial_port_base.parity.none;

            switch (parity)
            {
                case (Parity.Even):
                    t = asio.serial_port_base.parity.even;
                    break;
                case (Parity.Odd):
                    t = asio.serial_port_base.parity.odd;
                    break;
                default:
                    break;
            }

            return (asio.serial_port_base.parity)(t);
        }

        public static bool HasAbsoluteTime(GroupVariation gv)
        {
            switch (gv)
            {
                case (GroupVariation.Group2Var2):
                    return true;
                case (GroupVariation.Group4Var2):
                    return true;
                case (GroupVariation.Group11Var2):
                    return true;
                case (GroupVariation.Group13Var2):
                    return true;
                case (GroupVariation.Group21Var5):
                    return true;
                case (GroupVariation.Group21Var6):
                    return true;
                case (GroupVariation.Group22Var5):
                    return true;
                case (GroupVariation.Group22Var6):
                    return true;
                case (GroupVariation.Group23Var5):
                    return true;
                case (GroupVariation.Group23Var6):
                    return true;
                case (GroupVariation.Group32Var3):
                    return true;
                case (GroupVariation.Group32Var4):
                    return true;
                case (GroupVariation.Group32Var7):
                    return true;
                case (GroupVariation.Group32Var8):
                    return true;
                case (GroupVariation.Group42Var3):
                    return true;
                case (GroupVariation.Group42Var4):
                    return true;
                case (GroupVariation.Group42Var7):
                    return true;
                case (GroupVariation.Group42Var8):
                    return true;
                case (GroupVariation.Group43Var3):
                    return true;
                case (GroupVariation.Group43Var4):
                    return true;
                case (GroupVariation.Group43Var7):
                    return true;
                case (GroupVariation.Group43Var8):
                    return true;
                case (GroupVariation.Group50Var1):
                    return true;
                case (GroupVariation.Group50Var3):
                    return true;
                case (GroupVariation.Group50Var4):
                    return true;
                case (GroupVariation.Group51Var1):
                    return true;
                case (GroupVariation.Group51Var2):
                    return true;
                default:
                    return false;
            }
        }

        public static bool HasRelativeTime(GroupVariation gv)
        {
            switch (gv)
            {
                case (GroupVariation.Group2Var3):
                    return true;
                case (GroupVariation.Group4Var3):
                    return true;
                case (GroupVariation.Group52Var1):
                    return true;
                case (GroupVariation.Group52Var2):
                    return true;
                default:
                    return false;
            }
        }

        public static bool HasFlags(GroupVariation gv)
        {
            switch (gv)
            {
                case (GroupVariation.Group1Var2):
                    return true;
                case (GroupVariation.Group2Var1):
                    return true;
                case (GroupVariation.Group2Var2):
                    return true;
                case (GroupVariation.Group2Var3):
                    return true;
                case (GroupVariation.Group3Var2):
                    return true;
                case (GroupVariation.Group4Var1):
                    return true;
                case (GroupVariation.Group4Var2):
                    return true;
                case (GroupVariation.Group4Var3):
                    return true;
                case (GroupVariation.Group10Var2):
                    return true;
                case (GroupVariation.Group11Var1):
                    return true;
                case (GroupVariation.Group11Var2):
                    return true;
                case (GroupVariation.Group13Var1):
                    return true;
                case (GroupVariation.Group13Var2):
                    return true;
                case (GroupVariation.Group20Var1):
                    return true;
                case (GroupVariation.Group20Var2):
                    return true;
                case (GroupVariation.Group21Var1):
                    return true;
                case (GroupVariation.Group21Var2):
                    return true;
                case (GroupVariation.Group21Var5):
                    return true;
                case (GroupVariation.Group21Var6):
                    return true;
                case (GroupVariation.Group22Var1):
                    return true;
                case (GroupVariation.Group22Var2):
                    return true;
                case (GroupVariation.Group22Var5):
                    return true;
                case (GroupVariation.Group22Var6):
                    return true;
                case (GroupVariation.Group23Var1):
                    return true;
                case (GroupVariation.Group23Var2):
                    return true;
                case (GroupVariation.Group23Var5):
                    return true;
                case (GroupVariation.Group23Var6):
                    return true;
                case (GroupVariation.Group30Var1):
                    return true;
                case (GroupVariation.Group30Var2):
                    return true;
                case (GroupVariation.Group30Var5):
                    return true;
                case (GroupVariation.Group30Var6):
                    return true;
                case (GroupVariation.Group32Var1):
                    return true;
                case (GroupVariation.Group32Var2):
                    return true;
                case (GroupVariation.Group32Var3):
                    return true;
                case (GroupVariation.Group32Var4):
                    return true;
                case (GroupVariation.Group32Var5):
                    return true;
                case (GroupVariation.Group32Var6):
                    return true;
                case (GroupVariation.Group32Var7):
                    return true;
                case (GroupVariation.Group32Var8):
                    return true;
                case (GroupVariation.Group40Var1):
                    return true;
                case (GroupVariation.Group40Var2):
                    return true;
                case (GroupVariation.Group40Var3):
                    return true;
                case (GroupVariation.Group40Var4):
                    return true;
                case (GroupVariation.Group42Var1):
                    return true;
                case (GroupVariation.Group42Var2):
                    return true;
                case (GroupVariation.Group42Var3):
                    return true;
                case (GroupVariation.Group42Var4):
                    return true;
                case (GroupVariation.Group42Var5):
                    return true;
                case (GroupVariation.Group42Var6):
                    return true;
                case (GroupVariation.Group42Var7):
                    return true;
                case (GroupVariation.Group42Var8):
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsEvent(GroupVariation gv)
        {
            switch (gv)
            {
                case (GroupVariation.Group2Var1):
                    return true;
                case (GroupVariation.Group2Var2):
                    return true;
                case (GroupVariation.Group2Var3):
                    return true;
                case (GroupVariation.Group4Var1):
                    return true;
                case (GroupVariation.Group4Var2):
                    return true;
                case (GroupVariation.Group4Var3):
                    return true;
                case (GroupVariation.Group11Var1):
                    return true;
                case (GroupVariation.Group11Var2):
                    return true;
                case (GroupVariation.Group13Var1):
                    return true;
                case (GroupVariation.Group13Var2):
                    return true;
                case (GroupVariation.Group22Var1):
                    return true;
                case (GroupVariation.Group22Var2):
                    return true;
                case (GroupVariation.Group22Var5):
                    return true;
                case (GroupVariation.Group22Var6):
                    return true;
                case (GroupVariation.Group23Var1):
                    return true;
                case (GroupVariation.Group23Var2):
                    return true;
                case (GroupVariation.Group23Var5):
                    return true;
                case (GroupVariation.Group23Var6):
                    return true;
                case (GroupVariation.Group32Var1):
                    return true;
                case (GroupVariation.Group32Var2):
                    return true;
                case (GroupVariation.Group32Var3):
                    return true;
                case (GroupVariation.Group32Var4):
                    return true;
                case (GroupVariation.Group32Var5):
                    return true;
                case (GroupVariation.Group32Var6):
                    return true;
                case (GroupVariation.Group32Var7):
                    return true;
                case (GroupVariation.Group32Var8):
                    return true;
                case (GroupVariation.Group42Var1):
                    return true;
                case (GroupVariation.Group42Var2):
                    return true;
                case (GroupVariation.Group42Var3):
                    return true;
                case (GroupVariation.Group42Var4):
                    return true;
                case (GroupVariation.Group42Var5):
                    return true;
                case (GroupVariation.Group42Var6):
                    return true;
                case (GroupVariation.Group42Var7):
                    return true;
                case (GroupVariation.Group42Var8):
                    return true;
                case (GroupVariation.Group43Var1):
                    return true;
                case (GroupVariation.Group43Var2):
                    return true;
                case (GroupVariation.Group43Var3):
                    return true;
                case (GroupVariation.Group43Var4):
                    return true;
                case (GroupVariation.Group43Var5):
                    return true;
                case (GroupVariation.Group43Var6):
                    return true;
                case (GroupVariation.Group43Var7):
                    return true;
                case (GroupVariation.Group43Var8):
                    return true;
                default:
                    return false;
            }
        }

        public static string LogFlagToString(in LogLevel flag)
        {
            if (flag == opendnp3.flags.Globals.EVENT)
            {
                return "EVENT  ";
            }
            else if (flag == opendnp3.flags.Globals.ERR)
            {
                return "ERROR  ";
            }
            else if (flag == opendnp3.flags.Globals.WARN)
            {
                return "WARN   ";
            }
            else if (flag == opendnp3.flags.Globals.INFO)
            {
                return "INFO   ";
            }
            else if (flag == opendnp3.flags.Globals.DBG)
            {
                return "DEBUG  ";
            }
            else if (flag == opendnp3.flags.Globals.LINK_RX || flag == opendnp3.flags.Globals.LINK_RX_HEX)
            {
                return "<-LL-- ";
            }
            else if (flag == opendnp3.flags.Globals.LINK_TX || flag == opendnp3.flags.Globals.LINK_TX_HEX)
            {
                return "--LL-> ";
            }
            else if (flag == opendnp3.flags.Globals.TRANSPORT_RX)
            {
                return "<-TL-- ";
            }
            else if (flag == opendnp3.flags.Globals.TRANSPORT_TX)
            {
                return "--TL-> ";
            }
            else if (flag == opendnp3.flags.Globals.APP_HEADER_RX || flag == opendnp3.flags.Globals.APP_OBJECT_RX || flag == opendnp3.flags.Globals.APP_HEX_RX)
            {
                return "<-AL-- ";
            }
            else if (flag == opendnp3.flags.Globals.APP_HEADER_TX || flag == opendnp3.flags.Globals.APP_OBJECT_TX || flag == opendnp3.flags.Globals.APP_HEX_TX)
            {
                return "--AL-> ";
            }
            return "UNKNOWN";
        }

        public static HeaderBuilderT ConvertToLambda(List<Header> headers)
        {
            //C++ TO C# CONVERTER TASK: Only lambdas having all locals passed by reference can be converted to C#:
            //ORIGINAL LINE: return [headers](HeaderWriter& writer)->bool
            return (HeaderWriter writer) =>
            {
                foreach (var header in headers)
                {
                    if (!header.WriteTo(writer))
                    {
                        return false;
                    }
                }

                return true;
            };
        }

        public static string operato (string os, in ResponseInfo info)
        {
            os += "unsolicited: " + info.unsolicited + " fir: " + info.fir + " fin: " + info.fin;
            return os;
        }


        //public static IINField select_indices<Spec>(StaticDataMap<Spec> map, ICollection<ushort> indices, Spec.static_variation_t variation)
        //{
        //    var missing_index = false;
        //    //C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
        //    var select = (ushort index) =>
        //    {
        //        if (!map.select(new ushort(index), new Spec.static_variation_t(variation)))
        //        {
        //            missing_index = true;
        //        }
        //    };
        //    indices.ForeachItem(select);

        //    return missing_index ? new IINField(IINBit.PARAM_ERROR) : IINField.Empty();
        //}

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template<class Spec>
        //public static IINField select_indices<Spec>(StaticDataMap<Spec> map, in ICollection<ushort> indices)
        //{
        //    var missing_index = false;
        //    //C++ TO C# CONVERTER TASK: Lambda expressions cannot be assigned to 'var':
        //    var select = (ushort index) =>
        //    {
        //        if (!map.select(new ushort(index)))
        //        {
        //            missing_index = true;
        //        }
        //    };
        //    indices.ForeachItem(select);

        //    return missing_index ? new IINField(IINBit.PARAM_ERROR) : IINField.Empty();
        //}

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template<class Spec>
        //public static bool load_type<Spec>(StaticDataMap<Spec> map, HeaderWriter writer)
        //{
        //    while (true)
        //    {
        //        var iter = map.begin();

        //        if (iter == map.end())
        //        {
        //            // there is no data left to write
        //            return true;
        //        }

        //        if (!StaticWriters.get(iter.second.variation)(map, writer))
        //        {
        //            // the APDU is full
        //            return false;
        //        }
        //    }
        //}

        public static void initialize<T>(SortedDictionary<ushort, T> map, ushort count)
            where T : new()
        {
            for (ushort i = 0; i < count; ++i)
            {
                map[i] = new T();
            }
        }

        public static IINField IINFromParseResult(ParseResult result)
        {
            switch (result)
            {
                case (ParseResult.OK):
                    return IINField.Empty();
                case (ParseResult.UNKNOWN_OBJECT):
                    return new IINField(IINBit.OBJECT_UNKNOWN);
                default:
                    return new IINField(IINBit.PARAM_ERROR);
            }
        }

        public static bool convert_to_event_class(PointClass pc, ref EventClass ec)
        {
            switch (pc)
            {
                case (PointClass.Class1):
                    ec = EventClass.EC1;
                    return true;
                case (PointClass.Class2):
                    ec = EventClass.EC2;
                    return true;
                case (PointClass.Class3):
                    ec = EventClass.EC3;
                    return true;
                default:
                    return false;
            }
        }

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template<class Spec>
        public static Spec.static_variation_t check_for_promotion<Spec>(in Spec.meas_t value, Spec.static_variation_t variation)
        {
            return new Spec.static_variation_t(variation);
        }

        //C++ TO C# CONVERTER TASK: C++ template specialization was removed by C++ to C# Converter:
        //ORIGINAL LINE: StaticBinaryVariation check_for_promotion<BinarySpec>(const Binary& value, StaticBinaryVariation variation)
        public static StaticBinaryVariation check_for_promotion(in Binary value, StaticBinaryVariation variation)
        {
            if (variation == StaticBinaryVariation.Group1Var1)
            {
                return BinarySpec.IsQualityOnlineOnly(value) ? variation : StaticBinaryVariation.Group1Var2;
            }

            return variation;
        }

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template<class Spec>
        public static bool LoadWithRangeIterator<Spec, IndexType>(StaticDataMap<Spec> map, RangeWriteIterator<IndexType, typename Spec.meas_t> writer, Spec.static_variation_t variation)
        {
            var next_index = map.get_selected_range().start;

            foreach (var elem in map)
            {
                if (elem.second.variation != variation)
                {
                    // the variation has changed
                    return true;
                }

                if (elem.first != next_index)
                {
                    // we've loaded all we can with a contiguous range
                    return true;
                }

                if (!writer.Write(elem.second.value))
                {
                    return false;
                }

                ++next_index;
            }

            return true;
        }

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template<class Spec, class IndexType>
        public static bool LoadWithBitfieldIterator<Spec, IndexType>(StaticDataMap<Spec> map, BitfieldRangeWriteIterator<IndexType> iter, Spec.static_variation_t variation)
        {
            var next_index = map.get_selected_range().start;

            foreach (var elem in map)
            {
                if (elem.second.variation != variation)
                {
                    // the variation has changed
                    return true;
                }

                if (elem.first != next_index)
                {
                    // we've loaded all we can with a contiguous range
                    return true;
                }

                if (!iter.Write(elem.second.value.value))
                {
                    return false;
                }

                ++next_index;
            }

            return true;
        }

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template<class Spec, class GV>
        public static bool WriteSingleBitfield<Spec, GV>(StaticDataMap<Spec> map, HeaderWriter writer)
        {
            var range = map.get_selected_range();

            if (range.IsOneByte())
            {
                var write_iter = writer.IterateOverSingleBitfield<ser4cpp.UInt8>(GV.ID(), QualifierCode.UINT8_START_STOP, (byte)range.start);
                return LoadWithBitfieldIterator<Spec, ser4cpp.UInt8>(map, write_iter, GV.svariation);
            }

            var write_iter = writer.IterateOverSingleBitfield < new ser4cpp.Globals.Bit16<ushort, 0, 1>> (GV.ID(), QualifierCode.UINT16_START_STOP, new ushort(range.start));
            return LoadWithBitfieldIterator < Spec, new ser4cpp.Globals.Bit16<ushort, 0, 1>> (map, write_iter, GV.svariation);
        }

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template<class Spec, class Serializer>
        public static bool WriteWithSerializer<Spec, Serializer>(StaticDataMap<Spec> map, HeaderWriter writer)
        {
            var range = map.get_selected_range();

            if (range.IsOneByte())
            {
                var iter = writer.IterateOverRange < ser4cpp.UInt8, typename Serializer.Target > (QualifierCode.UINT8_START_STOP, Serializer.Inst(), (byte)range.start);
                return LoadWithRangeIterator<Spec, ser4cpp.UInt8>(map, iter, Serializer.svariation);
            }

            var iter = writer.IterateOverRange < ser4cpp.Globals.Bit16 < ushort, 0, 1 >, typename Serializer.Target > (QualifierCode.UINT16_START_STOP, Serializer.Inst(), new ushort(range.start));
            return LoadWithRangeIterator < Spec, new ser4cpp.Globals.Bit16<ushort, 0, 1>> (map, iter, Serializer.svariation);
        }

        public static bool write_octet_strings(StaticDataMap<OctetStringSpec> map, HeaderWriter writer)
        {
            var range = map.get_selected_range();

            byte starting_size = (*map.begin()).second.value.Size();
            OctetStringSerializer serializer = new OctetStringSerializer(false, starting_size);

            if (range.IsOneByte())
            {
                var iter = writer.IterateOverRange<ser4cpp.UInt8>(QualifierCode.UINT8_START_STOP, serializer, (byte)range.start);
                return write_some_octet_strings(map, iter);
            }

            var iter = writer.IterateOverRange < new ser4cpp.Globals.Bit16<ushort, 0, 1>> (QualifierCode.UINT16_START_STOP, serializer, new ushort(range.start));
            return write_some_octet_strings(map, iter);
        }


        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template<class Writer>
        public static bool write_some_octet_strings<Writer>(StaticDataMap<OctetStringSpec> map, Writer writer)
        {
            bool first = true;
            byte last_length = 0;
            ushort next_index = 0;

            foreach (var elem in map)
            {

                if (!first)
                {

                    if (next_index != elem.first)
                    {
                        // discontiguous indices
                        return true;
                    }

                    if (last_length != elem.second.value.Size())
                    {
                        // different lengths
                        return true;
                    }
                }

                first = false;
                next_index = elem.first + 1;
                last_length = elem.second.value.Size();

                if (!writer.Write(elem.second.value))
                {
                    return false;
                }
            }

            return true;
        }
        public static BufferedCollection<T, ReadFunc> CreateBufferedCollection<T, ReadFunc>(in RSeq/*<size_t>*/ buffer, /*size_t*/int count, in ReadFunc readFunc)
        {
            return BufferedCollection<T, ReadFunc>(buffer, count, readFunc);
        }
        public static TransformedCollection<T, U, Transform> Map<T, U, Transform>(in ICollection<T> input, Transform transform)
        {
            return TransformedCollection<T, U, Transform>(input, transform);
        }

        public static bool IsSuccess(ParseResult result)
        {
            return result == ParseResult.OK;
        }
        public static bool IsFailure(ParseResult result)
        {
            return result != ParseResult.OK;
        }
        // the default size for an APDU
        public static readonly uint DEFAULT_MAX_APDU_SIZE = 2048;

        // default timeout for the application layer
        //const  TimeDuration DEFAULT_APP_TIMEOUT =  TimeDuration::Seconds(5);
        public static readonly ulong DEFAULT_APP_TIMEOUT = 5;
        //C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
        //Target DownSampling<Source, Target>::TARGET_MAX<Source, Target>(std::numeric_limits<Target>::max() UnnamedParameter);

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template<class Source, class Target>
        //C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
        //Target DownSampling<Source, Target>::TARGET_MIN<Source, Target>(std::numeric_limits<Target>::lowest() UnnamedParameter);
        public static Indexed<T> WithIndex<T>(in T value, ushort index)
        {
            return Indexed<T>(value, index);
        }

        public static readonly byte LPDU_MIN_LENGTH = 5;
        public static readonly byte LPDU_MAX_LENGTH = 255;
        public static readonly byte LPDU_HEADER_SIZE = 10;
        public static readonly byte LPDU_DATA_BLOCK_SIZE = 16;
        public static readonly byte LPDU_CRC_SIZE = 2;
        public static readonly byte LPDU_DATA_PLUS_CRC_SIZE = 18;
        public static readonly byte LPDU_MAX_USER_DATA_SIZE = 250;
        public static readonly ushort LPDU_MAX_FRAME_SIZE = 292; // 10(header) + 250 (user data) + 32 (block CRC's) = 292 frame bytes

        public static readonly uint max_log_entry_size = 120;
        //C++ TO C# CONVERTER TASK: There is no equivalent in C# to templates on variables:
        //public static EventTypeImpl<T> EventTypeImpl<T>.instance = new EventTypeImpl<T>();
        public static object instance = new object();
        /// Maximum TPDU length
        public static readonly byte MAX_TPDU_LENGTH = 250;
        /// Maximum TPDU payload size
        public static readonly byte MAX_TPDU_PAYLOAD = 249;
    }
}

namespace opendnp3.build
{
    public static class Globals
    {
        // -------- requests -------------

        public static void ClassRequest(APDURequest request, FunctionCode fc, in ClassField classes, byte seq)
        {
            request.SetControl(new AppControlField(true, true, false, false, seq));
            request.SetFunction(fc);
            var writer = request.GetWriter();
            WriteClassHeaders(writer, classes);
        }

        public static bool WriteClassHeaders(HeaderWriter writer, in ClassField classes)
        {
            if (classes.HasClass1())
            {
                if (!writer.WriteHeader(Group60Var2.ID(), QualifierCode.ALL_OBJECTS))
                {
                    return false;
                }
            }
            if (classes.HasClass2())
            {
                if (!writer.WriteHeader(Group60Var3.ID(), QualifierCode.ALL_OBJECTS))
                {
                    return false;
                }
            }
            if (classes.HasClass3())
            {
                if (!writer.WriteHeader(Group60Var4.ID(), QualifierCode.ALL_OBJECTS))
                {
                    return false;
                }
            }
            if (classes.HasClass0())
            {
                if (!writer.WriteHeader(Group60Var1.ID(), QualifierCode.ALL_OBJECTS))
                {
                    return false;
                }
            }

            return true;
        }

        public static void ReadIntegrity(APDURequest request, in ClassField classes, byte seq = 0)
        {
            ClassRequest(request, FunctionCode.READ, classes, seq);
        }

        public static void ReadAllObjects(APDURequest request, GroupVariationID gvId, byte seq = 0)
        {
            request.SetControl(new AppControlField(true, true, false, false, seq));
            request.SetFunction(FunctionCode.READ);
            var writer = request.GetWriter();
            writer.WriteHeader(gvId, QualifierCode.ALL_OBJECTS);
        }

        public static void DisableUnsolicited(APDURequest request, byte seq = 0)
        {
            ClassRequest(request, FunctionCode.DISABLE_UNSOLICITED, ClassField.AllEventClasses(), seq);
        }

        public static void EnableUnsolicited(APDURequest request, in ClassField classes, byte seq = 0)
        {
            ClassRequest(request, FunctionCode.ENABLE_UNSOLICITED, classes, seq);
        }

        public static void ClearRestartIIN(APDURequest request, byte seq = 0)
        {
            request.SetFunction(FunctionCode.WRITE);
            request.SetControl(new AppControlField(true, true, false, false, seq));
            var writer = request.GetWriter();
            var iter = writer.IterateOverSingleBitfield<ser4cpp.UInt8>(new GroupVariationID(80, 1), QualifierCode.UINT8_START_STOP, (byte)IINBit.DEVICE_RESTART);
            iter.Write(false);
        }

        public static void MeasureDelay(APDURequest request, byte seq = 0)
        {
            request.SetFunction(FunctionCode.DELAY_MEASURE);
            request.SetControl(AppControlField.Request(seq));
        }

        public static void RecordCurrentTime(APDURequest request, byte seq = 0)
        {
            request.SetFunction(FunctionCode.RECORD_CURRENT_TIME);
            request.SetControl(AppControlField.Request(seq));
        }

        // -------- responses -------------

        public static void NullUnsolicited(APDUResponse response, byte seq, in IINField iin)
        {
            response.SetControl(new AppControlField(true, true, true, true, seq));
            response.SetFunction(FunctionCode.UNSOLICITED_RESPONSE);
            response.SetIIN(iin);
        }
    }
}

namespace opendnp3.logging
{
    public static class Globals
    {
        public static void LogHeader(Logger logger, in LogLevel flags, in APDUHeader header)
        {
            if (logger.is_enabled(flags))
            {
                string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
                SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "FIR: %i FIN: %i CON: %i UNS: %i SEQ: %i FUNC: %s", __VA_ARGS__);
                //C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
                logger.log(flags, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
            };
        }

        public static void LogHeader(Logger logger, in LogLevel flags, in APDUResponseHeader header)
        {
            if (logger.is_enabled(flags))
            {
                string message_buffer_some_name_no_conflict = new string(new char[opendnp3.Globals.max_log_entry_size]);
                SAFE_STRING_FORMAT(message_buffer_some_name_no_conflict, opendnp3.Globals.max_log_entry_size, "FIR: %i FIN: %i CON: %i UNS: %i SEQ: %i FUNC: %s IIN: [0x%02x, 0x%02x]", __VA_ARGS__);
                //C++ TO C# CONVERTER TASK: There is no direct equivalent in C# to the following C++ macro:
                logger.log(flags, "__FILE__ ( __LINE__ )", message_buffer_some_name_no_conflict);
            };
        }

        public static void ParseAndLogRequestTx(Logger logger, in RSeq/*<size_t>*/ apdu)
        {
            if (logger.is_enabled(opendnp3.flags.Globals.APP_HEX_TX))
            {
                //C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
                //ORIGINAL LINE: opendnp3::HexLogging::log(logger, flags::APP_HEX_TX, apdu, ' ', 18, 18);
                opendnp3.HexLogging.log(logger, new opendnp3.LogLevel(opendnp3.flags.Globals.APP_HEX_TX), apdu, ' ', 18, 18);
            };

            if (logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_TX))
            {
                var result = APDUHeaderParser.ParseRequest(apdu, logger);
                if (result.success)
                {
                    LogHeader(logger, opendnp3.flags.Globals.APP_HEADER_TX, result.header);

                    if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_TX))
                    {
                        var expectsContents = result.header.function != FunctionCode.READ;
                        //C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
                        //ORIGINAL LINE: APDUParser::ParseAndLogAll(result.objects, &logger, ParserSettings::Create(expectsContents, flags::APP_OBJECT_TX));
                        APDUParser.ParseAndLogAll(result.objects, logger, ParserSettings.Create(expectsContents, new opendnp3.LogLevel(opendnp3.flags.Globals.APP_OBJECT_TX)));
                    }
                }
            }
        }

        public static void ParseAndLogResponseTx(Logger logger, in RSeq/*<size_t>*/ apdu)
        {
            if (logger.is_enabled(opendnp3.flags.Globals.APP_HEX_TX))
            {
                //C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
                //ORIGINAL LINE: opendnp3::HexLogging::log(logger, flags::APP_HEX_TX, apdu, ' ', 18, 18);
                opendnp3.HexLogging.log(logger, new opendnp3.LogLevel(opendnp3.flags.Globals.APP_HEX_TX), apdu, ' ', 18, 18);
            };

            if (logger.is_enabled(opendnp3.flags.Globals.APP_HEADER_TX))
            {
                var result = APDUHeaderParser.ParseResponse(apdu, logger);
                if (result.success)
                {
                    LogHeader(logger, opendnp3.flags.Globals.APP_HEADER_TX, result.header);

                    if (logger.is_enabled(opendnp3.flags.Globals.APP_OBJECT_TX))
                    {
                        //C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
                        //ORIGINAL LINE: APDUParser::ParseAndLogAll(result.objects, &logger, ParserSettings::Create(true, flags::APP_OBJECT_TX));
                        APDUParser.ParseAndLogAll(result.objects, logger, ParserSettings.Create(true, new opendnp3.LogLevel(opendnp3.flags.Globals.APP_OBJECT_TX)));
                    }
                }
            }
        }
    }
}

namespace opendnp3.measurements
{
    public static class Globals
    {
        public static bool IsEvent<T, U>(in T val1, in T val2, T deadband)
        {
            // T can be unsigned data type so std::abs won't work since it only directly supports signed data types
            // If one uses std::abs and T is unsigned one will get an ambiguous override error.

            U diff = (val2 > val1) ? ((U)val2 - (U)val1) : ((U)val1 - (U)val2);

            return diff > deadband;
        }

        public static bool IsEvent(in TypedMeasurement<double> newMeas, in TypedMeasurement<double> oldMeas, double deadband)
        {
            if (newMeas.flags.value != oldMeas.flags.value)
            {
                return true;
            }

            double diff = Math.Abs(newMeas.value - oldMeas.value);
            if (diff == INFINITY)
            {
                return true;
            }

            return diff > deadband;
        }
    }
}

namespace opendnp3.flags
{
    public static class Globals
    {
        public static bool GetBinaryValue(Flags flags)
        {
            return (flags.value & (byte)BinaryQuality.STATE) != 0;
        }

        public static Flags GetBinaryFlags(Flags flags, bool value)
        {
            return (value) ? new Flags(flags.value | (byte)BinaryQuality.STATE) : new Flags(flags.value & (~(byte)BinaryQuality.STATE));
        }

        // base filters
        public static readonly LogLevel EVENT = new LogLevel(1);
        public static readonly LogLevel ERR = EVENT.next();
        public static readonly LogLevel WARN = ERR.next();
        public static readonly LogLevel INFO = WARN.next();
        public static readonly LogLevel DBG = INFO.next();

        // up-shift the custom dnp3 filters

        public static readonly LogLevel LINK_RX = DBG.next();
        public static readonly LogLevel LINK_RX_HEX = LINK_RX.next();

        public static readonly LogLevel LINK_TX = LINK_RX_HEX.next();
        public static readonly LogLevel LINK_TX_HEX = LINK_TX.next();

        public static readonly LogLevel TRANSPORT_RX = LINK_TX_HEX.next();
        public static readonly LogLevel TRANSPORT_TX = TRANSPORT_RX.next();

        public static readonly LogLevel APP_HEADER_RX = TRANSPORT_TX.next();
        public static readonly LogLevel APP_HEADER_TX = APP_HEADER_RX.next();

        public static readonly LogLevel APP_OBJECT_RX = APP_HEADER_TX.next();
        public static readonly LogLevel APP_OBJECT_TX = APP_OBJECT_RX.next();

        public static readonly LogLevel APP_HEX_RX = APP_OBJECT_TX.next();
        public static readonly LogLevel APP_HEX_TX = APP_HEX_RX.next();
    }
}

public class Globals
{
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

    internal const byte MAX_FIRST_READ_RETRIES = 5;

    //public static virtual void Dispose()
    //{
    //	this.shutdown();
    //	threads.clear();
    //}

    public static void shutdown()
    {
        if (!this.is_shutdown)
        {
            this.is_shutdown = true;
            this.infinite_timer.cancel();
            foreach (var thread in threads)
            {
                thread.join();
            }
        }
    }

    public static void run(uint threadnum)
    {
        this.on_thread_start(threadnum);

        this.io_service.run();

        this.on_thread_exit(threadnum);
    }

    public static readonly asio.io_service io_service;

    public static thread_init_t on_thread_start = new thread_init_t();
    public static thread_init_t on_thread_exit = new thread_init_t();

    public static bool is_shutdown = false;

    public static asio.basic_waitable_timer<std::chrono.steady_clock> infinite_timer = new asio.basic_waitable_timer<std::chrono.steady_clock>();
    public static List<std::thread> threads = new List<std::thread>();
}






namespace ser4cpp.serializers
{
    public static class Globals
    {
        // To use LittleEndian::write(...)
        public static bool write_one(WSeq dest, in opendnp3.DNPTime value)
        {
            return UInt48.write_to(dest, new UInt48Type(value.value));
        }

        public static bool read_one(RSeq input, opendnp3.DNPTime @out)
        {
            UInt48Type temp = new UInt48Type();
            bool result = UInt48.read_from(input, temp);
            //C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
            //ORIGINAL LINE: out.value = temp.Get();
            @out.value = (temp.Get());
            return result;
        }
        public static bool write_one(WSeq dest, in opendnp3.CommandStatus value)
        {
            return UInt8.write_to(dest, opendnp3.CommandStatusSpec.to_type(value));
        }

        public static bool read_one(RSeq input, ref opendnp3.CommandStatus @out)
        {
            byte tempCommandStatus = new byte();
            bool result = UInt8.read_from(input, ref tempCommandStatus);
            @out = opendnp3.CommandStatusSpec.from_type(new byte(tempCommandStatus));
            return result;
        }
        public static bool write_one(WSeq dest, in opendnp3.DoubleBit value)
        {
            return UInt8.write_to(dest, opendnp3.DoubleBitSpec.to_type(value));
        }

        public static bool read_one(RSeq input, ref opendnp3.DoubleBit @out)
        {
            byte tempDoubleBit = new byte();
            bool result = UInt8.read_from(input, ref tempDoubleBit);
            @out = opendnp3.DoubleBitSpec.from_type(new byte(tempDoubleBit));
            return result;
        }
        public static bool write_one(WSeq dest, in opendnp3.FlagsType value)
        {
            return UInt8.write_to(dest, opendnp3.FlagsTypeSpec.to_type(value));
        }

        public static bool read_one(RSeq input, ref opendnp3.FlagsType @out)
        {
            byte tempFlagsType = new byte();
            bool result = UInt8.read_from(input, ref tempFlagsType);
            @out = opendnp3.FlagsTypeSpec.from_type(tempFlagsType);
            return result;
        }
        public static bool write_one(WSeq dest, in opendnp3.FlowControl value)
        {
            return UInt8.write_to(dest, opendnp3.FlowControlSpec.to_type(value));
        }

        public static bool read_one(RSeq input, ref opendnp3.FlowControl @out)
        {
            byte tempFlowControl = new byte();
            bool result = UInt8.read_from(input, ref tempFlowControl);
            @out = opendnp3.FlowControlSpec.from_type(tempFlowControl);
            return result;
        }
        public static bool write_one(WSeq dest, in opendnp3.FunctionCode value)
        {
            return UInt8.write_to(dest, opendnp3.FunctionCodeSpec.to_type(value));
        }

        public static bool read_one(RSeq input, ref opendnp3.FunctionCode @out)
        {
            byte tempFunctionCode = new byte();
            bool result = UInt8.read_from(input, ref tempFunctionCode);
            @out = opendnp3.FunctionCodeSpec.from_type(new byte(tempFunctionCode));
            return result;
        }
        public static bool write_one(WSeq dest, in opendnp3.GroupVariation value)
        {
            return UInt16.write_to(dest, opendnp3.GroupVariationSpec.to_type(value));
        }

        public static bool read_one(RSeq input, ref opendnp3.GroupVariation @out)
        {
            ushort tempGroupVariation = new ushort();
            bool result = UInt16.read_from(input, tempGroupVariation);
            @out = opendnp3.GroupVariationSpec.from_type(tempGroupVariation);
            return result;
        }
        public static bool write_one(WSeq dest, in opendnp3.IntervalUnits value)
        {
            return UInt8.write_to(dest, opendnp3.IntervalUnitsSpec.to_type(value));
        }

        public static bool read_one(RSeq input, ref opendnp3.IntervalUnits @out)
        {
            byte tempIntervalUnits = new byte();
            bool result = UInt8.read_from(input, ref tempIntervalUnits);
            @out = opendnp3.IntervalUnitsSpec.from_type(tempIntervalUnits);
            return result;
        }
        public static bool write_one(WSeq dest, in opendnp3.LinkFunction value)
        {
            return UInt8.write_to(dest, opendnp3.LinkFunctionSpec.to_type(value));
        }

        public static bool read_one(RSeq input, ref opendnp3.LinkFunction @out)
        {
            byte tempLinkFunction = new byte();
            bool result = UInt8.read_from(input, ref tempLinkFunction);
            @out = opendnp3.LinkFunctionSpec.from_type(tempLinkFunction);
            return result;
        }
        public static bool write_one(WSeq dest, in opendnp3.Parity value)
        {
            return UInt8.write_to(dest, opendnp3.ParitySpec.to_type(value));
        }

        public static bool read_one(RSeq input, ref opendnp3.Parity @out)
        {
            byte tempParity = new byte();
            bool result = UInt8.read_from(input, ref tempParity);
            @out = opendnp3.ParitySpec.from_type(new byte(tempParity));
            return result;
        }
        public static bool write_one(WSeq dest, in opendnp3.QualifierCode value)
        {
            return UInt8.write_to(dest, opendnp3.QualifierCodeSpec.to_type(value));
        }

        public static bool read_one(RSeq input, ref opendnp3.QualifierCode @out)
        {
            byte tempQualifierCode = new byte();
            bool result = UInt8.read_from(input, ref tempQualifierCode);
            @out = opendnp3.QualifierCodeSpec.from_type(new byte(tempQualifierCode));
            return result;
        }
        public static bool write_one(WSeq dest, in opendnp3.StopBits value)
        {
            return UInt8.write_to(dest, opendnp3.StopBitsSpec.to_type(value));
        }

        public static bool read_one(RSeq input, ref opendnp3.StopBits @out)
        {
            byte tempStopBits = new byte();
            bool result = UInt8.read_from(input, ref tempStopBits);
            @out = opendnp3.StopBitsSpec.from_type(new byte(tempStopBits));
            return result;
        }
        //C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
        //bool read_one<T>(RSeq input, T @out);

        public static bool read_one<T>(RSeq input, byte @out)
        {
            return UInt8.read_from(input, @out);
        }

        public static bool read_one(RSeq input, Int16 @out)
        {
            return Int16.read_from(input, @out);
        }

        public static bool read_one(RSeq input, ushort @out)
        {
            return UInt16.read_from(input, @out);
        }

        public static bool read_one(RSeq input, int @out)
        {
            return Int32.read_from(input, @out);
        }

        public static bool read_one(RSeq input, uint @out)
        {
            return uint.read_from(input, @out);
        }

        public static bool read_one(RSeq input, long @out)
        {
            return Int64().read_from(input, @out);
        }

        public static bool read_one(RSeq input, ulong @out)
        {
            return UInt64.read_from(input, @out);
        }

        public static bool read_one(RSeq input, UInt48Type @out)
        {
            return UInt48.read_from(input, @out);
        }

        public static bool read_one(RSeq input, ref double @out)
        {
            return DoubleFloat.read_from(input, @out);
        }

        public static bool read_one(RSeq input, ref float @out)
        {
            return SingleFloat.read_from(input, @out);
        }

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template<typename T>
        //C++ TO C# CONVERTER TASK: The implementation of the following method could not be found:
        //bool write_one<T>(WSeq dest, in T value);

        public static bool write_one<T>(WSeq dest, in byte value)
        {
            return UInt8.write_to(dest, value);
        }

        public static bool write_one(WSeq dest, in Int16 value)
        {
            return Int16..write_to(dest, value);
        }

        public static bool write_one(WSeq dest, in ushort value)
        {
            return UInt16.write_to(dest, value);
        }

        public static bool write_one(WSeq dest, in int value)
        {
            return Int32.write_to(dest, value);
        }

        public static bool write_one(WSeq dest, in uint value)
        {
            return uint.write_to(dest, value);
        }

        public static bool write_one(WSeq dest, in long value)
        {
            return Int64.write_to(dest, value);
        }

        public static bool write_one(WSeq dest, in ulong value)
        {
            return UInt64.write_to(dest, value);
        }

        public static bool write_one(WSeq dest, in UInt48Type value)
        {
            return UInt48.write_to(dest, value);
        }

        public static bool write_one(WSeq dest, in double value)
        {
            return DoubleFloat.write_to(dest, value);
        }

        public static bool write_one(WSeq dest, in float value)
        {
            return SingleFloat.write_to(dest, value);
        }
    }
}



namespace opendnp3.priority
{
    public static class Globals
    {
        public static readonly int USER_STATUS_CHANGE = 20;

        public static readonly int UPDATE_KEY_CHANGE = 40;

        public static readonly int SESSION_KEY = 50;

        public static readonly int COMMAND = 100;

        public static readonly int USER_REQUEST = 110;

        public static readonly int CLEAR_RESTART = 120;

        public static readonly int DISABLE_UNSOLICITED = 130;

        public static readonly int ASSIGN_CLASS = 140;

        public static readonly int INTEGRITY_POLL = 150;

        public static readonly int TIME_SYNC = 160;

        public static readonly int ENABLE_UNSOLICITED = 170;

        public static readonly int EVENT_SCAN = 180;

        public static readonly int USER_POLL = 190;
    }
}



namespace ser4cpp
{
    /*
    public static class Globals
    {
        //C++ TO C# CONVERTER TASK: There is no equivalent in C# to templates on variables:
        public static  Bit16<T, B0, B1>.max_value = T.MaxValue;

        //C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
        //ORIGINAL LINE: template <class T, byte B0, byte B1>
        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template <class T, typename B0, typename B1> requires(byte<B0> && byte<B1>)
        //C++ TO C# CONVERTER TASK: There is no equivalent in C# to templates on variables:
        public static readonly T Bit16<T, B0, B1>.min_value = T.MinValue;

        //C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
        //ORIGINAL LINE: template <class T, byte B0, byte B1, byte B2, byte B3>
        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template <class T, typename B0, typename B1, typename B2, typename B3> requires(byte<B0> && byte<B1> && byte<B2> && byte<B3>)
        //C++ TO C# CONVERTER TASK: There is no equivalent in C# to templates on variables:
        public static readonly T Bit32<T, B0, B1, B2, B3>.max_value = T.MaxValue;

        //C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
        //ORIGINAL LINE: template <class T, byte B0, byte B1, byte B2, byte B3>
        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template <class T, typename B0, typename B1, typename B2, typename B3> requires(byte<B0> && byte<B1> && byte<B2> && byte<B3>)
        //C++ TO C# CONVERTER TASK: There is no equivalent in C# to templates on variables:
        public static readonly T Bit32<T, B0, B1, B2, B3>.min_value = T.MinValue;

        //C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
        //ORIGINAL LINE: template <class T, byte B0, byte B1, byte B2, byte B3, byte B4, byte B5, byte B6, byte B7>
        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template <class T, typename B0, typename B1, typename B2, typename B3, typename B4, typename B5, typename B6, typename B7> requires(byte<B0> && byte<B1> && byte<B2> && byte<B3> && byte<B4> && byte<B5> && byte<B6> && byte<B7>)
        //C++ TO C# CONVERTER TASK: There is no equivalent in C# to templates on variables:
        public static readonly T Bit64<T, B0, B1, B2, B3, B4, B5, B6, B7>.max_value = T.MaxValue;

        //C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
        //ORIGINAL LINE: template <class T, byte B0, byte B1, byte B2, byte B3, byte B4, byte B5, byte B6, byte B7>
        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template <class T, typename B0, typename B1, typename B2, typename B3, typename B4, typename B5, typename B6, typename B7> requires(byte<B0> && byte<B1> && byte<B2> && byte<B3> && byte<B4> && byte<B5> && byte<B6> && byte<B7>)
        //C++ TO C# CONVERTER TASK: There is no equivalent in C# to templates on variables:
        public static readonly T Bit64<T, B0, B1, B2, B3, B4, B5, B6, B7>.min_value = T.MinValue;


        //C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
        //ORIGINAL LINE: template <byte B0, byte B1, byte B2, byte B3, byte B4, byte B5>
        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template <typename B0, typename B1, typename B2, typename B3, typename B4, typename B5> requires(byte<B0> && byte<B1> && byte<B2> && byte<B3> && byte<B4> && byte<B5>)
        public static T min<T>(T a, T b)
                where T : IComparable, IComparable<T>
        {
            //return (a < b) ? a : b;
            return (a.CompareTo(b) <= 0) ? b : a;
        }

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template <class T>
        public static T max<T>(T a, T b)
                where T : IComparable, IComparable<T>
        {
            //return (a > b) ? a : b;
            return (a.CompareTo(b) <= 0) ? a : b;
        }

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template <class T>
        public static T bounded<T>(T value, T minimum, T maximum)
        {
            //return Math.Min(Math.Max(value, minimum), maximum);
            throw new NotImplementedException();
        }

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template <class T>
        public static bool is_within_limits<T>(T value, T min, T max)
        {
            throw new NotImplementedException();
            //return (value >= min) && (value <= max);
        }

        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template <class T>
        //public static bool float_equal<T>(T a, T b, T epsillon = 1e-6)
        //{
        //    T diff = a - b;
        //    if (diff < 0)
        //    {
        //        diff = -diff;
        //    }
        //    return diff <= epsillon;
        //}
    }
    */
}
