package mono.com.joanzapata.pdfview.util;


public class DragPinchListener_OnDragListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.joanzapata.pdfview.util.DragPinchListener.OnDragListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_endDrag:(FF)V:GetEndDrag_FFHandler:Com.Joanzapata.Pdfview.Util.DragPinchListener/IOnDragListenerInvoker, PdfViewBinding\n" +
			"n_onDrag:(FF)V:GetOnDrag_FFHandler:Com.Joanzapata.Pdfview.Util.DragPinchListener/IOnDragListenerInvoker, PdfViewBinding\n" +
			"n_startDrag:(FF)V:GetStartDrag_FFHandler:Com.Joanzapata.Pdfview.Util.DragPinchListener/IOnDragListenerInvoker, PdfViewBinding\n" +
			"";
		mono.android.Runtime.register ("Com.Joanzapata.Pdfview.Util.DragPinchListener+IOnDragListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DragPinchListener_OnDragListenerImplementor.class, __md_methods);
	}


	public DragPinchListener_OnDragListenerImplementor ()
	{
		super ();
		if (getClass () == DragPinchListener_OnDragListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Joanzapata.Pdfview.Util.DragPinchListener+IOnDragListenerImplementor, PdfViewBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void endDrag (float p0, float p1)
	{
		n_endDrag (p0, p1);
	}

	private native void n_endDrag (float p0, float p1);


	public void onDrag (float p0, float p1)
	{
		n_onDrag (p0, p1);
	}

	private native void n_onDrag (float p0, float p1);


	public void startDrag (float p0, float p1)
	{
		n_startDrag (p0, p1);
	}

	private native void n_startDrag (float p0, float p1);

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
