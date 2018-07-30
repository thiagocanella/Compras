package md52a6d6a1f3c470c70b56b2159dff268fb;


public class NumericTextBox
	extends android.widget.EditText
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onEditorAction:(I)V:GetOnEditorAction_IHandler\n" +
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"n_onFocusChanged:(ZILandroid/graphics/Rect;)V:GetOnFocusChanged_ZILandroid_graphics_Rect_Handler\n" +
			"n_onTextChanged:(Ljava/lang/CharSequence;III)V:GetOnTextChanged_Ljava_lang_CharSequence_IIIHandler\n" +
			"";
		mono.android.Runtime.register ("Com.Syncfusion.Numericupdown.NumericTextBox, Syncfusion.SfNumericUpDown.Android", NumericTextBox.class, __md_methods);
	}


	public NumericTextBox (android.content.Context p0)
	{
		super (p0);
		if (getClass () == NumericTextBox.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Numericupdown.NumericTextBox, Syncfusion.SfNumericUpDown.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public NumericTextBox (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == NumericTextBox.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Numericupdown.NumericTextBox, Syncfusion.SfNumericUpDown.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public NumericTextBox (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == NumericTextBox.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Numericupdown.NumericTextBox, Syncfusion.SfNumericUpDown.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public NumericTextBox (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == NumericTextBox.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Numericupdown.NumericTextBox, Syncfusion.SfNumericUpDown.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onEditorAction (int p0)
	{
		n_onEditorAction (p0);
	}

	private native void n_onEditorAction (int p0);


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);


	public void onFocusChanged (boolean p0, int p1, android.graphics.Rect p2)
	{
		n_onFocusChanged (p0, p1, p2);
	}

	private native void n_onFocusChanged (boolean p0, int p1, android.graphics.Rect p2);


	public void onTextChanged (java.lang.CharSequence p0, int p1, int p2, int p3)
	{
		n_onTextChanged (p0, p1, p2, p3);
	}

	private native void n_onTextChanged (java.lang.CharSequence p0, int p1, int p2, int p3);

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
