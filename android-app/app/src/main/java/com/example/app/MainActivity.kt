package com.example.app

import android.content.Intent
import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.material3.Button
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import com.example.app.ui.theme.AppTheme

class MainActivity : ComponentActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        
        setContent {
            AppTheme {
                MainScreen(onStartUnity = { startUnity() })
            }
        }
    }

    private fun startUnity() {
        // Usando sua UnityActivity customizada
        val intent = Intent(this, UnityActivity::class.java)
        intent.putExtra("tempo", "10") 
        startActivity(intent)
    }
}

@Composable
fun MainScreen(onStartUnity: () -> Unit) {
    Box(
        modifier = Modifier.fillMaxSize(),
        contentAlignment = Alignment.Center
    ) {
        Button(onClick = { onStartUnity() }) {
            Text("Abrir Unity")
        }
    }
}
