package mono.com.joanzapata.pdfview.listener;


public class OnDrawListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.joanzapata.pdfview.listener.OnDrawListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLayerDrawn:(Landroid/graphics/Canvas;FFI)V:GetOnLayerDrawn_Landroid_graphics_Canvas_FFIHandler:Com.Joanzapata.Pdfview.Listener.IOnDrawListenerInvoker, PdfViewBinding\n" +
			"";
		mono.android.Runtime.register ("Com.Joanzapata.Pdfview.Listener.IOnDrawListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", OnDrawListenerImplementor.class, __md_methods);
	}


	public OnDrawListenerImplementor ()
	{
		super ();
		if (getClass () == OnDrawListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Joanzapata.Pdfview.Listener.IOnDrawListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onLayerDrawn (android.graphics.Canvas p0, float p1, float p2, int p3)
	{
		n_onLayerDrawn (p0, p1, p2, p3);
	}

	private native void n_onLayerDrawn (android.graphics.Canvas p0, float p1, float p2, int p3);

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
