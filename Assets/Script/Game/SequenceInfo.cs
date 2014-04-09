using System;

namespace Game
{
	public class SequenceInfo
	{
			public int sceneIndex = 0;
			public SerializeData.Sequence	data;
			public SequenceInfo (SerializeData.Sequence seqData)
			{
				data 				= seqData;
				sceneIndex	= 0;
			}
	}
}