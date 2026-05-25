import styled from 'styled-components/native';

export const Container = styled.View`
  flex: 1;
  background-color: ${({ theme }) => theme.colors.background};
`;

export const Logo = styled.Text`
  font-size: 32px;
  padding-top: 50px;
  font-family: ${({ theme }) => theme.fonts.regular};
`;

export const HelloText = styled.Text`
  font-size: 64px;
  margin-top: 10px;
  margin-bottom: 30px;
  font-family: ${({ theme }) => theme.fonts.semiBold};
  align-self: center;
  text-align: center;
`;

export const StickyHeaderContainer = styled.View`
  background-color: ${({ theme }) => theme.colors.primary};
  width: 100%;
  border-top-left-radius: 15px;
  border-top-right-radius: 15px;
  align-items: center;
  padding-top: 20px;
`;

export const GalleryItemsContainer = styled.View`
  background-color: ${({ theme }) => theme.colors.primary};
  width: 100%;
  flex: 1;
  align-items: center;
  padding-bottom: 10px;
`;

export const Header = styled.View`
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  width: 92%;
  margin-bottom: 20px;
`;

export const GalleryTitle = styled.Text`
  font-size: 24px;
  font-family: ${({ theme }) => theme.fonts.regular};
`;