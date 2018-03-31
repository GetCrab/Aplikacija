package mono.org.vudroid.core.events;


public class ZoomListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		org.vudroid.core.events.ZoomListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_commitZoom:()V:GetCommitZoomHandler:Org.Vudroid.Core.Events.IZoomListenerInvoker, PdfViewBinding\n" +
			"n_zoomChanged:(FF)V:GetZoomChanged_FFHandler:Org.Vudroid.Core.Events.IZoomListenerInvoker, PdfViewBinding\n" +
			"";
		mono.android.Runtime.register ("Org.Vudroid.Core.Events.IZoomListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ZoomListenerImplementor.class, __md_methods);
	}


	public ZoomListenerImplementor ()
	{
		super ();
		if (getClass () == ZoomListenerImplementor.class)
			mono.android.TypeManager.Activate ("Org.Vudroid.Core.Events.IZoomListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void commitZoom ()
	{
		n_commitZoom ();
	}

	private native void n_commitZoom ();


	public void zoomChanged (float p0, float p1)
	{
		n_zoomChanged (p0, p1);
	}

	private native void n_zoomChanged (float p0, float p1);

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
