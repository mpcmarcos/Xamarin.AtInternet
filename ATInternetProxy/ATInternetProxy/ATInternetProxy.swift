//
//  ATInternetProxy.swift
//  ATInternetProxy
//
//  Created by Marcos Palacios on 26/02/2020.
//  Copyright © 2020 Marcos Palacios. All rights reserved.
//

import Foundation
import Tracker


@objc(ATInternetProxy)
public class ATInternetProxy : NSObject {

    @objc
    public func initTracker(siteId: Int, server: String, log: String, secureLog: String, enableDebugger: Bool, verbose: Bool) -> Bool {
        let trackerDelegate = DefaultTrackerDelegate() // weak var !
        
        Tracker.handleCrash = true
        let tracker: Tracker = ATInternet.sharedInstance.defaultTracker
        tracker.setConfig(["secure": "true"], completionHandler: nil)
        tracker.setSiteId(siteId, sync: true, completionHandler: nil) // required
        tracker.setDomain(server, completionHandler: nil)
        tracker.setLog(log, completionHandler: nil)
        tracker.setSecuredLog(secureLog, sync: true, completionHandler: nil) // required
        tracker.enableDebugger = enableDebugger // track the hit sent
        if(verbose){
            tracker.delegate = trackerDelegate // verbose mode
        }
        
        return true
    }
    
    @objc
    public func trackView(view: String) -> Bool {
        let tracker: Tracker = ATInternet.sharedInstance.defaultTracker
        tracker.screens.add(view).sendView();
        return true
    }
    
    @objc
    public func getErrors() -> String {
        let tracker: Tracker = ATInternet.sharedInstance.defaultTracker
        let crashInformation = tracker.getCrashInformation()
        return "CrashInformation \(String(describing: crashInformation))"
    }
}

