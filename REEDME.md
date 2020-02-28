# AT Internet for Xamarin

This project gives an example to use AT Internet in Xamarin. 

This project has two parts:
1. Swift project that create a wrapper for the the library Tracker.framework
2. Xamarin Project showing how to use, in Android and IOS

## Compiling a Wrapper

Each change on the swift project, must be compiled and releasing in the Xamarin.iOS.Binding project.

You must to execute the next script to release:

```
cd ~/Projects/ATInternet/ATInternetProxy

rm -Rf build
xcodebuild -sdk iphonesimulator13.2 -project "ATInternetProxy.xcodeproj" -configuration Release
xcodebuild -sdk iphoneos13.2 -project "ATInternetProxy.xcodeproj" -configuration Release

cd build
cp -R "Release-iphoneos" "Release-fat"

cp -R "Release-iphonesimulator/ATInternetProxy.framework/Modules/ATInternetProxy.swiftmodule/" "Release-fat/ATInternetProxy.framework/Modules/ATInternetProxy.swiftmodule/"
lipo -create -output "Release-fat/ATInternetProxy.framework/ATInternetProxy" "Release-iphoneos/ATInternetProxy.framework/ATInternetProxy" "Release-iphonesimulator/ATInternetProxy.framework/ATInternetProxy"
lipo -info "Release-fat/ATInternetProxy.framework/ATInternetProxy"

sharpie bind --sdk=iphoneos13.2 --output="XamarinApiDef" --namespace="Binding" --scope="Release-fat/ATInternetProxy.framework/Headers/" "Release-fat/ATInternetProxy.framework/Headers/ATInternetProxy-Swift.h"

cp XamarinApiDef/ApiDefinitions.cs ../../../Xamarin/Xamarin.IOS.Binding/ApiDefinitions.cs 
```