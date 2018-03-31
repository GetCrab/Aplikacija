package mono.com.github.jlmd.animatedcircleloadingview;


public class AnimatedCircleLoadingView_AnimationListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.github.jlmd.animatedcircleloadingview.AnimatedCircleLoadingView.AnimationListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnimationEnd:(Z)V:GetOnAnimationEnd_ZHandler:AnimatedLoadingViews.AnimatedCircleLoadingView/IAnimationListenerInvoker, AnimatedCircleLoadingView\n" +
			"";
		mono.android.Runtime.register ("AnimatedLoadingViews.AnimatedCircleLoadingView+IAnimationListenerImplementor, AnimatedCircleLoadingView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AnimatedCircleLoadingView_AnimationListenerImplementor.class, __md_methods);
	}


	public AnimatedCircleLoadingView_AnimationListenerImplementor ()
	{
		super ();
		if (getClass () == AnimatedCircleLoadingView_AnimationListenerImplementor.class)
			mono.android.TypeManager.Activate ("AnimatedLoadingViews.AnimatedCircleLoadingView+IAnimationListenerImplementor, AnimatedCircleLoadingView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onAnimationEnd (boolean p0)
	{
		n_onAnimationEnd (p0);
	}

	private native void n_onAnimationEnd (boolean p0);

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
