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


namespace opendnp3
{


//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
public class Node<T>
{
//C++ TO C# CONVERTER TASK: C# has no equivalent to ' = default':
//	Node() = default;

	public T value = default(T);

	private Node<T> prev = null;
	private Node<T> next = null;

//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class U>
//C++ TO C# CONVERTER TASK: C# has no concept of a 'friend' class:
//	friend class List;
}

// A container adapter for a -linked list
//C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
//ORIGINAL LINE: template<class T>
//public class List <T> : ser4cpp.HasLength<list_size_type_t>
//{
//	public class Iterator
//	{
//		public static Iterator From(Node<T> start)
//		{
//			return new Iterator(start);
//		}

////C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
////ORIGINAL LINE: template<class U>
//		public T Find<U>(in U matches)
//		{
//			while (this.current != null)
//			{
//				if (matches(this.current.value))
//				{
//					return (this.current.value);
//				}

//				this.current = this.current.next;
//			}

//			return null;
//		}

////C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
////ORIGINAL LINE: bool HasNext() const
//		public bool HasNext()
//		{
//			return this.current != null;
//		}

//		public Node<T> Next()
//		{
//			if (this.current == null)
//			{
//				return null;
//			}
//			var ret = this.current;
//			this.current = this.current.next;
////C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
////ORIGINAL LINE: return ret;
//			return new opendnp3.Node<T>(ret);
//		}

//		public Node<T> Current()
//		{
//			return this.current;
//		}

//		public T CurrentValue()
//		{
//			return (this.current) != null ? (this.current.value) : null;
//		}

//		private Iterator(Node<T> start)
//		{
//			this.current = start;
//		}

//		private Node<T> current;
//	}

//	//List(list_size_type_t maxSize) : ser4cpp::HasLength<list_size_type_t>(0), underlying(maxSize)
//	public List(list_size_type_t maxSize) : base(0)
//	{
//		Initialize();
//	}

////C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
////ORIGINAL LINE: inline list_size_type_t Capacity() const
//	public list_size_type_t Capacity()
//	{
//		//return underlying.length();
//		return new list_size_type_t(this.length());
//	}

//	public Node<T> Head()
//	{
//		return this.head;
//	}

////C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
////ORIGINAL LINE: inline Iterator Iterate() const
//	public Iterator Iterate()
//	{
////C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
////ORIGINAL LINE: return Iterator::From(this->head);
//		return new opendnp3.List.Iterator(Iterator.From(this.head));
//	}

//	public Node<T> Add(in T value)
//	{
//		return this.Insert(value, this.tail, null);
//	}

////C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
////ORIGINAL LINE: template<class U>
//	public void ForeachWhile<U>(in U select)
//	{
//		var iter = this.Iterate();
//		bool result = true;
//		while (result && iter.HasNext())
//		{
//			result = select(iter.Next().value);
//		}
//	}

////C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
////ORIGINAL LINE: template<class U>
//	public void Foreach<U>(in U action)
//	{
//		var iter = this.Iterate();
//		while (iter.HasNext())
//		{
//			action(iter.Next().value);
//		}
//	}

////C++ TO C# CONVERTER WARNING: The original C++ template specifier was replaced with a C# generic specifier, which may not produce the same behavior:
////ORIGINAL LINE: template<class U>
//	public uint RemoveAll<U>(in U match)
//	{
//		uint count = 0;

//		var iter = this.Iterate();
//		var current = iter.Next();
//		while (current != null)
//		{
//			if (match(current.value))
//			{
//				var removed = current;
////C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
////ORIGINAL LINE: current = iter.Next();
//				current=(iter.Next());
////C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
////ORIGINAL LINE: this->Remove(removed);
//				this.Remove(new opendnp3.Node<T>(removed));
//				++count;
//			}
//			else
//			{
////C++ TO C# CONVERTER TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
////ORIGINAL LINE: current = iter.Next();
//				current.CopyFrom(iter.Next());
//			}
//		}

//		return new uint(count);
//	}

//	public void Remove(Node<T> node)
//	{
//		if (node == this.head) // change of head
//		{
//			this.head = node.next;
//		}

//		if (node == this.tail) // change of tail
//		{
//			this.tail = this.tail.prev;
//		}

//		// attach the adjacent nodes to eachother if they exist
//		List.Link(node.prev, node.next);

//		// node becomes the head of the free list
//		node.prev = null;
//		List.Link(node, this.free);
//		this.free = node;

//		--(this.m_length);
//	}

////C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
////ORIGINAL LINE: bool IsFullAndCapacityNotZero() const
//	public bool IsFullAndCapacityNotZero()
//	{
//		return (this.free) == null && Capacity() > 0;
//	}

//	private Node<T> head = null;
//	private Node<T> tail = null;
//	private Node<T> free = null;

//	private ser4cpp.Array<Node<T>> underlying = new ser4cpp.Array<Node<T>>();


//	private Node<T> Insert(in T value, Node<T> left, Node<T> right)
//	{
//		if (this.free == null)
//		{
//			return null;
//		}

//		// initialize the new node, and increment the size
//		var new_node = this.free;
//		this.free = this.free.next;

//		new_node.value = value;
//		++(this.m_length);

////C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
////ORIGINAL LINE: this->Link(left, new_node);
//		List.Link(left, new opendnp3.Node<T>(new_node));
////C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
////ORIGINAL LINE: this->Link(new_node, right);
//		List.Link(new opendnp3.Node<T>(new_node), right);

//		// change of head
//		if (left == null)
//		{
//			this.head = new_node;
//		}

//		// change of tail
//		if (right == null)
//		{
//			this.tail = new_node;
//		}

////C++ TO C# CONVERTER TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
////ORIGINAL LINE: return new_node;
//		return new opendnp3.Node<T>(new_node);
//	}

//	private static void Link(Node<T> first, Node<T> second)
//	{
//		if (first != null)
//		{
//			first.next = second;
//		}
//		if (second != null)
//		{
//			second.prev = first;
//		}
//	}

//	private void Initialize()
//	{
//		if (underlying.is_empty())
//		{
//			return;
//		}

//		this.free = underlying[0];

//		for (uint i = 1; i < underlying.length(); ++i)
//		{
//			Link(underlying[i - 1], underlying[i]);
//		}
//	}
//}

} // namespace opendnp3

