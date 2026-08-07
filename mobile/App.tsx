import { NativeModules, Button, View, StyleSheet } from 'react-native';
import Home from './src/screens/Home';
import MetricsPage from './src/screens/MetricsPage';
import ContentPage from './src/screens/ContentPage';
import { ThemeProvider } from 'styled-components/native';
import theme from './src/theme';
import Routes from './src/navigation';

// const { UnityLauncher } = NativeModules;


export default function App() {
  return (
    <ThemeProvider theme={theme}>
          <Routes/>
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