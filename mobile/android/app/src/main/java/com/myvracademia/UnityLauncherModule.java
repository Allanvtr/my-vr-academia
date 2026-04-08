package com.myvracademia;

import android.content.Intent;
import android.content.pm.PackageManager;
import com.facebook.react.bridge.*;
import android.util.Log;

import android.widget.Toast;
import android.util.Log;

public class UnityLauncherModule extends ReactContextBaseJavaModule {

    public UnityLauncherModule(ReactApplicationContext reactContext) {
        super(reactContext);
    }

    @Override
    public String getName() {
        return "UnityLauncher";
    }

    @ReactMethod
    public void openUnityApp(int tempo, String fase) {

        try {
            Intent intent = new Intent();

            intent.setClassName(
                "com.DefaultCompany.my_vr_academia",
                "com.unity3d.player.UnityPlayerActivity"
            );

            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

            intent.putExtra("tempo", tempo);
            intent.putExtra("fase", fase);

            getReactApplicationContext().startActivity(intent);

            Toast.makeText(getReactApplicationContext(), "Abrindo Unity!", Toast.LENGTH_SHORT).show();

            Log.d("UNITY_TEST", "Tempo enviado: " + tempo);
            Log.d("UNITY_TEST", "Fase enviada: " + fase);

        } catch (Exception e) {
            Toast.makeText(getReactApplicationContext(), "Erro ao abrir Unity", Toast.LENGTH_LONG).show();
            Log.e("UNITY_LAUNCHER", "Erro ao abrir Unity: " + e.getMessage(), e);
            e.printStackTrace();
        }
    }
}