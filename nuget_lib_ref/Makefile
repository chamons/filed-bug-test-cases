all:: clean nuget sample

sample:: sample-standard sample-packageref

sample-packageref::
	nuget restore Sample.PackageRef/Sample.sln
	msbuild Sample.PackageRef/Sample.sln /v:quiet /nologo
	echo "Testing package refs"
	echo "These all should be lib but are ref (since things do not work)"
	mono ./Sample.PackageRef/Sample.Console/bin/Debug/Sample.Console.exe
	./Sample.PackageRef/Sample.MacFull/bin/Debug/Sample.MacFull.app/Contents/MacOS/Sample.MacFull
	./Sample.PackageRef/Sample.MacModern/bin/Debug/Sample.MacModern.app/Contents/MacOS/Sample.MacModern
	read -p $$'Action Required:\n\tTest ./Sample.PackageRef/Sample.iOS/Sample.iOS.csproj by hand.\nPress enter to continue: '

sample-standard::
	nuget restore Sample.StandardRef/Sample.sln
	msbuild Sample.StandardRef/Sample.sln /v:quiet /nologo
	echo "Testing standard refs"
	echo "These all should be lib if things are working"
	mono ./Sample.StandardRef/Sample.Console/bin/Debug/Sample.Console.exe
	./Sample.StandardRef/Sample.MacFull/bin/Debug/Sample.MacFull.app/Contents/MacOS/Sample.MacFull
	./Sample.StandardRef/Sample.MacModern/bin/Debug/Sample.MacModern.app/Contents/MacOS/Sample.MacModern
	read -p $$'Action Required:\n\tTest ./Sample.StandardRef/Sample.iOS/Sample.iOS.csproj by hand.\nPress enter to continue: '

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
	msbuild Sample.StandardRef/Sample.sln /t:clean /v:quiet /nologo
