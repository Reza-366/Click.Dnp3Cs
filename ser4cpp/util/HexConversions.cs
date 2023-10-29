using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

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

    public class HexConversions
    {
        public static char to_hex_char(char c)
        {
            return (char)((c > 9) ? ('A' + (c - 10)) : ('0' + c));
        }

        public static string byte_to_hex(byte b)
        {
            string oss = string.Empty;
            oss += HexConversions.to_hex_char((char)((b & 0xf0) >> 4)) + HexConversions.to_hex_char((char)(b & 0xf));
            return oss;
        }

        public static string to_hex(byte[] buffer, /*size_t*/int length, bool spaced = false)
        {
            string oss = string.Empty;
            int last = length - 1;
            for (int i = 0; i < length; i++)
            {
                char c = Convert.ToChar(buffer[i]);
                oss += HexConversions.to_hex_char(Convert.ToChar((c & 0xf0) >> 4)) + HexConversions.to_hex_char(Convert.ToChar(c & 0xf));
                if (spaced && i != last)
                {
                    oss += " ";
                }
            }
            return oss;
        }

        public static string to_hex(in RSeq buffer, bool spaced = true)
        {
            return to_hex(buffer.Array, buffer.length(), spaced);
        }

        public static string append_hex(List<string> segments)
        {
            string oss = string.Empty;

            foreach (var str in segments)
            {
                oss += str;
            }

            return to_hex(from_hex(oss).as_rslice());
        }

        public static string repeat_hex(byte @byte, ushort count, bool spaced = true)
        {
            Buffer buffer = new Buffer(count);
            buffer.as_wslice().set_all_to(@byte);
            return to_hex(buffer.as_rslice(), spaced);
        }

        public static string increment_hex(byte start, ushort count, bool spaced = true)
        {
            Buffer buffer = new Buffer(count);

            for (ushort i = 0; i < count; ++i)
            {
                buffer[i] = start;
                ++start;
            }

            return to_hex(buffer.as_rslice(), spaced);
        }

        public static Buffer from_hex(in string hex)
        {
            // create a copy of the string without space
            string copy = HexConversions.remove_spaces(hex);

            //annoying when you accidentally put an 'O' instead of zero '0'
            if (copy.IndexOfAny((Convert.ToString("oO")).ToCharArray()) != -1)
            {
                // throw std::invalid_argument("Sequence contains 'o' or 'O'"); //REZA
            }

            if (copy.Length % 2 != 0)
            {
                // throw std::invalid_argument(hex); //REZA
            }

            var num_bytes = copy.Length / 2;
            var buffer = new Buffer(num_bytes);

            for (/*size_t*/int index = 0, pos = 0; pos < copy.Length; ++index, pos += 2)
            {
                uint val = new uint();
                string ss = string.Empty;
                //ss += std::hex << copy.Substring(pos, 2);
                //if ((ss >> val).fail())
                //{
                //   // throw std::invalid_argument(hex); //REZA
                //}
                buffer[index] = (byte)val;
            }

            return buffer;
        }

        private static void remove_spaces_in_place(string hex)
        {
            /*size_t*/
            int pos = hex.IndexOfAny((Convert.ToString(' ')).ToCharArray());
            if (pos != -1)
            {
                hex = hex.Remove(pos, 1).Insert(pos, "");
                remove_spaces_in_place(hex);
            }
        }

        private static string remove_spaces(in string hex)
        {
            string copy = hex;
            remove_spaces_in_place(copy);
            return copy;
        }
    }

}

