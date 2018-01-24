all::
	@echo First we use mcs and it works
	mcs /nologo -out:builtin-types.dll -target:library -debug -unsafe Prim.cs
	csc /nologo -t:exe -out:Test_mcs_Builtin.exe -r:builtin-types.dll Test.cs	
	mono Test_mcs_Builtin.exe
	@echo Now we use a non-special name with csc and it works
	csc /nologo -out:not-builtin-types.dll -target:library -debug -unsafe Prim.cs
	csc /nologo -t:exe -out:Test_Not.exe -r:not-builtin-types.dll Test.cs	
	mono Test_Not.exe
	@echo Now we try csc and a special name and it fails
	csc /nologo -out:builtin-types.dll -target:library -debug -unsafe Prim.cs
	csc /nologo -t:exe -out:Test_Builtin.exe -r:builtin-types.dll Test.cs	
	mono Test_Builtin.exe
