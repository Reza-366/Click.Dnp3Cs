using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ser4cpp
{

    //C++ TO C# CONVERTER TASK: C# has no concept of 'private' inheritance:
    //ORIGINAL LINE: class Buffer : public HasLength</*size_t*/int>, private Uncopyable
    //C++ TO C# CONVERTER TASK: Multiple inheritance is not available in C#:
    public class Buffer : HasLength //</*size_t*/int>, Uncopyable
    {
        public Buffer()
                : base(0)
        {
        }

        //C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
        //	~Buffer() = default;

        public Buffer(int length)
                : base(length)
        {
            this._bytes = new List<byte>(length);
        }

        //C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
        //	Buffer(Buffer&&) = default;
        //C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
        //	Buffer& operator =(Buffer&&) = default;

        // initialize with the exact length and contents
        public Buffer(in RSeq input)
                : this(input.length())
        {
            this.as_wslice().copy_from(input);
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline RSeq as_rslice() const
        public RSeq as_rslice()
        {
            return new RSeq(this._bytes.ToArray());
        }

        public WSeq as_wslice()
        {
            return new WSeq(this._bytes.ToArray());
        }

        public byte this[int index]
        {
            get
            {
                return _bytes[index];
            }
            set
            {
                _bytes[index] = value;
            }
        }


        private List<byte> _bytes = new List<byte>();
    }

}

