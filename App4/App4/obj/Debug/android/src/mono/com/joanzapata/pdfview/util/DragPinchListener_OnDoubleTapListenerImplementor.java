package mono.com.joanzapata.pdfview.util;


public class DragPinchListener_OnDoubleTapListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.joanzapata.pdfview.util.DragPinchListener.OnDoubleTapListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDoubleTap:(FF)V:GetOnDoubleTap_FFHandler:Com.Joanzapata.Pdfview.Util.DragPinchListener/IOnDoubleTapListenerInvoker, PdfViewBinding\n" +
			"";
		mono.android.Runtime.register ("Com.Joanzapata.Pdfview.Util.DragPinchListener+IOnDoubleTapListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DragPinchListener_OnDoubleTapListenerImplementor.class, __md_methods);
	}


	public DragPinchListener_OnDoubleTapListenerImplementor ()
	{
		super ();
		if (getClass () == DragPinchListener_OnDoubleTapListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Joanzapata.Pdfview.Util.DragPinchListener+IOnDoubleTapListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onDoubleTap (float p0, float p1)
	{
		n_onDoubleTap (p0, p1);
	}

	private native void n_onDoubleTap (float p0, float p1);

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
