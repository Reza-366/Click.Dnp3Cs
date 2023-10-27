using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Copyright (c) 2018, Automatak LLC
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided that the
 * following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following
 * disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following
 * disclaimer in the documentation and/or other materials provided with the distribution.
 *
 * 3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote
 * products derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE
 * USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */



namespace ser4cpp
{


    /**
    *	Represents a write-able slice of a buffer located elsewhere. Mediates writing to the buffer
    *	to prevent overruns and other errors. Parameterized by the length type
*/
    //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
    //ORIGINAL LINE: template <class L>
    public class WSeq : HasLength
    {
        //typedef object* (memfunc_t) (object*, const object*, /*size_t*/int);

	public static WSeq empty()
        {
            return new WSeq();
        }

        public WSeq()
        {
        }

        public WSeq(byte[] buffer, int length)
            :base(length)
        {
            this.buffer_ = buffer;
        }

        public void set_all_to(byte value)
        {
            //C++ TO C# CONVERTER TASK: The memory management function 'memset' has no equivalent in C#:
            memset(this.buffer_, value, this.length());
        }

        public void make_empty()
        {
            this.buffer_ = null;
            this.m_length = 0;
        }

        public int advance(int count)
        {
            var num = ser4cpp.Globals.min(count, this.length());
            //C++ TO C# CONVERTER TASK: Pointer arithmetic on arrays is not converted:
            this.buffer_ += num;
            this.m_length -= num;
            return num;
        }

        public bool put(byte @byte)
        {
            if (this.length() == 0)
            {
                return false;
            }
            else
            {
                //C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
                //ORIGINAL LINE: this->buffer_[0] = byte;
                this.buffer_[0].CopyFrom(@byte);
                //C++ TO C# CONVERTER TASK: Pointer arithmetic on arrays is not converted:
                ++this.buffer_;
                --this.m_length;
                return true;
            }
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: WSeq skip(/*size_t*/int count) const
        public WSeq skip(/*size_t*/int count)
        {
            var num = ser4cpp.Globals.min(new /*size_t*/int(count), this.m_length);
            return new WSeq(this.buffer_ + num, this.m_length - num);
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: WSeq take(/*size_t*/int count) const
        public WSeq take(/*size_t*/int count)
        {
            return new WSeq(this.buffer_, ser4cpp.Globals.min(this.m_length, new /*size_t*/int(count)));
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: RSeq<L> readonly() const
        public RSeq @readonly()
        {
            return RSeq(this.buffer_, this.length());
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: operator byte* () const
        public static implicit operator byte(WSeq ImpliedObject)
        {
            return ImpliedObject.buffer_;
        }

        public RSeq copy_from(in RSeq src)
        {
            return this.transfer_from<memcpy>(src);
        }

        public RSeq move_from(in RSeq src)
        {
            return this.transfer_from<memmove>(src);
        }

        //C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
        //ORIGINAL LINE: template <memfunc_t mem_func>
        //C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
        //ORIGINAL LINE: template <typename mem_func> requires memfunc_t<mem_func>
        private RSeq transfer_from<mem_func>(in RSeq src)
        {
            if (src.length() > this.length())
            {
                //C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
                //ORIGINAL LINE: return RSeq<L>::empty();
                return new RSeq(RSeq.empty());
            }
            else
            {
                var ret = this.@readonly().take(src.length());
                mem_func(buffer_, src, src.length());
                this.advance(src.length());
                //C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
                //ORIGINAL LINE: return ret;
                return new RSeq(ret);
            }
        }

        private byte[] buffer_ = null;
    }


#if false
	/**
	*	Represents a write-able slice of a buffer located elsewhere. Mediates writing to the buffer
	*	to prevent overruns and other errors. Parameterized by the length type
*/
	//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
	//ORIGINAL LINE: template <class L>
	public class WSeq <L> : HasLength<L>
{
	typedef object * (memfunc_t)(object*, const object*, /*size_t*/int);

	public static WSeq empty()
	{
		return new WSeq();
	}

	public WSeq()
	{
	}

	public WSeq(byte buffer, L length)
	{
		this.HasLength<L> = length;
		this.buffer_ = buffer;
	}

	public void set_all_to(byte value)
	{
//C++ TO C# CONVERTER TASK: The memory management function 'memset' has no equivalent in C#:
		memset(this.buffer_, value, this.length());
	}

	public void make_empty()
	{
		this.buffer_ = null;
		this.m_length = 0;
	}

	public L advance(L count)
	{
		var num = ser4cpp.Globals.min(count, this.length());
//C++ TO C# CONVERTER TASK: Pointer arithmetic on arrays is not converted:
		this.buffer_ += num;
		this.m_length -= num;
		return num;
	}

	public bool put(byte @byte)
	{
		if (this.length() == 0)
		{
			return false;
		}
		else
		{
//C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
//ORIGINAL LINE: this->buffer_[0] = byte;
			this.buffer_[0].CopyFrom(@byte);
//C++ TO C# CONVERTER TASK: Pointer arithmetic on arrays is not converted:
			++this.buffer_;
			--this.m_length;
			return true;
		}
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: WSeq skip(/*size_t*/int count) const
	public WSeq skip(/*size_t*/int count)
	{
		var num = ser4cpp.Globals.min(new /*size_t*/int(count), this.m_length);
		return new WSeq(this.buffer_ + num, this.m_length - num);
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: WSeq take(/*size_t*/int count) const
	public WSeq take(/*size_t*/int count)
	{
		return new WSeq(this.buffer_, ser4cpp.Globals.min(this.m_length, new /*size_t*/int(count)));
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: RSeq<L> readonly() const
	public RSeq<L> @readonly()
	{
		return RSeq<L>(this.buffer_, this.length());
	}

//C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
//ORIGINAL LINE: operator byte* () const
	public static implicit operator byte(WSeq ImpliedObject)
	{
		return ImpliedObject.buffer_;
	}

	public RSeq<L> copy_from(in RSeq<L> src)
	{
		return this.transfer_from<memcpy>(src);
	}

	public RSeq<L> move_from(in RSeq<L> src)
	{
		return this.transfer_from<memmove>(src);
	}

//C++ TO C# CONVERTER TASK: Most C++ 'constraints' are not converted by C++ to C# Converter:
//ORIGINAL LINE: template <memfunc_t mem_func>
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template <typename mem_func> requires memfunc_t<mem_func>
	private RSeq<L> transfer_from<mem_func>(in RSeq<L> src)
	{
		if (src.length() > this.length())
		{
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return RSeq<L>::empty();
			return new RSeq(RSeq<L>.empty());
		}
		else
		{
			var ret = this.@readonly().take(src.length());
			mem_func(buffer_, src, src.length());
			this.advance(src.length());
//C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
//ORIGINAL LINE: return ret;
			return new RSeq(ret);
		}
	}

	private byte[] buffer_ = null;
}
#endif
}

