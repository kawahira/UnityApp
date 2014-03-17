/*
using System.IO;

public class FileBuffer
{
	public byte[] data_ = null;
	public FileInfo finfo_ = null;
	public bool Open(string filename)
	{
		if ( finfo_ == null )
		{
			finfo_ = new FileInfo(filename);
		}
		return finfo_.Exists;
	}
	public long GetSize()
	{
		return finfo_.Exists ? finfo_.Length : 0;
	}
	public bool Load()
	{
		long size = GetSize();
		if ( size == 0 )
		{
			if( data_ == null )
			{
				data_ = new byte[size];	// aligment?
				FileStream fs = finfo_.OpenRead();
				fs.Read(data_, 0, (int)size);
				fs.Flush();
				fs.Close();
			}
		}
		return data_.Length != 0  ? true : false;
	}
	void Destroy()
	{
	}
}
*/
