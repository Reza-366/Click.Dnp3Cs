namespace opendnp3
{

	public class EventWriting
	{
//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public EventRecord FindNextSelected<T>(List<EventRecord>.Iterator iter, EventType type)
		{
			while (true)
			{
				var current = iter.CurrentValue();
				if (!current)
				{
					return null;
				}
        
				if (current.state == EventState.selected)
				{
					// we terminate here since the type has changed
					return current.type.IsEqual(type) ? current : null;
				}
        
				iter.Next();
			}
		}

//C++ TO C# CONVERTER WARNING: The original C++ declaration of the following method implementation was not found:
		public ushort WriteSome(List<EventRecord>.Iterator iterator, EventLists lists, IEventWriteHandler handler)
		{
			// don't bother searching
			if (lists.counters.selected == 0)
			{
				return 0;
			}
        
			var value = iterator.Find((in EventRecord record) =>
			{
				return record.state == EventState.selected;
			});
        
			if (!value)
			{
				return 0; // no match
			}
        
			return value.type.WriteSome(iterator, lists, handler);
		}
	}
}
