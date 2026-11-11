import styled from 'styled-components/native';
import { responsiveSize } from '../../utils/responsiveSize';

export const Container = styled.View`
  flex: 1;
  background-color: ${({ theme }) => theme.colors.background};
`;

export const Logo = styled.Text`
  font-size: ${responsiveSize(32)}px;
  padding-top: ${responsiveSize(50)}px;
  font-family: ${({ theme }) => theme.fonts.regular};
`;

export const HelloText = styled.Text`
  font-size: ${responsiveSize(54)}px;
  margin-top: ${responsiveSize(10)}px;
  margin-bottom: ${responsiveSize(30)}px;
  font-family: ${({ theme }) => theme.fonts.medium};
  align-self: center;
  text-align: center;
`;

export const StickyHeaderContainer = styled.View`
  background-color: ${({ theme }) => theme.colors.primary};
  width: 100%;
  border-top-left-radius: ${responsiveSize(15)}px;
  border-top-right-radius: ${responsiveSize(15)}px;
  align-items: center;
  padding-top: ${responsiveSize(20)}px;
`;

export const GalleryItemsContainer = styled.View`
  background-color: ${({ theme }) => theme.colors.primary};
  width: 100%;
  flex: 1;
  align-items: center;
  padding-bottom: ${responsiveSize(90)}px;
`;

export const Header = styled.View`
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  width: 92%;
  margin-bottom: ${responsiveSize(20)}px;
`;

export const GalleryTitle = styled.Text`
  font-size: ${responsiveSize(24)}px;
  font-family: ${({ theme }) => theme.fonts.regular};
`;