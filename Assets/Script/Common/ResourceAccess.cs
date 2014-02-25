/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Text;

public struct ResouceItem
{
	public int category_;
	public int id_;
	public string name_;
};

/// <summary>
/// Resource access.
/// </summary>
//public class ResourceAccess : ConcurrentBehaviour
public class ResourceAccess : MonoBehaviour
{
//    public class Job : FileBuffer
	public class Job
	{
        public Job( ResouceItem resItem, System.Action< ResourceAccess.Job > callback = null )
         {
			ResItem		= resItem;
            Count       = 0;
            CallBack    = callback;
        }
        public void Update()
        {
            while( Count < 10000000 )
            {
                Count ++ ;
            }
        }
        public void Destroy()
        {
		}
		public ResouceItem ResItem {
			get;
			set;
		}
        public bool IsDestroy {
            get;
            set;
        }
        public int Count {
            get;
            set;
        }
        public System.Action< ResourceAccess.Job > CallBack {
            get;
            set;
        }
    }
 
    void Awake()
    {
        m_Thread = new Thread( threadWork );
		m_Thread.Priority = System.Threading.ThreadPriority.Lowest;
        m_Thread.Start();
    }
    void Update()
    {
		RequestObjectCount	= m_RequestJobList.Count;
		ActiveObjectCount	= RequestObjectCount + m_ActiveJobList.Count;
		TestCode();
	}
    void OnApplicationQuit()
    {
        m_Thread.Abort();
    }
	              
    private void threadWork()
    {
        while( true )
        {
            if( m_ActiveJobList.Count > 0 )
            {
				for ( int i = 0 ;  i < m_ActiveJobList.Count ; ++i )
				{
					ResourceAccess.Job job;
					lock( m_SyncObj )
					{
						job = m_ActiveJobList[0];
                	}
					if ( job.IsDestroy )
					{
						job.Destroy();
                		lock( m_SyncObj )
                		{
                	 		m_ActiveJobList.Remove( job );
							job = null;
						}
					}
				}
			}
            if( m_RequestJobList.Count > 0 )
            {
                ResourceAccess.Job job;
                lock( m_SyncObj )
				{
					job = m_RequestJobList[0];
                }
				if ( job.IsDestroy )
				{
					job.Destroy();
                	lock( m_SyncObj )
                	{
                		m_RequestJobList.Remove( job );
						job = null;
					}
				}
				else
				{
                	Debug.Log( "job start.req =" + m_RequestJobList.Count + " active =" + m_ActiveJobList.Count);
					job.Update();
                	if( job.CallBack != null )
					{
                		job.CallBack( job );
					}
                	lock( m_SyncObj )
                	{
                		m_RequestJobList.Remove( job );
						m_ActiveJobList.Add(job);
					}
                	Debug.Log( "job end.req =" + m_RequestJobList.Count + " active =" + m_ActiveJobList.Count);
				}
			}
			System.Threading.Thread.Sleep(0);
		}
	}
    public void Request( ResouceItem[] resItem, System.Action< ResourceAccess.Job > callback = null )
    {
        lock( m_SyncObj )
        {
			for ( int i = 0 ; i < resItem.Length ; ++i )
			{
	            m_RequestJobList.Add( new ResourceAccess.Job( resItem[i], callback ) );
			}
        }
        Debug.Log( "request job." );
    } 
	private void DestroyList(List< ResourceAccess.Job > list,int category, bool useID = false , int id = 0)
	{
		for ( int i = 0 ; i < list.Count ; ++i )
		{
			ResourceAccess.Job job = list[i];
			if ( job.ResItem.category_ != category ) continue;
			if ( useID && job.ResItem.id_ != id ) continue;
			job.IsDestroy = true;
		}
	}
	public void Destroy(int category, bool useID = false , int id = 0)
	{
		lock( m_SyncObj )
		{
			DestroyList(m_RequestJobList, category, useID, id);
			DestroyList(m_ActiveJobList , category, useID, id);
		}
		Debug.Log( "Request Destroy" + "Category:" + category + " ID:" + id + "UserID:" + useID);
	}
    private Thread m_Thread;
    private List< ResourceAccess.Job >	m_RequestJobList = new List< ResourceAccess.Job >();
    private List< ResourceAccess.Job >	m_ActiveJobList  = new List< ResourceAccess.Job >();
    private Object	m_SyncObj = new Object();
	public int RequestObjectCount { get; set; }
	public int ActiveObjectCount { get; set; }
	private int testProcess = 0;
	void TestCode()
	{
		switch(testProcess)
		{
			case 0 :
				ResouceItem[] resItem;
				resItem = new ResouceItem[3];
				for ( int i = 0 ; i < 3 ; ++i )
				{
					resItem[i].id_ = i;
				}
				resItem[0].category_ = 0;
				resItem[1].category_ = 0;
				resItem[2].category_ = 1;
				Request(resItem);
				++testProcess;
			break;
			case 1 :
			if ( m_ActiveJobList.Count == 3 ) 
			{
				Destroy(0, true, 1);
				++testProcess;
			}
			break;
			case 2 :
			if ( m_ActiveJobList.Count == 2 )
				{
				}
			break;
		}
	}
	void Start()
	{
	}
	/// <summary>
	/// Start this instance.
	/// </summary>
	public FileBuffer fileBuffer_ = new FileBuffer();
	public int loadCount = 0;
	public byte[] data_;
	public long size_;
	public string fname_;
	void Start ()
	{
		fname_	= Application.dataPath + '/' + "test.dat";
		size_		= fileBuffer_.GetSize(fname_) / 4;
		data_		= new byte[size_];	
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update ()
	{
		if ( size_ != 0 )
		{
			fileBuffer_.Load(fname_, data_, size_);
			++loadCount;
		}
//		System.Threading.Thread.Sleep(5000);
	}
	public void OnGUI ()
	{
		StringBuilder text = new StringBuilder ();
		text.Append ("Active Jobs:");
 		text.Append ((m_ActiveJobList.Count).ToString("0"));
		text.Append ("\n");
		for ( int i = 0 ; i < m_ActiveJobList.Count ; ++i )
		{
			ResourceAccess.Job job;
			job = m_ActiveJobList[i];
			text.Append ("[");
			text.Append ((i).ToString("0"));
			text.Append ("]:category:");
			text.Append ((job.ResItem.category_).ToString("0"));
			text.Append (" id:");
			text.Append ((job.ResItem.id_).ToString("0"));
			text.Append (" name:");
			text.Append (job.ResItem.name_);
			text.Append (" destroy:");
			text.Append (job.IsDestroy);
			text.Append ("\n");
		}

		text.Append ("Request Jobs:");
		text.Append ((m_RequestJobList.Count).ToString("0"));
		text.Append ("\n");
		for ( int i = 0 ; i < m_RequestJobList.Count ; ++i )
		{
			ResourceAccess.Job job;
			job = m_RequestJobList[i];
			text.Append ("[");
			text.Append ((i).ToString("0"));
			text.Append ("]:category:");
			text.Append ((job.ResItem.category_).ToString("0"));
			text.Append (" id:");
			text.Append ((job.ResItem.id_).ToString("0"));
			text.Append (" name:");
			text.Append (job.ResItem.name_);
			text.Append (" destroy:");
			text.Append (job.IsDestroy);
			text.Append ("\n");
		}

		GUI.Box (new Rect (5,5,310,80),"");
		GUI.Label (new Rect (10,5,1000,200),text.ToString ());
	}
}
*/
