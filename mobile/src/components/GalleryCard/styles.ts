import styled from 'styled-components/native';

export const Container = styled.View`
  background-color: #F4F7F7; 
  width: 94%; 
  border-radius: 10px; 
  flex-direction: row;
  margin-bottom: 20px;
`;

export const CardImage = styled.View`
  background-color: #767676;
  height: 104px;
  width: 104px;
  border-radius: 10px;
`;

export const TextContainer = styled.View`
  flex: 1;
  margin-left: 10px;
  justify-content: center;
`;

export const Title = styled.Text`
  font-size: 20px; 
  font-weight: bold;
`;

export const Description = styled.Text`
  margin-right: 5px;
`;