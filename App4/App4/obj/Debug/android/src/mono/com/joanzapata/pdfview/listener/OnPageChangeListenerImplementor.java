package mono.com.joanzapata.pdfview.listener;


public class OnPageChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.joanzapata.pdfview.listener.OnPageChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPageChanged:(II)V:GetOnPageChanged_IIHandler:Com.Joanzapata.Pdfview.Listener.IOnPageChangeListenerInvoker, PdfViewBinding\n" +
			"";
		mono.android.Runtime.register ("Com.Joanzapata.Pdfview.Listener.IOnPageChangeListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", OnPageChangeListenerImplementor.class, __md_methods);
	}


	public OnPageChangeListenerImplementor ()
	{
		super ();
		if (getClass () == OnPageChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Joanzapata.Pdfview.Listener.IOnPageChangeListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onPageChanged (int p0, int p1)
	{
		n_onPageChanged (p0, p1);
	}

	private native void n_onPageChanged (int p0, int p1);

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
