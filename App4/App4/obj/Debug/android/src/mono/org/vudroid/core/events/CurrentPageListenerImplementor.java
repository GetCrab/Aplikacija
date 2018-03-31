package mono.org.vudroid.core.events;


public class CurrentPageListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		org.vudroid.core.events.CurrentPageListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_currentPageChanged:(I)V:GetCurrentPageChanged_IHandler:Org.Vudroid.Core.Events.ICurrentPageListenerInvoker, PdfViewBinding\n" +
			"";
		mono.android.Runtime.register ("Org.Vudroid.Core.Events.ICurrentPageListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CurrentPageListenerImplementor.class, __md_methods);
	}


	public CurrentPageListenerImplementor ()
	{
		super ();
		if (getClass () == CurrentPageListenerImplementor.class)
			mono.android.TypeManager.Activate ("Org.Vudroid.Core.Events.ICurrentPageListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void currentPageChanged (int p0)
	{
		n_currentPageChanged (p0);
	}

	private native void n_currentPageChanged (int p0);

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
