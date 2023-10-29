using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ser4cpp
{
    //C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
    //ORIGINAL LINE: template </*size_t*/int LENGTH>
    //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
    //ORIGINAL LINE: template <typename LENGTH> requires /*size_t*/int<LENGTH>
    public sealed class StaticBuffer
    {
        private List<byte> _buffer = new List<byte>();
        readonly int LENGTH = 0;
        public StaticBuffer(int lenght)
        {
            _buffer = new List<byte>(lenght);
            LENGTH = lenght;
        }
        //C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
        //	StaticBuffer() = default;

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline RSeq as_seq() const
        public RSeq as_seq()
        {
            return new RSeq(this._buffer.ToArray());
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline RSeq as_seq(/*size_t*/int max_size) const
        public RSeq as_seq(/*size_t*/int max_size)
        {
            return this.as_seq().take(max_size);
        }

        public WSeq as_wseq()
        {
            return new WSeq(this._buffer.ToArray());
        }

        public WSeq as_wseq(/*size_t*/int max_size)
        {
            return new WSeq(this._buffer.ToArray().Take( Math.Min(LENGTH, max_size)).ToArray());
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: inline /*size_t*/int length() const
        public /*size_t*/int length()
        {
            return LENGTH;
        }

        //private byte[] buffer = Arrays.PadReferenceTypeArrayWithDefaultInstances(LENGTH, new byte[] { 0 });
        
    }

}

