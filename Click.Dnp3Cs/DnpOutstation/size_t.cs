using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;

namespace opendnp3
{
    using global::System.Globalization;
    using global::System.Runtime.InteropServices;
    using global::System.Security;
    using global::System;

    //
    // Summary:
    //     Represents a 32-bit signed integer.
    [Serializable]
    [ComVisible(true)]
    public struct /*size_t*/int : IComparable, IFormattable, IConvertible, IComparable</*size_t*/int>, IEquatable</*size_t*/int>
    {
        internal int m_value;

        //
        // Summary:
        //     Represents the largest possible value of an System.Int32. This field is constant.

        public const int MaxValue = 2147483647;

        //
        // Summary:
        //     Represents the smallest possible value of System.Int32. This field is constant.

        public const int MinValue = -2147483648;

        //
        // Summary:
        //     Compares this instance to a specified object and returns an indication of their
        //     relative values.
        //
        // Parameters:
        //   value:
        //     An object to compare, or null.
        //
        // Returns:
        //     A signed number indicating the relative values of this instance and value. Return
        //     Value Description Less than zero This instance is less than value. Zero This
        //     instance is equal to value. Greater than zero This instance is greater than value.
        //     -or- value is null.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     value is not an System.Int32.
        public int CompareTo(object value)
        {
            if (value == null)
            {
                return 1;
            }

            if (value is int)
            {
                int num = (int)value;
                if (this < num)
                {
                    return -1;
                }

                if (this > num)
                {
                    return 1;
                }

                return 0;
            }

            throw new ArgumentException(Environment.GetResourceString("Arg_MustBeInt32"));
        }

        //
        // Summary:
        //     Compares this instance to a specified 32-bit signed integer and returns an indication
        //     of their relative values.
        //
        // Parameters:
        //   value:
        //     An integer to compare.
        //
        // Returns:
        //     A signed number indicating the relative values of this instance and value. Return
        //     Value Description Less than zero This instance is less than value. Zero This
        //     instance is equal to value. Greater than zero This instance is greater than value.

        public int CompareTo(int value)
        {
            if (this < value)
            {
                return -1;
            }

            if (this > value)
            {
                return 1;
            }

            return 0;
        }

        //
        // Summary:
        //     Returns a value indicating whether this instance is equal to a specified object.
        //
        // Parameters:
        //   obj:
        //     An object to compare with this instance.
        //
        // Returns:
        //     true if obj is an instance of System.Int32 and equals the value of this instance;
        //     otherwise, false.

        public override bool Equals(object obj)
        {
            if (!(obj is int))
            {
                return false;
            }

            return this == (int)obj;
        }

        //
        // Summary:
        //     Returns a value indicating whether this instance is equal to a specified System.Int32
        //     value.
        //
        // Parameters:
        //   obj:
        //     An System.Int32 value to compare to this instance.
        //
        // Returns:
        //     true if obj has the same value as this instance; otherwise, false.
        

        public bool Equals(/*size_t*/int obj)
        {
            return this == obj;
        }

        //
        // Summary:
        //     Returns the hash code for this instance.
        //
        // Returns:
        //     A 32-bit signed integer hash code.

        public override int GetHashCode()
        {
            return this;
        }

        //
        // Summary:
        //     Converts the numeric value of this instance to its equivalent string representation.
        //
        // Returns:
        //     The string representation of the value of this instance, consisting of a negative
        //     sign if the value is negative, and a sequence of digits ranging from 0 to 9 with
        //     no leading zeroes.
        [SecuritySafeCritical]

        public override string ToString()
        {
            return Number.FormatInt32(this, null, NumberFormatInfo.CurrentInfo);
        }

        //
        // Summary:
        //     Converts the numeric value of this instance to its equivalent string representation,
        //     using the specified format.
        //
        // Parameters:
        //   format:
        //     A standard or custom numeric format string.
        //
        // Returns:
        //     The string representation of the value of this instance as specified by format.
        //
        // Exceptions:
        //   T:System.FormatException:
        //     format is invalid or not supported.
        [SecuritySafeCritical]

        public string ToString(string format)
        {
            return Number.FormatInt32(this, format, NumberFormatInfo.CurrentInfo);
        }

        //
        // Summary:
        //     Converts the numeric value of this instance to its equivalent string representation
        //     using the specified culture-specific format information.
        //
        // Parameters:
        //   provider:
        //     An object that supplies culture-specific formatting information.
        //
        // Returns:
        //     The string representation of the value of this instance as specified by provider.
        [SecuritySafeCritical]

        public string ToString(IFormatProvider provider)
        {
            return Number.FormatInt32(this, null, NumberFormatInfo.GetInstance(provider));
        }

        //
        // Summary:
        //     Converts the numeric value of this instance to its equivalent string representation
        //     using the specified format and culture-specific format information.
        //
        // Parameters:
        //   format:
        //     A standard or custom numeric format string.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information.
        //
        // Returns:
        //     The string representation of the value of this instance as specified by format
        //     and provider.
        //
        // Exceptions:
        //   T:System.FormatException:
        //     format is invalid or not supported.
        [SecuritySafeCritical]

        public string ToString(string format, IFormatProvider provider)
        {
            return Number.FormatInt32(this, format, NumberFormatInfo.GetInstance(provider));
        }

        //
        // Summary:
        //     Converts the string representation of a number to its 32-bit signed integer equivalent.
        //
        // Parameters:
        //   s:
        //     A string containing a number to convert.
        //
        // Returns:
        //     A 32-bit signed integer equivalent to the number contained in s.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s is null.
        //
        //   T:System.FormatException:
        //     s is not in the correct format.
        //
        //   T:System.OverflowException:
        //     s represents a number less than System.Int32.MinValue or greater than System.Int32.MaxValue.

        public static int Parse(string s)
        {
            return Number.ParseInt32(s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo);
        }

        //
        // Summary:
        //     Converts the string representation of a number in a specified style to its 32-bit
        //     signed integer equivalent.
        //
        // Parameters:
        //   s:
        //     A string containing a number to convert.
        //
        //   style:
        //     A bitwise combination of the enumeration values that indicates the style elements
        //     that can be present in s. A typical value to specify is System.Globalization.NumberStyles.Integer.
        //
        // Returns:
        //     A 32-bit signed integer equivalent to the number specified in s.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s is null.
        //
        //   T:System.ArgumentException:
        //     style is not a System.Globalization.NumberStyles value. -or- style is not a combination
        //     of System.Globalization.NumberStyles.AllowHexSpecifier and System.Globalization.NumberStyles.HexNumber
        //     values.
        //
        //   T:System.FormatException:
        //     s is not in a format compliant with style.
        //
        //   T:System.OverflowException:
        //     s represents a number less than System.Int32.MinValue or greater than System.Int32.MaxValue.
        //     -or- s includes non-zero, fractional digits.



        //
        // Summary:
        //     Converts the string representation of a number in a specified culture-specific
        //     format to its 32-bit signed integer equivalent.
        //
        // Parameters:
        //   s:
        //     A string containing a number to convert.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information about s.
        //
        // Returns:
        //     A 32-bit signed integer equivalent to the number specified in s.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s is null.
        //
        //   T:System.FormatException:
        //     s is not of the correct format.
        //
        //   T:System.OverflowException:
        //     s represents a number less than System.Int32.MinValue or greater than System.Int32.MaxValue.

        public static int Parse(string s, IFormatProvider provider)
        {
            return Number.ParseInt32(s, NumberStyles.Integer, NumberFormatInfo.GetInstance(provider));
        }

        //
        // Summary:
        //     Converts the string representation of a number in a specified style and culture-specific
        //     format to its 32-bit signed integer equivalent.
        //
        // Parameters:
        //   s:
        //     A string containing a number to convert.
        //
        //   style:
        //     A bitwise combination of enumeration values that indicates the style elements
        //     that can be present in s. A typical value to specify is System.Globalization.NumberStyles.Integer.
        //
        //   provider:
        //     An object that supplies culture-specific information about the format of s.
        //
        // Returns:
        //     A 32-bit signed integer equivalent to the number specified in s.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s is null.
        //
        //   T:System.ArgumentException:
        //     style is not a System.Globalization.NumberStyles value. -or- style is not a combination
        //     of System.Globalization.NumberStyles.AllowHexSpecifier and System.Globalization.NumberStyles.HexNumber
        //     values.
        //
        //   T:System.FormatException:
        //     s is not in a format compliant with style.
        //
        //   T:System.OverflowException:
        //     s represents a number less than System.Int32.MinValue or greater than System.Int32.MaxValue.
        //     -or- s includes non-zero, fractional digits.

        public static int Parse(string s, NumberStyles style, IFormatProvider provider)
        {
            NumberFormatInfo.ValidateParseStyleInteger(style);
            return Number.ParseInt32(s, style, NumberFormatInfo.GetInstance(provider));
        }

        //
        // Summary:
        //     Converts the string representation of a number to its 32-bit signed integer equivalent.
        //     A return value indicates whether the conversion succeeded.
        //
        // Parameters:
        //   s:
        //     A string containing a number to convert.
        //
        //   result:
        //     When this method returns, contains the 32-bit signed integer value equivalent
        //     of the number contained in s, if the conversion succeeded, or zero if the conversion
        //     failed. The conversion fails if the s parameter is null or System.String.Empty,
        //     is not of the correct format, or represents a number less than System.Int32.MinValue
        //     or greater than System.Int32.MaxValue. This parameter is passed uninitialized;
        //     any value originally supplied in result will be overwritten.
        //
        // Returns:
        //     true if s was converted successfully; otherwise, false.

        public static bool TryParse(string s, out int result)
        {
            return Number.TryParseInt32(s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
        }

        //
        // Summary:
        //     Converts the string representation of a number in a specified style and culture-specific
        //     format to its 32-bit signed integer equivalent. A return value indicates whether
        //     the conversion succeeded.
        //
        // Parameters:
        //   s:
        //     A string containing a number to convert. The string is interpreted using the
        //     style specified by style.
        //
        //   style:
        //     A bitwise combination of enumeration values that indicates the style elements
        //     that can be present in s. A typical value to specify is System.Globalization.NumberStyles.Integer.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information about s.
        //
        //   result:
        //     When this method returns, contains the 32-bit signed integer value equivalent
        //     of the number contained in s, if the conversion succeeded, or zero if the conversion
        //     failed. The conversion fails if the s parameter is null or System.String.Empty,
        //     is not in a format compliant with style, or represents a number less than System.Int32.MinValue
        //     or greater than System.Int32.MaxValue. This parameter is passed uninitialized;
        //     any value originally supplied in result will be overwritten.
        //
        // Returns:
        //     true if s was converted successfully; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     style is not a System.Globalization.NumberStyles value. -or- style is not a combination
        //     of System.Globalization.NumberStyles.AllowHexSpecifier and System.Globalization.NumberStyles.HexNumber
        //     values.

        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out int result)
        {
            NumberFormatInfo.ValidateParseStyleInteger(style);
            return Number.TryParseInt32(s, style, NumberFormatInfo.GetInstance(provider), out result);
        }

        //
        // Summary:
        //     Returns the System.TypeCode for value type System.Int32.
        //
        // Returns:
        //     The enumerated constant, System.TypeCode.Int32.
        public TypeCode GetTypeCode()
        {
            return TypeCode.Int32;
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToBoolean(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     true if the value of the current instance is not zero; otherwise, false.

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(this);
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToChar(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     The value of the current instance, converted to a System.Char.

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(this);
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToSByte(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     The value of the current instance, converted to an System.SByte.

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(this);
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToByte(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     The value of the current instance, converted to a System.Byte.

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(this);
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToInt16(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     The value of the current instance, converted to an System.Int16.

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(this);
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToUInt16(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     The value of the current instance, converted to a System.UInt16.

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(this);
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToInt32(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     The value of the current instance, unchanged.

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return this;
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToUInt32(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     The value of the current instance, converted to a System.UInt32.

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(this);
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToInt64(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     The value of the current instance, converted to an System.Int64.

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(this);
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToUInt64(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     The value of the current instance, converted to a System.UInt64.

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(this);
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToSingle(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     The value of the current instance, converted to a System.Single.

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(this);
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToDouble(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     The value of the current instance, converted to a System.Double.

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(this);
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToDecimal(System.IFormatProvider).
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     The value of the current instance, converted to a System.Decimal.

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(this);
        }

        //
        // Summary:
        //     This conversion is not supported. Attempting to use this method throws an System.InvalidCastException.
        //
        // Parameters:
        //   provider:
        //     This parameter is ignored.
        //
        // Returns:
        //     This conversion is not supported. No value is returned.
        //
        // Exceptions:
        //   T:System.InvalidCastException:
        //     In all cases.

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", "Int32", "DateTime"));
        }

        //
        // Summary:
        //     For a description of this member, see System.IConvertible.ToType(System.Type,System.IFormatProvider).
        //
        // Parameters:
        //   type:
        //     The type to which to convert this System.Int32 value.
        //
        //   provider:
        //     An object that provides information about the format of the returned value.
        //
        // Returns:
        //     The value of the current instance, converted to type.

        object IConvertible.ToType(Type type, IFormatProvider provider)
        {
            return Convert.DefaultToType(this, type, provider);
        }
    }
}
