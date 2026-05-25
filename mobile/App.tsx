import { NativeModules, Button, View, StyleSheet } from 'react-native';
import Home from './src/screens/home';

// const { UnityLauncher } = NativeModules;


export default function App() {
  return (
    <Home />





    // Como usar o UnityLauncher para abrir o aplicativo Unity
    // <View style={styles.container}>
    //   <Button
    //     title="Abrir VR"
    //     onPress={() => {
    //       console.log("CLIQUEI");
    //       UnityLauncher.openUnityApp(30, "Hello from React Native!");
    //     }}
    //   />
    // </View>
  );
}