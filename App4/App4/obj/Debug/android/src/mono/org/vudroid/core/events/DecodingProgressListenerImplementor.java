package mono.org.vudroid.core.events;


public class DecodingProgressListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		org.vudroid.core.events.DecodingProgressListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_decodingProgressChanged:(I)V:GetDecodingProgressChanged_IHandler:Org.Vudroid.Core.Events.IDecodingProgressListenerInvoker, PdfViewBinding\n" +
			"";
		mono.android.Runtime.register ("Org.Vudroid.Core.Events.IDecodingProgressListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DecodingProgressListenerImplementor.class, __md_methods);
	}


	public DecodingProgressListenerImplementor ()
	{
		super ();
		if (getClass () == DecodingProgressListenerImplementor.class)
			mono.android.TypeManager.Activate ("Org.Vudroid.Core.Events.IDecodingProgressListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void decodingProgressChanged (int p0)
	{
		n_decodingProgressChanged (p0);
	}

	private native void n_decodingProgressChanged (int p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
