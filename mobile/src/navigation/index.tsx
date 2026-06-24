import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';

import Home from '../screens/Home';
import ContentPage from '../screens/ContentPage';
import MetricsPage from '../screens/MetricsPage';

type metricType = 'Público' | 'Ruído' | 'Brilho' | 'Perguntas' | 'Tempo'


export type RootStackParamList = {
  Home: undefined;

  MetricsPage: {
    title: string;
  };

  ContentPage: {
    title: string,
    metricValues: Record<metricType, number>;
  }
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