package md589ef131702bfd4700f1df21205a78163;


public class ViewHolderInfo
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("App4.Resources.ViewHolderInfo, App4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ViewHolderInfo.class, __md_methods);
	}


	public ViewHolderInfo ()
	{
		super ();
		if (getClass () == ViewHolderInfo.class)
			mono.android.TypeManager.Activate ("App4.Resources.ViewHolderInfo, App4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
