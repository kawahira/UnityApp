using System;
using System.Collections.Generic;

public class ListItem
{
	public string Title;
	public string Help;
	public List<ListItem> child = null;
	public ListItem(string title, string help)
	{
		Title = title;
		Help = help;
	}
}

