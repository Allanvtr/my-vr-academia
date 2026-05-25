import styled from 'styled-components/native';

export const Container = styled.View`
  flex: 1;
  background-color: #F4F7F7;
`;

export const Logo = styled.Text`
  font-size: 32px;
  padding-top: 50px;
  font-family: 'Poppins-Regular';
`;

export const HelloText = styled.Text`
  font-size: 64px;
  margin-top: 10px;
  margin-bottom: 30px; /* Movido para cá para o header colar certinho no topo */
  font-family: 'Poppins-SemiBold';
  align-self: center;
  text-align: center;
`;

export const StickyHeaderContainer = styled.View`
  background-color: #AACFD0;
  width: 100%;
  border-top-left-radius: 15px;
  border-top-right-radius: 15px;
  align-items: center;
  padding-top: 20px;
`;

export const GalleryItemsContainer = styled.View`
  background-color: #AACFD0;
  width: 100%;
  flex: 1;
  align-items: center;
  padding-bottom: 30px; /* Espaço extra no final da rolagem */
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
  font-family: 'Poppins-Regular';
`;