import { NativeModules, Button, View, StyleSheet } from 'react-native';

const { UnityLauncher } = NativeModules;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
});

export default function App() {
  return (
    <View style={styles.container}>
      <Button
        title="Abrir VR"
        onPress={() => {
          console.log("CLIQUEI");
          UnityLauncher.openUnityApp(30, "Hello from React Native!");
        }}
      />
    </View>
  );
}