import styled from "styled-components/native";

export const TopContainer = styled.View`
    flex-direction: row;
    align-items: center;
    justify-content: center;
    position: relative;
    margin-bottom: 20px;
`;

export const ErrorMessage = styled.Text`
    background-color: red;
    text-align: center;
    font-size: 20px;
    font-family: ${({ theme }) => theme.fonts.medium}
`

export const BackButton = styled.TouchableOpacity`
    position: absolute;
    left: 10px;
    margin-top: 45px;
`;

export const Container = styled.View`
  flex: 1;
  background-color: ${({ theme }) => theme.colors.background};
`;

export const SectionTitle = styled.Text`
    font-family: ${({ theme }) => theme.fonts.medium};
    font-size: 24px;
    margin-left: 10px;
    margin-top: 30px;
`;

export const TitleInput = styled.TextInput`
    background-color: ${({ theme }) => theme.colors.input};
    margin: 10px;
    height: 50px;
    font-size: 16px;
`;

export const FileButton = styled.TouchableOpacity`
    background-color: ${({ theme }) => theme.colors.input};
    margin: 10px;
    height: 50px;
    justify-content: center;
`;

export const FileButtonText = styled.Text`
    font-size: 18px;
    text-align: center;
`;

export const FileDescription = styled.Text`
    font-family: ${({ theme }) => theme.fonts.regular};
    font-size: 14px;
    margin-left: 10px;
    margin-right: 10px;
`;

export const AbstractContainer = styled.View`
    flex-direction: row;
    justify-content: center;
    flex-wrap: wrap;
    padding: 20px;
    column-gap: 15px;
    row-gap: 20px;
`;