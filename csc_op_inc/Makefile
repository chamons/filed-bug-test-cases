all::
	csc /nologo -out:builtin-types.dll -target:library -debug -unsafe Prim.cs
	csc /nologo -out:not-builtin-types.dll -target:library -debug -unsafe Prim.cs
	csc /nologo -t:exe -out:Test_Not.exe -r:not-builtin-types.dll Test.cs	
	csc /nologo -t:exe -out:Test_Builtin.exe -r:builtin-types.dll Test.cs	
	mono Test_Not.exe
	mono Test_Builtin.exe
