all::
	csc /nologo -t:exe -out:Test_Lib.exe -r:HackLib.dll Test.cs	
	csc /nologo -t:exe -out:Test_XM.exe -d:USE_XM -r:Xamarin.Mac.dll Test.cs
	monodis Test_Lib.exe > test_lib.dis
	monodis Test_XM.exe > test_xm.dis
	MONO_VERBOSE_METHOD=Main mono Test_Lib.exe > test_lib.log
	MONO_VERBOSE_METHOD=Main mono Test_XM.exe > test_xm.log
