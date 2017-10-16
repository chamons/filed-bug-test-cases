all:: clean nuget sample

sample::
	
	
nuget:: TestLib.1.0.0.nupkg
	read -p $$'Action Required:\n\tCopy TestLib.1.0.0.nupkg to the location of your local nuget feed.\nPress enter to continue: '
	nuget locals all -clear

TestLib.1.0.0.nupkg:
	sed 's/BUILD_TYPE/lib/g' TestLib/MyClass.cs.in > TestLib/MyClass.cs 
	cp -r nuget.in/ nuget/
	
	msbuild TestLib/TestLib.sln /v:quiet /nologo
	cp TestLib/TestLib.Basic/bin/Debug/TestLib.dll nuget/lib/net47/TestLib.dll
	cp TestLib/TestLib.MacModern/bin/Debug/TestLib.dll nuget/lib/xamarinmac20/TestLib.dll
	cp TestLib/TestLib.iOS/bin/Debug/TestLib.dll nuget/lib/xamarinios10/TestLib.dll
	
	msbuild TestLib/TestLib.sln /t:clean /v:quiet /nologo
	sed 's/BUILD_TYPE/ref/g' TestLib/MyClass.cs.in > TestLib/MyClass.cs 
	msbuild TestLib/TestLib.sln /v:quiet /nologo
	cp TestLib/TestLib.Basic/bin/Debug/TestLib.dll nuget/ref/net47/TestLib.dll
	cp TestLib/TestLib.MacModern/bin/Debug/TestLib.dll nuget/ref/xamarinmac20/TestLib.dll
	cp TestLib/TestLib.iOS/bin/Debug/TestLib.dll nuget/ref/xamarinios10/TestLib.dll
	
	cd nuget && nuget pack
	mv nuget/TestLib.1.0.0.nupkg .

clean::
	rm -rf nuget/
	rm -f TestLib/MyClass.cs
	rm -f TestLib.1.0.0.nupkg
	msbuild TestLib/TestLib.sln /t:clean /v:quiet /nologo
