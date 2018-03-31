package mono.com.joanzapata.pdfview.listener;


public class OnLoadCompleteListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.joanzapata.pdfview.listener.OnLoadCompleteListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_loadComplete:(I)V:GetLoadComplete_IHandler:Com.Joanzapata.Pdfview.Listener.IOnLoadCompleteListenerInvoker, PdfViewBinding\n" +
			"";
		mono.android.Runtime.register ("Com.Joanzapata.Pdfview.Listener.IOnLoadCompleteListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", OnLoadCompleteListenerImplementor.class, __md_methods);
	}


	public OnLoadCompleteListenerImplementor ()
	{
		super ();
		if (getClass () == OnLoadCompleteListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Joanzapata.Pdfview.Listener.IOnLoadCompleteListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void loadComplete (int p0)
	{
		n_loadComplete (p0);
	}

	private native void n_loadComplete (int p0);

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
