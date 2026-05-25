import { NativeModules, Button, View, StyleSheet } from 'react-native';
import Home from './src/screens/Home';
import { ThemeProvider } from 'styled-components/native';
import theme from './src/theme';

// const { UnityLauncher } = NativeModules;


export default function App() {
  return (
    <ThemeProvider theme={theme}>
      <Home />
    </ThemeProvider>





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