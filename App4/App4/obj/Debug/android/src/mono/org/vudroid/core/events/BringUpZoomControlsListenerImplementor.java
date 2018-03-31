package mono.org.vudroid.core.events;


public class BringUpZoomControlsListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		org.vudroid.core.events.BringUpZoomControlsListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_toggleZoomControls:()V:GetToggleZoomControlsHandler:Org.Vudroid.Core.Events.IBringUpZoomControlsListenerInvoker, PdfViewBinding\n" +
			"";
		mono.android.Runtime.register ("Org.Vudroid.Core.Events.IBringUpZoomControlsListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BringUpZoomControlsListenerImplementor.class, __md_methods);
	}


	public BringUpZoomControlsListenerImplementor ()
	{
		super ();
		if (getClass () == BringUpZoomControlsListenerImplementor.class)
			mono.android.TypeManager.Activate ("Org.Vudroid.Core.Events.IBringUpZoomControlsListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void toggleZoomControls ()
	{
		n_toggleZoomControls ();
	}

	private native void n_toggleZoomControls ();

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
