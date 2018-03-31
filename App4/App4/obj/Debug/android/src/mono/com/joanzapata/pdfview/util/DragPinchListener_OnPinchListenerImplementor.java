package mono.com.joanzapata.pdfview.util;


public class DragPinchListener_OnPinchListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.joanzapata.pdfview.util.DragPinchListener.OnPinchListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPinch:(FLandroid/graphics/PointF;)V:GetOnPinch_FLandroid_graphics_PointF_Handler:Com.Joanzapata.Pdfview.Util.DragPinchListener/IOnPinchListenerInvoker, PdfViewBinding\n" +
			"";
		mono.android.Runtime.register ("Com.Joanzapata.Pdfview.Util.DragPinchListener+IOnPinchListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DragPinchListener_OnPinchListenerImplementor.class, __md_methods);
	}


	public DragPinchListener_OnPinchListenerImplementor ()
	{
		super ();
		if (getClass () == DragPinchListener_OnPinchListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Joanzapata.Pdfview.Util.DragPinchListener+IOnPinchListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onPinch (float p0, android.graphics.PointF p1)
	{
		n_onPinch (p0, p1);
	}

	private native void n_onPinch (float p0, android.graphics.PointF p1);

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
