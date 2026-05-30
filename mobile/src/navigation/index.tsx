import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';

import Home from '../screens/Home';
import ContentPage from '../screens/ContentPage';
import MetricsPage from '../screens/MetricsPage';

//aque que é configurado os parâmetros das rotas
export type RootStackParamList = {
  Home: undefined;
  ContentPage: undefined;
  MetricsPage: undefined;
};

const Stack = createNativeStackNavigator<RootStackParamList>();

export default function Routes() {
  return (
    <NavigationContainer>
      <Stack.Navigator 
      initialRouteName="Home" 
      screenOptions={{
      headerShown: false,
    }}>
        <Stack.Screen name="Home" component={Home} />
        <Stack.Screen name="ContentPage" component={ContentPage} />
        <Stack.Screen name="MetricsPage" component={MetricsPage} />
      </Stack.Navigator>
    </NavigationContainer>
  );
}