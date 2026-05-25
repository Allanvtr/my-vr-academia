import styled from 'styled-components/native'; 
import Ionicons from 'react-native-vector-icons/Ionicons';

const Container = styled.View`
  flex: 1;
  align-items: center;
  background-color: #F4F7F7;
`;

const Logo = styled.Text`
  font-size: 32px; 
  padding-top: 50px;
  font-family: 'Poppins-Regular';
`;

const GaleriaContainer = styled.View`
  background-color: #AACFD0;
  width: 100%;
  flex: 1;
  margin-top: 40px;
  border-radius: 15px;
  align-items: center;
`;

const HelloText = styled.Text`
  font-size: 64px;
  margin-top: 10px;
  font-family: 'Poppins-SemiBold';
`;

const CardContainer = styled.View`
  background-color: #F4F7F7;
  width: 94%;
  border-radius: 10px;
  flex-direction: row;
`;

const CardImage = styled.View`
  background-color: #767676;
  height: 104px;
  width: 104px;
  border-radius: 10px;
`;

const CardText = styled.View`
  flex: 1;
  margin-left: 10px;
  flex-direction: column;
  justify-content: center;
`;

const CardTextTitle = styled.Text` 
  font-size: 20px;
  font-weight: bold;
`;

const CardTextDescription = styled.Text`
  margin-right: 5px;
`;

const TitleAndSearch = styled.View`
  flex-direction: row;
  justify-content: space-between;
  width: 100%;
`;

const GaleryTitle = styled.Text`
  font-size: 24px;
  margin: 20px 20px 20px 20px;
`;

const SearchIcon = styled.View`
  margin: 20px 20px 20px 20px;
`;

export default function Home() {
  return (
    <Container>
      <Logo>My Vr Academy</Logo>

      <HelloText>Olá, Allan</HelloText>

      <GaleriaContainer>
        <TitleAndSearch>
          <GaleryTitle>
            Galeria
          </GaleryTitle>
          <SearchIcon> 
            <Ionicons name="search-outline" size={28} color="black" />
          </ SearchIcon> 
          
        </TitleAndSearch>

        <CardContainer>
          <CardImage />
          <CardText>
            <CardTextTitle>Sala de Aula</CardTextTitle>
            <CardTextDescription>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
            </CardTextDescription>
          </CardText>

        </CardContainer>
      </GaleriaContainer>
    </Container>
  );
}