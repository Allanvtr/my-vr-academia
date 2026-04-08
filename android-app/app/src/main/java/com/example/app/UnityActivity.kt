package com.example.app
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.unity3d.player.UnityPlayer

class UnityActivity : AppCompatActivity() {

    private lateinit var unityPlayer: UnityPlayer

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        unityPlayer = UnityPlayer(this)
        setContentView(unityPlayer)

        val tempo = intent.getStringExtra("tempo")

        unityPlayer.post {
            UnityPlayer.UnitySendMessage(
                "GameManager",
                "ReceberTempo",
                tempo ?: "0"
            )
        }
    }

    override fun onPause() {
        super.onPause()
        unityPlayer.pause()
    }

    override fun onResume() {
        super.onResume()
        unityPlayer.resume()
    }

    override fun onDestroy() {
        unityPlayer.destroy()
        super.onDestroy()
    }
}