## Description

I am having trouble with device builds on a project, and have isolated it to this sample.

- MathFramework is an objective-c library with some random stuff and a `void Load ()` C method that I want to call
- I've built it for iOS Device and checked it in `Debug-iphoneos/` directory
- MathUser is a simple Xamarin.iOS project with this in `AppDelegate.cs`.
   - It has a native reference to the checked in framework.
- I had to hack in a gcc_flags to even get past initial compilation, which seems wrong.

```
	[DllImport ("@rpath/MathFramework.framework/MathFramework")]
	internal static extern void Load ();
```

It builds fine for simulator, but fails in AOT on device.

## Steps to Reproduce

- Open `framework_load_issue/MathUser/MathUser.csproj`
- Open project options and fix the `-v -v --gcc_flags="-F/Users/donblas/tmp/ios_framework/Debug-iphoneos"` to point to your specific location
- Build Debug -> Generic Device

```
    /Applications/Xcode94.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/clang  -framework Foundation -framework UIKit -weak_framework MathFramework -weak_framework CFNetwork -Xlinker -rpath -Xlinker @executable_path /Users/donblas/Programming/filed-bug-test-cases/framework_load_issue/MathUser/obj/iPhone/Debug/mtouch-cache/arm64/MathUser.exe.o /Library/Frameworks/Xamarin.iOS.framework/Versions/11.12.0.4/SDKs/MonoTouch.iphoneos.sdk/usr/lib/libmonosgen-2.0.dylib /Library/Frameworks/Xamarin.iOS.framework/Versions/11.12.0.4/SDKs/MonoTouch.iphoneos.sdk/usr/lib/libxamarin-debug.dylib -lz -liconv -gdwarf-2 -std=c99 -I/Library/Frameworks/Xamarin.iOS.framework/Versions/11.12.0.4/SDKs/MonoTouch.iphoneos.sdk/usr/include -isysroot /Applications/Xcode94.app/Contents/Developer/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS11.4.sdk -Qunused-arguments -miphoneos-version-min=11.4 -arch arm64 -shared -read_only_relocs suppress -install_name @rpath/libMathUser.exe.dylib -fapplication-extension -o /Users/donblas/Programming/filed-bug-test-cases/framework_load_issue/MathUser/obj/iPhone/Debug/mtouch-cache/arm64/libMathUser.exe.dylib -DDEBUG
    Process exited with code 1, command:
    /Applications/Xcode94.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/clang  -framework Foundation -framework UIKit -weak_framework MathFramework -weak_framework CFNetwork -Xlinker -rpath -Xlinker @executable_path /Users/donblas/Programming/filed-bug-test-cases/framework_load_issue/MathUser/obj/iPhone/Debug/mtouch-cache/arm64/MathUser.exe.o /Library/Frameworks/Xamarin.iOS.framework/Versions/11.12.0.4/SDKs/MonoTouch.iphoneos.sdk/usr/lib/libmonosgen-2.0.dylib /Library/Frameworks/Xamarin.iOS.framework/Versions/11.12.0.4/SDKs/MonoTouch.iphoneos.sdk/usr/lib/libxamarin-debug.dylib -lz -liconv -gdwarf-2 -std=c99 -I/Library/Frameworks/Xamarin.iOS.framework/Versions/11.12.0.4/SDKs/MonoTouch.iphoneos.sdk/usr/include -isysroot /Applications/Xcode94.app/Contents/Developer/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS11.4.sdk -Qunused-arguments -miphoneos-version-min=11.4 -arch arm64 -shared -read_only_relocs suppress -install_name @rpath/libMathUser.exe.dylib -fapplication-extension -o /Users/donblas/Programming/filed-bug-test-cases/framework_load_issue/MathUser/obj/iPhone/Debug/mtouch-cache/arm64/libMathUser.exe.dylib -DDEBUG
    ld: framework not found MathFramework
    clang : error : linker command failed with exit code 1 (use -v to see invocation)
```
