using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ser4cpp
{

    /*
    *	Represents a readonly sequence of bytes with a parameterized length type (L)
    */
    //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
    //ORIGINAL LINE: template <class L>
    public class RSeq : HasLength
    {
        //C++ TO C# CONVERTER TASK: There is no equivalent in C# to 'static_assert':
        //	static_assert(std::numeric_limits<L>::is_integer&& !std::numeric_limits<L>::is_signed, "Must be an unsigned integer");

        public static RSeq empty()
        {
            return new RSeq(null, 0);
        }

        public RSeq() 
            : base(0)
        {}

        public RSeq(byte[] buffer, int length)
            :base(length)
        {
            this.buffer_ = buffer;
        }

        public void make_empty()
        {
            this.buffer_ = null;
            bitArray = new BitArray(0);
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: RSeq take(L count) const
        public RSeq take(int count)
        {
            return new RSeq(this.buffer_, (count < this.length()) ? count : this.length());
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: RSeq skip(L count) const
        //public RSeq skip(int count)
        //{
        //    var num = ser4cpp.Globals.min(this.length(), count);
        //    return new RSeq(this.buffer_ + num, this.length() - num);
        //}

        //public void advance(int count)
        //{
        //    var num = ser4cpp.Globals.min(this.length(), count);
        //    //C++ TO C# CONVERTER TASK: Pointer arithmetic on arrays is not converted:
        //    this.buffer_ += num;
        //    this.m_length -= num;
        //}

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: operator byte const* () const
        //public static implicit operator byte(RSeq ImpliedObject)
        //{
        //    return ImpliedObject.buffer_;
        //}

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: bool equals(const RSeq& rhs) const
        public bool equals(in RSeq rhs)
        {
            return this.bitArray.Equals(rhs.bitArray);
        }

        protected byte[] buffer_ = null;
    }

}

