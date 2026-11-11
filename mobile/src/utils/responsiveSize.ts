import { Dimensions } from 'react-native';

const { width } = Dimensions.get('window');

export const responsiveSize = (size: number) => {
  const baseWidth = 375;
  return (width / baseWidth) * size;
};