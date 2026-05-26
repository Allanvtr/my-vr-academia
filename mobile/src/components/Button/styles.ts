import styled from "styled-components/native";

export const Container = styled.TouchableOpacity`
    height: 50px;
    width: 200px;
    border-radius: 30px;
    background-color: ${({ theme }) => theme.colors.secondary};
    align-items: center;
    justify-content: center;
`;

export const ButtonText = styled.Text`
    font-family: ${({ theme }) => theme.fonts.medium};
    text-align: left;
    color: white;
    font-size: 20px;
`
