import { NativeModules, Button, View, StyleSheet } from 'react-native';
import Home from './src/screens/Home';
import MetricsPage from './src/screens/MetricsPage';
import { ThemeProvider } from 'styled-components/native';
import theme from './src/theme';
import BottomBar from './src/components/BottomBar'

// const { UnityLauncher } = NativeModules;


export default function App() {
  return (
    <ThemeProvider theme={theme}>
      <Home />
      <BottomBar />
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