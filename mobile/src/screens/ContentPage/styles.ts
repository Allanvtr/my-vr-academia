import styled from "styled-components/native";
import { responsiveSize } from "../../utils/responsiveSize";

export const TopContainer = styled.View`
    flex-direction: row;
    align-items: center;
    justify-content: center;
    position: relative;
`;

export const ErrorMessage = styled.Text`
    background-color: red;
    text-align: center;
    font-size: ${responsiveSize(20)}px;
    font-family: ${({ theme }) => theme.fonts.medium}
`

export const BackButton = styled.TouchableOpacity`
    position: absolute;
    left: ${responsiveSize(10)}px;
    margin-top: ${responsiveSize(16)}px;
`;

export const Container = styled.View`
  flex: 1;
  background-color: ${({ theme }) => theme.colors.background};
`;

export const SectionTitle = styled.Text`
    font-family: ${({ theme }) => theme.fonts.medium};
    font-size: ${responsiveSize(20)}px;
    margin-left: ${responsiveSize(10)}px;
    margin-top: ${responsiveSize(12)}px;
`;

export const TitleInput = styled.TextInput`
    background-color: ${({ theme }) => theme.colors.input};
    margin: 10px;
    height: ${responsiveSize(50)}px;
    font-size: ${responsiveSize(16)}px;
    border-radius: 5px;
`;

export const FileButton = styled.TouchableOpacity`
    background-color: ${({ theme }) => theme.colors.input};
    margin: ${responsiveSize(10)}px;
    height: ${responsiveSize(50)}px;
    justify-content: center;
    border-radius: 5px;
`;

export const FileButtonText = styled.Text`
    font-size: ${responsiveSize(18)}px;
    text-align: center;
`;

export const FileDescription = styled.Text`
    font-family: ${({ theme }) => theme.fonts.regular};
    font-size: ${responsiveSize(12)}px;
    margin-left: ${responsiveSize(10)}px;
    margin-right: ${responsiveSize(10)}px;
`;

export const AbstractContainer = styled.View`
    flex-direction: row;
    justify-content: center;
    flex-wrap: wrap;
    padding: ${responsiveSize(15)}px;
    column-gap: ${responsiveSize(10)}px;
    row-gap: ${responsiveSize(15)}px;
`;