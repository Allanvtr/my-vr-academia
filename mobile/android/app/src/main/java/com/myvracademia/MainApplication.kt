package com.myvracademia

import android.app.Application
import com.facebook.react.PackageList
import com.facebook.react.ReactApplication
import com.facebook.react.ReactHost
import com.facebook.react.ReactNativeApplicationEntryPoint.loadReactNative
import com.facebook.react.defaults.DefaultReactHost.getDefaultReactHost
import com.myvracademia.UnityLauncherPackage

class MainApplication : Application(), ReactApplication {

  override val reactHost: ReactHost by lazy {
    getDefaultReactHost(
      context = applicationContext,
      packageList = run {
        val packages = PackageList(this).packages.toMutableList()
        packages.add(UnityLauncherPackage())
        packages
      },
    )
  }

  override fun onCreate() {
    super.onCreate()
    loadReactNative(this)
  }
}
