using System;
using Foundation;

namespace Binding
{
	// @interface ATInternetProxy : NSObject
	[BaseType (typeof(NSObject))]
	interface ATInternetProxy
	{
		// -(BOOL)initTrackerWithSiteId:(NSInteger)siteId server:(NSString * _Nonnull)server log:(NSString * _Nonnull)log secureLog:(NSString * _Nonnull)secureLog enableDebugger:(BOOL)enableDebugger verbose:(BOOL)verbose __attribute__((warn_unused_result)) __attribute__((objc_method_family("none")));
		[Export ("initTrackerWithSiteId:server:log:secureLog:enableDebugger:verbose:")]
		bool InitTrackerWithSiteId (nint siteId, string server, string log, string secureLog, bool enableDebugger, bool verbose);

		// -(BOOL)trackViewWithView:(NSString * _Nonnull)view __attribute__((warn_unused_result));
		[Export ("trackViewWithView:")]
		bool TrackViewWithView (string view);

		// -(NSString * _Nonnull)getErrors __attribute__((warn_unused_result));
		[Export ("getErrors")]
		string Errors { get; }
	}
}
